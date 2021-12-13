using ASCOPC.Domain.Contracts;
using ASCOPC.Shared.Requests;
using ASCOPC.Shared.Responses;

namespace ASOPC.Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<IResult<UserTokenResponse>> AunthenticationAsync(AuthenticationRequest request);
        Task<IResult<UserTokenResponse>> LoginAsync(AuthenticationRequest request);
    }
}
