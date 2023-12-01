using Domain.Interfaces.IAlunoTurma;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ITurma;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class AlunoTurmaServico : IAlunoTurmaServico
    {
        private readonly InterfaceAlunoTurma _interfaceTurma;

        public AlunoTurmaServico(InterfaceAlunoTurma interfaceTurma)
        {
            _interfaceTurma =  interfaceTurma;
        }
        public async Task AdicionarAlunoTurma(AlunoTurma alunoTurma)
        {
            if (ValidaAlunoTurma(alunoTurma)) await _interfaceTurma.Add(alunoTurma);
        }



        public async Task<bool> RemoverAlunoTurma(AlunoTurma alunoTurma)
        {
            if (ValidaAlunoTurma(alunoTurma))
            {
                await _interfaceTurma.Delete(alunoTurma);
                return true;
            }
            return false;
        }

        private bool ValidaAlunoTurma(AlunoTurma alunoTurma)
        {
            if (alunoTurma.TurmaID < 0 || alunoTurma.Id < 0)
            {
                return false;
            }
            return true;
        }
    }
}
