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
    public class AdministradoresController : Controller
    {
        private readonly IService<Administrador> _administradorService;
        private readonly ILogger<AdministradoresController> _logger;
        private readonly IMapper _mapper;

        public AdministradoresController(
            IService<Administrador> administradorService,
            ILogger<AdministradoresController> logger,
            IMapper mapper)
        {
            _administradorService = administradorService;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize(Roles = "Contratista,Administrador")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AdministradorDto>>> GetAll()
        {
            _logger.LogInformation("Obteniendo todos los clientes");

            var administradores = await _administradorService.ListarAsync();
            return Ok(_mapper.Map<IEnumerable<AdministradorDto>>(administradores));
        }

        [Authorize(Roles = "Contratista,Administrador")]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AdministradorDto>> GetById(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("ID de empleado no válido: {Id}", id);
                return BadRequest(new { error = "ID de cliente no válido" });
            }

            _logger.LogInformation("Obteniendo cliente con ID: {Id}", id);

            var administrador = await _administradorService.ObtenerPorIdAsync(id);
            if (administrador == null)
            {
                _logger.LogWarning("Cliente con ID {Id} no encontrado", id);
                return NotFound(new { error = "Cliente no encontrado" });
            }

            return Ok(_mapper.Map<AdministradorDto>(administrador));
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AdministradorDto>> Create([FromBody] AdminCreateDto createDto)
        {
            _logger.LogInformation("Creando nuevo cliente");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Modelo inválido al crear cliente");
                return BadRequest(ModelState);
            }

            var administrador = _mapper.Map<Administrador>(createDto);
            var (ok, error) = await _administradorService.CrearAsync(administrador);

            if (!ok)
            {
                _logger.LogWarning("Error al crear cliente: {Error}", error);
                return BadRequest(new { error });
            }

            var AdministradorDto = _mapper.Map<AdministradorDto>(administrador);

            _logger.LogInformation("Cliente creado exitosamente con ID: {Id}", administrador.IdAdministrador);

            return CreatedAtAction(
                nameof(GetById),
                new { id = administrador.IdAdministrador },
                new { message = "Cliente creado exitosamente", administrador = AdministradorDto });
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AdministradorDto>> Update(int id, [FromBody] AdminUpdateDto updateDto)
        {
            _logger.LogInformation("Actualizando cliente con ID: {Id}", id);

            if (id != updateDto.IdAdministrador)
            {
                _logger.LogWarning("ID de ruta {Id} no coincide con ID del cuerpo {BodyId}",
                    id, updateDto.IdAdministrador);
                return BadRequest(new { error = "El ID del cliente no coincide" });
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Modelo inválido al actualizar cliente");
                return BadRequest(ModelState);
            }

            var existingAdministrador = await _administradorService.ObtenerPorIdAsync(id);
            if (existingAdministrador == null)
            {
                _logger.LogWarning("Cliente con ID {Id} no encontrado para actualizar", id);
                return NotFound(new { error = "Cliente no encontrado" });
            }

            _mapper.Map(updateDto, existingAdministrador);
            var (ok, error) = await _administradorService.ActualizarAsync(existingAdministrador);

            if (!ok)
            {
                _logger.LogWarning("Error al actualizar cliente: {Error}", error);
                return BadRequest(new { error });
            }

            var administradorDto = _mapper.Map<AdministradorDto>(existingAdministrador);

            _logger.LogInformation("Cliente con ID {Id} actualizado exitosamente", id);

            return Ok(new { message = "Cliente actualizado exitosamente", cliente = administradorDto });
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

            var existingAdministrador = await _administradorService.ObtenerPorIdAsync(id);
            if (existingAdministrador == null)
            {
                _logger.LogWarning("Cliente con ID {Id} no encontrado para eliminar", id);
                return NotFound(new { error = "Cliente no encontrado" });
            }

            var (ok, error) = await _administradorService.EliminarAsync(id);

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
