using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SM.Domaiin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infra.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public class ConverteUtc : ValueConverter<DateTime, DateTime>
        {
            public ConverteUtc()
                : base(v => v.ToUniversalTime(), v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(c => c.CreatedAt)
                .HasConversion(new ConverteUtc());

            modelBuilder.Entity<Cliente>()
                .Property(c => c.UpdatedAt)
                .HasConversion(new ConverteUtc());

            modelBuilder.Entity<Endereco>()
                .Property(e => e.CreatedAt)
                .HasConversion(new ConverteUtc());

            modelBuilder.Entity<Endereco>()
                .Property(e => e.UpdatedAt)
                .HasConversion(new ConverteUtc());

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        public DbSet<EnderecoSede> EnderecoSedes { get; set; }
    }
}
