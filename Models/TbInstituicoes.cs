using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TPC_EcoSupport.Models;

[Table("TB_INSTITUICOES")]
public partial class TbInstituicoes
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("NOME")]
    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [Column("CNPJ")]
    [StringLength(18)]
    public string Cnpj { get; set; } = null!;

    [Column("EMAIL")]
    [StringLength(100)]
    [EmailAddress]
    public string? Email { get; set; }

    [Column("TELEFONE")]
    [StringLength(20)]
    public string? Telefone { get; set; }

    [Column("ENDERECO")]
    [StringLength(200)]
    public string? Endereco { get; set; }
}
