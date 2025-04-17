using Domain.Enum;

namespace Domain.Entities
{
    public class Comprobante
    {
        #region Identificación
        public int Id { get; set; }
        public string? MotivoAnulacion { get; set; } //Si es un comprobante de anulación
        public DateTime FechaAlta { get; set; } = DateTime.Now;
        public TipoComprobante TipoComprobante { get; set; }
        #endregion
    }

}