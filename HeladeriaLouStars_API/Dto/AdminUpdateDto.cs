namespace HeladeriaLouStars_API.Dto
{
    public class AdminUpdateDto
    {
        public int IdAdministrador { get; set; }
        public string? NombreUsuario { get; set; } = string.Empty;
        public string? Contraseña { get; set; } = string.Empty;
        public string? Correo { get; set; } = string.Empty;
    }
}
