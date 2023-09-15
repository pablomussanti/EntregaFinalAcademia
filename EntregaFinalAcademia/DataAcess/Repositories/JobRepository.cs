using EntregaFinalAcademia.DataAcess.Repositories.Interfaces;
using EntregaFinalAcademia.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntregaFinalAcademia.DataAcess.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {

        public JobRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<bool> Update(Job job)
        {
            var jb = await _context.Jobs.FirstOrDefaultAsync(x => x.CodTrabajo == job.CodTrabajo);
            if (jb == null) { return false; }

            jb.CodProyecto = job.CodProyecto;
            jb.CodServicio = job.CodServicio;
            jb.CantHoras = job.CantHoras;
            jb.ValorHora = job.ValorHora;
            jb.Fecha = job.Fecha;
            jb.Costo = job.Costo;
            jb.Estado = job.Estado;


            _context.Jobs.Update(job);
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var jb = await _context.Jobs.Where(x => x.CodTrabajo == id).FirstOrDefaultAsync();
            if (jb != null)
            {
                _context.Jobs.Remove(jb);
            }

            return true;
        }

    }
}
