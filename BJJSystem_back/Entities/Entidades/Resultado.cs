using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    [Table("Resultado")]
    public class Resultado
    {
        public int ResultadoID { get; set; }
        public string Descricao { get; set; }
    }
}
