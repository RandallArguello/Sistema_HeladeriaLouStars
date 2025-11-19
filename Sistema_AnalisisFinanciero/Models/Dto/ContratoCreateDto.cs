namespace HeladeriaLouStarsApp.Models.Dto
{
    public class ContratoCreateDto
    {
        public decimal SalarioBase { get; set; }
        public string? TipoContrato { get; set; }
        public string? EstadoContrato { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin {  get; set; }
        
    }
}
