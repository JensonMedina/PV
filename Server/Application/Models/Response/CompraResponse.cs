using Domain.Enum;

namespace Application.Models.Response
{
    public class CompraResponse
    {
        public int Id { get; set; }
        public DateTime FechaAlta { get; set; }
        public decimal Subtotal { get; set; }
        public decimal? Descuento { get; set; }
        public decimal Total { get; set; }
        public FormaPago FormaPago { get; set; }
        public int? DiasPlazoPago { get; set; }
        public DateTime? FechaVencimientoPago { get; set; }
        public bool Pagado { get; set; }
        public int NegocioId { get; set; }
        public int? ProveedorId { get; set; }
        public int? UsuarioId { get; set; }
        public int ComprobanteId { get; set; }
        public int? ComprobanteAnulacionId { get; set; }
        public string? Observaciones { get; set; }
        public List<CompraDetalleResponse> Detalles { get; set; }
    }
}
