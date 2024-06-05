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
    public string Nome { get; set; } 

    [Column("CPF")]
    [StringLength(14)]
    public string Cpf { get; set; } 

    [Column("EMAIL")]
    [StringLength(100)]
    [EmailAddress]
    public string Email { get; set; } 

    [Column("SENHA")]
    [StringLength(100)]
    public string Senha { get; set; } 
}
