using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IMensalidade
{
    public interface InterfaceMensalidade : InterfaceGeneric<Mensalidade>
    {
        Task<IList<Mensalidade>> ListarTodasMensalidades();
        Task<Mensalidade> BuscarMensalidadeID(int mensalidadeID);
        Task<bool> LancarMensalidades();
        Task<IList<Mensalidade>> ListarMensalidadesPagas();
        Task<IList<Mensalidade>> ListarMensalidadesVencidas();
        Task<IList<Mensalidade>> ListarMensalidadesPendentes();

    }
}
