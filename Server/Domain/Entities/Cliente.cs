using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain.Entities
{
    public class Cliente
    {
        #region Identificación
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Apellido { get; set; }
        public TipoDocumento? TipoDocumento { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? NumeroDocumento { get; set; }
        public bool EsEmpresa { get; set; } = false;
        #endregion

        #region Contacto
        [Column(TypeName = "varchar(255)")]
        public string? Email { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Telefono { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string? Direccion { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? Ciudad { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? Provincia { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string? CodigoPostal { get; set; }
        #endregion

        #region Relación con Negocio
        public int NegocioId { get; set; }
        public Negocio Negocio { get; set; }
        #endregion

        #region Facturación
        public bool EsConsumidorFinal { get; set; } = true;
        #endregion

        #region Datos Comerciales
        public decimal? LimiteCredito { get; set; }
        public decimal? SaldoActual { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.UtcNow;
        [Column(TypeName = "varchar(500)")]
        public string? Observaciones { get; set; }
        #endregion

        #region Fidelización
        public int? PuntosFidelidad { get; set; }
        public DateTime? UltimaCompra { get; set; }
        #endregion

        #region Auditoría y Concurrencia
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public bool Activo { get; set; } = true;
        #endregion
    }

}