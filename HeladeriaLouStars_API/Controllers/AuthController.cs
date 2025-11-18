using HeladeriaLouStars_API.Dto;
using HeladeriaLouStars_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HeladeriaLouStars_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Validar credenciales (en un caso real, esto se haría contra la base de datos)
            if (request.User == "usuario_admin" && request.Pass == "AdminLoquendo123")
            {
                var token = GenerateJwtToken(request.User, "Administrador");
                return Ok(new LoginResponse
                {
                    Token = token,
                    User = request.User,
                    Rol = "Administrador",
                    Expiracion = DateTime.Now.AddMinutes(60)
                });
            }
            else if (request.User == "usuario_contratista" && request.Pass == "ContratistaLoquendo123")
            {
                var token = GenerateJwtToken(request.User, "Gerente");
                return Ok(new LoginResponse
                {
                    Token = token,
                    User = request.User,
                    Rol = "Contratista",
                    Expiracion = DateTime.Now.AddMinutes(60)
                });
            }

            return Unauthorized(new { error = "Credenciales inválidas" });
        }

        private string GenerateJwtToken(string usuario, string rol)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario),
                new Claim(ClaimTypes.Role, rol)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpireMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}