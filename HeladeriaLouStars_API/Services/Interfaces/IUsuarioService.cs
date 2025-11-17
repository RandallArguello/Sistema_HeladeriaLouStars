using HeladeriaLouStars_API.Models;

namespace HeladeriaLouStars_API.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario?> ValidarUsuarioAsync(string usuario, string contrasena);
        Task<string> GenerarTokenAsync(Usuario usuario);
    }
}
