using EntregaFinalAcademia.DataAcess.Repositories.Interfaces;
using EntregaFinalAcademia.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using static EntregaFinalAcademia.Entities.Proyect;

namespace EntregaFinalAcademia.DataAcess.Repositories
{
    public class ProyectRepository : Repository<Proyect>, IProyectRepository
    {

        public ProyectRepository(ApplicationDbContext context) : base(context)
        {
        }

        public  async Task<List<Proyect>> GetAllByStateAndProyectState(Boolean estadoactivo, EstadoProyecto estadoproyecto)
        {
            List<Proyect> lista = await _context.Proyects.ToListAsync();
            var listaFiltrada = new List<Proyect>();

            foreach (var pr in lista)
            {
                if (estadoactivo == true && pr.EstadoActivo == true)
                {
                    if (pr.Estado == estadoproyecto || estadoproyecto == 0)
                    {
                        listaFiltrada.Add(pr);
                    }

                }

                if (estadoactivo == false && pr.EstadoActivo == false)
                {
                    if (pr.Estado == estadoproyecto || estadoproyecto == 0)
                    {
                        listaFiltrada.Add(pr);
                    }
                }

            }

            return listaFiltrada;
        }

        public override async Task<Proyect> GetById(int id)
        {
            return await _context.Proyects.FirstOrDefaultAsync(x => x.CodProyecto == id);
        }

        public override async Task<bool> Update(Proyect proyect)
        {
            var pryt = await _context.Proyects.FirstOrDefaultAsync(x => x.CodProyecto == proyect.CodProyecto);
            if (pryt == null) { return false; }

            pryt.Direccion = proyect.Direccion;
            pryt.Estado = proyect.Estado;
            pryt.Nombre = proyect.Nombre;
            pryt.EstadoActivo = proyect.EstadoActivo;

            _context.Proyects.Update(pryt);
            return true;
        }

        public override async Task<bool> HardDelete(int id)
        {
            var pryt = await _context.Proyects.Where(x => x.CodProyecto == id).FirstOrDefaultAsync();
            if (pryt != null)
            {
                _context.Proyects.Remove(pryt);
                var jobsToRemove = _context.Jobs.Where(x => x.CodProyecto == id); 
                _context.Jobs.RemoveRange(jobsToRemove);

            }

            return true;
        }

        public override async Task<bool> SoftDelete(int id)
        {
            var pryt = await _context.Proyects.FirstOrDefaultAsync(x => x.CodProyecto == id);
            if (pryt == null) { return false; }

            pryt.EstadoActivo = false;

            _context.Proyects.Update(pryt);
            return true;
        }

    }
}
