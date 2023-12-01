using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    [Table("Competicao")]
    public class Competicao : Base
    {
        public DateTime Data { get; set; }
        public ICollection<ParticipacaoCompeticao> AlunosCompeticao { get; set; } = new List<ParticipacaoCompeticao>();
        public ICollection<Aluno> AlunosDaCompeticao { get; set; } = new List<Aluno>();

    }
}
