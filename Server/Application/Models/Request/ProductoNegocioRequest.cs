using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class ProductoNegocioRequest
    {
        [Required, Range(1, int.MaxValue)]
        public int NegocioId { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int ProductoId { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal PrecioVenta { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? PrecioCosto { get; set; }

        public bool GestionaStock { get; set; }

        [Required, Range(0, int.MaxValue)]
        public int StockActual { get; set; }

        [Range(0, int.MaxValue)]
        public int? StockMinimo { get; set; }

        [Range(0, int.MaxValue)]
        public int? StockMaximo { get; set; }

        [Required]
        public DateTime FechaAlta { get; set; }
    }
}
