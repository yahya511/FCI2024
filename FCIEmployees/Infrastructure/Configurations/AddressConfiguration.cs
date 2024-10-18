using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Infrastructure.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            // تعريف الخصائص
            builder.HasKey(a => a.AddressID);
            // تعيين AddressID كـ GUID وتوليد قيمته تلقائيًا
            builder.Property(a => a.AddressID)
                .HasDefaultValueSql("NEWID()")  // توليد GUID جديد تلقائيًا
                .ValueGeneratedOnAdd();
            builder.Property(a => a.AddressText).IsRequired().HasMaxLength(255);
            
            // علاقة مع Town
            builder.HasOne(a => a.Town)
                .WithMany(t => t.Addresses)
                .HasForeignKey(a => a.TownID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
        }
}
}
