using Domain.Interfaces.ICompeticao;
using Domain.Interfaces.IParticipacaoCompeticao;
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
    public class RepositorioParticipacaoCompeticao : RepositorioGenerics<ParticipacaoCompeticao>, InterfaceParticipacaoCompeticao
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuider;
        public RepositorioParticipacaoCompeticao()
        {
            _OptionsBuider = new DbContextOptions<ContextBase>();   
        }
        public async Task<IList<ParticipacaoCompeticao>> ListarInscricoesNaoPagas()
        {
            using (var banco = new ContextBase(_OptionsBuider))
            {
                return await banco.participacaoCompeticaos
                    .Where(PC => PC.StatusInscricao.Equals("Pendente"))
                    .AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<ParticipacaoCompeticao>> ListarInscricoesPaga()
        {
            using (var banco = new ContextBase(_OptionsBuider))
            {
                return await banco.participacaoCompeticaos
                    .Where(PT => PT.StatusInscricao.Equals("Pago"))
                    .AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<Aluno>> ListarTodosAlunosEmCompeticacaoEspecifica(int competicaoID)
        {
            using (var banco = new ContextBase(_OptionsBuider))
            {
                return await (from PC in banco.participacaoCompeticaos
                              join A in banco.alunos on PC.AlunoID equals A.Id
                              select A).AsNoTracking().ToListAsync();
            }
        }

        public async Task<int> TotalDeAlunosCompeticaoEspefica(int competicaoID)
        {
            using(var banco = new ContextBase(_OptionsBuider))
            {
                return await (from PC in banco.participacaoCompeticaos
                              join A in banco.alunos on PC.AlunoID equals A.Id
                              select A).AsNoTracking().CountAsync();
            }
        }
    }
}
