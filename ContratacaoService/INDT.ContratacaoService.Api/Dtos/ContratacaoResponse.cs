namespace INDT.ContratacaoService.Api.Dtos
{
    public class ContratacaoResponse
    {
        public Guid Id { get; set; }
        public Guid PropostaId { get; set; }
        public DateTime DataContratacao { get; set; }
    }
}
