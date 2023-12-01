using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    [Table("Aluno")]
    public class Aluno : Base
    {
        public string CPF { get; set; }

        [ForeignKey("Faixa")]
        public int FaixaID { get; set; }
        public Faixa Faixa { get; set; }

        public ICollection<AlunoTurma> TurmasAluno { get; set; } = new List<AlunoTurma>();
        public ICollection<ParticipacaoCompeticao> CompeticoesAluno { get; set; } = new List<ParticipacaoCompeticao>();
        public ICollection<Mensalidade> Mensalidades { get; set; } = new List<Mensalidade>();
    }
}
