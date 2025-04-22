using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class CompraRequest
    {
        [Required]
        public DateTime FechaAlta { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal Subtotal { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Descuento { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal Total { get; set; }

        [Required]
        public FormaPago FormaPago { get; set; }

        [Range(0, int.MaxValue)]
        public int? DiasPlazoPago { get; set; }

        public DateTime? FechaVencimientoPago { get; set; }

        public bool Pagado { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int NegocioId { get; set; }

        [Range(1, int.MaxValue)]
        public int? ProveedorId { get; set; }

        [Range(1, int.MaxValue)]
        public int? UsuarioId { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int ComprobanteId { get; set; }

        [Range(1, int.MaxValue)]
        public int? ComprobanteAnulacionId { get; set; }

        [StringLength(500)]
        public string? Observaciones { get; set; }

        [Required, MinLength(1)]
        public List<CompraDetalleRequest> Detalles { get; set; }
    }
}
