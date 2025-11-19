using System.ComponentModel.DataAnnotations;

namespace HeladeriaLouStarsApp.Models.Dto
{
    public class EmpleadoCreateDto
    {
        public int IdContrato { get; set; }
        public string? Nombre { get; set; } = string.Empty;
        public string? Apellido { get; set; } = string.Empty;
        public string? Genero { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; } = string.Empty;
        public string? Cedula { get; set; }
        public string? Nacionalidad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
