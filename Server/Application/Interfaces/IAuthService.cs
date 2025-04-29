using Application.Models.Request;
using Application.Models.Response;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> Register(RegisterRequest request);
        Task<AuthResponse> Login(LoginRequest request);
    }
}