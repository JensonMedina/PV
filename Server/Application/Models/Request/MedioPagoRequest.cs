using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class MedioPagoRequest
    {
        [Required, Range(0, 4)]
        public TipoMedioPago TipoMedioPago { get; set; }
        [Required, StringLength(255)]
        public string NombreTitular { get; set; }
        [StringLength(255)]
        public string? TokenProveedor { get; set; }
        [StringLength(4)]
        public string? UltimosDigitos { get; set; }
        [StringLength(20)]
        public string? FechaExpiracion { get; set; }
    }
}