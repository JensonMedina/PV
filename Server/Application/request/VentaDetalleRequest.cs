using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class VentaDetalleRequest
    {
        [Required, Range(1, int.MaxValue)]
        public int ProductoId { get; set; }

        [Range(1, int.MaxValue)]
        public int? Cantidad { get; set; }

        [Range(0, double.MaxValue)]
        public double? Peso { get; set; }

        [Required, Range(0, double.MaxValue)]
        public double Importe { get; set; }
    }
}
