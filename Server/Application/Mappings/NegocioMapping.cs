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
            Calle = request.Calle,
            Altura = request.Altura,
            Ciudad = request.Ciudad,
            Provincia = request.Provincia,
            Pais = request.Pais,
            CodigoPostal = request.CodigoPostal,
            Moneda = request.Moneda ?? Domain.Enum.Moneda.ARS,
            UsaFacturacion = request.UsaFacturacion,
            TipoFacturacion = request.TipoFacturacion,
            RubroId = request.RubroId,
            PlanSaasId = request.PlanSaasId,
            FechaAlta = DateTime.Now,
            RowVersion = DateTime.Now,
            FechaProximoDebito = DateTime.Now.AddMonths(1)
        };

        public static Negocio ModifiedToEntity(NegocioModifiedRequest request, Negocio negocio)
        {
            negocio.Nombre = request.Nombre ?? negocio.Nombre;
            negocio.Descripcion = request.Descripcion ?? negocio.Descripcion;
            negocio.TipoDocumento = request.TipoDocumento ?? negocio.TipoDocumento;
            negocio.NumeroDocumento = request.NumeroDocumento ?? negocio.NumeroDocumento;
            negocio.Email = request.Email ?? negocio.Email;
            negocio.Telefono = request.Telefono ?? negocio.Telefono;
            negocio.Calle = request.Calle ?? negocio.Calle;
            negocio.Altura = request.Altura ?? negocio.Altura;
            negocio.Ciudad = request.Ciudad ?? negocio.Ciudad;
            negocio.Provincia = request.Provincia ?? negocio.Provincia;
            negocio.Pais = request.Pais ?? negocio.Pais;
            negocio.CodigoPostal = request.CodigoPostal ?? negocio.CodigoPostal;
            negocio.Moneda = request.Moneda ?? negocio.Moneda;
            negocio.UsaFacturacion = request.UsaFacturacion ?? negocio.UsaFacturacion;
            negocio.TipoFacturacion = request.TipoFacturacion ?? negocio.TipoFacturacion;
            negocio.RubroId = request.RubroId ?? negocio.RubroId;
            negocio.PlanSaasId = request.PlanSaasId ?? negocio.PlanSaasId;
            negocio.RowVersion = DateTime.Now;
            return negocio;
        }

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
            PlanSaasId = entity.PlanSaasId
        };
    }
}