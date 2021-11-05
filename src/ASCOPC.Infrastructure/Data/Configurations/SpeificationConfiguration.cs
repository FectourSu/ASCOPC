using ASCOPC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASCOPC.Infrastructure.Data.Configurations
{
    public class SpeificationConfiguration : IEntityTypeConfiguration<Specifications>
    {
        public void Configure(EntityTypeBuilder<Specifications> builder)
        {
            builder.ToTable("Specifications")
                .HasIndex(i => i.Id);

            builder.Property(i => i.SpecificationTitle)
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.Property(i => i.SpecificationValue)
                 .HasMaxLength(200)
                 .IsUnicode(false);

            builder.HasMany(c => c.SpecificationComponent)
                .WithOne(s => s.Specifications)
                .HasForeignKey(s => s.ComponentId)
                .IsRequired();
        }
    }
}
