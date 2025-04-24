using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class ProductoNegocioMapping
    {
        public static ProductoNegocio ToEntity(ProductoNegocioRequest request) => new()
        {
            NegocioId = request.NegocioId,
            ProductoId = request.ProductoId,
            PrecioVenta = request.PrecioVenta,
            PrecioCosto = request.PrecioCosto,
            GestionaStock = request.GestionaStock,
            StockActual = request.StockActual,
            StockMinimo = request.StockMinimo,
            StockMaximo = request.StockMaximo,
        };

        public static ProductoNegocioResponse ToResponse(ProductoNegocio entity) => new()
        {
            Id = entity.Id,
            NegocioId = entity.NegocioId,
            ProductoId = entity.ProductoId,
            PrecioVenta = entity.PrecioVenta,
            PrecioCosto = entity.PrecioCosto,
            GestionaStock = entity.GestionaStock,
            StockActual = entity.StockActual,
            StockMinimo = entity.StockMinimo,
            StockMaximo = entity.StockMaximo,
            FechaAlta = entity.FechaAlta
        };
    }
}
