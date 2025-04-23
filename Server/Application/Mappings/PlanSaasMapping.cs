using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class PlanSaasMapping
    {
        public static PlanSaas ToEntity(PlanSaasRequest request) => new()
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Costo = request.Costo,
            Periodo = request.Periodo,
            Activo = request.Activo,
            LimiteUsuarios = request.LimiteUsuarios,
            LimiteProductos = request.LimiteProductos,
            LimiteVentasMensuales = request.LimiteVentasMensuales,
            LimiteAlmacenamientoMB = request.LimiteAlmacenamientoMB,
            AccesoFacturacion = request.AccesoFacturacion,
            AccesoReportes = request.AccesoReportes,
            AccesoSoportePrioritario = request.AccesoSoportePrioritario,
            AccesoPersonalizacion = request.AccesoPersonalizacion
        };

        public static PlanSaasResponse ToResponse(PlanSaas entity) => new()
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Descripcion = entity.Descripcion,
            Costo = entity.Costo,
            Periodo = entity.Periodo,
            Activo = entity.Activo,
            LimiteUsuarios = entity.LimiteUsuarios,
            LimiteProductos = entity.LimiteProductos,
            LimiteVentasMensuales = entity.LimiteVentasMensuales,
            LimiteAlmacenamientoMB = entity.LimiteAlmacenamientoMB,
            AccesoFacturacion = entity.AccesoFacturacion,
            AccesoReportes = entity.AccesoReportes,
            AccesoSoportePrioritario = entity.AccesoSoportePrioritario,
            AccesoPersonalizacion = entity.AccesoPersonalizacion
        };
    }
}
