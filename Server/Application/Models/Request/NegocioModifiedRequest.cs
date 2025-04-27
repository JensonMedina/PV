using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class NegocioModifiedRequest
    {
        [Required]
        public int Id { get; set; }
        [StringLength(100)]
        public string? Nombre { get; set; }
        [StringLength(200)]
        public string? Descripcion { get; set; }
        [Range(0, 2)]
        public TipoDocumento? TipoDocumento { get; set; }
        [StringLength(20)]
        public string? NumeroDocumento { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string? Telefono { get; set; }
        [Range(0, 10)]
        public Moneda? Moneda { get; set; }
        public bool? UsaFacturacion { get; set; } = false;
        [Range(0, 3)]
        public TipoFacturacion? TipoFacturacion { get; set; }
        [StringLength(100)]
        public string? Calle { get; set; }
        [StringLength(10)]
        public string? Altura { get; set; }
        [StringLength(100)]
        public string? Ciudad { get; set; }
        [StringLength(100)]
        public string? Provincia { get; set; }
        [StringLength(50)]
        public string? Pais { get; set; }
        [StringLength(10)]
        public string? CodigoPostal { get; set; }
        public int? PlanSaasId { get; set; }
        public int? RubroId { get; set; }
        public bool DebitoAutomaticoActivo { get; set; } 
    }
}
