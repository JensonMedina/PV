using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;
using Microsoft.AspNetCore.Identity;
namespace Domain.Entities
{
    public class Usuario : IdentityUser<int>
    {

        #region Datos Personales
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? Telefono { get; set; }
        public TipoDocumento? TipoDocumento { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? NumeroDocumento { get; set; }
        #endregion

        #region Rol o tipo de usuario
        public TipoUsuario Tipo { get; set; }
        #endregion

        #region Estado
        public bool Activo { get; set; } = true;
        public DateTime FechaAlta { get; set; } = DateTime.UtcNow;
        #endregion

        #region Relaciones
        public int? NegocioId { get; set; }
        public Negocio? Negocio { get; set; }
        #endregion

        #region Configuraciones Personales
        [Column(TypeName = "varchar(250)")]
        public string? AvatarUrl { get; set; } 
        #endregion

        #region Auditoría y Concurrencia
        public DateTime? UltimoLogin { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? IpUltimoLogin { get; set; }
        public DateTime RowVersion { get; set; }
        #endregion
    }
}
