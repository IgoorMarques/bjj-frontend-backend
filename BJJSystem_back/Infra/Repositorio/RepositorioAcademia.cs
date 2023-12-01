using Domain.Interfaces.IAcademia;
using Entities.Entidades;
using Infra.Repositorio.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioAcademia : RepositorioGenerics<Academia>, InterfaceAcademia
    {
    }
}
