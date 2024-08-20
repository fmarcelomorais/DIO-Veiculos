using Dio_Veiculos.API.Application.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dio_Veiculos.API.Token
{
    public class TokenService
    {
        public string Generate(AdministratorDto login)
        {
            // Cria uma instancia do JwtSecurityTokenHandler
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(ConfigurationToken.Key);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(login),
                SigningCredentials = credentials,
                Issuer = ConfigurationToken.Issuer,
                Audience = ConfigurationToken.Audience,
                Expires = DateTime.UtcNow.AddHours(2),
            };

            // Gera Token
            var token = handler.CreateToken(tokenDescriptor);
            // Gera string do token
            var strToken = handler.WriteToken(token);

            return strToken;
        }
        
        private static ClaimsIdentity GenerateClaims(AdministratorDto login)
        {
            var ci = new ClaimsIdentity();
            
            ci.AddClaim(new Claim(ClaimTypes.Name, login.Email));
            ci.AddClaim(new Claim("Perfil", login.Perfil.ToString()));
            ci.AddClaim(new Claim(ClaimTypes.Role, login.Perfil.ToString()));
           

            return ci;
        }
    }
}
