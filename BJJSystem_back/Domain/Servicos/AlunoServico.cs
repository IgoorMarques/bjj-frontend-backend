using Domain.Interfaces.IAluno;
using Domain.Interfaces.IFaixa;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class AlunoServico : IAlunoServico
    {
        private readonly InterfaceAluno _interfaceAluno;
        private readonly InterfaceFaixa _interfaceFaixa;
        public AlunoServico(InterfaceAluno interfaceAluno, InterfaceFaixa interfaceFaixa)
        {
            _interfaceAluno = interfaceAluno;
            _interfaceFaixa = interfaceFaixa;
        }

        public async Task CadastrarAluno(Aluno aluno)
        {
            if(ValidaAluno(aluno))
            {
                var faixa = await _interfaceFaixa.GetEntityByID(aluno.FaixaID);
                await _interfaceAluno.Add(aluno);  
            }
        }

        public async Task EditarAluno(Aluno aluno)
        {
            if (ValidaAluno(aluno))
            {
                await _interfaceAluno.Update(aluno);
            }

        }

        public async Task ExcluirAluno(Aluno aluno)
        {
            if (aluno.ValidaPropriedadeINT(aluno.Id, "AlunoID"))
            {
                await _interfaceAluno.Delete(aluno);
            }
            
        }
        private bool ValidaAluno(Aluno aluno)
        {
            var validNome = aluno.ValidaPropriedadeString(aluno.Nome, "Nome");
            var validCPF = aluno.ValidaPropriedadeString(aluno.CPF, "CPF");
            var validFaixaID = aluno.ValidaPropriedadeINT(aluno.FaixaID, "FaixaID");

            if (validNome && validCPF && validFaixaID)
            {
                return true;
            }
            return false;
        }
    }
}
