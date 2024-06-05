using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public string TipoContrato { get; set; } = null!;

    [Column("DATA_INICIO", TypeName = "DATE")]
    public DateTime DataInicio { get; set; }

    [Column("DATA_FIM", TypeName = "DATE")]
    public DateTime DataFim { get; set; }

    [Column("VALOR", TypeName = "NUMBER")]
    public decimal Valor { get; set; }

    [Column("STATUS")]
    [StringLength(50)]
    public string? Status { get; set; }

    [Column("ASSINATURA_PENDENTE")]
    [StringLength(1)]
    public string? AssinaturaPendente { get; set; }// 'S' ou 'N'

    [ForeignKey("IdEmpresa")]
    public virtual TbEmpresas Empresa { get; set; }

    [InverseProperty("Contrato")]
    public virtual ICollection<TbTransacoes> Transacoes { get; set; }
}
