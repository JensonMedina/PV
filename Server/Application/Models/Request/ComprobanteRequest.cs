using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class ComprobanteRequest
    {
        [Required]
        public TipoComprobante TipoComprobante { get; set; }

        [Required]
        public DateTime FechaAlta { get; set; }

        [StringLength(250)]
        public string? MotivoAnulacion { get; set; }
    }
}
