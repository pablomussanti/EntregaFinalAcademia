using EntregaFinalAcademia.DataAcess.Repositories.Interfaces;
using EntregaFinalAcademia.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntregaFinalAcademia.DataAcess.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {

        public ServiceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<bool> Update(Service service)
        {
            var Srvc = await _context.Services.FirstOrDefaultAsync(x => x.codServicio == service.codServicio);
            if (Srvc == null) { return false; }

            Srvc.estado = service.estado;
            Srvc.valorHora = service.valorHora;
            Srvc.descr = service.descr;

            _context.Services.Update(Srvc);
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var Srvc = await _context.Services.Where(x => x.codServicio == id).FirstOrDefaultAsync();
            if (Srvc != null)
            {
                _context.Services.Remove(Srvc);
            }

            return true;
        }

    }
}
