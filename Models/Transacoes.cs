using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPC_EcoSupport.Models
{
    [Table("TB_TRANSACOES")]
    public class Transacoes
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [ForeignKey("Contratos")]
        [Column("ID_Contrato")]
        public int IDContrato { get; set; }
        public Contratos Contrato { get; set; }

        [Required]
        [Column("Data")]
        public DateTime Data { get; set; }

        [Required]
        [Column("Valor")]
        public int Valor { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        public ICollection<Exibicoes> Exibicoes { get; set; }
    }
}

