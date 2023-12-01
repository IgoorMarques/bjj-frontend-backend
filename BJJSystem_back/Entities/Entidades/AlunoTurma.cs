using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    [Table("AlunoTurma")]
    public class AlunoTurma
    {
        [ForeignKey("Aluno")]
        public int Id { get; set; }
        public Aluno Aluno { get; set; }

        [ForeignKey("Turma")]
        public int TurmaID { get; set; }
        public Turma Turma { get; set; }
    }
}
