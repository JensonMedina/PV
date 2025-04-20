using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Producto
    {
        #region Datos Generales
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? Descripcion { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Marca { get; set; }

        //Relación con Categoria
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        //Relación con Rubro
        public int RubroId { get; set; }
        public Rubro Rubro { get; set; }

        //Relación con UnidadMedida
        public int UnidadMedidaId { get; set; }
        public UnidadMedida UnidadMedida { get; set; } // Unidad, Kg, Lt, Caja, etc.
        #endregion

        #region Producto privado
        public bool EsPrivado { get; set; } = true;

        // si es privado, se asocia al negocio creador
        public int? NegocioId { get; set; }
        public Negocio? Negocio { get; set; }
        #endregion

        #region Otros
        [Column(TypeName = "varchar(250)")]
        public string? ImagenUrl { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.Now;
        #endregion
    }
}
