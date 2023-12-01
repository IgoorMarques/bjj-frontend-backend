using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface ITurmaServico
    {
        Task CriarTurma(Turma turma);
        Task ExcluirTurma(int turmaID);
        Task EditarTurma(Turma turma, int turmaID);
        Task<Object> ListarProfessoresTurma(int turmaID);
        Task<Object> RemoverProfessorTurma(int turmaID);
        Task<Object> AdicionarProfessorTurma(ProfessorTurma professorTurma);
    }
}
