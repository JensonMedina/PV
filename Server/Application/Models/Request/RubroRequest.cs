using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class RubroRequest
    {
        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(200)]
        public string? Descripcion { get; set; }


    }
}
