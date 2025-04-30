using Domain.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class PuestoRequest
    {
        [Required(ErrorMessage = "El nombre del puesto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Nombre { get; set; }

        [RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$",
            ErrorMessage = "La dirección IP debe tener un formato válido (por ejemplo, 192.168.1.1).")]
        public string? DireccionIP { get; set; }

        [RegularExpression(@"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$",
            ErrorMessage = "La dirección MAC debe tener un formato válido (por ejemplo, AA:BB:CC:DD:EE:FF).")]
        public string? DireccionMAC { get; set; }

        [Range(0, 5, ErrorMessage = "El tipo de impresora debe estar entre 0 y 5.")]
        public TipoImpresora? TipoImpresora { get; set; }
        public string? ImpresoraConfigurada { get; set; }

        [Required(ErrorMessage = "El ID del negocio es obligatorio.")]
        public int NegocioId { get; set; }
    }
}
