namespace HeladeriaLouStars_API.Dto
{
    public class TurnoDto
    {
        public int IdTurno { get; set; }
        public int IdEmpleado { get; set; }
        public string? TipoJornada { get; set; }
        public string? Descripcion { get; set; }
        public decimal HorasTrabajadas { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
    }
}
