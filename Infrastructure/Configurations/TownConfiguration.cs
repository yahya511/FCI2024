using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Infrastructure.Configurations
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.ToTable("Towns");

            // تعريف الخصائص
            builder.HasKey(t => t.TownID);
            // تعيين TownID كـ GUID وتوليد قيمته تلقائيًا
            builder.Property(t => t.TownID)
                .HasDefaultValueSql("NEWID()")  // توليد GUID جديد تلقائيًا
                .ValueGeneratedOnAdd();           // تأكيد أن القيمة ستولد عند الإضافة

            builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
        }
    }
}
