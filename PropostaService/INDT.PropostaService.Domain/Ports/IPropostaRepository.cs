using INDT.PropostaService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDT.PropostaService.Domain.Ports
{
    public interface IPropostaRepository
    {
        Task AdicionarAsync(Proposta proposta);
        Task AtualizarAsync(Proposta proposta);
        Task<Proposta?> ObterPorIdAsync(Guid id);
        Task<List<Proposta>> ListarAsync();
    }

}
