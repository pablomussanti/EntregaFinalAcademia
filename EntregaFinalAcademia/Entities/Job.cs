using EntregaFinalAcademia.DTOs;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaFinalAcademia.Entities
{
    public class Job
    {


        [Key]
        [Column("job_id", TypeName = "int")]
        public int CodTrabajo { get; set; }

        [Required]
        [Column("job_date", TypeName = "date")]
        public DateTime Fecha { get; set; }

        [Required]
        [ForeignKey("Proyects")]
        public int CodProyecto { get; set; }

        [Required]
        [ForeignKey("Services")]
        public int CodServicio { get; set; }

        [Required]
        [Column("job_cantHoras", TypeName = "int")]
        public int CantHoras { get; set; }

        [Required]
        [Column("job_valorHora", TypeName = "float")]
        public double ValorHora { get; set; }

        [Required]
        [Column("job_costo", TypeName = "float")]
        public double Costo { get; set; }

        [Required]
        [Column("job_estado", TypeName = "bit")]
        [DefaultValue(true)]
        public Boolean Estado { get; set; }

        public Job(JobDto dto)
        {
            Fecha = dto.Fecha;
            CodProyecto = dto.CodProyecto;
            CodServicio = dto.CodServicio;
            CantHoras = dto.CantHoras;
            ValorHora = dto.ValorHora;
            Costo = dto.Costo;
            Estado = dto.Estado;
        }

        public Job(JobDto dto, int id)
        {
            CodTrabajo = id;
            Fecha = dto.Fecha;
            CodProyecto = dto.CodProyecto;
            CodServicio = dto.CodServicio;
            CantHoras = dto.CantHoras;
            ValorHora = dto.ValorHora;
            Costo = dto.Costo;
            Estado = dto.Estado;
        }

        public Job()
        {

        }


    }
}
