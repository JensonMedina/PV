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
            bool ipVacia = string.IsNullOrWhiteSpace(request.DireccionIP) || request.DireccionIP == "000.0.0.00";
            bool macVacia = string.IsNullOrWhiteSpace(request.DireccionMAC) || request.DireccionMAC == "AA:0A:0a:AA:0a:Aa";

            if (ipVacia && macVacia)
                throw ExceptionApp.BadRequest("Debe ingresar al menos Dirección IP o Dirección MAC.");

            if (string.IsNullOrWhiteSpace(request.Nombre) || request.Nombre == "string")
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
            ImpresoraConfigurada = entity.ImpresoraConfigurada,
            NegocioId = entity.NegocioId,
        };

        public static Puesto UpdatePuesto(Puesto entity, PuestoRequest response)
        {
            if (!string.IsNullOrWhiteSpace(response.DireccionIP) && response.DireccionIP != "000.0.0.00")
                entity.DireccionIP = response.DireccionIP;

            if (!string.IsNullOrWhiteSpace(response.DireccionMAC) && response.DireccionMAC != "AA:0A:0a:AA:0a:Aa")
                entity.DireccionMAC = response.DireccionMAC;

            if (!string.IsNullOrWhiteSpace(response.Nombre) && response.Nombre != "string")
                entity.Nombre = response.Nombre;

            if (!string.IsNullOrWhiteSpace(response.ImpresoraConfigurada) && response.ImpresoraConfigurada != "string")
                entity.ImpresoraConfigurada = response.ImpresoraConfigurada;

            entity.NegocioId = response.NegocioId;

            return entity;
        }
    }
}
