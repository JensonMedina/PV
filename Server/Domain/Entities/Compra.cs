using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain.Entities
{
    public class Compra
    {
        #region Identificación
        public int Id { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.UtcNow;
        #endregion

        #region Valores monetarios
        public decimal Subtotal { get; set; }
        public decimal? Descuento { get; set; }
        public decimal Total { get; set; }
        #endregion

        #region Condiciones de pago
        public FormaPago FormaPago { get; set; }
        public int? DiasPlazoPago { get; set; } // Si es a crédito
        public DateTime? FechaVencimientoPago { get; set; }
        public bool Pagado { get; set; } = false;
        #endregion

        #region Relaciones
        public int NegocioId { get; set; }
        public Negocio Negocio { get; set; }
        public int? ProveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }
        public int? UsuarioId { get; set; } // Quién registró la compra
        public Usuario? Usuario { get; set; }
        public int ComprobanteId { get; set; }
        public Comprobante Comprobante { get; set; }
        #endregion

        #region Anulación
        public int? ComprobanteAnulacionId { get; set; }
        public Comprobante? ComprobanteAnulacion { get; set; }
        #endregion

        #region Auditoría y control
        [Timestamp]
        public byte[] RowVersion { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string? Observaciones { get; set; }
        #endregion
    }

}
