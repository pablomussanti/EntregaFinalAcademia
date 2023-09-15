using EntregaFinalAcademia.DataAcess.Repositories.Interfaces;
using EntregaFinalAcademia.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntregaFinalAcademia.DataAcess.Repositories
{
    public class ProyectRepository : Repository<Proyect>, IProyectRepository
    {

        public ProyectRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<bool> Update(Proyect proyect)
        {
            var pryt = await _context.Proyects.FirstOrDefaultAsync(x => x.CodProyecto == proyect.CodProyecto);
            if (pryt == null) { return false; }

            pryt.Direccion = proyect.Direccion;
            pryt.Estado = proyect.Estado;
            pryt.Nombre = proyect.Nombre;

            _context.Proyects.Update(pryt);
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var pryt = await _context.Proyects.Where(x => x.CodProyecto == id).FirstOrDefaultAsync();
            if (pryt != null)
            {
                _context.Proyects.Remove(pryt);
            }

            return true;
        }

    }
}
