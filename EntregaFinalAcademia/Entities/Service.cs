using EntregaFinalAcademia.DTOs;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace EntregaFinalAcademia.Entities
{
    public class Service
    {
        public Service(ServiceDto dto)
        {
            descr = dto.descr;
            estado = dto.estado;
            valorHora = dto.valorHora;
        }

        public Service(ServiceDto dto, int id)
        {
            codServicio = id;
            descr = dto.descr;
            estado = dto.estado;
            valorHora = dto.valorHora;
        }

        public Service()
        {

        }

        [Key]
        [Column("service_id", TypeName = "int")]
        public int codServicio { get; set; }

        [Required]
        [Column("service_descr", TypeName = "VARCHAR(100)")]
        public string descr { get; set; }

        [Required]
        [Column("service_estado", TypeName = "bit")]
        [DefaultValue(true)]
        public Boolean estado { get; set; }

        [Required]
        [Column("service_valorHora", TypeName = "float")]
        public double valorHora { get; set; }

    }
}
