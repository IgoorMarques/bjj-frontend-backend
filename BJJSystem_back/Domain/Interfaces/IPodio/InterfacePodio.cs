using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IPodio
{
    public interface InterfacePodio : InterfaceGeneric<Podio>
    {
        Task<IList<Podio>> ListarTodosPodiosCompeticaoEspecifica(int competicaoID);
        Task<IList<Podio>> ListarPodiosAlunosID(int alunoID);
        Task<IList<int>> TotalMedalhas();

    }
}
