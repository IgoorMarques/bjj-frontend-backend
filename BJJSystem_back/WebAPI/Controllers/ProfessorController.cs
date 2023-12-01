using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IProfessor;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Models.InputModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly InterfaceProfessor _interfaceProfessor;
        private readonly IProfessorServico _professorServico;
        public ProfessorController(InterfaceProfessor interfaceProfessor,
            IProfessorServico professorServico)
        {
            _interfaceProfessor = interfaceProfessor;
            _professorServico = professorServico;
        }


        [HttpPost("/api/AdicionarNovoProfessor")]
        [Produces("application/json")]
        public async Task<Object> AdicionarProfessor(InputProfessorModel inputProfessorModel)
        {
            if (string.IsNullOrWhiteSpace(inputProfessorModel.Nome))
            {
                return Task.FromResult("Informe um nome");
            }
            var novoProf = new Professor
            {
                Nome = inputProfessorModel.Nome
            };
            await _professorServico.AdicionarNovoProfessor(novoProf);
            return novoProf;
        }


        [HttpPut("/api/EditarProfessor")]
        [Produces("application/json")]
        public async Task<Object> EditarProfessor(InputProfessorModel inputProfessorModel, int professorID)
        {
            if (!(string.IsNullOrWhiteSpace(inputProfessorModel.Nome)))
            {
                var findProf = await _interfaceProfessor.GetEntityByID(professorID);
                if(findProf != null)
                {
                    findProf.Nome = inputProfessorModel.Nome;
                    await _interfaceProfessor.Update(findProf);
                    return findProf;
                }
                else
                {
                    return "id inválido";
                }
            }
            return Task.FromResult("Nome inválido");
        }

        [HttpGet("/api/ListarProfessores")]
        [Produces("application/json")]
        public async Task<Object> ListarProfessores()
        {
            return await _interfaceProfessor.ListarProfessores();
        }

        [HttpDelete("/api/ExcluirProfessor")]
        [Produces("application/json")]
        public async Task<Object> ExcluirProfessor(int professorID)
        {
            var findProf = await _interfaceProfessor.GetEntityByID(professorID);
            if(findProf != null)
            {
               await _interfaceProfessor.Delete(findProf);
                return true;
            }
            return false; 
        }
    }
}
