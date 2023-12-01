using Entities.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.InputModels
{
    public class MensalidadeInputModel
    {
        public string? Nome { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public bool StatusMensalidade { get; set; }
        public int AlunoID { get; set; }
    }
}
