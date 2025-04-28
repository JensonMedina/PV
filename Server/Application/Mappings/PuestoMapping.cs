using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class PuestoMapping
    {
        public static Puesto ToEntity(PuestoRequest request) => new()
        {
            DireccionMAC= request.DireccionMAC,
            DireccionIP= request.DireccionIP,
            Nombre = request.Nombre,
            TipoImpresora= request.TipoImpresora,
            ImpresoraConfigurada=request.ImpresoraConfigurada,
            NegocioId= request.NegocioId,

        };

        public static PuestoResponse ToResponse(Puesto entity) => new()
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Activo = entity.Activo,
            DireccionIP= entity.DireccionIP,
            DireccionMAC= entity.DireccionMAC,
            ImpresoraConfigurada = entity.ImpresoraConfigurada,
            NegocioId = entity.NegocioId,
        };
    }
}
