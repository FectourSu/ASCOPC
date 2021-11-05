using ASCOPC.Domain.Common;

namespace ASCOPC.Domain.Interfaces
{
    public interface IUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
