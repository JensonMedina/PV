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
        };

        public static ProveedorResponse ToResponse(Proveedor entity) => new()
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            RazonSocial = entity.RazonSocial,
            TipoDocumento = entity.TipoDocumento.ToString(),
            NumeroDocumento = entity.NumeroDocumento,
            Email = entity.Email,
            Telefono = entity.Telefono,
            LimiteCredito = entity.LimiteCredito,
            DiasPlazoPago = entity.DiasPlazoPago,
            Observaciones = entity.Observaciones,
            Activo = entity.Activo
        };

        public static Proveedor ModifiedToEntity(ProveedorModifiedRequest request, Proveedor proveedor)
        {
            proveedor.Nombre = request.Nombre ?? proveedor.Nombre;
            proveedor.RazonSocial = request.RazonSocial ?? proveedor.RazonSocial;
            proveedor.TipoDocumento = request.TipoDocumento ?? proveedor.TipoDocumento;
            proveedor.NumeroDocumento = request.NumeroDocumento ?? proveedor.NumeroDocumento;
            proveedor.Email = request.Email ?? proveedor.Email;
            proveedor.Telefono = request.Telefono ?? proveedor.Telefono;
            proveedor.Direccion = request.Direccion ?? proveedor.Direccion;
            proveedor.Ciudad = request.Ciudad ?? proveedor.Ciudad;
            proveedor.Provincia = request.Provincia ?? proveedor.Provincia;
            proveedor.CodigoPostal = request.CodigoPostal ?? proveedor.CodigoPostal;
            proveedor.RubroId = request.RubroId ?? proveedor.RubroId;
            proveedor.RowVersion = BitConverter.GetBytes(DateTime.UtcNow.Ticks); // simulando cambio en concurrencia

            return proveedor;
        }

    }
}
