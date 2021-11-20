using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCOPC.Shared.DTO
{
    public class UserRoleDTO
    {
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<string> UserRoles { get; set;}
        public string Email { get; set; }
        public UserRoleDTO()
        {
            Roles = new List<string>();
            UserRoles = new List<string>();
        }
        public UserRoleDTO(string email, IEnumerable<string> roles, IEnumerable<string> userRoles)
        {
            Email = email;
            Roles = roles;
            UserRoles = userRoles;
        }
    }
}
