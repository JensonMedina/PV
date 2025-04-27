using Application.Common;
using Application.Interfaces;
using Application.Models.Request;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegocioController : ControllerBase
    {
        private readonly INegocioService _negocioService;
        private readonly ILoggerApp _logger;
        public NegocioController(INegocioService negocioService, ILoggerApp logger)
        {
            _logger = logger;
            _negocioService = negocioService;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] NegocioRequest newNegocio)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando endpoint Register. Intentando registrar el negocio {newNegocio.Nombre}");
            try
            {
                await _negocioService.Register(newNegocio);
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
    }
}
