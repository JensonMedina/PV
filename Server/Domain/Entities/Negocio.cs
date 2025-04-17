using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Domain.Entities
{
    public class Negocio
    {
        #region Identificacion
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? RazonSocial { get; set; }
        public string? Cuit { get; set; } 
        #endregion

        #region Contacto
        public string? EmailContacto { get; set; }
        public string? TelefonoContacto { get; set; }
        public string? Calle { get; set; } 
        public string? Altura { get; set; }
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }
        public string? Pais { get; set; }
        public string? CodigoPostal { get; set; }
        #endregion

        #region Información General
        public string? LogoUrl { get; set; }
        public Rubro Rubro { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.Now;
        public bool Activo { get; set; } = true; // true = activo, false = inactivo o suspendido
        #endregion

        #region Configuración
        public Moneda Moneda { get; set; } // Ej: "ARS", "USD", etc.
        public string? Idioma { get; set; }
        public string? TimeZone { get; set; }
        public string? FormatoFecha { get; set; } // "dd/MM/yyyy", YYYY/MM/DD, etc.
        public bool? UsaFacturacion { get; set; }
        public TipoFacturacion TipoFacturacion { get; set; } // "Electronica", "Manual", "Externa"
        #endregion

        #region Relación PlanSaas
        public int IdPlanSaas { get; set; }
        public PlanSaas PlanSaas { get; set; }
        #endregion
        //Manejar Concurrencia
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
