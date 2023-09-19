using EntregaFinalAcademia.DataAcess.Repositories;
using EntregaFinalAcademia.DataAcess;

namespace EntregaFinalAcademia.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UserRepository UserRepository { get; private set; }
        public JobRepository JobRepository { get; private set; }
        public ServiceRepository ServiceRepository { get; private set; }
        public ProyectRepository ProyectRepository { get; private set; }
        public RoleRepository RoleRepository { get; private set; }

        public UnitOfWorkService(ApplicationDbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            RoleRepository = new RoleRepository(_context);
            ServiceRepository = new ServiceRepository(_context);
            JobRepository = new JobRepository(_context);
            ProyectRepository = new ProyectRepository(_context);



        }

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }

    }
}
