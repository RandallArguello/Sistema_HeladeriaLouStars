namespace HeladeriaLouStarsApp.Models.Dto
{
    public class ContratoUpdateDto
    {
        public int IdContrato { get; set; }
        public decimal SalarioBase { get; set; }
        public string? TipoContrato { get; set; }
        public string? EstadoContrato { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
