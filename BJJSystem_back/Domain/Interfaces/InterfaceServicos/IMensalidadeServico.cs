using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IMensalidadeServico
    {
        Task CriarNovaMensalidade(Mensalidade mensalidade);
        Task AlterarStatusMensalidade(Mensalidade mensalidade);

    }
}
