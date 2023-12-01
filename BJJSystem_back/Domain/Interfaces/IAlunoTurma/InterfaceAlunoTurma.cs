using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IAlunoTurma
{
    public interface InterfaceAlunoTurma : InterfaceGeneric<AlunoTurma>
    {
        Task<IList<Aluno>> ListarTodosAlunosTurma(int turmaID);

    }
}
