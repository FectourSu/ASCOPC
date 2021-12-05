using ASCOPC.Domain.Entities;
using ASCOPC.Infrastructure.Data.Entities;
using ASCOPC.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASCOPC.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<
        User,
        Role,
        string,
        IdentityUserClaim<string>,
        UserRoles,
        IdentityUserLogin<string>,
        IdentityRoleClaim<string>,
        IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Component> Components { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Specifications> Specifications { get; set; }
        public DbSet<Builds> Builds { get; set; }
        public DbSet<UserBuilds> UsersBuilds { get; set; }
        public DbSet<ComponentBuilds> ComponentBuilds { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            DbInitializer.Initialize(builder);
        }
    }
}
