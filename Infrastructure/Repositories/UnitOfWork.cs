

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IAddressRepository Addresses { get; private set; }
        public ITownRepository Towns { get; private set; }
        public IProjectRepository Projects { get; private set; }
        public IEmployeeProjectRepository employeeProject { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext, 
                          IAddressRepository addressRepository,
                          ITownRepository townRepository,
                          IProjectRepository projectRepository,
                          IEmployeeProjectRepository employeeProjectRepository)
        {
            _dbContext = dbContext;
            Addresses = addressRepository;
            Towns = townRepository;
            Projects = projectRepository;
            employeeProject=employeeProjectRepository;
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync(); // حفظ جميع التغييرات
        }

        public void Dispose()
        {
            _dbContext.Dispose(); // تحرير الموارد
        }
    }
}
