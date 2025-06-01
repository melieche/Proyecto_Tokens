using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Proyecto_Tokens.Services
{
    public class TokenValidator
    {
        private readonly string _claveSecreta = "tu_clave_secreta";
        private readonly string _issuer = "tu_issuer";
        private readonly string _audience = "tu_audience";

        public ClaimsPrincipal? ValidarToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_claveSecreta);

            var parameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = _issuer,
                ValidateAudience = true,
                ValidAudience = _audience,
                ValidateLifetime = true
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, parameters, out SecurityToken validatedToken);
                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}