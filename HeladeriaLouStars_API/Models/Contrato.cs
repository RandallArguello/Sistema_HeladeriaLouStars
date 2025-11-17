using System.ComponentModel.DataAnnotations;

namespace HeladeriaLouStars_API.Models
{
    public class Contrato
    {
        public int IdContrato { get; set; }
        public decimal SalarioBase { get; set; }
        [StringLength(50)]
        public string? TipoContrato { get; set; }
        [StringLength(50)]
        public string? EstadoContrato { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        
    }
}
