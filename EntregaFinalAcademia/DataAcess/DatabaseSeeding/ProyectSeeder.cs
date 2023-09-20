using EntregaFinalAcademia.Entities;
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
                    Estado = Proyect.EstadoProyecto.Pendiente,
                    Nombre = "Proyecto A",
                    EstadoActivo = true

                },
                new Proyect
                {
                    CodProyecto = 2,
                    Direccion = "Suipacha 2923",
                    Estado = Proyect.EstadoProyecto.Confirmado,
                    Nombre = "Proyecto B",
                    EstadoActivo = true

                },
                new Proyect
                {
                    CodProyecto = 3,
                    Direccion = "Ferro 14545",
                    Estado = Proyect.EstadoProyecto.Terminado,
                    Nombre = "Proyecto C",
                    EstadoActivo = true

                });
        }
    }
}
