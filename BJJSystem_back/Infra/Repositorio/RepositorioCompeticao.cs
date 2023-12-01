using Domain.Interfaces.ICompeticao;
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
    public class RepositorioCompeticao : RepositorioGenerics<Competicao>, InterfaceCompeticao
    {

        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioCompeticao()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<Competicao> BuscarCompeticaoID(int competicaoID)
        {
            using( var banco = new ContextBase(_OptionsBuilder))
            {
                var competicao = await banco.competicaos
                    .FirstOrDefaultAsync(C => C.Id ==competicaoID);
                return competicao;
            }
        }

        public async Task<IList<Aluno>> ListarAlunosComp(int competicaoID)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                var alunos = await banco.alunos
               .Where(a => banco.participacaoCompeticaos.Any(PC => PC.CompeticaoID == competicaoID && a.Id == PC.AlunoID))
               .ToListAsync();
                return alunos;
            }
        }

        public async Task<IList<Competicao>> ListarTodasCompeticoes()
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                // Carrega as competições sem rastreamento
                var competicoes = await banco.competicaos.AsNoTracking().ToListAsync();

                // Obtém os IDs das competições
                var competicaoIds = competicoes.Select(c => c.Id).ToList();

                // Carrega as participações relacionadas às competições
                var participacoes = await banco.participacaoCompeticaos
                    .Where(pc => competicaoIds.Contains(pc.CompeticaoID))
                    .Include(pc => pc.Aluno) // Carrega os alunos associados às participações
                    .ToListAsync();

                // Associa os alunos às competições
                foreach (var competicao in competicoes)
                {
                    competicao.AlunosDaCompeticao = participacoes
                        .Where(pc => pc.CompeticaoID == competicao.Id)
                        .Select(pc => pc.Aluno)
                        .ToList();
                }
                return competicoes;
            }
        }
    }
}
