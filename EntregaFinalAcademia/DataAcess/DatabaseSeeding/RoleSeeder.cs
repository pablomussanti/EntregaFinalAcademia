using Microsoft.EntityFrameworkCore;
using System.Data;
using EntregaFinalAcademia.Entities;

namespace EntregaFinalAcademia.DataAcess.DatabaseSeeding
{
    public class RoleSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    Description = "Admin",
                    Activo = true,

                },
                 new Role
                 {
                     Id = 2,
                     Name = "Consultor",
                     Description = "Consultor",
                     Activo = true,
                 });
        }
    }
}
