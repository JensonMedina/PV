using Application.Models.Request;
using Domain.Entities;

namespace Application.Mappings
{
    public static class MedioPagoMapping
    {
        public static MedioPago ToEntity(MedioPagoRequest request, Negocio negocio) => new()
        {
            Negocio = negocio,
            TipoMedioPago = request.TipoMedioPago,
            NombreTitular = request.NombreTitular,
            TokenProveedor = request.TokenProveedor,
            UltimosDigitos = request.UltimosDigitos,
            FechaExpiracion = request.FechaExpiracion,
            FechaAlta = DateTime.Now,
            FechaUltimoUso = null
        };
    }
}
