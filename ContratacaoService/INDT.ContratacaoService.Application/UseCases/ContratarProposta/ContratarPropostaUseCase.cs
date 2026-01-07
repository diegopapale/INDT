using INDT.ContratacaoService.Domain.Entities;
using INDT.ContratacaoService.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDT.ContratacaoService.Application.UseCases.ContratarProposta
{
    public class ContratarPropostaUseCase
    {
        private readonly IContratacaoRepository _repository;
        private readonly IPropostaServiceClient _propostaServiceClient;

        public ContratarPropostaUseCase(
            IContratacaoRepository repository,
            IPropostaServiceClient propostaServiceClient)
        {
            _repository = repository;
            _propostaServiceClient = propostaServiceClient;
        }

        public async Task ExecutarAsync(Guid propostaId)
        {
            var aprovada = await _propostaServiceClient.PropostaEstaAprovada(propostaId);

            if (!aprovada)
                throw new InvalidOperationException("Proposta não está aprovada.");

            var contratacao = new Contratacao(propostaId);

            await _repository.SalvarAsync(contratacao);
        }
    }
}
