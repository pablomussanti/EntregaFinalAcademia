using EntregaFinalAcademia.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntregaFinalAcademia.DataAcess.DatabaseSeeding
{
    public class ServiceSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    codServicio = 1,
                    descr = "Reparacion",
                    estado = true,
                    valorHora = 250
                },
                new Service
                {
                    codServicio = 2,
                    descr = "Mantenimiento",
                    estado = true,
                    valorHora = 100
                });
        }
    }
}
