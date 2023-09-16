using EntregaFinalAcademia.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntregaFinalAcademia.DataAcess.DatabaseSeeding
{
    public class UserSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    CodUsuario = 1,
                    Clave = "1234",
                    Dni = 40951295,
                    Nombre = "Pedro",
                    Tipo = 1,
                    Estado = true
                });
        }
    }
}
