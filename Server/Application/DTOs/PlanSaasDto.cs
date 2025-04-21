using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PlanSaasDto
    {
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
