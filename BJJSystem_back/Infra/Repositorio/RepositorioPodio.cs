using Domain.Interfaces.IPodio;
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
    public class RepositorioPodio : RepositorioGenerics<Podio>, InterfacePodio
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositorioPodio()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Podio>> ListarPodiosAlunosID(int alunoID)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.podios.Where(P => P.AlunoID.Equals(alunoID)).ToListAsync();

            }
        }

        public async Task<IList<Podio>> ListarTodosPodiosCompeticaoEspecifica(int competicaoID)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.podios.Where(P => P.CompeticaoID.Equals(competicaoID)).ToListAsync();
            }
        }

        public async Task<IList<int>> TotalMedalhas()
        {
            var medalhas = new List<int>();

            using (var banco = new ContextBase(_OptionsBuilder))
            {
                var medalhasOuro = banco.podios.Where(P => P.Resultado.Descricao.Equals("Ouro")).AsNoTracking().CountAsync();
                medalhas.Add(await medalhasOuro);
                var medalhasPrata = banco.podios.Where(P => P.Resultado.Descricao.Equals("Prata")).AsNoTracking().CountAsync();
                medalhas.Add(await medalhasPrata);
                var medalhasBronze = banco.podios.Where(P => P.Resultado.Descricao.Equals("Bronze")).AsNoTracking().CountAsync();
                medalhas.Add(await medalhasBronze);
                var derrotas = banco.podios.Where(P => P.Resultado.Descricao.Equals("Derrota")).AsNoTracking().CountAsync();
                medalhas.Add(await derrotas);

                return medalhas;

            }
        }
    }
}
