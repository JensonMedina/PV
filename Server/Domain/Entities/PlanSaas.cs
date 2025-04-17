using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain.Entities
{
    public class PlanSaas
    {
        #region Identificación
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? Descripcion { get; set; }
        public double Costo { get; set; }
        public Periodo Periodo { get; set; }
        public bool Activo { get; set; } = true;
        #endregion

        #region Limites
        public int? LimiteUsuarios { get; set; }
        public int? LimiteProductos { get; set; }
        public int? LimiteVentasMensuales { get; set; }
        public int? LimiteAlmacenamientoMB { get; set; }
        #endregion

        #region Funcionalidades
        public bool? AccesoFacturacion { get; set; }
        public bool? AccesoReportes { get; set; }
        public bool? AccesoSoportePrioritario { get; set; }
        public bool? AccesoPersonalizacion { get; set; }
        #endregion
    }
}