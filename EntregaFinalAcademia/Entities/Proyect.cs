using EntregaFinalAcademia.DTOs;
using Microsoft.Extensions.Hosting;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaFinalAcademia.Entities
{
    public class Proyect
    {

        public Proyect(ProyectDto dto)
        {
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;
            Estado = dto.Estado;
        }

        public Proyect(ProyectDto dto, int id)
        {
            CodProyecto = id;
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;
            Estado = dto.Estado;
        }

        public Proyect()
        {

        }

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
