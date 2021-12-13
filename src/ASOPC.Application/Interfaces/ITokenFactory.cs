using ASCOPC.Shared.Responses;

namespace ASOPC.Application.Interfaces
{
    public interface ITokenFactory
    {
        UserTokenResponse CreateToken(IEnumerable<string> userRoles, string userName, string securityKey, DateTime expiration);
    }
}
