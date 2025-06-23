using Microsoft.Extensions.Configuration;
using ProductManager.Domain.Common.Enums;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace ProductManager.Application.Services
{
    public class JwtTokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Guid userId, string login, List<Permission> permissions)
        {
            // 📌 Agregando claims personalizados al token:
            // - Id del usuario
            // - Login
            // - Permisos (como claims separados)
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Name, login)
                };

            foreach (var permission in permissions)
            {
                claims.Add(new Claim("permission", permission.ToString()));
            }

            // 🔐 Cargando la clave secreta para firmar el token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            // 🖊️ Definiendo las credenciales de firma usando HMAC-SHA256
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 🏗️ Construyendo el objeto JwtSecurityToken con sus metadatos
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            // 🧾 Serializando el token a string para devolverlo al cliente
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
