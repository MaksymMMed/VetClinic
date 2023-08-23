using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VetClinic.BLL.Configs;
using VetClinic.DAL.Entities;

namespace VetClinic.BLL.TokenFactory
{
    public class JwtTokenFactory : IJwtTokenFactory
    {
        private readonly JwtTokenConfiguration jwtTokenConfiguration;

        public JwtSecurityToken BuildToken(BaseAccount user) => new(
            issuer: jwtTokenConfiguration.Issuer,
            audience: jwtTokenConfiguration.Audience,
            claims: GetClaims(user),
            expires: JwtTokenConfiguration.ExpirationDate,
            signingCredentials: jwtTokenConfiguration.Credentials);

        private static List<Claim> GetClaims(BaseAccount user) => new()
        {
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim("UserType", user.UserType),
            new Claim(ClaimTypes.Authentication, user.Id),
        };

        public JwtTokenFactory(JwtTokenConfiguration jwtTokenConfiguration) =>
            this.jwtTokenConfiguration = jwtTokenConfiguration;
    }
}
