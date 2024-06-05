using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TPC_EcoSupport.Models;

[Table("TB_CONTRATOS")]
public partial class TbContratos
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("ID_EMPRESA", TypeName = "NUMBER")]
    public decimal? IdEmpresa { get; set; }

    [Column("TIPO_CONTRATO")]
    [StringLength(50)]
    [Unicode(false)]
    public string TipoContrato { get; set; } = null!;

    [Column("DATA_INICIO", TypeName = "DATE")]
    public DateTime? DataInicio { get; set; }

    [Column("DATA_FIM", TypeName = "DATE")]
    public DateTime? DataFim { get; set; }

    [Column("VALOR", TypeName = "NUMBER")]
    public decimal? Valor { get; set; }

    [Column("STATUS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("ASSINATURA_PENDENTE")]
    [StringLength(1)]
    [Unicode(false)]
    public string? AssinaturaPendente { get; set; }

    [ForeignKey("IdEmpresa")]
    [InverseProperty("TbContratos")]
    public virtual TbEmpresas? IdEmpresaNavigation { get; set; }

    [InverseProperty("IdContratoNavigation")]
    public virtual ICollection<TbTransacoes> Transacoes { get; set; } = new List<TbTransacoes>();
}
