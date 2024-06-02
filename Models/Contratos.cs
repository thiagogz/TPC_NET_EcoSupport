using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPC_EcoSupport.Models
{
    [Table("TB_CONTRATOS")]
    public class Contratos
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [ForeignKey("Empresas")]
        [Column("ID_Empresa")]
        public int IDEmpresa { get; set; }
        public Empresas Empresa { get; set; }

        [Required]
        [Column("Tipo_Contrato")]
        public string TipoContrato { get; set; }

        [Column("Data_Inicio")]
        public DateTime DataInicio { get; set; }

        [Column("Data_Fim")]
        public DateTime DataFim { get; set; }

        [Column("Valor")]
        public int Valor { get; set; }

        [Column("Status")]
        public string Status { get; set; }

        public ICollection<Transacoes> Transacoes { get; set; }
    }
}
