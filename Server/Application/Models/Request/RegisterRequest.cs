using Domain.Enum;

namespace Application.Models.Request
{
    public class RegisterRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public TipoUsuario TipoUsuario { get; set; }
    }
}
