using Domain.Interfaces.IMensalidade;
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
    public class RepositorioMensalidade : RepositorioGenerics<Mensalidade>, InterfaceMensalidade
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositorioMensalidade()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<Mensalidade> BuscarMensalidadeID(int mensalidadeID)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.mensalidades
                    .Where(M => M.Id.Equals(mensalidadeID))
                    .FirstOrDefaultAsync();
            }
        }

        public async Task<bool> LancarMensalidades()
        {
            try
            {
                var hoje = DateTime.UtcNow;
                if (hoje.Day < 10)
                {
                    return false;
                }

                var vencimento = new DateTime(hoje.Year, hoje.Month, 10);

                using (var banco = new ContextBase(_OptionsBuilder))
                {
                    var mensalidades = await (from aluno in banco.alunos
                                              select new Mensalidade
                                              {
                                                  Nome = "Mensalidade do mês vigente",
                                                  DataVencimento = vencimento,
                                                  AlunoID = aluno.Id
                                              }).ToListAsync();

                    await banco.Set<Mensalidade>().AddRangeAsync(mensalidades);
                    await banco.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                // Lidar ou registrar a exceção
                return false;
            }
        }

        public async Task<IList<Mensalidade>> ListarMensalidadesPagas()
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.mensalidades
                    .Where(MP => MP.Pago.Equals(true))
                    .AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<Mensalidade>> ListarMensalidadesPendentes()
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.mensalidades
                    .Where(MPT => MPT.Pago.Equals(false))
                    .AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<Mensalidade>> ListarMensalidadesVencidas()
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.mensalidades
                    .Where(MM => MM.Pago.Equals(false))
                    .AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<Mensalidade>> ListarTodasMensalidades()
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.mensalidades.AsNoTracking().ToListAsync();
            }
        }
    }
}
