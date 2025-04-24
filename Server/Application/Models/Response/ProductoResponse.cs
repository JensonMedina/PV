namespace Application.Models.Response
{
    public class ProductoResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Marca { get; set; }
        public int CategoriaId { get; set; }
        public int RubroId { get; set; }
        public int UnidadMedidaId { get; set; }
        public string? ImagenUrl { get; set; }
        public int? NegocioId { get; set; }
    }
}
