using Microsoft.EntityFrameworkCore;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TbContratos> Contratos { get; set; }

        public DbSet<TbEmpresas> Empresas { get; set; }

        public DbSet<TbExibicoes> Exibicoes { get; set; }

        public DbSet<TbInstituicoes> Instituicoes { get; set; }

        public DbSet<TbPessoasFisicas> PessoasFisicas { get; set; }

        public DbSet<TbServicos> Servicos { get; set; }

        public DbSet<TbTermosCondicoes> TermosCondicoes { get; set; }

        public DbSet<TbTransacoes> Transacoes { get; set; }

        public DbSet<TbUsuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema("RM99085")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<TbContratos>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SYS_C002408507");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TbEmpresas>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SYS_C002408483");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TbExibicoes>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SYS_C002408519");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TbInstituicoes>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SYS_C002408486");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TbPessoasFisicas>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SYS_C002408491");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TbServicos>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SYS_C002408515");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TbTermosCondicoes>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SYS_C002408503");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TbTransacoes>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SYS_C002408511");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TbUsuarios>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SYS_C002408497");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.HasSequence("SEQ_CONTRATOS");
            modelBuilder.HasSequence("SEQ_EMPRESAS");
            modelBuilder.HasSequence("SEQ_EXIBICOES");
            modelBuilder.HasSequence("SEQ_INSTITUICOES");
            modelBuilder.HasSequence("SEQ_PESSOAS_FISICAS");
            modelBuilder.HasSequence("SEQ_SERVICOS");
            modelBuilder.HasSequence("SEQ_TERMOS_CONDICOES");
            modelBuilder.HasSequence("SEQ_TRANSACOES");
            modelBuilder.HasSequence("SEQ_USUARIOS");

            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder) { }
    }
}
