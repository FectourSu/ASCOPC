using ASCOPC.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASCOPC.Infrastructure.Data.Configurations
{
    public class BuildsComponentConfiguration : IEntityTypeConfiguration<BuildsComponent>
    {
        public void Configure(EntityTypeBuilder<BuildsComponent> builder)
        {
            builder.ToTable("BuildsComponents")
                .HasKey(f => new { f.BuildId, f.ComponentId });

            builder.Navigation(s => s.Builds).AutoInclude();
            builder.Navigation(s => s.Components).AutoInclude();
        }
    }
}
