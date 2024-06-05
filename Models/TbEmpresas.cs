using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TPC_EcoSupport.Models;

[Table("TB_EMPRESAS")]
public partial class TbEmpresas
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("NOME")]
    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column("CNPJ")]
    [StringLength(18)]
    [Unicode(false)]
    public string Cnpj { get; set; } = null!;

    [Column("EMAIL")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("TELEFONE")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Telefone { get; set; }

    [Column("ENDERECO")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Endereco { get; set; }

    // Propriedade de navegação corrigida para apontar para a classe TbUsuarios
    [InverseProperty("Empresa")]
    public virtual ICollection<TbUsuarios> Usuarios { get; set; }

    [InverseProperty("Empresa")]
    public virtual ICollection<TbContratos> Contratos { get; set; }

    [InverseProperty("Empresa")]
    public virtual ICollection<TbServicos> Servicos { get; set; }
}
