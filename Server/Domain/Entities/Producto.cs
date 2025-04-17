using Domain.Enum;

namespace Domain.Entities
{
    public class Producto
    {
        #region Identificación
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        #endregion

        #region Datos Generales
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }

        //Relación con Categoria
        public int? CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        //Relación con UnidadMedida
        public int UnidadMedidaId { get; set; }
        public UnidadMedida UnidadMedida { get; set; } // Unidad, Kg, Lt, Caja, etc.

        public bool TieneVencimiento { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        #endregion

        #region Precios
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal? Margen { get; set; }
        public Moneda Moneda { get; set; }
        public bool IncluyeImpuestos { get; set; }
        #endregion

        #region Stock
        public bool GestionaStock { get; set; }
        public int StockActual { get; set; }
        public int? StockMinimo { get; set; }
        public int? StockMaximo { get; set; }
        #endregion

        #region Otros
        public bool Activo { get; set; }
        public string ImagenUrl { get; set; }
        public DateTime FechaCreacion { get; set; }
        #endregion
    }

}
