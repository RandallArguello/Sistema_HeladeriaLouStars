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
    public class TurnosController : Controller
    {
        private readonly IService<Turno> _turnoService;
        private readonly ILogger<TurnosController> _logger;
        private readonly IMapper _mapper;

        public TurnosController(
            IService<Turno> turnoService,
            ILogger<TurnosController> logger,
            IMapper mapper)
        {
            _turnoService = turnoService;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize(Roles = "Contratista,Administrador")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TurnoDto>>> GetAll()
        {
            _logger.LogInformation("Obteniendo todos los clientes");

            var turnos = await _turnoService.ListarAsync();
            return Ok(_mapper.Map<IEnumerable<TurnoDto>>(turnos));
        }

        [Authorize(Roles = "Contratista,Administrador")]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TurnoDto>> GetById(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("ID de empleado no válido: {Id}", id);
                return BadRequest(new { error = "ID de cliente no válido" });
            }

            _logger.LogInformation("Obteniendo cliente con ID: {Id}", id);

            var turno = await _turnoService.ObtenerPorIdAsync(id);
            if (turno == null)
            {
                _logger.LogWarning("Cliente con ID {Id} no encontrado", id);
                return NotFound(new { error = "Cliente no encontrado" });
            }

            return Ok(_mapper.Map<TurnoDto>(turno));
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TurnoDto>> Create([FromBody] TurnoCreateDto createDto)
        {
            _logger.LogInformation("Creando nuevo cliente");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Modelo inválido al crear cliente");
                return BadRequest(ModelState);
            }

            var turno = _mapper.Map<Turno>(createDto);
            var (ok, error) = await _turnoService.CrearAsync(turno);

            if (!ok)
            {
                _logger.LogWarning("Error al crear cliente: {Error}", error);
                return BadRequest(new { error });
            }

            var TurnoDto = _mapper.Map<TurnoDto>(turno);

            _logger.LogInformation("Cliente creado exitosamente con ID: {Id}", turno.IdTurno);

            return CreatedAtAction(
                nameof(GetById),
                new { id = turno.IdTurno },
                new { message = "Cliente creado exitosamente", turno = TurnoDto });
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TurnoDto>> Update(int id, [FromBody] TurnoUpdateDto updateDto)
        {
            _logger.LogInformation("Actualizando cliente con ID: {Id}", id);

            if (id != updateDto.IdTurno)
            {
                _logger.LogWarning("ID de ruta {Id} no coincide con ID del cuerpo {BodyId}",
                    id, updateDto.IdTurno);
                return BadRequest(new { error = "El ID del cliente no coincide" });
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Modelo inválido al actualizar cliente");
                return BadRequest(ModelState);
            }

            var existingTurno = await _turnoService.ObtenerPorIdAsync(id);
            if (existingTurno == null)
            {
                _logger.LogWarning("Cliente con ID {Id} no encontrado para actualizar", id);
                return NotFound(new { error = "Cliente no encontrado" });
            }

            _mapper.Map(updateDto, existingTurno);
            var (ok, error) = await _turnoService.ActualizarAsync(existingTurno);

            if (!ok)
            {
                _logger.LogWarning("Error al actualizar cliente: {Error}", error);
                return BadRequest(new { error });
            }

            var turnoDto = _mapper.Map<TurnoDto>(existingTurno);

            _logger.LogInformation("Cliente con ID {Id} actualizado exitosamente", id);

            return Ok(new { message = "Cliente actualizado exitosamente", cliente = turnoDto });
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

            var existingTurno = await _turnoService.ObtenerPorIdAsync(id);
            if (existingTurno == null)
            {
                _logger.LogWarning("Cliente con ID {Id} no encontrado para eliminar", id);
                return NotFound(new { error = "Cliente no encontrado" });
            }

            var (ok, error) = await _turnoService.EliminarAsync(id);

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
