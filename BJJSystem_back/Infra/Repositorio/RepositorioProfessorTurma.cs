using Domain.Interfaces.IProfessor;
using Domain.Interfaces.IProfessorTurma;
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
    public class RepositorioProfessorTurma : RepositorioGenerics<ProfessorTurma>, InterfaceProfessorTurma
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositorioProfessorTurma()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Professor>> ListarProfessorTurma(int turmaID)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                var professors = await banco.professores
                .Where(t => banco.professorTurmas.Any(pt => pt.TurmaID == turmaID && pt.ProfessorID == t.ProfessorID))
                .ToListAsync();
                return professors;
            }
        }

        public async Task<IList<Turma>> ListarTurmasProfessor(int professorID)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                var turmas = await banco.turmas
                .Where(t => banco.professorTurmas.Any(pt => pt.ProfessorID == professorID && pt.TurmaID == t.TurmaID))
                .ToListAsync();
                return turmas;
            }
        }

        public async Task<bool> RemoverProfessorTurma(int turmaID, int professorID)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
             var professorTurma = await banco.professorTurmas
            .Where(pt => pt.ProfessorID == professorID && pt.TurmaID == turmaID)
            .FirstOrDefaultAsync();

                if (professorTurma != null)
                {
                    banco.professorTurmas.Remove(professorTurma);
                    await banco.SaveChangesAsync();
                    return true;
                }

                return false;
            }
        }
    }
}
