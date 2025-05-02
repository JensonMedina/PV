using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class NegocioMapping
    {
        public static Negocio ToEntity(NegocioRequest request) => new()
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            TipoDocumento = request.TipoDocumento,
            NumeroDocumento = request.NumeroDocumento,
            Email = request.Email,
            Telefono = request.Telefono,
            Moneda = request.Moneda,
            PlanSaasId = request.IdPlanSaas
        };

        public static NegocioResponse ToResponse(Negocio entity) => new()
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Descripcion = entity.Descripcion,
            TipoDocumento = entity.TipoDocumento.ToString(),
            NumeroDocumento = entity.NumeroDocumento,
            Email = entity.Email,
            Telefono = entity.Telefono,
            Moneda = entity.Moneda.ToString(),
            TipoFacturacion = entity.TipoFacturacion.ToString(),
            PlanSaasId = entity.PlanSaasId,
        };
    }
}
