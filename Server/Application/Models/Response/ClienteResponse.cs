namespace Application.Models.Response
{
    public class ClienteResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? TipoDocumento { get; set; } 
        public string? NumeroDocumento { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; } 
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }
        public string? CodigoPostal { get; set; }
        public bool EsConsumidorFinal { get; set; }
        public decimal? LimiteCredito { get; set; }
        public decimal? SaldoActual { get; set; }
        public string? Observaciones { get; set; }
        public int? PuntosFidelidad { get; set; }
        public DateTime? UltimaCompra { get; set; }
        public bool Activo { get; set; }
    }
}
