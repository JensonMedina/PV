using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class UnidadMedidaRequest
    {
        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [Required, StringLength(10)]
        public string Abreviatura { get; set; }

        [Required]
        public TipoUnidadMedida TipoUnidadMedida { get; set; }

        public bool Activo { get; set; }
    }
}
