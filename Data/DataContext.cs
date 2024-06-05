using Microsoft.EntityFrameworkCore;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<TbContratos> Contratos { get; set; }

        public virtual DbSet<TbEmpresas> Empresas { get; set; }

        public virtual DbSet<TbExibicoes> Exibicoes { get; set; }

        public virtual DbSet<TbInstituicoes> Instituicoes { get; set; }

        public virtual DbSet<TbPessoasFisicas> PessoasFisicas { get; set; }

        public virtual DbSet<TbServicos> Servicos { get; set; }

        public virtual DbSet<TbTermosCondicoes> TermosCondicoes { get; set; }

        public virtual DbSet<TbTransacoes> Transacoes { get; set; }

        public virtual DbSet<TbUsuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema("RM99085")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<TbContratos>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SYS_C002408507");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Contratos).HasConstraintName("SYS_C002408508");
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

                entity.HasOne(d => d.IdTransacaoNavigation).WithMany(p => p.Exibicoes).HasConstraintName("SYS_C002408520");
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

                entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Servicos).HasConstraintName("SYS_C002408516");
            });

            modelBuilder.Entity<TbTermosCondicoes>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SYS_C002408503");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TermosCondicoes).HasConstraintName("SYS_C002408504");
            });

            modelBuilder.Entity<TbTransacoes>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SYS_C002408511");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdContratoNavigation).WithMany(p => p.Transacoes).HasConstraintName("SYS_C002408512");
            });

            modelBuilder.Entity<TbUsuarios>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SYS_C002408497");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Usuarios).HasConstraintName("SYS_C002408499");

                entity.HasOne(d => d.IdInstituicaoNavigation).WithMany(p => p.Usuarios).HasConstraintName("SYS_C002408500");

                entity.HasOne(d => d.IdPessoaFisicaNavigation).WithMany(p => p.Usuarios).HasConstraintName("SYS_C002408501");
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
