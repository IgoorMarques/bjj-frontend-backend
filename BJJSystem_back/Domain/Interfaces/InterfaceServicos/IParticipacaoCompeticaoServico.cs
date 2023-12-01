using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IParticipacaoCompeticaoServico
    {
        Task AdicionarAlunoCompeticao(ParticipacaoCompeticao participacaoCompeticao);
        Task RemoverAlunoCompeticao(ParticipacaoCompeticao participacaoCompeticao);
        Task AlterarStatusInscricaoAluno(ParticipacaoCompeticao participacaoCompeticao);
    }
}
