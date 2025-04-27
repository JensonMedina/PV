using Application.Common;
using Application.Interfaces;
using Application.Models.Request;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class NegocioController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerApp _logger;
        public NegocioController(IServiceManager serviceManager, ILoggerApp logger)
        {
            _logger = logger;
            _serviceManager = serviceManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] NegocioRequest newNegocio)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando endpoint Register. Intentando registrar el negocio {newNegocio.Nombre}");
            try
            {
                await _serviceManager.NegocioService.Register(newNegocio);
                _logger.LogInfo(this.GetType().Name, $"Ejecutando endpoint Register. Se registró con éxito el negocio {newNegocio.Nombre}");
                return Ok(Result<object>.Ok());
            }
            catch (ExceptionApp ex)
            {
                _logger.LogError(this.GetType().Name, $"Error controlado en Register: {ex.Message}");
                switch (ex.Type)
                {
                    case ExceptionType.NotFound:
                        return NotFound(Result<object>.NotFound(ex.Message));
                    default:
                        return StatusCode(500, Result<object>.Error("Se produjo un error inesperado al procesar la solicitud."));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Error no controlado en Register: {ex.Message}");
                return StatusCode(500, Result<object>.Error("Error interno del servidor. Por favor intente más tarde."));
            }
        }
        [HttpPut]
        public async Task<IActionResult> Modify([FromBody] NegocioModifiedRequest request)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando endpoint Modify. Intentando modificar el negocio con Id: {request.Id}");
            try
            {
                await _serviceManager.NegocioService.Modify(request);
                _logger.LogInfo(this.GetType().Name, $"Ejecutando endpoint Modify. Se modificó con éxito el negocio con Id: {request.Id}");
                return Ok(Result<object>.Ok($"Se modificó con éxito el negocio con Id: {request.Id}"));
            }
            catch (ExceptionApp ex)
            {
                _logger.LogError(this.GetType().Name, $"Error controlado en Modify: {ex.Message}");
                switch (ex.Type)
                {
                    case ExceptionType.NotFound:
                        return NotFound(Result<object>.NotFound(ex.Message));
                    default:
                        return StatusCode(500, Result<object>.Error("Se produjo un error inesperado al procesar la solicitud."));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Error no controlado en Modify: {ex.Message}");
                return StatusCode(500, Result<object>.Error("Error interno del servidor. Por favor intente más tarde."));
            }
        }
    }
}
