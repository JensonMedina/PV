namespace Domain.Entities
{
    public class ProveedorNegocio
    {
        public int NegocioId { get; set; }
        public Negocio Negocio { get; set; }

        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        public DateTime FechaAgregado { get; set; } = DateTime.UtcNow;
    }
}
