using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class ProveedorRequest
    {
        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string? RazonSocial { get; set; }

        public TipoDocumento? TipoDocumento { get; set; }

        [StringLength(20)]
        public string? NumeroDocumento { get; set; }

        [StringLength(20), Phone]
        public string? Telefono { get; set; }

        [StringLength(255), EmailAddress]
        public string? Email { get; set; }

        [StringLength(150)]
        public string? Direccion { get; set; }

        [StringLength(100)]
        public string? Ciudad { get; set; }

        [StringLength(100)]
        public string? Provincia { get; set; }

        [StringLength(10)]
        public string? CodigoPostal { get; set; }

        [StringLength(100)]
        public string? Web { get; set; }

        [Required]
        public int RubroId { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? LimiteCredito { get; set; }

        [Range(0, int.MaxValue)]
        public int? DiasPlazoPago { get; set; }

        [StringLength(500)]
        public string? Observaciones { get; set; }

        public bool Activo { get; set; }
    }
}
