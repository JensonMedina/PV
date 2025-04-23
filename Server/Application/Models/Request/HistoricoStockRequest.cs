using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class HistoricoStockRequest
    {
        [Required, Range(1, int.MaxValue)]
        public int ProductoNegocioId { get; set; }

        [Required, Range(0, int.MaxValue)]
        public int StockAnterior { get; set; }

        [Required]
        public DateTime FechaCambio { get; set; }
    }
}
