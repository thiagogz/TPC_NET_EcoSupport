using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPC_EcoSupport.Models
{
    [Table("TB_EXIBICOES")]
    public class Exibicoes
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [ForeignKey("Transacoes")]
        [Column("ID_Transacao")]
        public int IDTransacao { get; set; }
        public Transacoes Transacao { get; set; }

        [Required]
        [Column("Valor")]
        public int Valor { get; set; }

        [Required]
        [Column("Data_Exibicao")]
        public DateTime DataExibicao { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }
    }
}
