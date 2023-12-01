using Domain.Interfaces.IProfessor;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioProfessor : RepositorioGenerics<Professor>, InterfaceProfessor
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositorioProfessor()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<Professor>> ListarProfessores()
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.professores.AsNoTracking().ToListAsync();
            }
        }
    }
}
