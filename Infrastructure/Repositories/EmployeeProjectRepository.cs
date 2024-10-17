

namespace Infrastructure.Repositories
{
    public class EmployeeProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public EmployeeProjectRepository(ProjectsDbContext dbContext) : base(dbContext)
        {
        }

        // يمكن إضافة وظائف إضافية خاصة بـ Project هنا إذا لزم الأمر.
    }
}
