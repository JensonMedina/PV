using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class VentaMapping
    {
        public static Venta ToEntity(VentaRequest request) => new()
        {
            NegocioId = request.NegocioId,
            PuestoId = request.PuestoId,
            EmpleadoId = request.EmpleadoId,
            ClienteId = request.ClienteId,
            FechaAlta = request.FechaAlta,
            Subtotal = request.Subtotal,
            DescuentoTotal = request.DescuentoTotal,
            Impuestos = request.Impuestos,
            Total = request.Total,
            FormaPago = request.FormaPago,
            Detalles = request.Detalles.Select(VentaDetalleMapping.ToEntity).ToList()
        };

        public static VentaResponse ToResponse(Venta entity) => new()
        {
            Id = entity.Id,
            NegocioId = entity.NegocioId,
            PuestoId = entity.PuestoId,
            EmpleadoId = entity.EmpleadoId,
            ClienteId = entity.ClienteId,
            FechaAlta = entity.FechaAlta,
            Subtotal = entity.Subtotal,
            DescuentoTotal = entity.DescuentoTotal,
            Impuestos = entity.Impuestos,
            Total = entity.Total,
            FormaPago = entity.FormaPago,
            Detalles = entity.Detalles.Select(VentaDetalleMapping.ToResponse).ToList()
        };
    }
}
