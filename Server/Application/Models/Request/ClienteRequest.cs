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

        [Range(0, 2, ErrorMessage = "El tipo de documento debe estar entre o y 2")]
        public TipoDocumento? TipoDocumento { get; set; }

        [StringLength(20)]
        public string? NumeroDocumento { get; set; }

        [Phone]
        [StringLength(20)]

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

        public decimal? LimiteCredito { get; set; }

        public decimal? SaldoActual { get; set; }

        [StringLength(500)]
        public string? Observaciones { get; set; }


        public int? PuntosFidelidad { get; set; }
    }
}
