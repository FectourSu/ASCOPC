using ASCOPC.Domain.Contracts;
using ASCOPC.Domain.Entities;
using ASCOPC.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace ASCOPC.Infrastructure.Data.Entities
{
    public class User : IdentityUser, IUser
    {
        public virtual ICollection<UserRoles> UserRoles { get; set; }

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
