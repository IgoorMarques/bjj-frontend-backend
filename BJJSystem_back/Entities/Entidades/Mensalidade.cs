using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    [Table("Mensalidade")]
    public class Mensalidade : Base
    {
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public bool Pago { get; set; } = false;

        [ForeignKey("Aluno")]
        public int AlunoID { get; set; }
        public Aluno Aluno { get; set; }
    }
}
