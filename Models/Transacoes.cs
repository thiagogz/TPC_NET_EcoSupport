using System.ComponentModel.DataAnnotations;

namespace TPC_EcoSupport.Models
{
    public class Transacoes
    {
        public int ID { get; set; }
        public ICollection<Contratos> ID_Contrato { get; set; }
        [Required]
        public DateOnly Data { get; set; }
        [Required]
        public int Valor { get; set; }
        public string Descricao { get; set; }
    }
}
