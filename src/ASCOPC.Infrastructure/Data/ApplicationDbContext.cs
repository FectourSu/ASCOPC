using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASCOPC.Domain.Entities;
using ASCOPC.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;

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
        public DbSet<ComponentType> ComponentTypes { get; set; } 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            DbInitializer.Initialize(builder);
        }
    }
}
