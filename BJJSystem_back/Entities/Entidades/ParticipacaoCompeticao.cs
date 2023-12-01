using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    [Table("ParticipacaoCompeticao")]
    public class ParticipacaoCompeticao
    {
        [ForeignKey("Aluno")]
        public int AlunoID { get; set; }
        public Aluno Aluno { get; set; }

        [ForeignKey("Competicao")]
        public int CompeticaoID { get; set; }
        public Competicao Competicao { get; set; }

        public string StatusInscricao { get; set; } = "Pendente";
    }
}
