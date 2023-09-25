using EntregaFinalAcademia.Entities;

namespace EntregaFinalAcademia.DataAcess.Repositories.Interfaces
{
    public interface IProyectRepository : IRepository<Proyect>
    {

        public Task<List<Proyect>> GetAllByStateAndProyectState(Boolean state, Proyect.EstadoProyecto proyectState);

    }
}
