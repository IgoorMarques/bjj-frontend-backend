using Domain.Interfaces.IAluno;
using Domain.Interfaces.IFaixa;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.InputModels;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly InterfaceAluno _interfaceAluno;
        private readonly IAlunoServico _interfaceAlunoServico;
        private readonly InterfaceFaixa _interfaceFaixa;

        public AlunoController(InterfaceAluno interfaceAluno, 
            IAlunoServico interfaceAlunoServico,
            InterfaceFaixa interfaceFaixa)
        {
            _interfaceAluno = interfaceAluno;
            _interfaceAlunoServico = interfaceAlunoServico;
            _interfaceFaixa = interfaceFaixa;
        }

        [HttpGet("/api/ListaAlunosAcademia")]
        [Produces("application/json")]
        public async Task<Object> ListarAlunosAcademia()
        {
            return await _interfaceAluno.ListarTodosAlunos();  
        }

        [HttpPost("/api/AdicionarAluno")]
        [Produces("application/json")]
        public async Task<Object> AdicionarAluno(InputAlunoModel inputAlunoModel)
        {
            if (inputAlunoModel.Faixa == null)
            {
                return BadRequest("O campo faixa é obrigatório");
            }
            var faixa = new Faixa
            {
                Nome = inputAlunoModel.Faixa,
                Descricao = inputAlunoModel.Descricao,
                Graus = inputAlunoModel.Graus
            };

            var novoAluno = new Aluno
            {
                Nome = inputAlunoModel.Nome,
                CPF = inputAlunoModel.CPF,
                FaixaID = await _interfaceFaixa.AddFaixaAluno(faixa)
            };

            await _interfaceAlunoServico.CadastrarAluno(novoAluno);
            return Ok(novoAluno);
        }

        private bool ValidaInputAnluno(InputAlunoModel inputAluno)
        {
            if(string.IsNullOrEmpty(inputAluno.Nome) || string.IsNullOrEmpty(inputAluno.CPF))
            {
                return false;
            }
            return true;
        }


        [HttpPut("/api/AtualizarAluno")]
        [Produces("application/json")]
        public async Task<Object> AtualizarAluno(InputAlunoModel inputAlunoModel, int alunoID)
        {
            var aluno = await _interfaceAluno.GetEntityByID(alunoID);
            var faixaAluno = await _interfaceFaixa.GetEntityByID(aluno.FaixaID);
            var valid1 = ValidaInputAnluno(inputAlunoModel);
            if (aluno != null && valid1)
            {
                aluno.Nome = inputAlunoModel.Nome;
                aluno.CPF = inputAlunoModel.CPF;

                faixaAluno.Nome = inputAlunoModel.Faixa;
                faixaAluno.Descricao = inputAlunoModel.Descricao;
                faixaAluno.Graus = inputAlunoModel.Graus;


                await _interfaceFaixa.Update(faixaAluno);
                await _interfaceAlunoServico.EditarAluno(aluno);
                return Ok("Aluno atualizado com sucesso!");
            }
            return BadRequest("DADOS INCORRETOS");  
        }

        [HttpGet("/api/ObterAluno")]
        [Produces("application/json")]
        public async Task<Object> ObterAluno(int alunoID)
        {
            var aluno = _interfaceAluno.GetEntityByID(alunoID);
            return await aluno;
        }

        [HttpDelete("/api/DeletarAluno")]
        [Produces("application/json")]
        public async Task<Object> DeletarAluno(int alunoID)
        {
            try
            {
                var alunoOb = await _interfaceAluno.GetEntityByID(alunoID);
                await _interfaceAluno.Delete(alunoOb);
            }
            catch (Exception ex)
            {
                return ex;
            }
            return true;
        }
    }
}
