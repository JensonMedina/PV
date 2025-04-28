using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class NegocioRequest
    {
        [Required, StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(200)]
        public string? Descripcion { get; set; }
        [Required, Range(0,2)]
        public TipoDocumento? TipoDocumento { get; set; }
        [Required, StringLength(20)]
        public string? NumeroDocumento { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string Telefono { get; set; }
        [Required, Range(0, 10)]
        public Moneda? Moneda { get; set; } = Domain.Enum.Moneda.ARS;
        public bool? UsaFacturacion { get; set; } = false;
        [Range(0, 3)]
        public TipoFacturacion? TipoFacturacion { get; set; } = null;
        [StringLength(100)]
        public string? Calle { get; set; } = null;
        [StringLength(10)]
        public string? Altura { get; set; } = null;
        [StringLength(100)]
        public string? Ciudad { get; set; } = null;
        [StringLength(100)]
        public string? Provincia { get; set; } = null;
        [StringLength(50)]
        public string? Pais { get; set; } = null;
        [StringLength(10)]
        public string? CodigoPostal { get; set; } = null;
        [Required]
        public int PlanSaasId { get; set; }
        [Required]
        public int RubroId { get; set; }
        public bool DebitoAutomaticoActivo { get; set; } = false;
        [Required]
        public MedioPagoRequest MedioPagoRequest { get; set; }
    }
}
