using Domain.Interfaces.IAluno;
using Domain.Interfaces.IAlunoTurma;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IProfessor;
using Domain.Interfaces.IProfessorTurma;
using Domain.Interfaces.ITurma;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Models.InputModels;
using WebAPI.Models.OutPutModels.TurmaOutput;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly InterfaceTurma _interfaceTurma;
        private readonly InterfaceProfessor _interfaceProfessor;
        private readonly ITurmaServico _interfaceTurmaServico;
        private readonly InterfaceAlunoTurma _interfaceAlunoTurma;
        private readonly IAlunoTurmaServico _interfaceAlunoTurmaServico;
        private readonly InterfaceProfessorTurma _interfaceProfessorTurma;
        private readonly InterfaceAluno _interfaceAluno;

        public TurmaController(InterfaceTurma interfaceTurma,
            ITurmaServico interfaceTurmaServico,
            InterfaceAlunoTurma interfaceAlunoTurma,
            IAlunoTurmaServico interfaceAlunoTurmaServico,
            InterfaceProfessorTurma interfaceProfessorTurma,
            InterfaceProfessor interfaceProfessor,
            InterfaceAluno interfaceAluno)
        {
            _interfaceTurma = interfaceTurma;
            _interfaceTurmaServico = interfaceTurmaServico;
            _interfaceAlunoTurma = interfaceAlunoTurma;
            _interfaceAlunoTurmaServico = interfaceAlunoTurmaServico;
            _interfaceProfessorTurma = interfaceProfessorTurma;
            _interfaceProfessor = interfaceProfessor;
            _interfaceAluno = interfaceAluno;
        }


        private bool ValidaTurmaModel(TurmaModel turma)
        {
            var valida = string.IsNullOrWhiteSpace(turma.Nome);
            var valida1 = turma.Hora > 0 && turma.Minutos > 0;
            if(!valida && valida1)
            {
                return true;
            }
            return false;
        }

        [HttpGet("/api/ListarTurmas")]
        [Produces("application/json")]
        public async Task<Object> ListarTurmas()
        {
            var turmas = await _interfaceTurma.List();
            var outPutTumma = new List<TurmaOutput>();
            foreach (var item in turmas)
            {
                var dados = new TurmaOutput
                {
                    TurmaID = item.TurmaID,
                    Nome = item.Nome,
                    Descricao = item.Descricao,
                    Horario = item.Horario,
                    professores = await _interfaceProfessorTurma.ListarProfessorTurma(item.TurmaID),
                    alunos = await _interfaceAlunoTurma.ListarTodosAlunosTurma(item.TurmaID)
               
                };
                outPutTumma.Add(dados);
            }
            return outPutTumma;
        }

        [HttpPost("/api/CriarNovaTurma")]
        [Produces("application/json")]
        public async Task<Object> CriarTurma(TurmaModel turmaModel)
        {
            if (ValidaTurmaModel(turmaModel))
            {
                TimeSpan horario = new TimeSpan(turmaModel.Hora, turmaModel.Minutos, 0);
                var novaTurma = new Turma
                {
                    Nome = turmaModel.Nome,
                    Descricao = turmaModel.Descricao,
                    Horario = horario,
                };
                await _interfaceTurmaServico.CriarTurma(novaTurma);
                return novaTurma;
            }
            return Task.FromResult("Dados incompletos");
        }

        [HttpPost("/api/AdicionarProfessorTurma")]
        [Produces("application/json")]
        public async Task<Object> AdicionarProfessorTurma(int turmaID, int professorID)
        {
            var professor = await _interfaceProfessor.GetEntityByID(professorID);
            var turma = await _interfaceTurma.GetEntityByID(turmaID);

            if (professor != null && turma != null)
            {
                var P_T = new ProfessorTurma
                {
                    ProfessorID = professorID,
                    TurmaID = turmaID
                };
                await _interfaceProfessorTurma.Add(P_T);
                return Ok("Professor adicionado com sucesso!");
            }
            var out1 = professor == null ? "ProfessorID NULO" : "TurmaID NULO";

            return BadRequest(out1);
        }


        [HttpPost("/api/AdicionarAlunoTurma")]
        [Produces("application/json")]
        public async Task<Object> AdicionarAlunoTurma(int turmaID, int alunoID)
        {

            var aluno = await _interfaceAluno.GetEntityByID(alunoID);
            var turma = await _interfaceTurma.GetEntityByID(turmaID);

            if (aluno != null && turma != null)
            {
                var alunoTurma = new AlunoTurma
                {
                    Id = aluno.Id,
                    TurmaID = turma.TurmaID
                };

                await _interfaceAlunoTurma.Add(alunoTurma);
                return Ok("Aluno adicionado com sucesso!");
            }
            return NotFound("turma ou aluno não encontrados");
        }

        [HttpPut("/api/AtualizarTurma")]
        [Produces("application/json")]
        public async Task<object> AtualizarTurma([FromBody] TurmaModel turmaModel, int turmaID)
        {
            var turma = await _interfaceTurma.GetEntityByID(turmaID);
            var valida = ValidaTurmaModel(turmaModel);

            if (turma == null)
            {
                return BadRequest("Turma não encontrada!");
            }

            var horario = new TimeSpan(turmaModel.Hora, turmaModel.Minutos, 0);
            Turma novaTurma = new Turma
            {
                TurmaID = turma.TurmaID,
                Nome = turma.Nome != turmaModel.Nome && turmaModel.Nome != null ? turmaModel.Nome : turma.Nome,
                Descricao = turma.Descricao != turmaModel.Descricao && turmaModel.Descricao != null ? turmaModel.Descricao : turma.Descricao,
                Horario = turma.Horario != horario ? horario : turma.Horario,
            };
            await _interfaceTurma.Update(novaTurma);
            return Ok("Turma atualizada");
        }

        [HttpDelete("/api/DeletarTurma")]
        [Produces("application/json")]
        public async Task<Object> ExcluirTurma(int turmaID)
        {
            return await _interfaceTurma.ExcluirTurma(turmaID);
        }

        [HttpDelete("/api/RemoverAlunoTurma")]
        [Produces("application/json")]
        public async Task<Object> RemoverAlunoTurma(int turmaID, int alunoID)
        {
            var alunoTurma = new AlunoTurma
            {
                Id = alunoID,
                TurmaID = turmaID
            };
            return await _interfaceAlunoTurmaServico.RemoverAlunoTurma(alunoTurma);
        }


        [HttpDelete("/api/RemoverProfessorTurma")]
        [Produces("application/json")]
        public async Task<Object> RemoverProfessorTurma(int turmaID, int professorID)
        {
            return await _interfaceProfessorTurma.RemoverProfessorTurma(turmaID, professorID);
        }

    }
}
