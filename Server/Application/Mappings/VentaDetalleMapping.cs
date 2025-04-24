using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class VentaDetalleMapping
    {
        public static VentaDetalle ToEntity(VentaDetalleRequest request) => new()
        {
            ProductoId = request.ProductoId,
            Cantidad = request.Cantidad,
            Peso = request.Peso,
            Importe = request.Importe
        };

        public static VentaDetalleResponse ToResponse(VentaDetalle entity) => new()
        {
            ProductoId = entity.ProductoId,
            Cantidad = entity.Cantidad,
            Peso = entity.Peso,
            Importe = entity.Importe
        };
    }

}
