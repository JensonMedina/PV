namespace Application.Models.Response
{
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? AvatarUrl { get; set; }
        public List<PuestoResponse> Puestos { get; set; }

    }
}
