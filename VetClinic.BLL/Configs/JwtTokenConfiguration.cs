using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace VetClinic.BLL.Configs
{
    public class JwtTokenConfiguration
    {
        private readonly IConfiguration configuration;

        public string Issuer => configuration["Jwt:Issuer"];

        public string Audience => configuration["Jwt:Audience"];

        public static DateTime ExpirationDate => DateTime.UtcNow.AddDays(28);

        public SymmetricSecurityKey Key =>
            new(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

        public SigningCredentials Credentials =>
            new(Key, SecurityAlgorithms.HmacSha256);

        public JwtTokenConfiguration(IConfiguration configuration) =>
            this.configuration = configuration;
    }
}
