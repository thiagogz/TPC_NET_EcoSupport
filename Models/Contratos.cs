using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPC_EcoSupport.Models
{
    public class Contratos
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        public ICollection<Empresas> ID_Empresa { get; set; }
        [Required]
        public string Tipo_Contrato { get; set; }
        public string Data_Inicio { get; set; }
        public string Data_Fim { get; set; }
        public int Valor { get; set; }
        public string Status { get; set; }
    }
}
