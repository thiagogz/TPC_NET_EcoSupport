using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TPC_EcoSupport.Models;

[Table("TB_USUARIOS")]
[Index("Email", Name = "SYS_C002408498", IsUnique = true)]
public partial class TbUsuarios
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("NOME")]
    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column("EMAIL")]
    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("SENHA")]
    [StringLength(100)]
    [Unicode(false)]
    public string Senha { get; set; } = null!;

    [Column("TIPO")]
    [StringLength(20)]
    [Unicode(false)]
    public string Tipo { get; set; } = null!;

    [Column("ID_EMPRESA", TypeName = "NUMBER")]
    public decimal? IdEmpresa { get; set; }

    [Column("ID_INSTITUICAO", TypeName = "NUMBER")]
    public decimal? IdInstituicao { get; set; }

    [Column("ID_PESSOA_FISICA", TypeName = "NUMBER")]
    public decimal? IdPessoaFisica { get; set; }

    [ForeignKey("IdEmpresa")]
    [InverseProperty("TbUsuarios")]
    public virtual TbEmpresas? IdEmpresaNavigation { get; set; }

    [ForeignKey("IdInstituicao")]
    [InverseProperty("TbUsuarios")]
    public virtual TbInstituicoes? IdInstituicaoNavigation { get; set; }

    [ForeignKey("IdPessoaFisica")]
    [InverseProperty("TbUsuarios")]
    public virtual TbPessoasFisicas? IdPessoaFisicaNavigation { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<TbTermosCondicoes> TermosCondicoes { get; set; } = new List<TbTermosCondicoes>();
}
