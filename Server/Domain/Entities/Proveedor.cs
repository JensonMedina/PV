using System.ComponentModel.DataAnnotations;
using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Proveedor
    {
        #region Identificación
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? RazonSocial { get; set; }
        public TipoDocumento? TipoDocumento { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? NumeroDocumento { get; set; }
        #endregion

        #region Contacto
        [Column(TypeName = "varchar(20)")]
        public string? Telefono { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string? Email { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string? Direccion { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? Ciudad { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? Provincia { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string? CodigoPostal { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? Web { get; set; }
        #endregion

        #region Datos Comerciales
        public DateTime FechaAlta { get; set; } = DateTime.UtcNow;
        public int? RubroId { get; set; }
        public Rubro? Rubro { get; set; } // Ej: Alimentos, Limpieza, Tecnología...
        public decimal? LimiteCredito { get; set; }
        public int? DiasPlazoPago { get; set; } // Ej: 15 días para pagar
        [Column(TypeName = "varchar(500)")]
        public string? Observaciones { get; set; }
        #endregion

        #region Auditoría y Concurrencia
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public bool Activo { get; set; } = true;
        #endregion
    }

}
