using EntregaFinalAcademia.DataAcess.Repositories.Interfaces;
using EntregaFinalAcademia.Entities;
using Microsoft.EntityFrameworkCore;
using EntregaFinalAcademia.DTOs;

namespace EntregaFinalAcademia.DataAcess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.CodUsuario == id);
        }

        public override async Task<bool> Update(User updateUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.CodUsuario == updateUser.CodUsuario);
            if (user == null) { return false; }

            user.Nombre = updateUser.Nombre;
            user.Dni = updateUser.Dni;
            user.Role = updateUser.Role;
            user.Estado = updateUser.Estado;
            user.Clave = updateUser.Clave;

            _context.Users.Update(user);
            return true;
        }

        public override async Task<bool> HardDelete(int id)
        {
            var user = await _context.Users.Where(x => x.CodUsuario == id).FirstOrDefaultAsync();
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            return true;
        }

        public override async Task<bool> SoftDelete(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.CodUsuario == id);
            if (user == null) { return false; }

            user.Estado = false;

            _context.Users.Update(user);
            return true;
        }

        //public async Task<User?> AuthenticateCredentials(AuthenticateDto dto)
        //{
        //    return await _context.Users.SingleOrDefaultAsync(x => x.Email == dto.Email && x.Password == PasswordEncryptHelper.EncryptPassword(dto.Password));
        //}
    }
}
