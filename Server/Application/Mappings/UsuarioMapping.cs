using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class UsuarioMapping
    {
        public static Usuario ToEntity(UsuarioRequest request) => new()
        {
            Nombre = request.Nombre,
            Apellido = request.Apellido,
            AvatarUrl = request.AvatarUrl
        };

        public static UsuarioResponse ToResponse(Usuario entity) => new()
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Apellido = entity.Apellido,
            AvatarUrl = entity.AvatarUrl,
           // Puestos = entity.Puestos.Select(PuestoMapping.ToResponse).ToList()
        };
    }
}
