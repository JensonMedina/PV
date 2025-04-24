namespace Application.Models.Response
{
    public class PuestoResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DireccionIP { get; set; }
        public string DireccionMAC { get; set; }
        public int NegocioId { get; set; }

        public string? TipoImpresora { get; set; } 

        public string? ImpresoraConfigurada { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaAlta { get; set; }
        public DateTime? UltimaConexion { get; set; }
    }
}
