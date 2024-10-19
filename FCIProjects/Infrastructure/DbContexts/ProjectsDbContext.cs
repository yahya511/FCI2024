

namespace Infrastructure.DbContexts
{
    public class ProjectsDbContext : DbContext
    {
        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options)
            : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeesProjects> EmployeesProjects { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeesProjectsConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        // نقل دالة SaveChangesAsync هنا
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && 
                            (e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted));

            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = Guid.NewGuid(); // أو تعيين المستخدم الحالي
                    entity.CreatedOn = DateTime.UtcNow;
                   // entity.RowVersion = BitConverter.GetBytes(DateTime.UtcNow.Ticks);
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.UpdatedBy = Guid.NewGuid(); // أو تعيين GUID الموجود إذا كنت تمتلكه
                    entity.UpdatedOn = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entity.IsDeleted = true;
                    entry.State = EntityState.Modified; // تحديث الكائن بدلاً من حذفه
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
