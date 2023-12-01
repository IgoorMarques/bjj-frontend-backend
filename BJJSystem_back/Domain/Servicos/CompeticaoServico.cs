using Domain.Interfaces.IAluno;
using Domain.Interfaces.ICompeticao;
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
    public class CompeticaoServico : ICompeticaoServico
    {
        private readonly InterfaceCompeticao _interfaceCompeticao;
        private readonly InterfaceAluno _interfaceAluno;
        private readonly InterfaceParticipacaoCompeticao _participacaoCompeticao;
        public CompeticaoServico(InterfaceCompeticao interfaceCompeticao,
            InterfaceParticipacaoCompeticao participacaoCompeticao,
            InterfaceAluno interfaceAluno)
        {
            _interfaceCompeticao = interfaceCompeticao;
            _participacaoCompeticao = participacaoCompeticao;
            _interfaceAluno = interfaceAluno;
        }

        public async Task<Object> AdicionarAlunoCompeticao(int competicaoID, int alunoID)
        {
            var competicao = await _interfaceCompeticao.GetEntityByID(competicaoID);
            var aluno = await _interfaceAluno.GetEntityByID(alunoID);
            if (competicao == null)
            {
                return "Competição não encontrada";
            }
            if (aluno == null)
            {
                return "Aluno não encontrado";
            }
            var PC = new ParticipacaoCompeticao
            {
                CompeticaoID = competicaoID,
                AlunoID = alunoID,
            };
            await _participacaoCompeticao.Add(PC);
            return "Aluno adicionado com sucesso!";
        }

        public async Task CriarCompeticao(Competicao competicao)
        {
            if (ValidaCompeticao(competicao)) await _interfaceCompeticao.Add(competicao); 
        }

        public async Task EditarCompeticao(Competicao competicao, string competicaoID)
        {
            if (ValidaCompeticao(competicao)) await _interfaceCompeticao.Update(competicao);
        }

        public async Task<bool> RemoverAlunoCompeticao(int competicaoID, int alunoID)
        {
            try
            {
                var PC = new ParticipacaoCompeticao { 
                    CompeticaoID = competicaoID,
                    AlunoID = alunoID
                };
                await _participacaoCompeticao.Delete(PC);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private bool ValidaCompeticao(Competicao competicao)
        {
            var compicaoNome = competicao.ValidaPropriedadeString(competicao.Nome, "Nome");
            return compicaoNome;
        }
    }
}
