using HeladeriaLouStars_API.DAO;
using HeladeriaLouStars_API.Models;
using HeladeriaLouStars_API.Services.Interfaces;

namespace HeladeriaLouStars_API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioDAO _usuarioDAO;
        private readonly JwtService _jwtService;

        public UsuarioService(UsuarioDAO usuarioDAO, JwtService jwtService)
        {
            _usuarioDAO = usuarioDAO;
            _jwtService = jwtService;
        }

        public Task<string> GenerarTokenAsync(Usuario usuario)
        {
            var token = _jwtService.GenerateToken(usuario);
            return Task.FromResult(token);
        }

        public async Task<Usuario?> ValidarUsuarioAsync(string usuario, string contrasena)
        {
            return await _usuarioDAO.ValidarUsuarioAsync(usuario, contrasena);
        }
    }
}
