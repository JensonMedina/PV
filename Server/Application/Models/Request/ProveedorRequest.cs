using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class ProveedorRequest
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Nombre { get; set; }

        [StringLength(100, ErrorMessage = "La razón social no puede superar los 100 caracteres.")]
        public string? RazonSocial { get; set; }

        [Range(0, 2, ErrorMessage = "El tipo de documento debe ser un valor válido entre 0 y 2 (DNI = 0, CUIT = 1, Pasaporte = 2).")]
        public TipoDocumento? TipoDocumento { get; set; }

        [StringLength(20, ErrorMessage = "El número de documento no puede superar los 20 caracteres.")]
        public string? NumeroDocumento { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono no puede superar los 20 caracteres.")]
        [Phone(ErrorMessage = "El teléfono debe tener un formato válido.")]
        public string? Telefono { get; set; }

        [StringLength(255, ErrorMessage = "El email no puede superar los 255 caracteres.")]
        [EmailAddress(ErrorMessage = "El email debe tener un formato válido.")]
        public string? Email { get; set; }

        [StringLength(150, ErrorMessage = "La dirección no puede superar los 150 caracteres.")]
        public string? Direccion { get; set; }

        [StringLength(100, ErrorMessage = "La ciudad no puede superar los 100 caracteres.")]
        public string? Ciudad { get; set; }

        [StringLength(100, ErrorMessage = "La provincia no puede superar los 100 caracteres.")]
        public string? Provincia { get; set; }

        [StringLength(10, ErrorMessage = "El código postal no puede superar los 10 caracteres.")]
        public string? CodigoPostal { get; set; }

        [StringLength(100, ErrorMessage = "La página web no puede superar los 100 caracteres.")]
        public string? Web { get; set; }

        [Required(ErrorMessage = "El RubroId es obligatorio.")]
        public int RubroId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El límite de crédito debe ser un valor positivo.")]
        public decimal? LimiteCredito { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Los días de plazo de pago deben ser un número entero positivo.")]
        public int? DiasPlazoPago { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden superar los 500 caracteres.")]
        public string? Observaciones { get; set; }
    }
}
