using Microsoft.EntityFrameworkCore;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Contratos> Contratos { get; set; }
        public DbSet<Exibicoes> Exibicoes { get; set; }
        public DbSet<Transacoes> Transacoes { get; set; }
        public DbSet<Instituicoes> Instituicoes { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Servicos> Servicos { get; set; }
        public DbSet<Perfis_Empresa> Perfis_Empresa { get; set; }
        public DbSet<Perfis_Instituicao> Perfis_Instituicao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contratos>()
                .HasOne(c => c.Empresa)
                .WithMany(e => e.Contratos)
                .HasForeignKey(c => c.IDEmpresa)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Exibicoes>()
                .HasOne(e => e.Transacao)
                .WithMany(t => t.Exibicoes)
                .HasForeignKey(e => e.IDTransacao);

            modelBuilder.Entity<Transacoes>()
                .HasOne(t => t.Contrato)
                .WithMany(c => c.Transacoes)
                .HasForeignKey(t => t.IDContrato);

            modelBuilder.Entity<Servicos>()
                .HasOne(s => s.Empresa)
                .WithMany(e => e.Servicos)
                .HasForeignKey(s => s.IDEmpresa);

            modelBuilder.Entity<Perfis_Empresa>()
                .HasOne(pe => pe.Usuario)
                .WithMany()
                .HasForeignKey(pe => pe.IDUsuario);

            modelBuilder.Entity<Perfis_Empresa>()
                .HasOne(pe => pe.Empresa)
                .WithMany()
                .HasForeignKey(pe => pe.IDEmpresa);

            modelBuilder.Entity<Perfis_Instituicao>()
                .HasOne(pi => pi.Usuario)
                .WithMany()
                .HasForeignKey(pi => pi.IDUsuario);

            modelBuilder.Entity<Perfis_Instituicao>()
                .HasOne(pi => pi.Instituicao)
                .WithMany()
                .HasForeignKey(pi => pi.IDInstituicao);
        }
    }
}
