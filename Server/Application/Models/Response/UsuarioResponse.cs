namespace Application.Models.Response
{
    public class UsuarioResponse
    {
        public int Id { get; set; }

        #region Datos Personales
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        #endregion

        #region Rol o tipo de usuario
        public string? TipoUsuario  { get; set; }
        #endregion

        #region Estado
        public bool Activo { get; set; } = true;
        public DateTime FechaAlta { get; set; } 
        #endregion

        #region Relaciones
        public int NegocioId { get; set; }
        #endregion

        #region Configuraciones Personales
        public string? AvatarUrl { get; set; }
        #endregion


    }
}
