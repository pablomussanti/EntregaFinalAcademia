using EntregaFinalAcademia.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Extensions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

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
        [Column("proyect_estado", TypeName = "int")]
        public EstadoProyecto Estado { get; set; }

        [Required]
        [Column("proyect_estadoActivo", TypeName = "bit")]
        [DefaultValue(true)]
        public Boolean EstadoActivo { get; set; }

        public enum EstadoProyecto
        {
            Pendiente = 1,
            Confirmado = 2,
            Terminado = 3
        }

        public Proyect(ProyectDto dto)
        {
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;
            Estado = dto.Estado;
            EstadoActivo = dto.EstadoActivo;
            
        }

        public Proyect(ProyectDto dto, int id)
        {
            CodProyecto = id;
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;
            Estado = dto.Estado;
            EstadoActivo = dto.EstadoActivo;
        }

        public Proyect()
        {
        }

    }
}
