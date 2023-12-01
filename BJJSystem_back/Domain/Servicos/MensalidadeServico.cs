using Domain.Interfaces.IMensalidade;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class MensalidadeServico : IMensalidadeServico
    {

        private readonly InterfaceMensalidade _interfaceMensalidade;

        public MensalidadeServico(InterfaceMensalidade interfaceMensalidade)
        {
            _interfaceMensalidade = interfaceMensalidade;
        }

        private bool ValidaMensalidade(Mensalidade mensalidade)
        {
            return mensalidade.ValidaPropriedadeString(mensalidade.Nome, "Nome");
        }


        public async Task AlterarStatusMensalidade(Mensalidade mensalidade)
        {
            if (ValidaMensalidade(mensalidade))
            {
                await _interfaceMensalidade.Update(mensalidade);
            }
        }

        public async Task CriarNovaMensalidade(Mensalidade mensalidade)
        {
            if (ValidaMensalidade(mensalidade))
            {
                await _interfaceMensalidade.Add(mensalidade);
            }
        }
    }
}
