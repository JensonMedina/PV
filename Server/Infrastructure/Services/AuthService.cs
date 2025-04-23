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

namespace Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(UserManager<Usuario> userManager, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
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
                return new AuthResponse
                {
                    IsSuccessful = false,
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }

            return await GenerateAuthResponseAsync(user);
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            try
            {
                // Validar que email y contraseña no sean nulos
                if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                {
                    return new AuthResponse
                    {
                        IsSuccessful = false,
                        Errors = new List<string> { "El correo y la contraseña son requeridos" }
                    };
                }

                // Buscar el usuario por email
                var usuario = await _userManager.FindByEmailAsync(request.Email);
                if (usuario == null)
                {
                    return new AuthResponse
                    {
                        IsSuccessful = false,
                        Errors = new List<string> { "Correo o contraseña incorrectos" }
                    };
                }

                // Verificar la contraseña
                var isPasswordValid = await _userManager.CheckPasswordAsync(usuario, request.Password);
                if (!isPasswordValid)
                {
                    return new AuthResponse
                    {
                        IsSuccessful = false,
                        Errors = new List<string> { "Correo o contraseña incorrectos" }
                    };
                }

                // Actualizar último login
                usuario.UltimoLogin = DateTime.UtcNow;
                usuario.IpUltimoLogin = _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                await _userManager.UpdateAsync(usuario);

                // Generar el token y respuesta
                return await GenerateAuthResponseAsync(usuario);
            }
            catch (Exception ex)
            {
                // Loguear la excepción
                return new AuthResponse
                {
                    IsSuccessful = false,
                    Errors = new List<string> { $"Error interno: {ex.Message}" }
                };
            }
        }

        private async Task<AuthResponse> GenerateAuthResponseAsync(Usuario user)
        {
            // Verificar que el usuario no sea nulo
            if (user == null)
                return new AuthResponse { IsSuccessful = false, Errors = new List<string> { "Usuario no encontrado" } };

            try
            {
                // Crear los claims
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
            new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
            new Claim("nombre_completo", $"{user.Nombre} {user.Apellido}".Trim()),
            new Claim("tipo_usuario", user.Tipo.ToString())
        };

                // Verificar que la clave secreta no sea nula
                var secretKey = _config["AuthenticationService:Key"];
                if (string.IsNullOrEmpty(secretKey))
                    throw new InvalidOperationException("La clave secreta para JWT no está configurada");

                // Crear el token
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var issuer = _config["AuthenticationService:Issuer"] ?? "DefaultIssuer";
                var audience = _config["AuthenticationService:Audience"] ?? "DefaultAudience";

                // Definir tiempo de expiración del token (7 días)
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

                return new AuthResponse
                {
                    IsSuccessful = true,
                    Token = token,
                    Expiration = expirationTime,
                    Errors = null
                };
            }
            catch (Exception ex)
            {
                return new AuthResponse
                {
                    IsSuccessful = false,
                    Token = null,
                    Expiration = null,
                    Errors = new List<string> { $"Error al generar el token: {ex.Message}" }
                };
            }
        }
    }
}