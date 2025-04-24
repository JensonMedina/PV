using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class CategoriaRequest
    {
        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string? Descripcion { get; set; }

        [Url, StringLength(255)]
        public string? ImagenUrl { get; set; }
    }
}
