namespace Application.Mappings
{
    public static class PuestoMapping
    {
        public static Domain.Entities.Puesto ToEntity(Application.Models.Request.PuestoRequest request) => new()
        {
            DireccionMAC= request.DireccionMAC,
            DireccionIP= request.DireccionIP,
            Nombre = request.Nombre,
            Activo = request.Activo,
            TipoImpresora= request.TipoImpresora,
            ImpresoraConfigurada=request.ImpresoraConfigurada,



        };

        public static Application.Models.Response.PuestoResponse ToResponse(Domain.Entities.Puesto entity) => new()
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Activo = entity.Activo,
            DireccionIP= entity.DireccionIP,
            DireccionMAC= entity.DireccionMAC,
            ImpresoraConfigurada = entity.ImpresoraConfigurada,
            TipoImpresora= entity.TipoImpresora,
        };
    }
}
