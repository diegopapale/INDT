using INDT.PropostaService.Domain.Entities;
using INDT.PropostaService.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDT.PropostaService.Application.UseCases.ListarPropostas
{
    public class ListarPropostasUseCase
    {
        private readonly IPropostaRepository _repository;

        public ListarPropostasUseCase(IPropostaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Proposta>> ExecutarAsync()
        {
            return await _repository.ListarAsync();
        }
    }
}
