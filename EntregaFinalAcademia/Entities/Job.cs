﻿namespace EntregaFinalAcademia.Entities
{
    public class Job
    {
        public int codTrabajo { get; set; }

        public DateTime fecha { get; set; }
        
        public int codProyecto { get; set; }

        public int codServicio { get; set; }

        public int cantHoras { get; set; }

        public double valorHora { get; set; }

        public double costo { get; set; }


    }
}