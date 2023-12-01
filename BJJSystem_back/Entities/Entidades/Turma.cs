using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    [Table("Turma")]
    public class Turma
    {
        public int TurmaID { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public TimeSpan Horario { get; set; }

        public virtual ICollection<AlunoTurma> AlunosTurma { get; set; } = new List<AlunoTurma>();
        public virtual ICollection<ProfessorTurma> ProfessorTurmas { get; set; } = new List<ProfessorTurma>();
    }
}
