using EntregaFinalAcademia.DataAcess.Repositories;

namespace EntregaFinalAcademia.Services
{
    public interface IUnitOfWork
    {
        public UserRepository UserRepository { get; }
        public RoleRepository RoleRepository { get; }
        public ProyectRepository ProyectRepository { get; }
        public JobRepository JobRepository { get; }
        public ServiceRepository ServiceRepository { get; }
        Task<int> Complete();

    }
}
