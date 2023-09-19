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
                    Clave = "Admin",
                    Dni = 11111111,
                    Nombre = "Admin",
                    Tipo = 1,
                    Estado = true
                });
        }
    }
}
