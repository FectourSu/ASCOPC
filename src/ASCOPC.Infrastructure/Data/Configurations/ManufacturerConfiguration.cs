using ASCOPC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASCOPC.Infrastructure.Data.Configurations
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("Manufacturers")
                .HasKey(k => k.Id);

            builder.HasIndex(n => n.Name)
                .IsUnique();
            
            builder.Property(n => n.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.HasMany(c => c.Components)
                .WithOne(m => m.Manufacturer)
                .HasForeignKey(f => f.ManufacturerId)
                .IsRequired();            
        }
    }
}
