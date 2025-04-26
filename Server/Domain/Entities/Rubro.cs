using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Rubro
    {
        #region Propiedades Base
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? Descripcion { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FechaAlta { get; set; }
        #endregion
    }
}