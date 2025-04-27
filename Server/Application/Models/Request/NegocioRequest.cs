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
        [Required]
        public TipoDocumento? TipoDocumento { get; set; }
        [Required, StringLength(20)]
        public string? NumeroDocumento { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string Telefono { get; set; }
        [Required]
        public Moneda? Moneda { get; set; }
        [Required]
        public int PlanSaasId { get; set; }
        [Required]
        public int RubroId { get; set; }
        public bool DebitoAutomaticoActivo { get; set; }
        [Required]
        public MedioPagoRequest MedioPagoRequest { get; set; }
    }
}
