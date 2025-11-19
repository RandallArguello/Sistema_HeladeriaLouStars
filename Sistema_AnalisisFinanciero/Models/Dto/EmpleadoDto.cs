using System.ComponentModel.DataAnnotations;

namespace HeladeriaLouStarsApp.Models.Dto
{
    public class EmpleadoDto
    {
        public int IdContrato { get; set; }
        public int IdEmpleado { get; set; }
        
        public string? Nombre { get; set; } = string.Empty;
        
        public string? Apellido { get; set; } = string.Empty;
        public DateTime? FechaNacimiento { get; set; }
        public string? Genero { get; set; }
       
        public string? Direccion { get; set; }
      
        public string? Telefono { get; set; }
        
        public string? Email { get; set; } = string.Empty;
        public DateTime FechaIngreso { get; set; }
       
        public string? Cedula { get; set; }
        
        public string? Nacionalidad { get; set; }
    }
}
