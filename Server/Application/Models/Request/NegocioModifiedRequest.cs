using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class NegocioModifiedRequest
    {
        [Required(ErrorMessage = "El ID del negocio es obligatorio.")]
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string? Nombre { get; set; }

        [StringLength(200, ErrorMessage = "La descripción no puede superar los 200 caracteres.")]
        public string? Descripcion { get; set; }

        [Range(0, 2, ErrorMessage = "El tipo de documento debe ser un valor entre 0 y 2.")]
        public TipoDocumento? TipoDocumento { get; set; }

        [StringLength(20, ErrorMessage = "El número de documento no puede superar los 20 caracteres.")]
        public string? NumeroDocumento { get; set; }

        [EmailAddress(ErrorMessage = "El formato del correo electrónico es incorrecto.")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "El formato del teléfono es incorrecto.")]
        public string? Telefono { get; set; }

        [Range(0, 10, ErrorMessage = "La moneda debe ser un valor entre 0 y 10.")]
        public Moneda? Moneda { get; set; }
        public bool? UsaFacturacion { get; set; } = false;

        [Range(0, 3, ErrorMessage = "El tipo de facturación debe ser un valor entre 0 y 3.")]
        public TipoFacturacion? TipoFacturacion { get; set; }

        [StringLength(100, ErrorMessage = "La calle no puede superar los 100 caracteres.")]
        public string? Calle { get; set; }

        [StringLength(10, ErrorMessage = "La altura no puede superar los 10 caracteres.")]
        public string? Altura { get; set; }

        [StringLength(100, ErrorMessage = "La ciudad no puede superar los 100 caracteres.")]
        public string? Ciudad { get; set; }

        [StringLength(100, ErrorMessage = "La provincia no puede superar los 100 caracteres.")]
        public string? Provincia { get; set; }

        [StringLength(50, ErrorMessage = "El país no puede superar los 50 caracteres.")]
        public string? Pais { get; set; }

        [StringLength(10, ErrorMessage = "El código postal no puede superar los 10 caracteres.")]
        public string? CodigoPostal { get; set; }

        public int? PlanSaasId { get; set; }

        public int? RubroId { get; set; }

        public bool DebitoAutomaticoActivo { get; set; }
    }
}