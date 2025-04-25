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
        public TipoDocumento? TipoDocumento { get; set; }
        [StringLength(20)]
        public string? NumeroDocumento { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Telefono { get; set; }
        [Required]
        public Moneda? Moneda { get; set; }
        public int IdPlanSaas { get; set; }
        [Required]
        public int RubroId { get; set; }
        public bool DebitoAutomaticoActivo { get; set; }
    }
}
