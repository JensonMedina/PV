using Application.Common;
using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Enum;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("v1/puesto")]
    [ApiController]
    public class PuestoController : ControllerBase
    {
        private readonly IPuestoService _puestoService;
        private readonly ILoggerApp _logger;

        public PuestoController(IPuestoService puestoService, ILoggerApp logger)
        {
            _puestoService = puestoService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<PuestoResponse>>> GetAll([FromQuery] int negocioId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            string contexto = $"{this.GetType().Name} - {nameof(GetAll)}";
            _logger.LogInfo(contexto, "Inicializando método.");

            try
            {
                var response = await _puestoService.GetAll(negocioId, pageNumber, pageSize);
                _logger.LogInfo(contexto, $"Se recuperaron {response.Data.Count()} puestos.");
                return Ok(Result<PagedResponse<PuestoResponse>>.Ok(response));
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                {

                    case ExceptionType.NotFound:
                        _logger.LogError(contexto, "Puestos no encontrados", ex.Message);
                        return NotFound(Result<object>.NotFound(ex.Message));
                    case ExceptionType.BadRequest:
                        _logger.LogError(contexto, "Error controlado: ", ex.Message);
                        return BadRequest(Result<object>.BadRequest(ex.Message));
                    default:
                        _logger.LogError(contexto, "Error inesperado creando puesto", ex.Message);
                        return StatusCode(500, Result<object>.Error(ex.Message));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado: {ex.Message}");
                return StatusCode(500, Result<object>.Error(ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PuestoResponse>> GetById([FromRoute]int id, [FromQuery]int negocioId)
        {
            string contexto = $"{this.GetType().Name} - {nameof(GetById)}";
            _logger.LogInfo(contexto, $"Recuperando puesto con ID {id}.");

            try
            {
                var response = await _puestoService.GetById(negocioId, id);
                _logger.LogInfo(contexto, $"Puesto con ID {id} encontrado.");
                return Ok(Result<PuestoResponse>.Ok(response));
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                {
                    case ExceptionType.NotFound:
                        _logger.LogError(contexto, "Puesto no encontrado", ex.Message);
                        return NotFound(Result<object>.NotFound(ex.Message));
                    case ExceptionType.BadRequest:
                        _logger.LogError(contexto, "Error controlado: ", ex.Message);
                        return BadRequest(Result<object>.BadRequest(ex.Message));
                    default:
                        _logger.LogError(contexto, "Error inesperado buscando puesto", ex.Message);
                        return StatusCode(500, Result<object>.Error(ex.Message));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado: {ex.Message}");
                return StatusCode(500, Result<object>.Error(ex.Message));
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] PuestoRequest request)
        {
            string contexto = $"{this.GetType().Name} - {nameof(Register)}";
            _logger.LogInfo(contexto, "Creando nuevo puesto.");

            try
            {
                var response = await _puestoService.Register(request);
                _logger.LogInfo(contexto, $"Puesto creado con nombre {response.Nombre}.");
                return StatusCode(201, Result<object>.Ok(response, "Puesto creado correctamente."));
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                {
                    case ExceptionType.BadRequest:
                        _logger.LogError(contexto, ex.Message);
                        return BadRequest(Result<object>.BadRequest(ex.Message));
                    case ExceptionType.NotFound:
                        _logger.LogError(contexto, ex.Message);
                        return NotFound(Result<object>.NotFound(ex.Message));
                    default:
                        _logger.LogError(contexto, "Error inesperado buscando puesto", ex.Message);
                        return StatusCode(500, Result<object>.Error(ex.Message));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado: {ex.Message}");
                return StatusCode(500, Result<object>.Error(ex.Message));
            }
        }

        [HttpPut("modify")]
        public async Task<ActionResult<PuestoResponse>> Modify([FromQuery]int id, [FromBody] PuestoRequest request)
        {
            string contexto = $"{this.GetType().Name} - {nameof(Modify)}";
            _logger.LogInfo(contexto, $"Actualizando puesto con ID {id}.");

            try
            {
                var response = await _puestoService.Modify(id, request);
                _logger.LogInfo(contexto, $"Puesto con ID {id} actualizado correctamente.");
                return Ok(Result<PuestoResponse>.Ok(response, "Puesto actualizado correctamente."));
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                {
                    case ExceptionType.BadRequest:
                        _logger.LogError(contexto, ex.Message);
                        return NotFound(Result<object>.NotFound(ex.Message));
                    case ExceptionType.NotFound:
                        _logger.LogError(contexto, ex.Message);
                        return NotFound(Result<object>.NotFound(ex.Message));
                    default:
                        _logger.LogError(contexto, "Error inesperado buscando puesto", ex.Message);
                        return StatusCode(500, Result<object>.Error(ex.Message));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado: {ex.Message}");
                return StatusCode(500, Result<object>.Error(ex.Message));
            }
        }

        [HttpDelete("disable")]
        public async Task<IActionResult> Disable([FromQuery]int negocioId, [FromQuery]int id)
        {
            string contexto = $"{this.GetType().Name} - {nameof(Disable)}";
            _logger.LogInfo(contexto, $"Eliminando puesto con ID {id}.");

            try
            {
                await _puestoService.Disable(negocioId, id);
                _logger.LogInfo(contexto, $"Puesto con ID {id} eliminado correctamente.");
                return Ok(Result<object>.Ok("Puesto eliminado correctamente."));
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                {
                    case ExceptionType.BadRequest:
                        _logger.LogError(contexto, ex.Message);
                        return NotFound(Result<object>.NotFound(ex.Message));
                    case ExceptionType.NotFound:
                        _logger.LogError(contexto, ex.Message);
                        return NotFound(Result<object>.NotFound(ex.Message));
                    default:
                        _logger.LogError(contexto, "Error inesperado buscando puesto", ex.Message);
                        return StatusCode(500, Result<object>.Error(ex.Message));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado: {ex.Message}");
                return StatusCode(500, Result<object>.Error(ex.Message));
            }
        }
    }
}
