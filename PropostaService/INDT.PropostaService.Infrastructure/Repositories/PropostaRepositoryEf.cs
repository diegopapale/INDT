using INDT.PropostaService.Domain.Entities;
using INDT.PropostaService.Domain.Ports;
using INDT.PropostaService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDT.PropostaService.Infrastructure.Repositories
{
    public class PropostaRepositoryEf : IPropostaRepository
    {
        private readonly PropostaDbContext _context;

        public PropostaRepositoryEf(PropostaDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Proposta proposta)
        {
            _context.Propostas.Add(proposta);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Proposta proposta)
        {
            _context.Propostas.Update(proposta);
            await _context.SaveChangesAsync();
        }

        public async Task<Proposta?> ObterPorIdAsync(Guid id)
        {
            return await _context.Propostas.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Proposta>> ListarAsync()
        {
            return await _context.Propostas
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
