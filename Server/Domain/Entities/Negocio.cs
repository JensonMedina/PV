using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain.Entities
{
    public class Negocio
    {
        #region Identificacion
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? Descripcion { get; set; }
        [Column(TypeName = "varchar(100)")]
        public TipoDocumento? TipoDocumento { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? NumeroDocumento { get; set; }
        #endregion

        #region Contacto
        [Column(TypeName = "varchar(255)")]
        public string? Email { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Telefono { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? Calle { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string? Altura { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? Ciudad { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? Provincia { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Pais { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string? CodigoPostal { get; set; }
        #endregion

        #region Información General
        [Column(TypeName = "varchar(250)")]
        public string? LogoUrl { get; set; }
        public int RubroId { get; set; }
        public Rubro Rubro { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Activo { get; set; } = true; // true = activo, false = inactivo o suspendido
        #endregion

        #region Configuración
        public Moneda Moneda { get; set; } // Ej: "ARS", "USD", etc.
        public bool? UsaFacturacion { get; set; } = false;
        public TipoFacturacion? TipoFacturacion { get; set; } // "Electronica", "Manual", "Externa"
        #endregion

        #region Relación PlanSaas
        public int PlanSaasId { get; set; }
        public PlanSaas PlanSaas { get; set; }
        #endregion
        
        #region Relación con Proveedores
        public ICollection<ProveedorNegocio> ProveedoresNegocio { get; set; }
        #endregion
        
        #region Facturación Automática
        public bool DebitoAutomaticoActivo { get; set; } = false;
        public DateTime? FechaProximoDebito { get; set; }
        #endregion

        //Manejar Concurrencia
        public DateTime RowVersion { get; set; }
    }
}
