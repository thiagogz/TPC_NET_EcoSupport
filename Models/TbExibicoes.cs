using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TPC_EcoSupport.Models;

[Table("TB_EXIBICOES")]
public partial class TbExibicoes
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("ID_TRANSACAO", TypeName = "NUMBER")]
    public decimal? IdTransacao { get; set; }

    [Column("VALOR", TypeName = "NUMBER")]
    public decimal Valor { get; set; }

    [Column("DATA_EXIBICAO", TypeName = "DATE")]
    public DateTime DataExibicao { get; set; }

    [Column("DESCRICAO")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Descricao { get; set; }

    [ForeignKey("IdTransacao")]
    [InverseProperty("TbExibicoes")]
    public virtual TbTransacoes? IdTransacaoNavigation { get; set; }
}
