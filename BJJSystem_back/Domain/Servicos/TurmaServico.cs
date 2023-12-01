using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IProfessor;
using Domain.Interfaces.IProfessorTurma;
using Domain.Interfaces.ITurma;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class TurmaServico : ITurmaServico
    {
        private readonly InterfaceTurma _interfaceTurma;
        private readonly InterfaceProfessor _interfaceProfessor;
        private readonly InterfaceProfessorTurma _interfaceProfessorTurma;

        public TurmaServico(InterfaceTurma interfaceTurma,
            InterfaceProfessor interfaceProfessor,
            InterfaceProfessorTurma interfaceProfessorTurma)
        {
            _interfaceTurma = interfaceTurma;
            _interfaceProfessor = interfaceProfessor;
            _interfaceProfessorTurma = interfaceProfessorTurma;
        }

        public async Task<Object> AdicionarProfessorTurma(ProfessorTurma professorTurma)
        {
           await _interfaceProfessorTurma.Add(professorTurma);
            return true;
        }

        public async Task CriarTurma(Turma turma)
        {
            await _interfaceTurma.Add(turma);
        }

        public async Task EditarTurma(Turma turma, int turmaID)
        {
            await _interfaceTurma.Update(turma);
        }

        public async Task ExcluirTurma(int turmaID)
        {
            await _interfaceTurma.ExcluirTurma(turmaID);
        }

        public async Task<object> ListarProfessoresTurma(int turmaID)
        {
            var turmasProf = await _interfaceProfessorTurma.ListarTurmasProfessor(turmaID);
            return true;
            
        }

        public async Task<object> RemoverProfessorTurma(int turmaID)
        {
            var turma = await _interfaceTurma.GetEntityByID(turmaID);
            await _interfaceTurma.Update(turma);
            return turma;
        }
    }
}
