using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ITurma
{
    public interface InterfaceTurma : InterfaceGeneric<Turma>
    {
        Task<IList<Turma>> ListarTodasAsTurmas();
        Task<Turma> BuscarTurmaID(int turmaID);
        Task<bool> ExcluirTurma(int turmaID);
    }
}
