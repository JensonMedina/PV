namespace Application.Models.Response
{
    public class HistoricoPrecioResponse
    {
        public int Id { get; set; }
        public int ProductoNegocioId { get; set; }
        public decimal PrecioAnterior { get; set; }
        public DateTime FechaCambio { get; set; }
    }
}
