using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class ProveedorRequest
    {
        [Required, StringLength(150)]
        public string Nombre { get; set; }

        [StringLength(150)]
        public string? RazonSocial { get; set; }

        public TipoDocumento? TipoDocumento { get; set; }

        [StringLength(50)]
        public string? NumeroDocumento { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Telefono { get; set; }

        [Required, Range(1, int.MaxValue)]
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
