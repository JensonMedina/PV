using Application.Common;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class PuestoMapping
    {
        public static Puesto ToEntity(PuestoRequest request)
        {
            bool ipVacia = string.IsNullOrWhiteSpace(request.DireccionIP);
            bool macVacia = string.IsNullOrWhiteSpace(request.DireccionMAC);

            if (ipVacia && macVacia)
                throw ExceptionApp.BadRequest("Debe ingresar al menos Dirección IP o Dirección MAC.");

            if (string.IsNullOrWhiteSpace(request.Nombre))
                throw ExceptionApp.BadRequest("Debe rellenar el campo Nombre.");

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

        public static Puesto UpdatePuesto(Puesto entity, PuestoModifyRequest response)
        {
            //no tienen sentido estas validaciones por la manera en la que esta definido directamente el dto. Directamente no me deja no mandar nombre, ip y mac. Entonces para que se valida si es null ?
            if (!string.IsNullOrWhiteSpace(response.DireccionIP))
                entity.DireccionIP = response.DireccionIP;

            if (!string.IsNullOrWhiteSpace(response.DireccionMAC))
                entity.DireccionMAC = response.DireccionMAC;
            entity.Nombre = response.Nombre!;
            if (response.TipoImpresora.HasValue)
                entity.TipoImpresora = response.TipoImpresora;
            if (!string.IsNullOrWhiteSpace(response.ImpresoraConfigurada))
                entity.ImpresoraConfigurada = response.ImpresoraConfigurada;

            entity.NegocioId = response.NegocioId;

            return entity;
        }

    }
}
