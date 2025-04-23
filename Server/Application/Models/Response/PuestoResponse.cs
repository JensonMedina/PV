using Domain.Enum;

namespace Application.Models.Response
{
    public class PuestoResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DireccionIP { get; set; }
        public string DireccionMAC { get; set; }
        public TipoImpresora? TipoImpresora { get; set; }
        public string? ImpresoraConfigurada { get; set; }
        public bool Activo { get; set; }
    }
}
