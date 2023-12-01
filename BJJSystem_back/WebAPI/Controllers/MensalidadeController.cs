using Domain.Interfaces.IMensalidade;
using Domain.Interfaces.InterfaceServicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.InputModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensalidadeController : ControllerBase
    {
        private readonly InterfaceMensalidade _interfaceMensalidade;
        private readonly IMensalidadeServico _mensalidadeServico;

        public MensalidadeController(InterfaceMensalidade interfaceMensalidade, IMensalidadeServico mensalidadeServico)
        {
            _interfaceMensalidade = interfaceMensalidade;
            _mensalidadeServico = mensalidadeServico;
        }


        [HttpGet("/api/ListarMensalidade")]
        [Produces("application/json")]
        public async Task<object> ListarMensalidade()
        {
            var mensalidades = await _interfaceMensalidade.List();
            return Ok(mensalidades);
        }


        [HttpGet("/api/EditarMensalidade")]
        [Produces("application/json")]
        public async Task<object> EditarMensalidade(int competicaoID, [FromBody] MensalidadeInputModel mensalidadeInput)
        {
            var mensalidade = await _interfaceMensalidade.GetEntityByID(competicaoID);
            if (mensalidade == null)
            {
                return NotFound("Mensalidade não encontrada!");
            }
            mensalidade.Nome = mensalidadeInput.Nome == null ? $"AlunoID: {mensalidade.Id}" : mensalidadeInput.Nome;
            mensalidade.DataPagamento = mensalidadeInput.DataPagamento != mensalidade.DataPagamento ? mensalidadeInput.DataPagamento : mensalidade.DataPagamento;
            
            return Ok(mensalidade);
        }

        [HttpDelete("/api/DeletarMensalidade")]
        [Produces("application/json")]
        public async Task<object> DeletarMensalidade(int competicaoID)
        {
            var mensalidade = await _interfaceMensalidade.GetEntityByID(competicaoID);
            if (mensalidade == null)
            {
                return NotFound("Mensalidade não encontrada!");
            }
            await _interfaceMensalidade.Delete(mensalidade);

            return Ok("Mensalidade deletada");
        }


        [HttpPost("/api/LançarMensalidade")]
        [Produces("application/json")]
        public async Task<object> LancarMensalidade()
        {
            return await _interfaceMensalidade.LancarMensalidades();
        }


        [HttpPut("/api/AlterarStatusMensalidade")]
        [Produces("application/json")]
        public async Task<object> AlterarStatusMensalidade(int mensalidadeID, bool StatusMensalidade)
        {
            var mensalidade = await _interfaceMensalidade.GetEntityByID(mensalidadeID);
            if (mensalidade == null)
            {
                return NotFound("Mensalidade não encontrada!");
            }
            mensalidade.Pago = StatusMensalidade;
            await _interfaceMensalidade.Update(mensalidade);
            return Ok(mensalidade);
        }
    }
}
