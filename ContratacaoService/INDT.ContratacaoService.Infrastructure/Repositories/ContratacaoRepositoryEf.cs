using INDT.ContratacaoService.Domain.Entities;
using INDT.ContratacaoService.Domain.Ports;
using INDT.ContratacaoService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace INDT.ContratacaoService.Infrastructure.Repositories
{
    public class ContratacaoRepositoryEf : IContratacaoRepository
    {
        private readonly ContratacaoDbContext _context;

        public ContratacaoRepositoryEf(ContratacaoDbContext context)
        {
            _context = context;
        }

        public async Task SalvarAsync(Contratacao contratacao)
        {
            _context.Contratacoes.Add(contratacao);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contratacao>> ListarAsync()
        {
            return await _context.Contratacoes
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
