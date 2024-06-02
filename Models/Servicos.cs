using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPC_EcoSupport.Models
{
    [Table("TB_SERVICOS")]
    public class Servicos
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [ForeignKey("Empresas")]
        [Column("ID_Empresa")]
        public int IDEmpresa { get; set; }
        public Empresas Empresa { get; set; }

        [Required]
        [Column("Data_Servico")]
        public DateTime DataServico { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("Status")]
        public string Status { get; set; }
    }
}

