﻿using EntregaFinalAcademia.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntregaFinalAcademia.DataAcess.DatabaseSeeding
{
    public class ProyectSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proyect>().HasData(
                new Proyect
                {
                    CodProyecto = 1,
                    Direccion = "Santa Fe 29475",
                    Estado = true,
                    Nombre = "Proyecto 1"

                });
        }
    }
}