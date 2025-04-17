using Domain.Enum;

namespace Domain.Entities
{
    public class Comprobante
    {
        #region Identificación
        public int Id { get; set; }
        public string MotivoAnulacion { get; set; }
        public DateTime FechaAnulacion { get; set; }
        public TipoComprobante TipoComprobante { get; set; }
        #endregion
    }

}