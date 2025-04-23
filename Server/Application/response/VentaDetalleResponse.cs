namespace Application.Models.Response
{
    public class VentaDetalleResponse
    {
        public int ProductoId { get; set; }
        public int? Cantidad { get; set; }
        public double? Peso { get; set; }
        public double Importe { get; set; }
    }
}
