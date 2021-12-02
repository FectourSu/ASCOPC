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
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Categories)
                .IsRequired();

            builder.HasOne(u => u.User)
                .WithMany(u => u.Builds);
        }
    }
}
