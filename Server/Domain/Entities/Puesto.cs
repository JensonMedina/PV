using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain.Entities
{
    public class Puesto
    {
        #region Identificación
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string DireccionIP { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string DireccionMAC { get; set; }
        #endregion

        #region Relacion con Negocio
        public int NegocioId { get; set; }
        public Negocio Negocio { get; set; }
        #endregion

        #region Relación con Usuario
        public int? UsuarioAsignadoId { get; set; }
        public Usuario? Usuario { get; set; }
        #endregion

        #region Configuración
        public TipoImpresora? TipoImpresora { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? ImpresoraConfigurada { get; set; }
        #endregion

        #region Auditoría
        public DateTime FechaAlta { get; set; } = DateTime.Now;
        public DateTime? UltimaConexion { get; set; }
        public bool Activo { get; set; } = true;
        #endregion
    }

}
