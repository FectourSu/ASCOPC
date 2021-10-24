using ASCOPC.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ASCOPC.Infrastructure.Data.Configurations
{
    public class ComponentConfigurations : IEntityTypeConfiguration<Component>
    {

        public void Configure(EntityTypeBuilder<Component> builder)
        {
            //builder.Property(i => i..)HasKey()

            builder.ToTable("Components").HasKey(i => i.Id);
        }
    }
}
