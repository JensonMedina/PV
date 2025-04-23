using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class UnidadMedidaMapping
    {
        public static UnidadMedida ToEntity(UnidadMedidaRequest request) => new()
        {
            Nombre = request.Nombre,
            Abreviatura = request.Abreviatura,
            TipoUnidadMedida = request.TipoUnidadMedida,
            Activo = request.Activo
        };

        public static UnidadMedidaResponse ToResponse(UnidadMedida entity) => new()
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Abreviatura = entity.Abreviatura,
            TipoUnidadMedida = entity.TipoUnidadMedida,
            Activo = entity.Activo
        };
    }
}
