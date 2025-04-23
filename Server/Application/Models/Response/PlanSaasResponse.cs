using Domain.Enum;

namespace Application.Models.Response
{
    public class PlanSaasResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public double Costo { get; set; }
        public Periodo Periodo { get; set; }
        public bool Activo { get; set; }
        public int? LimiteUsuarios { get; set; }
        public int? LimiteProductos { get; set; }
        public int? LimiteVentasMensuales { get; set; }
        public int? LimiteAlmacenamientoMB { get; set; }
        public bool? AccesoFacturacion { get; set; }
        public bool? AccesoReportes { get; set; }
        public bool? AccesoSoportePrioritario { get; set; }
        public bool? AccesoPersonalizacion { get; set; }
    }
}
