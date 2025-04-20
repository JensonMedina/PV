namespace Domain.Entities
{
    public class HistoricoPrecio
    {
        public int Id { get; set; }
        public int ProductoNegocioId { get; set; }
        public ProductoNegocio ProductoNegocio { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
