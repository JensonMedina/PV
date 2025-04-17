using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Cliente
    {
        #region Identificación
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public bool EsEmpresa { get; set; } = false;
        #endregion

        #region Contacto
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }
        public string? CodigoPostal { get; set; }
        #endregion

        #region Facturación
        public bool EsConsumidorFinal { get; set; } = true;
        #endregion

        #region Datos Comerciales
        public decimal? LimiteCredito { get; set; }
        public decimal? SaldoActual { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.UtcNow;
        public string? Observaciones { get; set; }
        public string? VendedorAsignado { get; set; }
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