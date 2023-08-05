using System.IdentityModel.Tokens.Jwt;
using VetClinic.DAL.Entities;

namespace VetClinic.BLL.TokenFactory
{
    public interface IJwtTokenFactory
    {
        JwtSecurityToken BuildToken(BaseAccount user);
    }
}