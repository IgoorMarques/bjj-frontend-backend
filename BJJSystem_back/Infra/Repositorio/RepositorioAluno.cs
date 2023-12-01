using Domain.Interfaces.Generics;
using Domain.Interfaces.IAluno;
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
    public class RepositorioAluno : RepositorioGenerics<Aluno>, InterfaceAluno
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositorioAluno()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<Aluno> BuscarAlunoID(int id)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.alunos
                    .Where(A => A.Id.Equals(id))
                    .FirstAsync();
            }
        }

        public async Task<IList<Aluno>> ListarTodosAlunos()
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.alunos.AsNoTracking().ToListAsync();
            }
        }
    }
}
