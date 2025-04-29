using Domain.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class PuestoRequest
    {
        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$")]
        [DefaultValue("000.0.0.00")]
        public string DireccionIP { get; set; }

        [RegularExpression(@"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$")]
        [DefaultValue("AA:0A:0a:AA:0a:Aa")]
        public string DireccionMAC { get; set; }

        [Range(0, 5, ErrorMessage = "El tipo de impresora debe estar entre 0 y 5.")]
        public TipoImpresora? TipoImpresora { get; set; }

        [DefaultValue(null)]
        public string? ImpresoraConfigurada { get; set; }

        [Required]
        public int NegocioId { get; set; }

    }
}
