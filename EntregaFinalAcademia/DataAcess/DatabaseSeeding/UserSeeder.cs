using EntregaFinalAcademia.Entities;
using EntregaFinalAcademia.Helpers;
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
                    Dni = 11111111,
                    Nombre = "Admin",
                    RoleId = 1,
                    Estado = true,
                    Email = "admin@hotmail.com",
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", "admin@hotmail.com")
                });
        }
    }
}
