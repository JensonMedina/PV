namespace Domain.Entities
{
    public class VentaDetalle
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int? Cantidad { get; set; }
        public double? Peso { get; set; }
        public double Importe { get; set; }
    }

}