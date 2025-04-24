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
            Descripcion = request.Descripcion,
            ImagenUrl = request.ImagenUrl
        };

        public static CategoriaResponse ToResponse(Categoria entity) => new()
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Descripcion = entity.Descripcion,
            ImagenUrl = entity.ImagenUrl
        };
    }
}
