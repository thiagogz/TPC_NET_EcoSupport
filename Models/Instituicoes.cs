using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPC_EcoSupport.Models
{
    [Table("TB_INSTITUICOES")]
    public class Instituicoes
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Required]
        [Column("Nome")]
        public string Nome { get; set; }

        [Required]
        [Column("CNPJ")]
        public string CNPJ { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Telefone")]
        public string Telefone { get; set; }

        [Column("Endereco")]
        public string Endereco { get; set; }
    }
}

