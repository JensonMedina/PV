using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class CompraMapping
    {
        public static Compra ToEntity(CompraRequest request) => new()
        {
            FechaAlta = request.FechaAlta,
            Subtotal = request.Subtotal,
            Descuento = request.Descuento,
            Total = request.Total,
            FormaPago = request.FormaPago,
            DiasPlazoPago = request.DiasPlazoPago,
            FechaVencimientoPago = request.FechaVencimientoPago,
            Pagado = request.Pagado,
            NegocioId = request.NegocioId,
            ProveedorId = request.ProveedorId,
            UsuarioId = request.UsuarioId,
            ComprobanteId = request.ComprobanteId,
            ComprobanteAnulacionId = request.ComprobanteAnulacionId,
            Observaciones = request.Observaciones,
            //Detalles = request.Detalles.Select(CompraDetalleMapping.ToEntity).ToList()
        };

        public static CompraResponse ToResponse(Compra entity) => new()
        {
            Id = entity.Id,
            FechaAlta = entity.FechaAlta,
            Subtotal = entity.Subtotal,
            Descuento = entity.Descuento,
            Total = entity.Total,
            FormaPago = entity.FormaPago,
            DiasPlazoPago = entity.DiasPlazoPago,
            FechaVencimientoPago = entity.FechaVencimientoPago,
            Pagado = entity.Pagado,
            NegocioId = entity.NegocioId,
            ProveedorId = entity.ProveedorId,
            UsuarioId = entity.UsuarioId,
            ComprobanteId = entity.ComprobanteId,
            ComprobanteAnulacionId = entity.ComprobanteAnulacionId,
            Observaciones = entity.Observaciones,
           // Detalles = entity.Detalles.Select(CompraDetalleMapping.ToResponse).ToList()
        };
    }
}
