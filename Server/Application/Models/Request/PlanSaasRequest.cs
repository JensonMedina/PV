using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class PlanSaasRequest
    {
        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string? Descripcion { get; set; }

        [Required, Range(0, double.MaxValue)]
        public double Costo { get; set; }

        [Required]
        public Domain.Enum.Periodo Periodo { get; set; }

        public bool Activo { get; set; }

        [Range(0, int.MaxValue)]
        public int? LimiteUsuarios { get; set; }

        [Range(0, int.MaxValue)]
        public int? LimiteProductos { get; set; }

        [Range(0, int.MaxValue)]
        public int? LimiteVentasMensuales { get; set; }

        [Range(0, int.MaxValue)]
        public int? LimiteAlmacenamientoMB { get; set; }

        public bool? AccesoFacturacion { get; set; }

        public bool? AccesoReportes { get; set; }

        public bool? AccesoSoportePrioritario { get; set; }

        public bool? AccesoPersonalizacion { get; set; }
    }
}
