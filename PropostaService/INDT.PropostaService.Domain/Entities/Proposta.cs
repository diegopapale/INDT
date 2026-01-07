using INDT.PropostaService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDT.PropostaService.Domain.Entities
{
    public class Proposta
    {

        public Guid Id { get; private set; }
        public string ClienteNome { get; private set; }
        public PropostaStatus Status { get; private set; }

        protected Proposta() { }

        public Proposta(string clienteNome)
        {
            if (string.IsNullOrWhiteSpace(clienteNome))
                throw new ArgumentException("Nome do cliente é obrigatório.");

            Id = Guid.NewGuid();
            ClienteNome = clienteNome;
            Status = PropostaStatus.EmAnalise;
        }

        public void Aprovar()
        {
            if (Status != PropostaStatus.EmAnalise)
                throw new InvalidOperationException("Somente propostas em análise podem ser aprovadas.");

            Status = PropostaStatus.Aprovada;
        }

        public void Rejeitar()
        {
            if (Status != PropostaStatus.EmAnalise)
                throw new InvalidOperationException("Somente propostas em análise podem ser rejeitadas.");

            Status = PropostaStatus.Rejeitada;
        }
    }
}
