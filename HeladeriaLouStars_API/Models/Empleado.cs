using System.ComponentModel.DataAnnotations;

namespace HeladeriaLouStars_API.Models
{
    public class Empleado
    {
        public int IdContrato { get; set; }
        public int IdEmpleado { get; set; }
        [StringLength(50)]
        public string? Nombre { get; set; }= string.Empty;
        [StringLength(50)]
        public string? Apellido { get; set; }= string.Empty;
        public DateTime? FechaNacimiento { get; set; }
        public string? Genero { get; set; }
        [StringLength(50)]
        public string? Direccion { get; set; }
        [StringLength(50)]
        public string? Telefono { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }=string.Empty;
        public DateTime FechaIngreso { get; set; }
        [StringLength(50)]
        public string? Cedula { get; set; }
        [StringLength(50)]
        public string? Nacionalidad { get; set; }
    }
}
