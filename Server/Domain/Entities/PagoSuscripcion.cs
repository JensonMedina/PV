using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain.Entities
{
    public class PagoSuscripcion
    {
        #region Identificación
        public int Id { get; set; }

        public int NegocioId { get; set; }
        public Negocio Negocio { get; set; }
        #endregion

        #region Relación PlanSaas
        public int IdPlanSaas { get; set; }
        public PlanSaas PlanSaas { get; set; }
        #endregion

        #region Información de Pago
        public DateTime FechaPago { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public double Monto { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? NumeroComprobante { get; set; }
        public EstadoPago Estado { get; set; }
        #endregion

        #region Información Adicional
        [Column(TypeName = "varchar(500)")]
        public string? Observaciones { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaActualizacion { get; set; }
        #endregion
    }
}