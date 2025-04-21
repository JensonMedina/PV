using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class VentaDto
    {
        public int NegocioId { get; set; }
        public int PuestoId { get; set; }
        public int EmpleadoId { get; set; }
        public int? ClienteId { get; set; }
        public DateTime FechaAlta { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? DescuentoTotal { get; set; }
        public decimal? Impuestos { get; set; }
        public decimal Total { get; set; }
        public FormaPago FormaPago { get; set; }
        public List<VentaDetalleDto> Detalles { get; set; }

    }
}
