using AT_DanilloLiz.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AT_DanilloLiz.DAL
{
    public class InfnetDbContext : IdentityDbContext
    {
        public InfnetDbContext(DbContextOptions<InfnetDbContext> options) : base(options)
        {

        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Funcionario>()
                .HasOne(a => a.Endereco)
                .WithOne(e => e.Funcionario)
                .HasForeignKey<Funcionario>(a => a.EnderecoId);

            modelBuilder.Entity<Funcionario>()
                .HasOne(a => a.Departamento)
                .WithMany(e => e.Funcionarios)
                .HasForeignKey(a => a.DepartamentoId);
        }
    }
}