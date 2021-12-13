using ASCOPC.Shared.Responses;
using ASOPC.Application.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASCOPC.Infrastructure.Factories
{
    public class JwtFactory : ITokenFactory
    {

        public UserTokenResponse CreateToken(IEnumerable<string> userRoles, string userName, string securityKey, DateTime expiration)
        {
            var claims = CreateClaims(userRoles, userName);
            var securityToken = CreateJwtToken(claims, securityKey, expiration);

            return new UserTokenResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiration = expiration
            };
        }

        private JwtSecurityToken CreateJwtToken(IEnumerable<Claim> claims, string securityKey, DateTime expiration)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: credentials);
        }

        private IEnumerable<Claim> CreateClaims(IEnumerable<string> userRoles, string userName)
        {
            yield return new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());
            yield return new Claim(JwtRegisteredClaimNames.UniqueName, userName);
            yield return new Claim(ClaimTypes.Name, userName);

            foreach (var role in userRoles)
                yield return new Claim(ClaimTypes.Role, role);

        }
    }
}
