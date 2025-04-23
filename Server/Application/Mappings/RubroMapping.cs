using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class RubroMapping
    {
        public static Rubro ToEntity(RubroRequest request) => new()
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Activo = request.Activo,
            FechaAlta = request.FechaAlta
        };

        public static RubroResponse ToResponse(Rubro entity) => new()
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Descripcion = entity.Descripcion,
            Activo = entity.Activo,
            FechaAlta = entity.FechaAlta
        };
    }
}
