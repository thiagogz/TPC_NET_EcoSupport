using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TPC_EcoSupport.Models;

[Table("TB_SERVICOS")]
public partial class TbServicos
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("ID_EMPRESA", TypeName = "NUMBER")]
    public decimal? IdEmpresa { get; set; }

    [Column("DATA_SERVICO", TypeName = "DATE")]
    public DateTime DataServico { get; set; }

    [Column("DESCRICAO")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Descricao { get; set; }

    [Column("STATUS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [ForeignKey("IdEmpresa")]
    [InverseProperty("TbServicos")]
    public virtual TbEmpresas? IdEmpresaNavigation { get; set; }
}
