

using INDT.ContratacaoService.Domain.Entities;

namespace INDT.ContratacaoService.Domain.Ports
{
    public interface IContratacaoRepository
    {
        Task SalvarAsync(Contratacao contratacao);
        Task<IEnumerable<Contratacao>> ListarAsync();
    }
}
