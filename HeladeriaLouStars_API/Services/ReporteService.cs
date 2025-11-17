using HeladeriaLouStars_API.DAO;
using HeladeriaLouStars_API.Dto;
using HeladeriaLouStars_API.Services.Interfaces;

namespace HeladeriaLouStars_API.Services
{
    public class ReporteService : IReporteService
    {
        private readonly ReportesDAO _dao;

        public ReporteService(ReportesDAO dao)
        {
            _dao = dao;
        }

        public Task<IEnumerable<ReporteEmpleadoDto>> ObtenerReporteEmpleados(DateTime? inicio, DateTime? fin)
            => _dao.ReporteEmpleadosAsync(inicio, fin);
    }
}
