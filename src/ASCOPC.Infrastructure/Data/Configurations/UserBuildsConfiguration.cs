using ASCOPC.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASCOPC.Infrastructure.Data.Configurations
{
    public class UserBuildsConfiguration : IEntityTypeConfiguration<UserBuilds>
    {
        public void Configure(EntityTypeBuilder<UserBuilds> builder)
        {
            builder.HasKey(u => new { u.UserId, u.BuildId });
        }
    }
}
