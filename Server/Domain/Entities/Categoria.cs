using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Categoria
    {
        #region Identificación
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string? Descripcion { get; set; }
        #endregion

        #region Otros
        public bool Activa { get; set; } = true;
        [Column(TypeName = "varchar(255)")]
        public string? ImagenUrl { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.UtcNow;
        #endregion

        #region Concurrencia
        [Timestamp]
        public byte[] RowVersion { get; set; }
        #endregion
    }
}
