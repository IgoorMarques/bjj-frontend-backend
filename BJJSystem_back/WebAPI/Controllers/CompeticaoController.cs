using Domain.Interfaces.IAluno;
using Domain.Interfaces.IAlunoTurma;
using Domain.Interfaces.ICompeticao;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IProfessorTurma;
using Domain.Interfaces.ITurma;
using Entities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using WebAPI.Models;
using WebAPI.Models.InputModels;
using WebAPI.Models.OutPutModels;
using WebAPI.Models.OutPutModels.TurmaOutput;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompeticaoController : ControllerBase
    {
        private readonly InterfaceCompeticao _interfaceCompeticao;
        private readonly ICompeticaoServico _IcompeticaoServico;

        public CompeticaoController(InterfaceCompeticao interfaceCompeticao,
            ICompeticaoServico icompeticaoServico)
        {
            _interfaceCompeticao = interfaceCompeticao;
            _IcompeticaoServico = icompeticaoServico;
        }

        [HttpGet("/api/ListaCompeticoesAcademia")]
        [Produces("application/json")]
        public async Task<object> ListarCompeticao()
        {
            var competicoes = await _interfaceCompeticao.List();
            var outPutComp = new List<CompeticaoOutPut>();
            foreach (var item in competicoes)
            {
                var dado = new CompeticaoOutPut
                {
                    ID = item.Id,
                    Nome = item.Nome,
                    Data = item.Data,
                    Alunos = await _interfaceCompeticao.ListarAlunosComp(item.Id)

                };
                outPutComp.Add(dado);
            }
            return outPutComp;
        }

        [HttpPut("/api/EditarCompeticaoAcademia")]
        [Produces("application/json")]
        public async Task<object> EditarCompeticao(int turmaID, InputCompeticaoModel inputCompeticao)
        {
            var competicao = await _interfaceCompeticao.GetEntityByID(turmaID);

            if (competicao == null)
            {
                return NotFound("Não contido");
            }

            competicao.Nome = inputCompeticao.Nome != competicao.Nome && inputCompeticao.Nome != null ? inputCompeticao.Nome :
            competicao.Nome;
            if (inputCompeticao.Ano != null && inputCompeticao.Mes != null && inputCompeticao.Dia != null)
            { 
                int ano, mes, dia;

                // Verifica se é possível converter os valores para inteiros
                if (int.TryParse(inputCompeticao.Ano, out ano) &&
                    int.TryParse(inputCompeticao.Mes, out mes) &&
                    int.TryParse(inputCompeticao.Dia, out dia))
                {
                    var data = new DateTime(year: ano, month: mes, day: dia);
                    competicao.Data = data != competicao.Data ? data : competicao.Data;
                }
            }
            await _interfaceCompeticao.Update(competicao);
            return Ok("Competição editada com sucesso!");
        }

        [HttpPost("/api/CriarCompeticao")]
        [Produces("application/json")]
        public async Task<object> CriarCompeticao(InputCompeticaoModel competicaoModel)
        {
            if (competicaoModel.Nome == null)
            {
                return BadRequest("Campo nome é obrigatorio");
            }
            int dia, mes, ano;
            if (int.TryParse(competicaoModel.Ano, out ano) &&
                int.TryParse(competicaoModel.Mes, out mes) &&
                int.TryParse(competicaoModel.Dia, out dia))
            {
                var data = new DateTime(year: ano, month: mes, day: dia);
                var competicao = new Competicao
                {
                    Nome = competicaoModel.Nome,
                    Data = new DateTime(year: ano, month: mes, day: dia)
                };
                await _interfaceCompeticao.Add(competicao);
                return Ok("Competição criada com sucesso");
            }
            return BadRequest("Data inválida!");
        }

        [HttpDelete("/api/DeletarCompeticao")]
        [Produces("application/json")]
        public async Task<object> DeletarCompeticao(int competicaoID)
        {
            var competicao = await _interfaceCompeticao.GetEntityByID(competicaoID);
            if (competicao.Equals(null))
            {
                return NotFound("Competição não encontrada");
            }
            await _interfaceCompeticao.Delete(competicao);
            return Ok("Competição excluida com sucesso!");
        }

        [HttpPost("/api/AdicionarAlunoCompeticao")]
        [Produces("application/json")]
        public async Task<object> AdicionarAlunoCompeticao(int competicaoID, int alunoID)
        {
            return await _IcompeticaoServico.AdicionarAlunoCompeticao(competicaoID, alunoID);
        }




    }
}
