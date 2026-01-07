using INDT.ContratacaoService.Domain.Entities;
using INDT.ContratacaoService.Domain.Ports;


namespace INDT.ContratacaoService.Application.UseCases.ListarContratacoes
{
    public class ListarContratacoesUseCase
    {
        private readonly IContratacaoRepository _listarContratacoesUseCase;

        public ListarContratacoesUseCase(IContratacaoRepository repository)
        {
            _listarContratacoesUseCase = repository;
        }

        public async Task<IEnumerable<Contratacao>> ExecutarAsync()
        {
            return await _listarContratacoesUseCase.ListarAsync();
        }
    }
}

