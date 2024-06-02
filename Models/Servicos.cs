using System.ComponentModel.DataAnnotations;

namespace TPC_EcoSupport.Models
{
    public class Servicos
    {
        public int ID { get; set; }
        public ICollection<Empresas> ID_Empresa { get; set; }
        [Required]
        public DateOnly Data_Servico { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
    }
}
