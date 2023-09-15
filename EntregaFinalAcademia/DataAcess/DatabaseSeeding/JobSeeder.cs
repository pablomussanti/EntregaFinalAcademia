using EntregaFinalAcademia.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntregaFinalAcademia.DataAcess.DatabaseSeeding
{
    public class JobSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasData(
                new Job
                {
                    CodProyecto = 1,
                    CodServicio = 1,
                    CodTrabajo = 1,
                    CantHoras = 20,
                    Costo = 2000,
                    Fecha = DateTime.Now,
                    ValorHora = 100,
                    Estado = true
                });
        }
    }
}
