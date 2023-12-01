using Entities.Entidades;

namespace WebAPI.Models.OutPutModels
{
    public class CompeticaoOutPut
    {
        public int ID { get; set; }
        public string? Nome { get; set; }
        public DateTime Data { get; set; }
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}
