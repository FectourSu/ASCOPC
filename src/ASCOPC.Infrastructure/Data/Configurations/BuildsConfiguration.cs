using ASCOPC.Domain.Entities;
using ASCOPC.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASCOPC.Infrastructure.Data.Configurations
{
    internal class BuildsConfiguration : IEntityTypeConfiguration<Builds>
    {
        public void Configure(EntityTypeBuilder<Builds> builder)
        {
            builder.ToTable("Builds")
                .HasKey(i => i.Id);

            builder.Property(n => n.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Categories)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnType("decimal")
                .IsRequired();

            builder.HasMany(b => b.UserBuilds)
                .WithOne(u => u.Builds)
                .IsRequired();
        }
    }
}
