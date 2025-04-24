namespace Application.Models.Response
{
    public class ProveedorResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? RazonSocial { get; set; }

        public string? TipoDocumento { get; set; } 

        public string? NumeroDocumento { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }

        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }
        public string? Web { get; set; }

        public decimal? LimiteCredito { get; set; }
        public int? DiasPlazoPago { get; set; }
        public string? Observaciones { get; set; }
        public bool Activo { get; set; }
    }
}
