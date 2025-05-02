using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class ClienteMapping
    {
        public static Cliente ToEntity(ClienteRequest request) => new()
        {
            Nombre = request.Nombre ?? request.Nombre,
            Apellido = request.Apellido ?? request.Apellido,
            Email = request.Email ?? request.Email ?? request.Email,
            TipoDocumento = request.TipoDocumento ?? request.TipoDocumento,
            NumeroDocumento = request.NumeroDocumento ?? request.NumeroDocumento,
            Telefono = request.Telefono ?? request.Telefono,
            Direccion = request.Direccion ?? request.Direccion,
            Ciudad = request.Ciudad ?? request.Ciudad,
            Provincia = request.Provincia ?? request.Provincia,
            CodigoPostal = request.CodigoPostal ?? request.CodigoPostal,
            EsConsumidorFinal = request.EsConsumidorFinal,
            LimiteCredito = request.LimiteCredito ?? request.LimiteCredito,
            SaldoActual = request.SaldoActual ?? request.SaldoActual,
            Observaciones = request.Observaciones ?? request.Observaciones,
            PuntosFidelidad = request.PuntosFidelidad ?? request.PuntosFidelidad,
            NegocioId = request.NegocioId
        };

        public static ClienteResponse ToResponse(Cliente entity) => new()
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Apellido = entity.Apellido,
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
