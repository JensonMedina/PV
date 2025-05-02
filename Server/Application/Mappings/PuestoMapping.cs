using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class PuestoMapping
    {
        public static Puesto ToEntity(PuestoRequest request)
        {

            return new Puesto
            {
                DireccionIP = request.DireccionIP,
                DireccionMAC = request.DireccionMAC,
                Nombre = request.Nombre,
                ImpresoraConfigurada = request.ImpresoraConfigurada,
                TipoImpresora = request.TipoImpresora,
                NegocioId = request.NegocioId
            };
        }

        public static PuestoResponse ToResponse(Puesto entity) => new()
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Activo = entity.Activo,
            DireccionIP = entity.DireccionIP,
            DireccionMAC = entity.DireccionMAC,
            TipoImpresora = entity.TipoImpresora.ToString(),
            ImpresoraConfigurada = entity.ImpresoraConfigurada,
            NegocioId = entity.NegocioId,
        };

        public static Puesto UpdatePuesto(Puesto entity, PuestoModifyRequest request)
        {
            entity.Nombre = request.Nombre ?? entity.Nombre;
            entity.DireccionIP = request.DireccionIP ?? entity.DireccionIP;
            entity.DireccionMAC = request.DireccionMAC ?? entity.DireccionMAC;
            entity.TipoImpresora = request.TipoImpresora ?? entity.TipoImpresora;
            entity.ImpresoraConfigurada = request.ImpresoraConfigurada ?? entity.ImpresoraConfigurada;
            return entity;
        }

    }
}
