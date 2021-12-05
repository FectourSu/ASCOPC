using ASCOPC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASCOPC.Infrastructure.Data.Configurations
{
    public class ComponentBuildsConfiguration : IEntityTypeConfiguration<ComponentBuilds>
    {
        public void Configure(EntityTypeBuilder<ComponentBuilds> builder)
        {
            builder.HasKey(u => new { u.ComponentId, u.BuildId });

            builder.Navigation(s => s.Components).AutoInclude();
            builder.Navigation(s => s.Build).AutoInclude();
        }
    }
}
