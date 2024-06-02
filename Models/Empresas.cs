using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPC_EcoSupport.Models
{
    [Table("TB_EMPRESAS")]
    public class Empresas
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("NOME")]
        public string Nome { get; set; }
        [Column("CNPJ")]
        public string CNPJ { get; set; }
        [Column("EMAIL")]
        public string? Email { get; set; }
        [Column("TELEFONE")]
        public string? Telefone { get; set; }
        [Column("ENDERECO")]
        public string? Endereco { get; set; }
    }
}
