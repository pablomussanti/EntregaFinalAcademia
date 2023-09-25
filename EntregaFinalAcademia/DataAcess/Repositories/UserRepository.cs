using EntregaFinalAcademia.DataAcess.Repositories.Interfaces;
using EntregaFinalAcademia.Entities;
using Microsoft.EntityFrameworkCore;
using EntregaFinalAcademia.DTOs;
using EntregaFinalAcademia.Helpers;

namespace EntregaFinalAcademia.DataAcess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<List<User>> GetAll()
        {
            return await _context.Users.Include(x => x.Role).ToListAsync();
        }

        public override async Task<List<User>> GetAllByState(Boolean estado)
        {
            List<User> lista = await _context.Users.ToListAsync();
            var listaFiltrada = new List<User>();

            foreach (var usr in lista)
            {
                if (estado == true && usr.Estado == true)
                {
                    listaFiltrada.Add(usr);
                }

                if (estado == false && usr.Estado == false)
                {
                    listaFiltrada.Add(usr);
                }
            }

            return listaFiltrada;
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

        public async Task<User?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Users.Include(x => x.Role).SingleOrDefaultAsync(x => x.Email == dto.Email && x.Clave == PasswordEncryptHelper.EncryptPassword(dto.Password, dto.Email));
        }
        public async Task<bool> UserEx(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);
        }
    }
}
