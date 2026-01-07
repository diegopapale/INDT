using INDT.ContratacaoService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDT.ContratacaoService.Infrastructure.Persistence
{
    public class ContratacaoDbContext : DbContext
    {
        public ContratacaoDbContext(DbContextOptions<ContratacaoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contratacao> Contratacoes => Set<Contratacao>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contratacao>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.PropostaId)
                      .IsRequired();

                entity.Property(c => c.DataContratacao)
                      .IsRequired();
            });
        }
    }
}
