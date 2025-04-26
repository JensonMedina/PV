using Microsoft.AspNetCore.Mvc;
using Application.Interfaces; // Acá estaría IProveedorService
using Domain.Entities;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;
        private readonly ILoggerApp _loggerApp;

        public ProveedorController(IProveedorService proveedorService, ILoggerApp loggerApp)
        {
            _proveedorService = proveedorService;
            _loggerApp = loggerApp;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarProveedor([FromBody] Proveedor proveedor)
        {
            // desde proveedor service
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarProveedorPorId(int id)
        {
            // desde proveedor service
            return Ok();
        }

        [HttpGet("negocio/{negocio}")]
        public async Task<IActionResult> ConsultarProveedorPorNegocio(string negocio)
        {
            // desde proveedor service
            return Ok();
        }

        [HttpGet("rubro/{rubro}")]
        public async Task<IActionResult> ConsultarProveedorPorRubro(string rubro)
        {
            // desde proveedor service
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProveedor(int id)
        {
            // desde proveedor service
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarProveedor(int id, [FromBody] Proveedor proveedor)
        {
            // desde proveedor service
            return Ok();
        }
    }
}
