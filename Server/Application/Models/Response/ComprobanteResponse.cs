using Domain.Enum;

namespace Application.Models.Response
{
    public class ComprobanteResponse
    {
        public int Id { get; set; }
        public TipoComprobante TipoComprobante { get; set; }
        public DateTime FechaAlta { get; set; }
        public string? MotivoAnulacion { get; set; }
    }
}
