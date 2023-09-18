using System.ComponentModel;

namespace EntregaFinalAcademia.DTOs
{
    public class JobDto
    {
        public DateTime Fecha { get; set; }
        public int CodProyecto { get; set; }
        public int CodServicio { get; set; }
        public int CantHoras { get; set; }
        public double ValorHora { get; set; }
        public double Costo { get; set; }
        public Boolean Estado { get; set; }
    }
}
