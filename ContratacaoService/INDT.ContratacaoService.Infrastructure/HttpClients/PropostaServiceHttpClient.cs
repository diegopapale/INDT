using INDT.ContratacaoService.Domain.Ports;
using INDT.ContratacaoService.Infrastructure.Dtos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace INDT.ContratacaoService.Infrastructure.HttpClients
{
    public class PropostaServiceHttpClient : IPropostaServiceClient
    {
        private readonly HttpClient _httpClient;

        public PropostaServiceHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> PropostaEstaAprovada(Guid propostaId)
        {
            var propostas = await _httpClient
                .GetFromJsonAsync<List<PropostaDto>>("/propostas");

            var proposta = propostas.FirstOrDefault(p => p.Id == propostaId);

            return proposta?.Status == PropostaStatusDto.Aprovada;
        }

    }
}
