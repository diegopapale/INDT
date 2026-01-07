using INDT.PropostaService.Domain.Entities;
using INDT.PropostaService.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDT.PropostaService.Infrastructure.Repositories
{
    public class PropostaRepositoryInMemory //: IPropostaRepository
    {
        private static readonly List<Proposta> _propostas = new();

        public void Salvar(Proposta proposta)
        {
            _propostas.RemoveAll(p => p.Id == proposta.Id);
            _propostas.Add(proposta);
        }

        public Proposta? ObterPorId(Guid id)
            => _propostas.FirstOrDefault(p => p.Id == id);

        public IEnumerable<Proposta> Listar()
            => _propostas;
    }
}
