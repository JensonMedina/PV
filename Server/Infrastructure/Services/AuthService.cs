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

        public async Task<Result<AuthResponse>> RegisterAsync(RegisterRequest request)
        {
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
                _logger.LogError(nameof(RegisterAsync), "Error al registrar usuario", string.Join(", ", errors));
                return Result<AuthResponse>.BadRequest("Error al registrar usuario", errors);
            }

            _logger.LogInfo(nameof(RegisterAsync), "Usuario registrado exitosamente Email:", user.Email);
            var authResponse = await GenerateAuthResponseAsync(user);
            if (!authResponse.IsSuccessful)
            {
                return Result<AuthResponse>.Error("Error al generar token de autenticación", authResponse.Errors);
            }

            return Result<AuthResponse>.Ok(authResponse);
        }

        public async Task<Result<AuthResponse>> LoginAsync(LoginRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                {
                    _logger.LogError(nameof(LoginAsync), $"Intento de login fallido: Email o contraseña nulos. Email: {request.Email}, Password: {MaskPassword(request.Password)}");
                    return Result<AuthResponse>.BadRequest("El correo y la contraseña son requeridos");
                }

                var usuario = await _userManager.FindByEmailAsync(request.Email);
                if (usuario == null)
                {
                    _logger.LogError(nameof(LoginAsync), $"Intento de login fallido: Usuario no encontrado. Email: {request.Email}, Password: {MaskPassword(request.Password)}");
                    return Result<AuthResponse>.BadRequest("Correo o contraseña incorrectos");
                }

                var isPasswordValid = await _userManager.CheckPasswordAsync(usuario, request.Password);
                if (!isPasswordValid)
                {
                    _logger.LogError(nameof(LoginAsync), $"Intento de login fallido: Contraseña incorrecta. Usuario: {request.Email}, Password: {MaskPassword(request.Password)}");
                    return Result<AuthResponse>.BadRequest("Correo o contraseña incorrectos");
                }

                usuario.UltimoLogin = DateTime.UtcNow;
                usuario.IpUltimoLogin = _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                await _userManager.UpdateAsync(usuario);

                _logger.LogInfo(nameof(LoginAsync), $"Login exitoso para usuario: {request.Email}, Password: {MaskPassword(request.Password)}");
                var authResponse = await GenerateAuthResponseAsync(usuario);
                if (!authResponse.IsSuccessful)
                {
                    return Result<AuthResponse>.Error("Error al generar token de autenticación", authResponse.Errors);
                }

                return Result<AuthResponse>.Ok(authResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(LoginAsync), $"Error al intentar iniciar sesión: {ex.Message}. Usuario: {request.Email}, Password: {MaskPassword(request.Password)}", ex.ToString());
                return Result<AuthResponse>.Error("Error interno al intentar iniciar sesión", new List<string> { ex.Message });
            }
        }

        private async Task<AuthResponse> GenerateAuthResponseAsync(Usuario user)
        {
            if (user == null)
            {
                _logger.LogError(nameof(GenerateAuthResponseAsync), "Usuario nulo al generar token");
                return new AuthResponse { IsSuccessful = false, Errors = new List<string> { "Usuario no encontrado" } };
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

                _logger.LogInfo(nameof(GenerateAuthResponseAsync), "Token generado correctamente", user.Email);

                return new AuthResponse
                {
                    IsSuccessful = true,
                    Token = token,
                    Expiration = expirationTime
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(GenerateAuthResponseAsync), $"Error al generar token: {ex.Message}", ex.ToString());
                return new AuthResponse
                {
                    IsSuccessful = false,
                    Errors = new List<string> { $"Error al generar el token: {ex.Message}" }
                };
            }
        }

        private string MaskPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "pass***ord";  // Para el caso de contraseñas vacías o nulas.

            int visibleChars = 3; // Definimos cuántos caracteres serán visibles al inicio y al final.
            if (password.Length <= visibleChars * 2)
            {
                return password; // Si la contraseña es demasiado corta, mostramos toda.
            }

            var start = password.Substring(0, visibleChars);
            var end = password.Substring(password.Length - visibleChars);
            var masked = new string('*', password.Length - (visibleChars * 2)); // Generar los asteriscos en el medio.

            return $"{start}{masked}{end}"; // Concatenar los primeros 3, los asteriscos, y los últimos 3 caracteres.
        }
    }
}
