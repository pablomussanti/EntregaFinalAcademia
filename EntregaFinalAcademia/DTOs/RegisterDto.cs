using EntregaFinalAcademia.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EntregaFinalAcademia.DTOs
{
    public class RegisterDto
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public int Tipo { get; set; }
        public string Clave { get; set; }
        public Boolean Estado { get; set; }
    }
}
