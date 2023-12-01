using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IFaixa
{
    public interface InterfaceFaixa : InterfaceGeneric<Faixa>
    {
        Task<int> AddFaixaAluno(Faixa faixa);
    }
}
