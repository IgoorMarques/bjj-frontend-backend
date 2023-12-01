using Entities.Entidades;

namespace WebAPI.Models
{
    public class TurmaModel
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int Hora { get; set; }
        public int Minutos { get; set; }

    }
}
