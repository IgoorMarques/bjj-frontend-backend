using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    [Table("Podio")]
    public class Podio : Base
    {
        [ForeignKey("Competicao")]
        public int CompeticaoID { get; set; }
        public Competicao Competicao { get; set; }

        [ForeignKey("Aluno")]
        public int AlunoID { get; set; }
        public Aluno Aluno { get; set; }

        [ForeignKey("Resultado")]
        public int ResultadoID { get; set; }
        public Resultado Resultado { get; set; }
    }
}
