using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class HistoricoPrecioRequest
    {
        [Required, Range(1, int.MaxValue)]
        public int ProductoNegocioId { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal PrecioAnterior { get; set; }

        [Required]
        public DateTime FechaCambio { get; set; }
    }
}
