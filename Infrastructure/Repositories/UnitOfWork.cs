

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeesDbContext _dbContext;

        public IAddressRepository Addresses { get; private set; }
        public ITownRepository Towns { get; private set; }
        public IEmployeeProjectRepository employeeProject { get; private set; }

        public UnitOfWork(EmployeesDbContext dbContext, 
                          IAddressRepository addressRepository,
                          ITownRepository townRepository,
                          IEmployeeProjectRepository employeeProjectRepository)
        {
            _dbContext = dbContext;
            Addresses = addressRepository;
            Towns = townRepository;
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
