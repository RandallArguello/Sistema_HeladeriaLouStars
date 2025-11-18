namespace HeladeriaLouStars_API.Dto
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public DateTime Expiracion { get; set; }
    }
}
