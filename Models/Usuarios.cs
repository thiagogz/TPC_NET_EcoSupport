using System.ComponentModel.DataAnnotations;

namespace TPC_EcoSupport.Models
{
    public class Usuarios
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string Tipo { get; set; }
    }
}
