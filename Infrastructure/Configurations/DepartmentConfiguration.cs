using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Infrastructure.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            // تعريف الخصائص
            builder.HasKey(d => d.DepartmentID);
            // تعيين DepartmentID كـ GUID وتوليد قيمته تلقائيًا
            builder.Property(d => d.DepartmentID)
                .HasDefaultValueSql("NEWID()")  // توليد GUID جديد تلقائيًا
                .ValueGeneratedOnAdd();
            builder.Property(d => d.DepartmentName).IsRequired().HasMaxLength(100);
            builder.Property(d => d.ManagerID).IsRequired(); // يمكن أن يكون GUID
        }
    }
}
