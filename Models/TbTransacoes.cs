using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPC_EcoSupport.Models;

[Table("TB_TRANSACOES")]
public partial class TbTransacoes
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("ID_CONTRATO", TypeName = "NUMBER")]
    public decimal? IdContrato { get; set; }

    [Column("DATA", TypeName = "DATE")]
    public DateTime Data { get; set; }

    [Column("VALOR", TypeName = "NUMBER")]
    public decimal Valor { get; set; }

    [Column("DESCRICAO")]
    [StringLength(200)]
    public string Descricao { get; set; }

    [ForeignKey("IdContrato")]
    [InverseProperty("Transacoes")]
    public virtual TbContratos Contrato { get; set; }
}
