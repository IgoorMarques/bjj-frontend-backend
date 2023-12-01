using Domain.Interfaces.IFaixa;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infra.Repositorio
{
    public class RepositorioFaixa : RepositorioGenerics<Faixa>, InterfaceFaixa
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioFaixa()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<int> AddFaixaAluno(Faixa faixa)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                await data.Set<Faixa>().AddAsync(faixa);
                await data.SaveChangesAsync();
                return faixa.Id;
            }
        }
    }
}
