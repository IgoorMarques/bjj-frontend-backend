using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IProfessor;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class ProfessorServico : IProfessorServico
    {

        private readonly InterfaceProfessor _interfaceProfessor;
        public ProfessorServico(InterfaceProfessor interfaceProfessor)
        {
            _interfaceProfessor = interfaceProfessor;
        }

        private bool ValidaProfessor(Professor professor)
        {
            return true;
        }

        public async Task AdicionarNovoProfessor(Professor professor)
        {
            if (ValidaProfessor(professor))
            {
                await _interfaceProfessor.Add(professor);
            }
        }

        public async Task EditarProfessor(Professor professor, int professorID)
        {
            if (ValidaProfessor(professor))
            {
                await _interfaceProfessor.Update(professor);
            }
        }


        public async Task ExcluirProfessor(Professor professor)
        {
            await _interfaceProfessor.Delete(professor);
        }
    }
}
