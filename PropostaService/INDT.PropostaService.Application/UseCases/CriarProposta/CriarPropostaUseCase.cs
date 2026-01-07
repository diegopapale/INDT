using INDT.PropostaService.Domain.Entities;
using INDT.PropostaService.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDT.PropostaService.Application.UseCases.CriarProposta
{
    public class CriarPropostaUseCase
    {
        private readonly IPropostaRepository _repository;

        public CriarPropostaUseCase(IPropostaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> ExecutarAsync(string clienteNome)
        {
            var proposta = new Proposta(clienteNome);

            await _repository.AdicionarAsync(proposta);

            return proposta.Id;
        }
    }
}
