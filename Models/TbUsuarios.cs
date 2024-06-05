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
    public string Nome { get; set; } = null!;

    [Column("EMAIL")]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column("SENHA")]
    [StringLength(100)]
    public string Senha { get; set; } = null!;

    [Column("TIPO")]
    [StringLength(20)]
    public string Tipo { get; set; } = null!;

    [Column("ID_EMPRESA", TypeName = "NUMBER")]
    public decimal? IdEmpresa { get; set; }

    [Column("ID_INSTITUICAO", TypeName = "NUMBER")]
    public decimal? IdInstituicao { get; set; }

    [Column("ID_PESSOA_FISICA", TypeName = "NUMBER")]
    public decimal? IdPessoaFisica { get; set; }

    [ForeignKey("IdEmpresa")]
    public virtual TbEmpresas? Empresa { get; set; }

    [ForeignKey("IdInstituicao")]
    public virtual TbInstituicoes? Instituicao { get; set; }

    [ForeignKey("IdPessoaFisica")]
    public virtual TbPessoasFisicas? PessoaFisica { get; set; }
}