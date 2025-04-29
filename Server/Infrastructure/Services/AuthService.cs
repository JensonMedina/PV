using Application.Common;
using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Application.Common.Interfaces;

namespace Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILoggerApp _logger;

        public AuthService(
            UserManager<Usuario> userManager,
            IConfiguration config,
            IHttpContextAccessor httpContextAccessor,
            ILoggerApp logger)
        {
            _userManager = userManager;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            string contexto = $"{this.GetType().Name} - {nameof(RegisterAsync)}";

            var user = new Usuario
            {
                UserName = request.Email,
                Email = request.Email,
                Tipo = request.TipoUsuario,
                Nombre = request.Nombre,
                Apellido = request.Apellido,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();

                // Aquí combinamos todos los mensajes de error en uno solo para enviar al cliente
                string errorMessage = string.Join(". ", errors);

                // Logueamos el error completo
                _logger.LogError(contexto, "Error al registrar usuario", errorMessage);

                // Lanzamos la excepción con el mensaje detallado
                throw ExceptionApp.BadRequest(errorMessage);
            }

            _logger.LogInfo(contexto, "Usuario registrado exitosamente", user.Email);

            try
            {
                return await GenerateAuthResponseAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, "Error al generar token de autenticación", ex.ToString());
                throw new Exception("Error al generar token de autenticación");
            }
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            string contexto = $"{this.GetType().Name} - {nameof(LoginAsync)}";

            try
            {
                if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                {
                    _logger.LogError(contexto, "Intento de login fallido: Email o contraseña nulos",
                        $"Email: {request.Email}, Password: {MaskPassword(request.Password)}");
                    throw ExceptionApp.BadRequest("El correo y la contraseña son requeridos");
                }

                var usuario = await _userManager.FindByEmailAsync(request.Email);
                if (usuario == null)
                {
                    _logger.LogError(contexto, "Intento de login fallido: Usuario no encontrado",
                        $"Email: {request.Email}, Password: {MaskPassword(request.Password)}");
                    throw ExceptionApp.BadRequest("Correo o contraseña incorrectos");
                }

                var isPasswordValid = await _userManager.CheckPasswordAsync(usuario, request.Password);
                if (!isPasswordValid)
                {
                    _logger.LogError(contexto, "Intento de login fallido: Contraseña incorrecta",
                        $"Usuario: {request.Email}, Password: {MaskPassword(request.Password)}");
                    throw ExceptionApp.BadRequest("Correo o contraseña incorrectos");
                }

                usuario.UltimoLogin = DateTime.UtcNow;
                usuario.IpUltimoLogin = _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                await _userManager.UpdateAsync(usuario);

                _logger.LogInfo(contexto, "Login exitoso para usuario",
                    $"Email: {request.Email}, Password: {MaskPassword(request.Password)}");

                return await GenerateAuthResponseAsync(usuario);
            }
            catch (ExceptionApp)
            {
                // Re-lanzar excepciones específicas para que sean capturadas en el controller
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error al intentar iniciar sesión: {ex.Message}",
                    $"Usuario: {request.Email}, Password: {MaskPassword(request.Password)}");
                throw new Exception("Error interno al intentar iniciar sesión");
            }
        }

        private async Task<AuthResponse> GenerateAuthResponseAsync(Usuario user)
        {
            string contexto = $"{this.GetType().Name} - {nameof(GenerateAuthResponseAsync)}";

            if (user == null)
            {
                _logger.LogError(contexto, "Usuario nulo al generar token", null);
                throw ExceptionApp.BadRequest("Usuario no encontrado");
            }

            try
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
                    new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                    new Claim("nombre_completo", $"{user.Nombre} {user.Apellido}".Trim()),
                    new Claim("tipo_usuario", user.Tipo.ToString())
                };

                var secretKey = _config["AuthenticationService:Key"];
                if (string.IsNullOrEmpty(secretKey))
                    throw new InvalidOperationException("La clave secreta para JWT no está configurada");

                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var issuer = _config["AuthenticationService:Issuer"] ?? "DefaultIssuer";
                var audience = _config["AuthenticationService:Audience"] ?? "DefaultAudience";
                var expirationTime = DateTime.UtcNow.AddDays(7);

                var tokenDescriptor = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: expirationTime,
                    signingCredentials: creds
                );

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.WriteToken(tokenDescriptor);

                _logger.LogInfo(contexto, "Token generado correctamente", user.Email);

                return new AuthResponse
                {
                    Token = token,
                    Expiration = expirationTime
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(contexto, $"Error al generar token: {ex.Message}", ex.ToString());
                throw new Exception($"Error al generar el token: {ex.Message}");
            }
        }

        private string MaskPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "****";  // Valor genérico seguro.

            int totalLength = password.Length;

            // Si es muy corta, ocultar todo.
            if (totalLength <= 4)
                return new string('*', totalLength);

            // Para contraseñas de 5-8 caracteres, mostrar solo 1 carácter inicial.
            if (totalLength <= 8)
                return $"{password[0]}{new string('*', totalLength - 1)}";

            // Para contraseñas largas, mostrar 2 al inicio y 2 al final como máximo.
            int visibleStart = 2;
            int visibleEnd = 2;
            int maskedLength = totalLength - (visibleStart + visibleEnd);

            string start = password.Substring(0, visibleStart);
            string end = password.Substring(totalLength - visibleEnd);

            return $"{start}{new string('*', maskedLength)}{end}";
        }


    }
}