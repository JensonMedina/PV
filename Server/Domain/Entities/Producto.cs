using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain.Entities
{
    public class Producto
    {
        #region Identificación
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? CodigoBarras { get; set; }
        #endregion

        #region Datos Generales
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? Descripcion { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Marca { get; set; }

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
        public decimal? PrecioCosto { get; set; }
        public decimal? Margen { get; set; }
        public Moneda Moneda { get; set; } = Moneda.ARS;
        public bool? IncluyeImpuestos { get; set; }
        #endregion

        #region Stock
        public bool GestionaStock { get; set; }
        public int StockActual { get; set; }
        public int? StockMinimo { get; set; }
        public int? StockMaximo { get; set; }
        #endregion

        #region Otros
        public bool Activo { get; set; } = true;
        [Column(TypeName = "varchar(250)")]
        public string? ImagenUrl { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.Now;
        #endregion

        //Manejar Concurrencia
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

}
