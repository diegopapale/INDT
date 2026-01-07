using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDT.ContratacaoService.Domain.Entities
{
    public class Contratacao
    {
        public Guid Id { get; private set; }
        public Guid PropostaId { get; private set; }
        public DateTime DataContratacao { get; private set; }

        public Contratacao(Guid propostaId)
        {
            if (propostaId == Guid.Empty)
                throw new ArgumentException("Proposta inválida.");

            Id = Guid.NewGuid();
            PropostaId = propostaId;
            DataContratacao = DateTime.UtcNow;
        }
    }
}
