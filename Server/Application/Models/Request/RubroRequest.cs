using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class RubroRequest
    {
        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(250)]
        public string? Descripcion { get; set; }

        public bool Activo { get; set; }

        [Required]
        public DateTime FechaAlta { get; set; }
    }
}
