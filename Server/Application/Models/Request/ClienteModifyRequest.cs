using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class ClienteModifyRequest
    {
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El ID del negocio es obligatorio.")]
        public int NegocioId { get; set; }

        
        [StringLength(100, ErrorMessage = "El apellido no puede tener más de 100 caracteres.")]
        public string? Apellido { get; set; }

        
        [EmailAddress(ErrorMessage = "El email no tiene un formato válido.")]
        [StringLength(255, ErrorMessage = "El email no puede tener más de 255 caracteres.")]
        public string? Email { get; set; }

        [Range(0, 2, ErrorMessage = "El tipo de documento debe estar entre 0 y 2.")]
        public TipoDocumento? TipoDocumento { get; set; }

        [StringLength(20, ErrorMessage = "El número de documento no puede tener más de 20 caracteres.")]
        public string? NumeroDocumento { get; set; }

        [Phone(ErrorMessage = "El teléfono no tiene un formato válido.")]
        [StringLength(20, ErrorMessage = "El teléfono no puede tener más de 20 caracteres.")]
        public string? Telefono { get; set; }

        [StringLength(255, ErrorMessage = "La dirección no puede tener más de 255 caracteres.")]
        public string? Direccion { get; set; }

        [StringLength(100, ErrorMessage = "La ciudad no puede tener más de 100 caracteres.")]
        public string? Ciudad { get; set; }

        [StringLength(100, ErrorMessage = "La provincia no puede tener más de 100 caracteres.")]
        public string? Provincia { get; set; }

        [StringLength(10, ErrorMessage = "El código postal no puede tener más de 10 caracteres.")]
        public string? CodigoPostal { get; set; }

        public bool? EsConsumidorFinal { get; set; }

        public decimal? LimiteCredito { get; set; }

        public decimal? SaldoActual { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden tener más de 500 caracteres.")]
        public string? Observaciones { get; set; }

        public int? PuntosFidelidad { get; set; }

    }
}
