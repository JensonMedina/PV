using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class ComprobanteMapping
    {
        public static Comprobante ToEntity(ComprobanteRequest request) => new()
        {
            TipoComprobante = request.TipoComprobante,
            FechaAlta = request.FechaAlta,
            MotivoAnulacion = request.MotivoAnulacion
        };

        public static ComprobanteResponse ToResponse(Comprobante entity) => new()
        {
            Id = entity.Id,
            TipoComprobante = entity.TipoComprobante,
            FechaAlta = entity.FechaAlta,
            MotivoAnulacion = entity.MotivoAnulacion
        };
    }

}
