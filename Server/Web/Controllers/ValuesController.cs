using Application.Common;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILoggerApp _logger;
        public ValuesController(ILoggerApp logger)
        {
            _logger = logger;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInfo(this.GetType().Name, "Ejecutando método GET");
            List<string> values = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                values.Add(i.ToString());
            }
            return Ok(Result<List<string>>.Ok(values, "Valores obtenidos exitosamente"));
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logger.LogInfo(this.GetType().Name, "Ejecutando método GETById");
            try
            {
                if (id == 1)
                {
                    throw new Exception();
                }
                if (id == 2)
                {
                    _logger.LogError(this.GetType().Name, $"No se encontró el usuario con ID: {id}");
                    return NotFound(Result<object>.NotFound($"No se encontró el usuario con ID: {id}"));
                }
                return Ok(Result<object>.Ok());
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error inesperado en el método GETByID: {ex.Message}");
                return StatusCode(500, Result<object>.Error(ex.Message));
            }
        }
    }
}
