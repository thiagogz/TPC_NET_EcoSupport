using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TPC_EcoSupport.Models;

[Table("TB_TERMOS_CONDICOES")]
public partial class TbTermosCondicoes
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("ID_USUARIO", TypeName = "NUMBER")]
    public decimal? IdUsuario { get; set; }

    [Column("ACEITOU")]
    [StringLength(1)]
    [Unicode(false)]
    public string? Aceitou { get; set; }

    [Column("DATA_ACEITE", TypeName = "DATE")]
    public DateTime? DataAceite { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("TbTermosCondicos")]
    public virtual TbUsuarios? IdUsuarioNavigation { get; set; }
}
