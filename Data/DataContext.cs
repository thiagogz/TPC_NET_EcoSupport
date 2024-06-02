using Microsoft.EntityFrameworkCore;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Instituicoes> Instituicoes { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Contratos> Contratos { get; set; }
        public DbSet<Transacoes> Transacoes { get; set; }
        public DbSet<Exibicoes> Exibicoes { get; set; }
        public DbSet<Servicos> Servicos { get; set; }
        public DbSet<Perfis_Empresa> Perfis_Empresa { get; set; }
        public DbSet<Perfis_Instituicao> Perfis_Instituicao { get; set; }
    }
}
