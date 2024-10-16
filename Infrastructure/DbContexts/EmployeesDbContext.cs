using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infrastructure.Configurations;

namespace Infrastructure.DbContexts
{
    public class EmployeesDbContext : ApplicationDbContext
    {

         public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options) 
        : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Address> Addresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new TownConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
