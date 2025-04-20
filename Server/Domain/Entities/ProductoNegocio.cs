using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ProductoNegocio
    {
        public int Id { get; set; }

        public int NegocioId { get; set; }
        public Negocio Negocio { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        #region Precios
        public decimal PrecioVenta { get; set; }
        public decimal? PrecioCosto { get; set; }
        public Moneda Moneda { get; set; } = Moneda.ARS;
        #endregion

        #region Stock
        public bool GestionaStock { get; set; } = true;
        public int StockActual { get; set; }
        public int? StockMinimo { get; set; }
        public int? StockMaximo { get; set; }
        #endregion

        public DateTime FechaAlta { get; set; } = DateTime.Now;

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
