using System.ComponentModel.DataAnnotations;

namespace TPC_EcoSupport.Models
{
    public class Instituicoes
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public long CNPJ { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }
}
