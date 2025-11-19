using HeladeriaLouStarsApp.Models.Dto;

namespace HeladeriaLouStars_API.Services.Interfaces
{
    public interface IReporteRepository
    {
        Task<IEnumerable<ReporteEmpleadoDto>> ObtenerReporteEmpleados(DateTime? inicio, DateTime? fin);
    }
}
