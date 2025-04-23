using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class CategoriaRequest
    {
        [Required, StringLength(100)]
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }

        [StringLength(250)]
        public string? Descripcion { get; set; }

        public bool Activa { get; set; }

        [Url, StringLength(200)]
        public string? ImagenUrl { get; set; }
    }
}
