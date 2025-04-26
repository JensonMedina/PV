using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class ClienteRequest
    {
        [Required, StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        public int NegocioId { get; set; }

        [Required, StringLength(100)]
        public string Apellido { get; set; }

        [Required, EmailAddress, StringLength(255)]
        public string Email { get; set; }
        public TipoDocumento? TipoDocumento { get; set; }

        [StringLength(20)]
        [RegularExpression(@"^\d{7,11}$", ErrorMessage = "El número de documento debe tener entre 7 y 11 dígitos.")]
        public string? NumeroDocumento { get; set; }

        [Phone]
        public string? Telefono { get; set; }

        [StringLength(255)]
        public string? Direccion { get; set; }

        [StringLength(100)]
        public string? Ciudad { get; set; }

        [StringLength(100)]
        public string? Provincia { get; set; }

        [StringLength(10)]
        public string? CodigoPostal { get; set; }

        public bool EsConsumidorFinal { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? LimiteCredito { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? SaldoActual { get; set; }

        [StringLength(500)]
        public string? Observaciones { get; set; }

        [Range(0, int.MaxValue)]
        public int? PuntosFidelidad { get; set; }
    }
}
