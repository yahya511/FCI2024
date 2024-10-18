using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;
using Domain.Enums;

namespace Infrastructure.Configurations
    {
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            // تعريف الخصائص
            builder.HasKey(e => e.EmployeeID);
            // تعيين EmployeeID كـ GUID وتوليد قيمته تلقائيًا
            builder.Property(e => e.EmployeeID)
                .HasDefaultValueSql("NEWID()")  // توليد GUID جديد تلقائيًا
                .ValueGeneratedOnAdd();           // تأكيد أن القيمة ستولد عند الإضافة

            builder.Property(e => e.JobTitle)
                   .HasConversion(
                       v => v.ToString(),
                       v => (JobTitle)Enum.Parse(typeof(JobTitle), v))
                   .IsRequired();

            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.MiddleName).HasMaxLength(100);
            builder.Property(e => e.JobTitle).HasMaxLength(100);
            builder.Property(e => e.HireDate).IsRequired();
            builder.Property(e => e.Salary).IsRequired().HasColumnType("decimal(18,2)");
        

            // علاقة مع Manager
            builder.HasOne(e => e.Manager)
                .WithMany(e => e.Subordinates)
                .HasForeignKey(e => e.ManagerID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // علاقة مع Address
            builder.HasOne(e => e.Address)
                .WithMany(a => a.Employees)
                .HasForeignKey(e => e.AddressID);
        }
    }
}