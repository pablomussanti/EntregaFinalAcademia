using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EntregaFinalAcademia.DTOs
{
    public class ServiceDto
    {
        public string descr { get; set; }
        public Boolean estado { get; set; }
        public double valorHora { get; set; }
    }
}
