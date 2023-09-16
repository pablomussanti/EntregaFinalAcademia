using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaFinalAcademia.Entities
{
    public class User
    {
        [Key]
        [Column("user_id", TypeName = "int")]
        public int CodUsuario { get; set; }

        [Required]
        [Column("user_dni", TypeName = "float")]
        public int Dni { get; set; }

        [Required]
        [Column("user_nombre", TypeName = "VARCHAR(100)")]
        public string Nombre { get; set; }

        [Required]
        [Column("user_tipo", TypeName = "int")]
        public int Tipo { get; set; }

        [Required]
        [Column("user_clave", TypeName = "VARCHAR(60)")]
        public string Clave { get; set; }

        public Role? Role { get; set; }

        [Required]
        [Column("user_estado", TypeName = "bit")]
        [DefaultValue(true)]
        public Boolean Estado { get; set; }

    }
}
