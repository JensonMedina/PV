using Domain.Enum;

namespace Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        #region Datos Personales
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; } 
        public string Dni { get; set; } 
        #endregion

        #region Rol o tipo de usuario
        public TipoUsuario Tipo { get; set; }
        #endregion

        #region Estado
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.UtcNow;
        #endregion

        #region Relaciones
        public int NegocioId { get; set; }
        public Negocio Negocio { get; set; }
        #endregion

        #region Configuraciones Personales
        public string? AvatarUrl { get; set; } //opcional
        #endregion

        #region Datos para audicion
        public DateTime UltimoLogin { get; set; }
        public string IpUltimoLogin { get; set; }
        #endregion
    }
}
