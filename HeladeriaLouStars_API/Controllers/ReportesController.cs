using AutoMapper;
using HeladeriaLouStars_API.Dto;
using HeladeriaLouStars_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeladeriaLouStars_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : Controller
    {
        private readonly IReporteService _service;
        private readonly ILogger<ReportesController> _logger;
        private readonly IMapper _mapper;

        public ReportesController(IReporteService service, ILogger<ReportesController> logger,
            IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize(Roles = "Contratista,Administrador")]
        [HttpGet("EmpleadosJson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ReporteEmpleadoDto>>> EmpleadosJson(DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            _logger.LogInformation("Obteniendo reporte de los empleados");

            var data = await _service.ObtenerReporteEmpleados(fechaInicio, fechaFin);
            return Ok(_mapper.Map<IEnumerable<ReporteEmpleadoDto>>(data));
        }
    }
}
