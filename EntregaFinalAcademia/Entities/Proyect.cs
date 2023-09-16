using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaFinalAcademia.Entities
{
    public class Proyect
    {
        [Key]
        [Column("proyect_id")]
        public int CodProyecto { get; set; }

        [Required]
        [Column("proyect_nombre", TypeName = "VARCHAR(100)")]
        public string Nombre { get; set; }

        [Required]
        [Column("proyect_direccion", TypeName = "VARCHAR(100)")]
        public string Direccion { get; set; }

        [Required]
        [Column("proyect_estado", TypeName = "bit")]
        [DefaultValue(true)]
        public Boolean Estado { get; set; } 

    }
}
