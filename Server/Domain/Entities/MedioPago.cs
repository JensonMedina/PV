using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain.Entities
{
    public class MedioPago
    {
        public int Id { get; set; }
        public Negocio Negocio { get; set; }
        public TipoMedioPago TipoMedioPago { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string NombreTitular { get; set; } // Nombre del titular o identificador
        // Estos campos dependerán del proveedor de pagos que uses
        [Column(TypeName = "varchar(255)")]
        public string? TokenProveedor { get; set; } // Token seguro del proveedor (Stripe, MercadoPago, etc.)
        [Column(TypeName = "varchar(4)")]
        public string? UltimosDigitos { get; set; } // Para tarjetas, los últimos 4 dígitos
        [Column(TypeName = "varchar(20)")]
        public string? FechaExpiracion { get; set; } // Para tarjetas
        public bool Activo { get; set; } = true;
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaUltimoUso { get; set; }
    }
}
