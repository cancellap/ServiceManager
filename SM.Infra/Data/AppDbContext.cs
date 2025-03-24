using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SM.Domaiin.Entities;
using System;

namespace SM.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EnderecoComplemento>(entity =>
            {
                entity.HasKey(ec => ec.Id);

                entity.Property(ec => ec.Id)
                      .ValueGeneratedOnAdd();

                entity.HasOne(ec => ec.Cliente)
                      .WithOne(c => c.EnderecoComplemento)
                      .HasForeignKey<EnderecoComplemento>(ec => ec.ClienteId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ec => ec.Tecnico)
                      .WithOne(t => t.EnderecoComplemento)
                      .HasForeignKey<EnderecoComplemento>(ec => ec.TecnicoId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ec => ec.Endereco)
                      .WithOne() // Relação 1:1
                      .HasForeignKey<EnderecoComplemento>(ec => ec.EnderecoId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Rua).IsRequired();
                entity.Property(e => e.Numero).IsRequired();
                entity.Property(e => e.Bairro).IsRequired();
                entity.Property(e => e.Cidade).IsRequired();
                entity.Property(e => e.Estado).IsRequired();
                entity.Property(e => e.Pais).IsRequired();
                entity.Property(e => e.Cep).IsRequired();
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.RazaoSocial).IsRequired();
                entity.Property(c => c.NomeFantasia).IsRequired();
                entity.Property(c => c.Email).IsRequired();
                entity.Property(c => c.Cnpj).IsRequired();

                entity.HasOne(c => c.EnderecoComplemento)
                      .WithOne(ec => ec.Cliente)
                      .HasForeignKey<EnderecoComplemento>(ec => ec.ClienteId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(c => c.Servicos)
                      .WithOne(s => s.Cliente)
                      .HasForeignKey(s => s.ClienteId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Tecnico>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Email).IsRequired();
                entity.Property(t => t.Nome).IsRequired();
                entity.Property(t => t.Cpf).IsRequired();

                entity.HasOne(t => t.EnderecoComplemento)
                      .WithOne(ec => ec.Tecnico)
                      .HasForeignKey<EnderecoComplemento>(ec => ec.TecnicoId)
                      .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<ServicoTecnico>()
                      .HasOne(st => st.Tecnico)
                      .WithMany(a => a.servicoTecnicos)
                      .HasForeignKey(st => st.TecnicoId);
            });

            modelBuilder.Entity<ServicoTecnico>()
                    .HasKey(ac => new { ac.TecnicoId, ac.ServicoId });
            
            modelBuilder.Entity<Servicos>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Descricao).IsRequired();
                entity.Property(s => s.IsAtivo).IsRequired();
                entity.Property(s => s.ClienteId).IsRequired();

                entity.HasOne(s => s.Cliente)
                      .WithMany(c => c.Servicos)
                      .HasForeignKey(s => s.ClienteId)
                      .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<ServicoTecnico>()
                      .HasOne(st => st.Servico)
                      .WithMany(a => a.servicoTecnicos)
                      .HasForeignKey(st => st.ServicoId);
            });
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EnderecoComplemento> EnderecoComplementos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<Servicos> Servicos { get; set; }
    }
}
