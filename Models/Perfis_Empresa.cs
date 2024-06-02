namespace TPC_EcoSupport.Models
{
    public class Perfis_Empresa
    {
        public int ID { get; set; }
        public ICollection<Usuarios> ID_Usuario { get; set; }
        public ICollection<Empresas> ID_Empresa { get; set; }
    }
}
