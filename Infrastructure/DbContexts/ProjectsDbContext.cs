using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infrastructure.Configurations;

namespace Infrastructure.DbContexts
{
    public class ProjectsDbContext : ApplicationDbContext
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
    }
}
