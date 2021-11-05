using Microsoft.AspNetCore.Identity;

namespace ASCOPC.Infrastructure.Data.Entities
{
    public class Role : IdentityRole
    {
        public virtual ICollection<UserRoles> UserRoles { get; set; }

        public Role()
        {

        }
        public Role(string roleName) : base(roleName)
        {

        }
    }
}
