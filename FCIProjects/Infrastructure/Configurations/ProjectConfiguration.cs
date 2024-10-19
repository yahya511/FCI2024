

namespace Infrastructure.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            // تعريف الخصائص
            builder.HasKey(p => p.ProjectID);
            // تعيين ProjectID كـ GUID وتوليد قيمته تلقائيًا
            builder.Property(p => p.ProjectID)
                .HasDefaultValueSql("NEWID()")  // توليد GUID جديد تلقائيًا
                .ValueGeneratedOnAdd();           // تأكيد أن القيمة ستولد عند الإضافة

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.StartDate).IsRequired();
            builder.Property(p => p.EndDate).IsRequired(false);
        }
    }
}
