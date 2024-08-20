using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;



namespace Dio_Veiculos.API.Token
{
    public static class AuthenticationJWT
    {
        public static IServiceCollection AddAuthenticationJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<TokenService>();
            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = ConfigurationToken.Issuer,
                            ValidAudience = ConfigurationToken.Audience,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationToken.Key))
                        };
                    });
            // services.AddAuthentication("Bearer").AddJwtBearer();
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //}).AddCookie();

            return services;
        }
    }
}
