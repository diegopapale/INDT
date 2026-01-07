using INDT.PropostaService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace INDT.PropostaService.Infrastructure.Persistence
{
    public class PropostaDbContext : DbContext
    {
        public PropostaDbContext(DbContextOptions<PropostaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Proposta> Propostas => Set<Proposta>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proposta>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.ClienteNome)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(p => p.Status)
                      .IsRequired();
            });
        }
    }
}
