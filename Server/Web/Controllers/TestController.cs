using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/test2")]
    public class TestController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        public TestController(UserManager<Usuario> userManager) {
            _userManager = userManager;
        }

        [HttpGet("publico")]
        public IActionResult Publico()
        {
            return Ok("Cualquiera puede ver esto.");
        }
        [Authorize] //ESTOS ENDPOINTS DE ABAJO NO FUNCIONAN  TODOS 404
        [HttpGet("autenticado")]
        public IActionResult Autenticado()
        {
            Console.WriteLine("Endpoint autenticado alcanzado.");
            return Ok("Estás autenticado.");
        }

        [Authorize(Policy = "AdministradorPolicy")]
        [HttpGet("admin")]
        public IActionResult SoloAdmins()
        {
            return Ok("Sos admin, podés ver esto.");
        }

        [Authorize(Policy = "EmpleadoPolicy")]
        [HttpGet("empleado")]
        public IActionResult SoloEmpleados()
        {
            return Ok("Sos empleado, podés ver esto.");
        }
        // Endpoint para obtener el tipo de usuario (enum) del usuario autenticado
        [HttpGet("get-user-type")]
        [Authorize]  // Este endpoint requiere que el usuario esté autenticado
        public async Task<IActionResult> GetUserType()
        {
            var user = await _userManager.GetUserAsync(User);  // Obtener el usuario actual
            if (user == null)
            {
                return Unauthorized("Usuario no autenticado.");
            }

            // Acceder al tipo de usuario (enum) desde la propiedad Tipo
            var userType = user.Tipo;  // 'Tipo' es el enum que representa el rol o tipo de usuario

            // Devolver el tipo de usuario
            return Ok(new { userType = userType.ToString() });
        }
        [HttpGet("debug-auth")]
        public IActionResult DebugAuth()
        {
            var isAuthenticated = User?.Identity?.IsAuthenticated ?? false;
            var claims = User?.Claims?.Select(c => new { c.Type, c.Value }).ToList();
            var headers = Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());

            return Ok(new
            {
                isAuthenticated,
                claims,
                headers,
                method = Request.Method,
                path = Request.Path.Value,
                scheme = Request.Scheme
            });
        }
    }
}
