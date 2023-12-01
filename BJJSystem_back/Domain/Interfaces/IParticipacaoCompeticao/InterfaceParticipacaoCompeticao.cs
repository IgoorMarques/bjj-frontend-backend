using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IParticipacaoCompeticao
{
    public interface InterfaceParticipacaoCompeticao : InterfaceGeneric<ParticipacaoCompeticao>
    {
        Task<IList<Aluno>> ListarTodosAlunosEmCompeticacaoEspecifica(int competicaoID);
        Task<IList<ParticipacaoCompeticao>> ListarInscricoesPaga();
        Task<IList<ParticipacaoCompeticao>> ListarInscricoesNaoPagas();
        Task<int> TotalDeAlunosCompeticaoEspefica(int competicaoID);

    }
}
