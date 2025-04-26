using Application.Common;
using Application.Interfaces;
using Application.Models.Request;
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
        public async Task<IActionResult> RegisterAsync([FromBody]NegocioRequest newNegocio)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando endpoint Register. Intentando registrar el negocio {newNegocio.Nombre}");
            try
            {
                await _negocioService.Register(newNegocio);
                _logger.LogInfo(this.GetType().Name, $"Ejecutando endpoint Register. Se registró con éxito el negocio {newNegocio.Nombre}");
                return Ok(Result<object>.Ok());
            }
            catch (Exception)
            {
                //vamos a capturar las excepciones que se vengan traslandando ya sea desde el repositorio o el servicio.
                throw;
            }
        }
    }
}
