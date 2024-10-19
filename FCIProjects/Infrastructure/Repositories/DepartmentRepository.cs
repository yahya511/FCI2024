

namespace Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ProjectsDbContext dbContext) : base(dbContext)
        {
        }

        // يمكن إضافة وظائف إضافية خاصة بـ Department هنا إذا لزم الأمر.
    }
}
