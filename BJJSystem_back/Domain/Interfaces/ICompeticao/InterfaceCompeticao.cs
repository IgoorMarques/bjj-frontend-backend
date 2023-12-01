using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ICompeticao
{
    public interface InterfaceCompeticao : InterfaceGeneric<Competicao>
    {
        Task<IList<Competicao>> ListarTodasCompeticoes();
        Task<Competicao> BuscarCompeticaoID(int competicaoID);
        Task<IList<Aluno>> ListarAlunosComp(int competicaoID);
    }
}
