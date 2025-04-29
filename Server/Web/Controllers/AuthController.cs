using Application.Common;
using Application.Common.Interfaces;
using Application.Interfaces;
using Application.Models.Request;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILoggerApp _logger;
        public AuthController(IAuthService authService, ILoggerApp logger)
        {
            _authService = authService;
            _logger = logger;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            string contexto = $"{this.GetType().Name} - {nameof(Register)}";
            _logger.LogInfo(contexto, $"Ejecutando endpoint Register. Intentando registrar el usuario: {request.Nombre} - {request.Email}");
            try
            {
                var response = await _authService.RegisterAsync(request);
                _logger.LogInfo(contexto, $"Usuario registrado correctamente. Usuario: {request.Nombre} - {request.Email}");
                return Ok(Result<object>.Ok(response));
            }
            catch (ExceptionApp ex)
            {
                _logger.LogError(this.GetType().Name, $"Error controlado en Register: {ex.Message}");
                switch (ex.Type)
                {
                    case ExceptionType.BadRequest:
                        // Extraer y pasar los detalles del error desde el mensaje de la excepción
                        var errorDetails = new List<string> { ex.Message };
                        return BadRequest(Result<object>.BadRequest(ex.Message, errorDetails));
                    case ExceptionType.NotFound:
                        return NotFound(Result<object>.NotFound(ex.Message));
                    default:
                        return StatusCode(500, Result<object>.Error(ex.Message));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Error no controlado en Register: {ex.Message}");
                return StatusCode(500, Result<object>.Error(ex.Message));
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            string contexto = $"{this.GetType().Name} - {nameof(Login)}";
            _logger.LogInfo(contexto, $"Ejecutando endpoint Login. Intentando autenticar el usuario: {request.Email}");
            try
            {
                var response = await _authService.LoginAsync(request);
                _logger.LogInfo(contexto, $"Login exitoso para el usuario: {request.Email}");
                return Ok(Result<object>.Ok(response));
            }
            catch (ExceptionApp ex)
            {
                _logger.LogError(this.GetType().Name, $"Error controlado en Login: {ex.Message}");
                switch (ex.Type)
                {
                    case ExceptionType.BadRequest:
                        // Extraer y pasar los detalles del error desde el mensaje de la excepción
                        var errorDetails = new List<string> { ex.Message };
                        return BadRequest(Result<object>.BadRequest(ex.Message, errorDetails));
                    case ExceptionType.NotFound:
                        return NotFound(Result<object>.NotFound(ex.Message));
                    default:
                        return StatusCode(500, Result<object>.Error(ex.Message));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Error no controlado en Login: {ex.Message}");
                return StatusCode(500, Result<object>.Error(ex.Message));
            }
        }
    }
}