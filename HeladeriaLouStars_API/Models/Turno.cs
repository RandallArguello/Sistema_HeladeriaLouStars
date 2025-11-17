namespace HeladeriaLouStars_API.Models
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public string? Descripcion { get; set; }
        public decimal HorasTrabajadas { get; set; }
        public string? TipoJornada { get; set; }
    }
}
