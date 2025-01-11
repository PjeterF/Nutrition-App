using Microsoft.IdentityModel.Tokens;
using NutritionApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NutritionApp.Utility
{
    public class AccountJwtTokenUtility
    {
        IConfiguration configuration;
        public AccountJwtTokenUtility(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public List<Claim> GenerateClaims(Account account)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim("Username", account.Username));

            return claims;
        }
        public string GenerateToken(Account account)
        {
            string key = configuration["Jwt:Key"];
            SecurityKey secKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials credentials=new SigningCredentials(secKey, SecurityAlgorithms.RsaSha256);
            var claims = GenerateClaims(account);

            JwtSecurityToken token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                DateTime.Now.AddMinutes(60)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public IEnumerable<Claim> ExtractClaims(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            if (!handler.CanReadToken(token))
            {
                throw new Exception("Error reading token");
            }

            return handler.ReadJwtToken(token).Claims;
        }
    }
}
