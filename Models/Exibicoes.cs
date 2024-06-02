using System.ComponentModel.DataAnnotations;

namespace TPC_EcoSupport.Models
{
    public class Exibicoes
    {
        public int ID { get; set; }
        public ICollection<Transacoes> ID_Transacao { get; set; }
        [Required]
        public int Valor { get; set; }
        [Required]
        public DateOnly Data_Exibicao { get; set; }
        public string Descricao { get; set; }
    }
}
