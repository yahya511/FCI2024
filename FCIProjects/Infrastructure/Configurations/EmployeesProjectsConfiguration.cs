

namespace Infrastructure.Configurations
{
    public class EmployeesProjectsConfiguration : IEntityTypeConfiguration<EmployeesProjects>
    {
        public void Configure(EntityTypeBuilder<EmployeesProjects> builder)
        {
            builder.ToTable("EmployeesProjects");

            // تعريف الخصائص
            builder.HasKey(ep => new { ep.EmployeeID, ep.ProjectID });

            
        }
    }
}
