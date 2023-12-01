using Domain.Interfaces.IAcademia;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class AcademiaServico : IAcademiaServico
    {
        private readonly InterfaceAcademia _interfaceAcademia;
        public AcademiaServico(InterfaceAcademia interfaceAcademia)
        {
            _interfaceAcademia = interfaceAcademia;
        }

        private bool ValidaAcademia(Academia academia)
        {
            var validoNome = academia.ValidaPropriedadeString(academia.Nome, "Nome");
            var validoUser = academia.ValidaPropriedadeString(academia.UsuarioLogin, "UsuarioLogin");
            var validoSenha = academia.ValidaPropriedadeString(academia.SenhaHash, "SenhaHash");

            if (validoNome && validoUser && validoSenha)
            {
                return true;
            }
            return false;
        }

        public async Task AdicionarAcademia(Academia academia)
        {
            if (ValidaAcademia(academia)) await _interfaceAcademia.Add(academia);
        }

        public async Task AtualizarCategoria(Academia academia, int academiaID)
        {
            if (ValidaAcademia(academia)) await _interfaceAcademia.Update(academia);
        }
    }
}
