using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Test.Service.Data.Models;

namespace Test.Service.Help
{
    public class TokenJwt
    {
        private readonly IConfiguration _configuration;
        public TokenJwt(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerarToken(string user)
        {

            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            var claims = new[]
            {
                new Claim (JwtRegisteredClaimNames.Sub,jwt.Subject),
                new Claim (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim (JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                new Claim ("user",user)
            };

            var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signIn = new Microsoft.IdentityModel.Tokens.SigningCredentials(key, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audiencie,
                claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: signIn
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

         public bool ValidarToken(ClaimsIdentity identity)
        {
           
            if (identity.Claims.Count() > 0)
            {
               return true;
            }
            else
            {
                return false;
            }
        }
    }
}
