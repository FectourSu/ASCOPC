using ASCOPC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ASCOPC.Infrastructure.Data.Configurations
{
    public class ComponentConfiguration : IEntityTypeConfiguration<Component>
    {

        public void Configure(EntityTypeBuilder<Component> builder)
        {
            builder.ToTable("Components")
                .HasKey(i => i.Id);

            builder.HasIndex(i => i.Name)
                .IsUnique();
                
            builder.Property(p => p.Price)
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(r => r.Rating)
                .HasColumnType("decimal(5, 2)");

            builder.Property(n => n.Name)
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.HasMany(c => c.SpecificationComponent)
                .WithOne(s => s.Component)
                .HasForeignKey(s => s.ComponentId)
                .IsRequired();
        }
    }
}
