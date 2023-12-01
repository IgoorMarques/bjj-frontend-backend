using Domain.Interfaces.IAlunoTurma;
using Domain.Interfaces.ITurma;
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
    public class RepositorioAlunoTurma : RepositorioGenerics<AlunoTurma>, InterfaceAlunoTurma
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioAlunoTurma()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Aluno>> ListarTodosAlunosTurma(int turmaID)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                var alunos = await banco.alunos
               .Where(a => banco.alunosTurmas.Any(at => at.TurmaID == turmaID && at.Id == a.Id))
               .ToListAsync();
                return alunos;
            }
        }
    }
}