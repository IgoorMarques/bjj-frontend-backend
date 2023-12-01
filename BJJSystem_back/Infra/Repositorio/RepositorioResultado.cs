using Domain.Interfaces.IResultado;
using Entities.Entidades;
using Infra.Repositorio.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioResultado : RepositorioGenerics<Resultado>, InterfaceResultado
    {
    }
}
