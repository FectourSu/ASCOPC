using ASCOPC.Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace ASCOPC.Infrastructure.Data.Entities
{
    public class User : IdentityUser, IUser
    {
        public virtual ICollection<UserRoles> UserRoles { get; set; }
        public virtual ICollection<Builds> Builds { get; set; }

        public User()
        {

        }
        public User(string email, string userName)
        {
            Email = email;
            UserName = userName;
        }
    }
}
