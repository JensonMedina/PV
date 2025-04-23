namespace Application.Mappings
{
    public static class HistoricoPrecioMapping
    {
        public static Domain.Entities.HistoricoPrecio ToEntity(Application.Models.Request.HistoricoPrecioRequest request) => new()
        {
            //revisar
            Precio = request.Precio,
            ProductoNegocioId = request.ProductoNegocioId,
            Fecha = request.Fecha,
        };
        public static Application.Models.Response.HistoricoPrecioResponse ToResponse(Domain.Entities.HistoricoPrecio entity) => new()
        {
            //revisar
            Id = entity.Id,
            PrecioAnterior= entity.Precio,
            ProductoNegocioId = entity.ProductoNegocioId,
            FechaCambio = entity.Fecha,

        };

      

    }
}
