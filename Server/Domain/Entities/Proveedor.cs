using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Proveedor
    {
        #region Identificación
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string TipoDocumento { get; set; } // CUIT, CUIL, DNI, etc.
        public string NumeroDocumento { get; set; }
        #endregion

        #region Contacto
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }
        public string? CodigoPostal { get; set; }
        public string? PersonaContacto { get; set; }
        public string? Web { get; set; }
        #endregion

        #region Datos Comerciales
        public DateTime FechaAlta { get; set; } = DateTime.UtcNow;
        public int RubroId { get; set; }
        public Rubro? Rubro { get; set; } // Ej: Alimentos, Limpieza, Tecnología...
        public decimal? LimiteCredito { get; set; }
        public int? DiasPlazoPago { get; set; } // Ej: 15 días para pagar
        public string? Observaciones { get; set; }
        #endregion

        #region Auditoría y Concurrencia
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public bool Activo { get; set; } = true;
        #endregion
    }

}
