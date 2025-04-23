using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class ClienteMapping
    {
        public static Cliente ToEntity(ClienteRequest request) => new()
        {
            Nombre = request.Nombre,
            Apellido = request.Apellido,
            TipoDocumento = request.TipoDocumento,
            NumeroDocumento = request.NumeroDocumento,
            Telefono = request.Telefono,
            Direccion = request.Direccion,
            Ciudad = request.Ciudad,
            Provincia = request.Provincia,
            CodigoPostal = request.CodigoPostal,
            EsConsumidorFinal = request.EsConsumidorFinal,
            LimiteCredito = request.LimiteCredito,
            SaldoActual = request.SaldoActual,
            Observaciones = request.Observaciones,
            PuntosFidelidad = request.PuntosFidelidad,
            UltimaCompra = request.UltimaCompra,
            Activo = request.Activo
        };

        public static ClienteResponse ToResponse(Cliente entity) => new()
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Apellido = entity.Apellido,
            TipoDocumento = entity.TipoDocumento,
            NumeroDocumento = entity.NumeroDocumento,
            Telefono = entity.Telefono,
            Direccion = entity.Direccion,
            Ciudad = entity.Ciudad,
            Provincia = entity.Provincia,
            CodigoPostal = entity.CodigoPostal,
            EsConsumidorFinal = entity.EsConsumidorFinal,
            LimiteCredito = entity.LimiteCredito,
            SaldoActual = entity.SaldoActual,
            Observaciones = entity.Observaciones,
            PuntosFidelidad = entity.PuntosFidelidad,
            UltimaCompra = entity.UltimaCompra,
            Activo = entity.Activo
        };
    }

}
