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
            Email = request.Email,
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
            NegocioId = request.NegocioId,
            FechaAlta = DateTime.Now
        };
        public static Cliente FromUpdatedToEntity(Cliente cliente, ClienteModifyRequest request)
        {
            cliente.Nombre = request.Nombre ?? cliente.Nombre;
            cliente.Apellido = request.Apellido ?? cliente.Apellido;
            cliente.Email = request.Email ?? cliente.Email;
            cliente.TipoDocumento = request.TipoDocumento ?? cliente.TipoDocumento;
            cliente.NumeroDocumento = request.NumeroDocumento ?? cliente.NumeroDocumento;
            cliente.Telefono = request.Telefono ?? cliente.Telefono;
            cliente.Direccion = request.Direccion ?? cliente.Direccion;
            cliente.Ciudad = request.Ciudad ?? cliente.Ciudad;
            cliente.Provincia = request.Provincia ?? cliente.Provincia;
            cliente.CodigoPostal = request.CodigoPostal ?? cliente.CodigoPostal;
            cliente.EsConsumidorFinal = request.EsConsumidorFinal ?? cliente.EsConsumidorFinal;
            cliente.LimiteCredito = request.LimiteCredito ?? cliente.LimiteCredito;
            cliente.SaldoActual = request.SaldoActual ?? cliente.SaldoActual;
            cliente.Observaciones = request.Observaciones ?? cliente.Observaciones;
            cliente.PuntosFidelidad = request.PuntosFidelidad ?? cliente.PuntosFidelidad;
            return cliente;
        }

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
