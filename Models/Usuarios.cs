using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPC_EcoSupport.Models
{
    [Table("TB_USUARIOS")]
    public class Usuarios
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Required]
        [Column("Nome")]
        public string Nome { get; set; }

        [Required]
        [Column("Email")]
        public string Email { get; set; }

        [Required]
        [Column("Senha")]
        public string Senha { get; set; }

        [Required]
        [Column("Tipo")]
        public string Tipo { get; set; }
    }
}

