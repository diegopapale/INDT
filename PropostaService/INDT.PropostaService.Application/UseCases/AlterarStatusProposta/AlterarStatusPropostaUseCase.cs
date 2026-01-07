using INDT.PropostaService.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDT.PropostaService.Application.UseCases.AlterarStatusProposta
{
    public class AlterarStatusPropostaUseCase
    {
        private readonly IPropostaRepository _repository;

        public AlterarStatusPropostaUseCase(IPropostaRepository repository)
        {
            _repository = repository;
        }

        public async Task AprovarAsync(Guid propostaId)
        {
            var proposta = await _repository.ObterPorIdAsync(propostaId)
                            ?? throw new InvalidOperationException("Proposta não encontrada.");

            proposta.Aprovar();
            await _repository.AtualizarAsync(proposta);
        }

        public async Task RejeitarAsync(Guid propostaId)
        {
            var proposta = await _repository.ObterPorIdAsync(propostaId)
                             ?? throw new InvalidOperationException("Proposta não encontrada.");

            proposta.Rejeitar();
            await _repository.AtualizarAsync(proposta);
        }
    }
}
