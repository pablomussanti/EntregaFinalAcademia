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

        public override async Task<List<Service>> GetAllByState(Boolean estado)
        {
            List<Service> lista = await _context.Services.ToListAsync();
            var listaFiltrada = new List<Service>();

            foreach (var srv in lista)
            {
                if (estado == true && srv.estado == true)
                {
                    listaFiltrada.Add(srv);
                }

                if (estado == false && srv.estado == false)
                {
                    listaFiltrada.Add(srv);
                }
            }

            return listaFiltrada;
        }


        public override async Task<Service> GetById(int id)
        {
            return await _context.Services.FirstOrDefaultAsync(x => x.codServicio == id);
        }

        public override async Task<bool> Update(Service service)
        {
            var srv = await _context.Services.FirstOrDefaultAsync(x => x.codServicio == service.codServicio);
            if (srv == null) { return false; }

            srv.estado = service.estado;
            srv.valorHora = service.valorHora;
            srv.descr = service.descr;

            _context.Services.Update(srv);
            return true;
        }

        public override async Task<bool> HardDelete(int id)
        {
            var Srvc = await _context.Services.Where(x => x.codServicio == id).FirstOrDefaultAsync();
            if (Srvc != null)
            {
                _context.Services.Remove(Srvc);
                var jobsToRemove = _context.Jobs.Where(x => x.CodServicio == id);
                _context.Jobs.RemoveRange(jobsToRemove);
            }

            return true;
        }

        public override async Task<bool> SoftDelete(int id)
        {
            var srv = await _context.Services.FirstOrDefaultAsync(x => x.codServicio == id);
            if (srv == null) { return false; }

            srv.estado = false;

            _context.Services.Update(srv);
            return true;
        }

    }
}
