using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class CompraDetalleMapping
    {
        public static CompraDetalle ToEntity(CompraDetalleRequest request) => new()
        {
            ProductoId = request.ProductoId,
            Cantidad = request.Cantidad,
            Peso = request.Peso,
            Importe = request.Importe
        };

        public static CompraDetalleResponse ToResponse(CompraDetalle entity) => new()
        {
            ProductoId = entity.ProductoId,
            Cantidad = entity.Cantidad,
            Peso = entity.Peso,
            Importe = entity.Importe
        };
    }
}
