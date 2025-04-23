using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class PuestoRequest
    {
        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [Required, RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$")] 
        public string DireccionIP { get; set; }

        [Required, RegularExpression(@"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$")] 
        public string DireccionMAC { get; set; }

        public Domain.Enum.TipoImpresora? TipoImpresora { get; set; }

        public string? ImpresoraConfigurada { get; set; }

        public bool Activo { get; set; }

    }
}
