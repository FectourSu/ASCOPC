using ASCOPC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASCOPC.Infrastructure.Data.Configurations
{
    public class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
    {
        public void Configure(EntityTypeBuilder<ComponentType> builder)
        {
            builder.ToTable("ComponentsTypes")
                .HasKey(i => i.Id);

            builder.HasIndex(n => n.Name)
                .IsUnique();

            builder.Property(i => i.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.HasMany(c => c.Components)
                .WithOne(t => t.Type)
                .IsRequired();
        }
    }
}
