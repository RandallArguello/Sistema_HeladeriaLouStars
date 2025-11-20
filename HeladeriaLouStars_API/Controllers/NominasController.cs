using AutoMapper;
using HeladeriaLouStars_API.Dto;
using HeladeriaLouStars_API.Models;
using HeladeriaLouStars_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeladeriaLouStars_API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    public class NominasController : Controller
    {
        private readonly IService<Nomina> _nominaService;
        private readonly ILogger<NominasController> _logger;
        private readonly IMapper _mapper;

        public NominasController(
            IService<Nomina> nominaService,
            ILogger<NominasController> logger,
            IMapper mapper)
        {
            _nominaService = nominaService;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize(Roles = "Contratista,Administrador")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<NominaDto>>> GetAll()
        {
            _logger.LogInformation("Obteniendo todos los clientes");

            var nominas = await _nominaService.ListarAsync();
            return Ok(_mapper.Map<IEnumerable<NominaDto>>(nominas));
        }

        [Authorize(Roles = "Contratista,Administrador")]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<NominaDto>> GetById(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("ID de empleado no válido: {Id}", id);
                return BadRequest(new { error = "ID de cliente no válido" });
            }

            _logger.LogInformation("Obteniendo cliente con ID: {Id}", id);

            var nomina = await _nominaService.ObtenerPorIdAsync(id);
            if (nomina == null)
            {
                _logger.LogWarning("Cliente con ID {Id} no encontrado", id);
                return NotFound(new { error = "Cliente no encontrado" });
            }

            return Ok(_mapper.Map<NominaDto>(nomina));
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NominaDto>> Create([FromBody] NominaCreateDto createDto)
        {
            _logger.LogInformation("Creando nuevo cliente");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Modelo inválido al crear cliente");
                return BadRequest(ModelState);
            }

            var nomina = _mapper.Map<Nomina>(createDto);
            var (ok, error) = await _nominaService.CrearAsync(nomina);

            if (!ok)
            {
                _logger.LogWarning("Error al crear cliente: {Error}", error);
                return BadRequest(new { error });
            }

            var nominaDto = _mapper.Map<NominaDto>(nomina);

            _logger.LogInformation("Cliente creado exitosamente con ID: {Id}", nomina.NominaID);

            return CreatedAtAction(
                nameof(GetById),
                new { id = nomina.NominaID },
                new { message = "Cliente creado exitosamente", nomina = nominaDto });
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NominaDto>> Update(int id, [FromBody] NominaUpdateDto updateDto)
        {
            _logger.LogInformation("Actualizando cliente con ID: {Id}", id);

            if (id != updateDto.NominaID)
            {
                _logger.LogWarning("ID de ruta {Id} no coincide con ID del cuerpo {BodyId}",
                    id, updateDto.NominaID);
                return BadRequest(new { error = "El ID del cliente no coincide" });
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Modelo inválido al actualizar cliente");
                return BadRequest(ModelState);
            }

            var existingNomina = await _nominaService.ObtenerPorIdAsync(id);
            if (existingNomina == null)
            {
                _logger.LogWarning("Cliente con ID {Id} no encontrado para actualizar", id);
                return NotFound(new { error = "Cliente no encontrado" });
            }

            _mapper.Map(updateDto, existingNomina);
            var (ok, error) = await _nominaService.ActualizarAsync(existingNomina);

            if (!ok)
            {
                _logger.LogWarning("Error al actualizar cliente: {Error}", error);
                return BadRequest(new { error });
            }

            var nominaDto = _mapper.Map<NominaDto>(existingNomina);

            _logger.LogInformation("Cliente con ID {Id} actualizado exitosamente", id);

            return Ok(new { message = "Cliente actualizado exitosamente", cliente = nominaDto });
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Eliminando cliente con ID: {Id}", id);

            if (id <= 0)
            {
                _logger.LogWarning("ID de cliente no válido: {Id}", id);
                return BadRequest(new { error = "ID de cliente no válido" });
            }

            var existingNomina = await _nominaService.ObtenerPorIdAsync(id);
            if (existingNomina == null)
            {
                _logger.LogWarning("Cliente con ID {Id} no encontrado para eliminar", id);
                return NotFound(new { error = "Cliente no encontrado" });
            }

            var (ok, error) = await _nominaService.EliminarAsync(id);

            if (!ok)
            {
                _logger.LogWarning("Error al eliminar cliente: {Error}", error);
                return BadRequest(new { error });
            }

            _logger.LogInformation("Cliente con ID {Id} eliminado exitosamente", id);

            return NoContent();
        }
    }
}

