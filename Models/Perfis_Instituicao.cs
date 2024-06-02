namespace TPC_EcoSupport.Models
{
    public class Perfis_Instituicao
    {
        public int ID { get; set; }
        public ICollection<Usuarios> ID_Usuario { get; set; }
        public ICollection<Instituicoes> ID_Instituicao { get; set; }
    }
}
