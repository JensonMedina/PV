using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class UsuarioRequest
    {
        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [Required, StringLength(100)]
        public string Apellido { get; set; }

        [Url]
        public string? AvatarUrl { get; set; }

        [Required, MinLength(1)]
        public List<int> PuestosIds { get; set; }
    }
}
