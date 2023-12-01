using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{

    [Table("ProfessorTurma")]
    public class ProfessorTurma
    {
        [ForeignKey("Turma")]
        public int TurmaID { get; set; }
        public Turma Turma { get; set; }

        [ForeignKey("Professor")]
        public int ProfessorID { get; set; }
        public Professor Professor { get; set; }

    }
}
