using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IProfessorTurma
{
    public interface InterfaceProfessorTurma : InterfaceGeneric<ProfessorTurma>
    {
        Task<IList<Turma>> ListarTurmasProfessor(int professorID);
        Task<IList<Professor>> ListarProfessorTurma(int turmaID);
        Task<bool> RemoverProfessorTurma(int turmaID, int professorID);
    }
}
