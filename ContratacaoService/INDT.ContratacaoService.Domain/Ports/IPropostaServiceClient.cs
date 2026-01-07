
namespace INDT.ContratacaoService.Domain.Ports
{
    public interface IPropostaServiceClient
    {
        Task<bool> PropostaEstaAprovada(Guid propostaId);
    }
}
