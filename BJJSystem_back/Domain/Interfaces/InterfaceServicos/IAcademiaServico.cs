using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IAcademiaServico
    {
        Task AdicionarAcademia(Academia academia);
        Task AtualizarCategoria(Academia academia, int academiaID);
    }
}
