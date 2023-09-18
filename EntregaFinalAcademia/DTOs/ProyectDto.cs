using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EntregaFinalAcademia.DTOs
{
    public class ProyectDto
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public Boolean Estado { get; set; }

    }
}
