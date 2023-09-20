using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using EntregaFinalAcademia.Entities;

namespace EntregaFinalAcademia.DTOs
{
    public class ProyectDto
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public Proyect.EstadoProyecto Estado { get; set; }
        public Boolean EstadoActivo { get; set; }



    }
}
