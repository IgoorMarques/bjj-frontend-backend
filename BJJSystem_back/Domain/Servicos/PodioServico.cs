using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IPodio;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class PodioServico : IPodioServico
    {
        private readonly InterfacePodio _interfacePodio;
        public PodioServico(InterfacePodio interfacePodio)
        {
            _interfacePodio = interfacePodio;
        }


        public async Task CriarNovoPodio(Podio podio)
        {
            await _interfacePodio.Add(podio);   
        }

        public async Task EditarPodio(Podio podio, int podioID)
        {
            await _interfacePodio.Update(podio);
        }
    }
}
