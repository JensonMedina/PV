using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Categoria
    {
        #region Identificación
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        #endregion

        #region Otros
        public bool Activa { get; set; } = true;
        public string? ImagenUrl { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.UtcNow;
        #endregion

        #region Concurrencia
        [Timestamp]
        public byte[] RowVersion { get; set; } = null!;
        #endregion
    }
}
