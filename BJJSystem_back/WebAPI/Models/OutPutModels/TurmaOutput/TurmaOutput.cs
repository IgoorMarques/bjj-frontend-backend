using Entities.Entidades;

namespace WebAPI.Models.OutPutModels.TurmaOutput
{
    public class TurmaOutput
    {
        public int? TurmaID { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public TimeSpan? Horario { get; set; }

        public ICollection<Professor> professores { get; set; } = new List<Professor>();
        public ICollection<Aluno> alunos { get; set; } = new List<Aluno>();
    }
}
