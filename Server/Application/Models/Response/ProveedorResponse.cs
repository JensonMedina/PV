using Domain.Enum;

namespace Application.Models.Response
{
    public class ProveedorResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? RazonSocial { get; set; }
        public TipoDocumento? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public RubroResponse Rubro { get; set; }
        public decimal? LimiteCredito { get; set; }
        public int? DiasPlazoPago { get; set; }
        public string? Observaciones { get; set; }
        public bool Activo { get; set; }
    }
}
