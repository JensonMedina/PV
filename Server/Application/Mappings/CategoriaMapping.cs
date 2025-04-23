using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class CategoriaMapping
    {
        public static Categoria ToEntity(CategoriaRequest request) => new()
        {
            Nombre = request.Nombre,
            FechaAlta = request.FechaAlta,
            Descripcion = request.Descripcion,
            Activa = request.Activa,
            ImagenUrl = request.ImagenUrl
        };

        public static CategoriaResponse ToResponse(Categoria entity) => new()
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Descripcion = entity.Descripcion,
            Activa = entity.Activa,
            ImagenUrl = entity.ImagenUrl,
            FechaAlta = entity.FechaAlta
        };
    }
}
