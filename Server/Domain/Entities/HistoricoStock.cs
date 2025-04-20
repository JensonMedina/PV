namespace Domain.Entities
{
    public class HistoricoStock
    {
        public int Id { get; set; }

        public int ProductoNegocioId { get; set; }
        public ProductoNegocio ProductoNegocio { get; set; }

        public int Stock { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}

