using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain.Entities
{
    public class MedioPago
    {
        public int Id { get; set; }
        public int IdNegocio { get; set; }
        public Negocio Negocio { get; set; }
        public TipoMedioPago Tipo { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Nombre { get; set; } // Nombre del titular o identificador
        // Estos campos dependerán del proveedor de pagos que uses
        [Column(TypeName = "varchar(255)")]
        public string? TokenProveedor { get; set; } // Token seguro del proveedor (Stripe, MercadoPago, etc.)
        [Column(TypeName = "varchar(50)")]
        public string? UltimosDigitos { get; set; } // Para tarjetas, los últimos 4 dígitos
        [Column(TypeName = "varchar(20)")]
        public string? FechaExpiracion { get; set; } // Para tarjetas
        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaUltimoUso { get; set; }
    }
}
