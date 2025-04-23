namespace Application.Models.Response
{
    public class CategoriaResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Activa { get; set; }
        public string? ImagenUrl { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
