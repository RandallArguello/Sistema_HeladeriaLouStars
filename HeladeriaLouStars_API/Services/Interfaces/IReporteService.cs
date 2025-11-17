using HeladeriaLouStars_API.Dto;

namespace HeladeriaLouStars_API.Services.Interfaces
{
    public interface IReporteService
    {
        Task<IEnumerable<ReporteEmpleadoDto>> ObtenerReporteEmpleados(DateTime? inicio, DateTime? fin);
    }
}
