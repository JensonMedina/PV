using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Required]
        public DateTime FechaAlta { get; set; }

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
        public List<VentaDetalleRequest> Detalles { get; set; }
    }
}
