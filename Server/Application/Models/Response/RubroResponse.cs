namespace Application.Models.Response
{
    public class RubroResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
