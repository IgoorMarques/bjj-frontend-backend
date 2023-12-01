using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IAlunoServico
    {
        Task CadastrarAluno(Aluno aluno);
        Task ExcluirAluno(Aluno aluno);
        Task EditarAluno(Aluno aluno);

    }
}
