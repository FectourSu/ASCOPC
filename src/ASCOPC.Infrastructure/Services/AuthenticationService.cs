using ASCOPC.Domain.Contracts;
using ASCOPC.Infrastructure.Data.Entities;
using ASCOPC.Shared.Requests;
using ASCOPC.Shared.Responses;
using ASOPC.Application.Interfaces;
using ASOPC.Application.Interfaces.Services;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;

namespace ASCOPC.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private readonly IConfiguration _configuration;
        private readonly ITokenFactory _tokenFactory;

        public AuthenticationService(UserManager<User> user, SignInManager<User> sign,
            IConfiguration config, ITokenFactory token)
        {
            _userManager = user;
            _signInManager = sign;

            _configuration = config;
            _tokenFactory = token;

        }
        
        public DateTime TokenInspiration { get; }

        public Task<IResult<UserTokenResponse>> AunthenticationAsync(AuthenticationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<UserTokenResponse>> LoginAsync(AuthenticationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
