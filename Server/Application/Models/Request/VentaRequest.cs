using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class VentaRequest
    {
        [Required, Range(1, int.MaxValue)]
        public int NegocioId { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int PuestoId { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int EmpleadoId { get; set; }

        [Range(1, int.MaxValue)]
        public int? ClienteId { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Subtotal { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? DescuentoTotal { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Impuestos { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal Total { get; set; }

        [Required]
        public FormaPago FormaPago { get; set; }

        [Required, MinLength(1)]
        public List<VentaDetalleRequest> Detalles { get; set; } = new List<VentaDetalleRequest>();
    }
}
