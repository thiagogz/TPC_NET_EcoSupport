using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPC_EcoSupport.Models
{
    [Table("TB_PERFIS_EMPRESA")]
    public class Perfis_Empresa
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [ForeignKey("Usuarios")]
        [Column("ID_Usuario")]
        public int IDUsuario { get; set; }
        public Usuarios Usuario { get; set; }

        [ForeignKey("Empresas")]
        [Column("ID_Empresa")]
        public int IDEmpresa { get; set; }
        public Empresas Empresa { get; set; }
    }
}
