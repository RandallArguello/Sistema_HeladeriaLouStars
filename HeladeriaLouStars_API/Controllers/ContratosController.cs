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
    public class ContratosController : Controller
    {
        private readonly IService<Contrato> _contratoService;
        private readonly ILogger<ContratosController> _logger;
        private readonly IMapper _mapper;

        public ContratosController(
            IService<Contrato> contratoService,
            ILogger<ContratosController> logger,
            IMapper mapper)
        {
            _contratoService = contratoService;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize(Roles = "Contratista,Administrador")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ContratoDto>>> GetAll()
        {
            _logger.LogInformation("Obteniendo todos los clientes");

            var contratos = await _contratoService.ListarAsync();
            return Ok(_mapper.Map<IEnumerable<ContratoDto>>(contratos));
        }

        [Authorize(Roles = "Contratista,Administrador")]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContratoDto>> GetById(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("ID de empleado no válido: {Id}", id);
                return BadRequest(new { error = "ID de cliente no válido" });
            }

            _logger.LogInformation("Obteniendo cliente con ID: {Id}", id);

            var contrato = await _contratoService.ObtenerPorIdAsync(id);
            if (contrato == null)
            {
                _logger.LogWarning("Cliente con ID {Id} no encontrado", id);
                return NotFound(new { error = "Cliente no encontrado" });
            }

            return Ok(_mapper.Map<ContratoDto>(contrato));
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ContratoDto>> Create([FromBody] ContratoCreateDto createDto)
        {
            _logger.LogInformation("Creando nuevo cliente");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Modelo inválido al crear cliente");
                return BadRequest(ModelState);
            }

            var contrato = _mapper.Map<Contrato>(createDto);
            var (ok, error) = await _contratoService.CrearAsync(contrato);

            if (!ok)
            {
                _logger.LogWarning("Error al crear cliente: {Error}", error);
                return BadRequest(new { error });
            }

            var contratoDto = _mapper.Map<ContratoDto>(contrato);

            _logger.LogInformation("Cliente creado exitosamente con ID: {Id}", contrato.IdContrato);

            return CreatedAtAction(
                nameof(GetById),
                new { id = contrato.IdContrato },
                new { message = "Cliente creado exitosamente", contrato = contratoDto });
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ContratoDto>> Update(int id, [FromBody] ContratoUpdateDto updateDto)
        {
            _logger.LogInformation("Actualizando cliente con ID: {Id}", id);

            if (id != updateDto.IdContrato)
            {
                _logger.LogWarning("ID de ruta {Id} no coincide con ID del cuerpo {BodyId}",
                    id, updateDto.IdContrato);
                return BadRequest(new { error = "El ID del cliente no coincide" });
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Modelo inválido al actualizar cliente");
                return BadRequest(ModelState);
            }

            var existingContrato = await _contratoService.ObtenerPorIdAsync(id);
            if (existingContrato == null)
            {
                _logger.LogWarning("Cliente con ID {Id} no encontrado para actualizar", id);
                return NotFound(new { error = "Cliente no encontrado" });
            }

            _mapper.Map(updateDto, existingContrato);
            var (ok, error) = await _contratoService.ActualizarAsync(existingContrato);

            if (!ok)
            {
                _logger.LogWarning("Error al actualizar cliente: {Error}", error);
                return BadRequest(new { error });
            }

            var contratoDto = _mapper.Map<ContratoDto>(existingContrato);

            _logger.LogInformation("Cliente con ID {Id} actualizado exitosamente", id);

            return Ok(new { message = "Cliente actualizado exitosamente", contrato = contratoDto });
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

            var existingContrato = await _contratoService.ObtenerPorIdAsync(id);
            if (existingContrato == null)
            {
                _logger.LogWarning("Cliente con ID {Id} no encontrado para eliminar", id);
                return NotFound(new { error = "Cliente no encontrado" });
            }

            var (ok, error) = await _contratoService.EliminarAsync(id);

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
