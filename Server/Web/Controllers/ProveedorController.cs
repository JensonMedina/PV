using Application.Common;
using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;
        private readonly ILoggerApp _logger;

        public ProveedorController(IProveedorService proveedorService, ILoggerApp logger)
        {
            _proveedorService = proveedorService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] ProveedorRequest proveedorRequest)
        {
            string contexto = $"{this.GetType().Name} - {nameof(Register)}";

            try
            {
                _logger.LogInfo(contexto, "Iniciando método.");
                await _proveedorService.Register(proveedorRequest);

                _logger.LogInfo(contexto, "Registro de proveedor finalizado exitosamente.", $"ProveedorNombre: {proveedorRequest.Nombre}");

                return Ok(Result<Object>.Ok());
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                {
                    case ExceptionType.NotFound:
                        _logger.LogError(contexto, ex.Message);
                        return NotFound(Result<object>.NotFound());
                    default:
                        _logger.LogError(contexto, "Error inesperado creando el proveedor.", ex.Message);
                        return StatusCode(500, Result<string>.Error("Ocurrió un error inesperado al registrar el proveedor.", ex.Message));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(Register), "Error al registrar proveedor.", ex.ToString());

                return StatusCode(500, Result<string>.Error("Ocurrió un error inesperado al registrar el proveedor.", ex.Message));
            }
        }
        [HttpGet("negocio/{negocioId}")]
        public async Task<ActionResult<Result<PagedResponse<ProveedorResponse>>>> GetByNegocio(
            int negocioId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] bool onlyActive = true)
        {
            string contexto = $"{this.GetType().Name} - {nameof(GetByNegocio)}";
            _logger.LogInfo(contexto, "Inicializando método.");
            try
            {
                var response = await _proveedorService.GetByNegocio(pageNumber, pageSize, onlyActive, negocioId);
                _logger.LogInfo(contexto, $"Se recuperaron {response.Data.Count} proveedores.");
                return Ok(Result<PagedResponse<ProveedorResponse>>.Ok(response));
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                {
                    case ExceptionType.NotFound:
                        _logger.LogError(contexto, "Proveedores no encontrados", ex.Message);
                        return NotFound(Result<PagedResponse<ProveedorResponse>>.NotFound(ex.Message));
                    case ExceptionType.BadRequest:
                        _logger.LogError(contexto, "Solicitud incorrecta", ex.Message);
                        return BadRequest(Result<PagedResponse<ProveedorResponse>>.BadRequest(ex.Message));
                    default:
                        _logger.LogError(contexto, "Error interno", ex.Message);
                        return StatusCode(500, Result<PagedResponse<ProveedorResponse>>.Error(ex.Message));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, "Error inesperado", ex.ToString());
                return StatusCode(500, Result<PagedResponse<ProveedorResponse>>.Error("Error interno del servidor"));
            }
        }

        [HttpGet("rubro/{rubroId}")]
        public async Task<ActionResult<Result<PagedResponse<ProveedorResponse>>>> GetByRubro(
            int rubroId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] bool onlyActive = true)
        {
            string contexto = $"{this.GetType().Name} - {nameof(GetByRubro)}";
            _logger.LogInfo(contexto, "Inicializando método.");
            try
            {
                var response = await _proveedorService.GetByRubro(pageNumber, pageSize, onlyActive, rubroId);
                _logger.LogInfo(contexto, $"Se recuperaron {response.Data.Count} proveedores.");
                return Ok(Result<PagedResponse<ProveedorResponse>>.Ok(response));
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                {
                    case ExceptionType.NotFound:
                        _logger.LogError(contexto, "Proveedores no encontrados", ex.Message);
                        return NotFound(Result<PagedResponse<ProveedorResponse>>.NotFound(ex.Message));
                    case ExceptionType.BadRequest:
                        _logger.LogError(contexto, "Solicitud incorrecta", ex.Message);
                        return BadRequest(Result<PagedResponse<ProveedorResponse>>.BadRequest(ex.Message));
                    default:
                        _logger.LogError(contexto, "Error interno", ex.Message);
                        return StatusCode(500, Result<PagedResponse<ProveedorResponse>>.Error(ex.Message));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, "Error inesperado", ex.ToString());
                return StatusCode(500, Result<PagedResponse<ProveedorResponse>>.Error("Error interno del servidor"));
            }
        }


        [HttpDelete("disable")]
        public async Task<IActionResult> Disable([FromQuery] int negocioId, [FromQuery] int proveedorId)
        {
            string contexto = $"{this.GetType().Name} - {nameof(Disable)}";
            _logger.LogInfo(contexto, $"Eliminando Proveedor con ID {proveedorId}.");

            try
            {
                await _proveedorService.Disable(negocioId, proveedorId);
                _logger.LogInfo(contexto, $"Proveedor con ID {proveedorId} eliminado correctamente.");
                return Ok(Result<object>.Ok("Proveedor eliminado correctamente."));
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
        [HttpPut("modify")]
        public async Task<ActionResult<PuestoResponse>> Modify([FromQuery] int proveedorId, [FromBody] ProveedorModifiedRequest request)
        {
            string contexto = $"{this.GetType().Name} - {nameof(Modify)}";
            _logger.LogInfo(contexto, $"Actualizando Proveedor con ID {proveedorId}.");

            try
            {
                await _proveedorService.Modify(proveedorId, request);
                _logger.LogInfo(contexto, $"Proveedor con ID {proveedorId} actualizado correctamente.");
                return Ok(Result<PuestoResponse>.Ok("Proveedor actualizado correctamente."));
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                {
                    case ExceptionType.BadRequest:
                        _logger.LogError(contexto, ex.Message);
                        return BadRequest(Result<object>.NotFound(ex.Message));
                    case ExceptionType.NotFound:
                        _logger.LogError(contexto, ex.Message);
                        return NotFound(Result<object>.NotFound(ex.Message));
                    default:
                        _logger.LogError(contexto, "Error inesperado buscando el proveedor", ex.Message);
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