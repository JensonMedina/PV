using Application.Common;
using Application.Interfaces;
using Application.Models.Request;
using Domain.Entities;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> RegistrarProveedor([FromBody] ProveedorRequest proveedorRequest)
        {
            string contexto = $"{this.GetType().Name} - {nameof(RegistrarProveedor)}";

            try
            {
                _loggerApp.LogInfo(contexto, "Iniciando método.");
                await _proveedorService.RegistrarProveedorAsync(proveedorRequest);

                _loggerApp.LogInfo(contexto, "Registro de proveedor finalizado exitosamente.", $"ProveedorNombre: {proveedorRequest.Nombre}");

                return Ok(Result<Object>.Ok());
            }
            catch (ExceptionApp ex)
            {
                switch (ex.Type)
                {
                    case ExceptionType.NotFound:
                        _loggerApp.LogError(contexto, ex.Message);
                        return NotFound(Result<object>.NotFound());
                    default:
                        _loggerApp.LogError(contexto, "Error inesperado creando el proveedor.", ex.Message);
                        return StatusCode(500, Result<string>.Error("Ocurrió un error inesperado al registrar el proveedor.", ex.Message));
                }
            }
            catch (Exception ex)
            {
                _loggerApp.LogError(nameof(RegistrarProveedor), "Error al registrar proveedor.", ex.ToString());

                return StatusCode(500, Result<string>.Error("Ocurrió un error inesperado al registrar el proveedor.", ex.Message));
            }
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
