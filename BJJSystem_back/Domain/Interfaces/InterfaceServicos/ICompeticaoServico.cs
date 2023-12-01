using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface ICompeticaoServico
    {
        Task CriarCompeticao(Competicao competicao);
        Task EditarCompeticao(Competicao competicao, string competicaoID);
        Task<Object> AdicionarAlunoCompeticao(int competicaoID, int alunoID);
        Task<bool> RemoverAlunoCompeticao(int competicaoID, int alunoID);
    }
}
