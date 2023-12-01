using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IProfessor
{
    public interface InterfaceProfessor : InterfaceGeneric<Professor>
    {
        Task<IList<Professor>> ListarProfessores();
    }
}
