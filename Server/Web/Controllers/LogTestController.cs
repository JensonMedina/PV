
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogTestController : ControllerBase
    {
        private readonly ILoggerApp _logger;

        public LogTestController(ILoggerApp logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInfo(this.GetType().Name,"Se llamó al endpoint GET");
            return Ok("Hola desde el log controller");
        }
    }
}
