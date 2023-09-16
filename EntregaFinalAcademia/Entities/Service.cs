using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaFinalAcademia.Entities
{
    public class Service
    {
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
