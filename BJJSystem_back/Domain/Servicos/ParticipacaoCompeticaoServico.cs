using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IParticipacaoCompeticao;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class ParticipacaoCompeticaoServico : IParticipacaoCompeticaoServico
    {
        private readonly InterfaceParticipacaoCompeticao _interfaceParticipacaoCompeticao;
        public ParticipacaoCompeticaoServico(InterfaceParticipacaoCompeticao participacaoCompeticao)
        {
            _interfaceParticipacaoCompeticao = participacaoCompeticao;
        }


        private bool ValidadaPC(ParticipacaoCompeticao participacaoCompeticao)
        {
            if (string.IsNullOrWhiteSpace(participacaoCompeticao.StatusInscricao))
            {
                return false;
            }
            return true;
        }

        public async Task AdicionarAlunoCompeticao(ParticipacaoCompeticao participacaoCompeticao)
        {
            if (ValidadaPC(participacaoCompeticao))
            {
                await _interfaceParticipacaoCompeticao.Add(participacaoCompeticao);
            }
        }

        public async Task AlterarStatusInscricaoAluno(ParticipacaoCompeticao participacaoCompeticao)
        {
            if (ValidadaPC(participacaoCompeticao))
            {
                await _interfaceParticipacaoCompeticao.Update(participacaoCompeticao);
            }
        }

        public async Task RemoverAlunoCompeticao(ParticipacaoCompeticao participacaoCompeticao)
        {
            await _interfaceParticipacaoCompeticao.Delete(participacaoCompeticao);
        }
    }
}
