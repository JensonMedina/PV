using Application.Common;
using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<PagedResponse<PuestoResponse>>> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            string contexto = $"{this.GetType().Name} - {nameof(PuestoController)}";
            _logger.LogInfo(contexto, "Inicializando método.");

            try
            {
                var response = await _puestoService.GetAllAsync(pageNumber, pageSize);
                _logger.LogInfo(contexto, $"Se recuperaron {response.Data.Count()} puestos.");
                return Ok(Result<PagedResponse<PuestoResponse>>.Ok(response));
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                {

                    case ExceptionType.NotFound:
                        _logger.LogError(contexto, "Puestos no encontrados", ex.Message);
                        return NotFound(Result<object>.NotFound());
                    default:
                        _logger.LogError(contexto, "Error inesperado creando puesto", ex.Message);
                        return StatusCode(500, Result<object>.Error());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado: {ex.Message}");
                return StatusCode(500, Result<object>.Error());
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PuestoResponse>> GetById(int id)
        {
            string contexto = $"{this.GetType().Name} - {nameof(PuestoController)}";
            _logger.LogInfo(contexto, $"Recuperando puesto con ID {id}.");

            try
            {
                var response = await _puestoService.GetByIdAsync(id);
                _logger.LogInfo(contexto, $"Puesto con ID {id} encontrado.");
                return Ok(Result<PuestoResponse>.Ok(response));
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                {

                    case ExceptionType.NotFound:
                        _logger.LogError(contexto, "Puesto no encontrado", ex.Message);
                        return NotFound(Result<object>.NotFound());
                    default:
                        _logger.LogError(contexto, "Error inesperado buscando puesto", ex.Message);
                        return StatusCode(500, Result<object>.Error());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado: {ex.Message}");
                return StatusCode(500, Result<object>.Error());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PuestoRequest request)
        {
            string contexto = $"{this.GetType().Name} - {nameof(PuestoController)}";
            _logger.LogInfo(contexto, "Creando nuevo puesto.");

            try
            {
                var response = await _puestoService.AddAsync(request);
                _logger.LogInfo(contexto, $"Puesto creado con nombre {response.Nombre}.");
                return StatusCode(201, Result<object>.Ok(response, "Puesto creado correctamente."));
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                {
                    case ExceptionType.BadRequest:
                        _logger.LogError(contexto, ex.Message);
                        return NotFound(Result<object>.NotFound());
                    case ExceptionType.NotFound:
                        _logger.LogError(contexto, ex.Message);
                        return NotFound(Result<object>.NotFound());
                    default:
                        _logger.LogError(contexto, "Error inesperado buscando puesto", ex.Message);
                        return StatusCode(500, Result<object>.Error());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado: {ex.Message}");
                return StatusCode(500, Result<object>.Error());
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PuestoResponse>> Update(int id, [FromBody] PuestoRequest request)
        {
            string contexto = $"{this.GetType().Name} - {nameof(PuestoController)}";
            _logger.LogInfo(contexto, $"Actualizando puesto con ID {id}.");

            try
            {
                var response = await _puestoService.UpdateAsync(id, request);
                _logger.LogInfo(contexto, $"Puesto con ID {id} actualizado correctamente.");
                return Ok(Result<PuestoResponse>.Ok(response, "Puesto actualizado correctamente."));
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                {
                    case ExceptionType.BadRequest:
                        _logger.LogError(contexto, ex.Message);
                        return NotFound(Result<object>.NotFound());
                    case ExceptionType.NotFound:
                        _logger.LogError(contexto, ex.Message);
                        return NotFound(Result<object>.NotFound());
                    default:
                        _logger.LogError(contexto, "Error inesperado buscando puesto", ex.Message);
                        return StatusCode(500, Result<object>.Error());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado: {ex.Message}");
                return StatusCode(500, Result<object>.Error());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            string contexto = $"{this.GetType().Name} - {nameof(PuestoController)}";
            _logger.LogInfo(contexto, $"Eliminando puesto con ID {id}.");

            try
            {
                await _puestoService.DeleteAsync(id);
                _logger.LogInfo(contexto, $"Puesto con ID {id} eliminado correctamente.");
                return Ok(Result<object>.Ok("Puesto eliminado correctamente."));
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                {
                    case ExceptionType.BadRequest:
                        _logger.LogError(contexto, ex.Message);
                        return NotFound(Result<object>.NotFound());
                    case ExceptionType.NotFound:
                        _logger.LogError(contexto, ex.Message);
                        return NotFound(Result<object>.NotFound());
                    default:
                        _logger.LogError(contexto, "Error inesperado buscando puesto", ex.Message);
                        return StatusCode(500, Result<object>.Error());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error inesperado: {ex.Message}");
                return StatusCode(500, Result<object>.Error());
            }
        }
    }
}
