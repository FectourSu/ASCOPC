using ASCOPC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASCOPC.Infrastructure.Data.Configurations
{
    internal class SpecCompConfiguration : IEntityTypeConfiguration<SpecificationComponent>
    {
        public void Configure(EntityTypeBuilder<SpecificationComponent> builder)
        {
            builder.ToTable("SpecificationsComponents")
                .HasKey(f => new { f.ComponentId, f.SpecificationId });

            builder.Navigation(s => s.Component).AutoInclude();
            builder.Navigation(s => s.Specifications).AutoInclude();
        }
    }
}
