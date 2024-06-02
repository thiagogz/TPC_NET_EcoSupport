using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPC_EcoSupport.Models
{
    [Table("TB_PERFIS_INSTITUICAO")]
    public class Perfis_Instituicao
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [ForeignKey("Usuarios")]
        [Column("ID_Usuario")]
        public int IDUsuario { get; set; }
        public Usuarios Usuario { get; set; }

        [ForeignKey("Instituicoes")]
        [Column("ID_Instituicao")]
        public int IDInstituicao { get; set; }
        public Instituicoes Instituicao { get; set; }
    }
}
