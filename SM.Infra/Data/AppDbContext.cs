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


            // Configuração da entidade EnderecoComplemento
            modelBuilder.Entity<EnderecoComplemento>(entity =>
            {
                entity.HasKey(ec => ec.Id);

                // Configuração para gerar o Id automaticamente
                entity.Property(ec => ec.Id)
                      .ValueGeneratedOnAdd();

                // Relação 1:1 com Cliente
                entity.HasOne(ec => ec.Cliente)
                      .WithOne(c => c.EnderecoComplemento)
                      .HasForeignKey<EnderecoComplemento>(ec => ec.ClienteId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relação 1:1 com Tecnico
                entity.HasOne(ec => ec.Tecnico)
                      .WithOne(t => t.EnderecoComplemento)
                      .HasForeignKey<EnderecoComplemento>(ec => ec.TecnicoId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relação 1:1 com Endereco
                entity.HasOne(ec => ec.Endereco)
                      .WithOne() // Relação 1:1
                      .HasForeignKey<EnderecoComplemento>(ec => ec.EnderecoId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuração da entidade Endereco
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

            // Configuração da entidade Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.RazaoSocial).IsRequired();
                entity.Property(c => c.NomeFantasia).IsRequired();
                entity.Property(c => c.Email).IsRequired();
                entity.Property(c => c.Cnpj).IsRequired();

                // Relação 1:1 com EnderecoComplemento
                entity.HasOne(c => c.EnderecoComplemento)
                      .WithOne(ec => ec.Cliente)
                      .HasForeignKey<EnderecoComplemento>(ec => ec.ClienteId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuração da entidade Tecnico
            modelBuilder.Entity<Tecnico>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Email).IsRequired();
                entity.Property(t => t.Nome).IsRequired();
                entity.Property(t => t.Cpf).IsRequired();

                // Relação 1:1 com EnderecoComplemento
                entity.HasOne(t => t.EnderecoComplemento)
                      .WithOne(ec => ec.Tecnico)
                      .HasForeignKey<EnderecoComplemento>(ec => ec.TecnicoId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EnderecoComplemento> EnderecoComplementos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }

    }
}