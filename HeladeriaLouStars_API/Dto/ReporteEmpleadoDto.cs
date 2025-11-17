namespace HeladeriaLouStars_API.Dto
{
    public class ReporteEmpleadoDto
    {
        public int IdContrato { get; set; }
        public int IdEmpleado { get; set; }

        public string? Nombre { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? Email { get; set; } = string.Empty;
      
        public string? Cedula { get; set; }

        public string? Nacionalidad { get; set; }
        public int CantidadNominas { get; set; }
        public decimal TotalPagado { get; set; }
    }
}
