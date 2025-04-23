using Domain.Enum;

namespace Application.Models.Response
{
    public class VentaResponse
    {
        public int Id { get; set; }
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
        public List<VentaDetalleResponse> Detalles { get; set; }
    }
}
