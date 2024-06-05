using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
    [Unicode(false)]
    public string? Descricao { get; set; }

    [ForeignKey("IdContrato")]
    [InverseProperty("TbTransacos")]
    public virtual TbContratos? IdContratoNavigation { get; set; }

    [InverseProperty("IdTransacaoNavigation")]
    public virtual ICollection<TbExibicoes> Exibicoes { get; set; } = new List<TbExibicoes>();
}
