using Microsoft.AspNetCore.Identity;

namespace ASCOPC.Infrastructure.Data.Entities
{
    public class UserRoles : IdentityUserRole<string>
    {
        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}