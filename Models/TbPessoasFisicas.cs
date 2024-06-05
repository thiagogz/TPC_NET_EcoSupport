using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TPC_EcoSupport.Models;

[Table("TB_PESSOAS_FISICAS")]
[Index("Email", Name = "SYS_C002408492", IsUnique = true)]
public partial class TbPessoasFisicas
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("NOME")]
    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column("CPF")]
    [StringLength(14)]
    [Unicode(false)]
    public string Cpf { get; set; } = null!;

    [Column("EMAIL")]
    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("SENHA")]
    [StringLength(100)]
    [Unicode(false)]
    public string Senha { get; set; } = null!;

    [InverseProperty("IdPessoaFisicaNavigation")]
    public virtual ICollection<TbUsuarios> Usuarios { get; set; } = new List<TbUsuarios>();
}
