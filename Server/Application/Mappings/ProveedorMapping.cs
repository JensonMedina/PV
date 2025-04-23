using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class ProveedorMapping
    {
        public static Proveedor ToEntity(ProveedorRequest request) => new()
        {
            Nombre = request.Nombre,
            RazonSocial = request.RazonSocial,
            TipoDocumento = request.TipoDocumento,
            NumeroDocumento = request.NumeroDocumento,
            Email = request.Email,
            Telefono = request.Telefono,
            RubroId = request.RubroId,
            LimiteCredito = request.LimiteCredito,
            DiasPlazoPago = request.DiasPlazoPago,
            Observaciones = request.Observaciones,
            Activo = request.Activo
        };

        public static ProveedorResponse ToResponse(Proveedor entity) => new()
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            RazonSocial = entity.RazonSocial,
            TipoDocumento = entity.TipoDocumento,
            NumeroDocumento = entity.NumeroDocumento,
            Email = entity.Email,
            Telefono = entity.Telefono,
            Rubro = RubroMapping.ToResponse(entity.Rubro),
            LimiteCredito = entity.LimiteCredito,
            DiasPlazoPago = entity.DiasPlazoPago,
            Observaciones = entity.Observaciones,
            Activo = entity.Activo
        };
    }
}
