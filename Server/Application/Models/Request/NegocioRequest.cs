using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class NegocioRequest
    {
        [Required, StringLength(150)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string? Descripcion { get; set; }

        public TipoDocumento? TipoDocumento { get; set; }

        [StringLength(50)]
        public string? NumeroDocumento { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Telefono { get; set; }

        [Required]
        public Domain.Enum.Moneda Moneda { get; set; }

        public bool? UsaFacturacion { get; set; }

        public Domain.Enum.TipoFacturacion TipoFacturacion { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int IdPlanSaas { get; set; }
    }
}
