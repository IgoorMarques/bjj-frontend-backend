using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IProfessorServico
    {
        Task AdicionarNovoProfessor(Professor professor);
        Task ExcluirProfessor(Professor professor);
        Task EditarProfessor(Professor professor, int professorID);
    }
}
