

namespace Infrastructure.Repositories
{
    public class EmployeeProjectRepository : GenericRepository<Project>, IEmployeeProjectRepository
    {
        public EmployeeProjectRepository(EmployeesDbContext dbContext) : base(dbContext)
        {
        }

        // يمكن إضافة وظائف إضافية خاصة بـ Project هنا إذا لزم الأمر.
    }
}
