using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProductoNegocioDto
    {
        public int NegocioId { get; set; }
        public int ProductoId { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal? PrecioCosto { get; set; }
        public bool GestionaStock { get; set; }
        public int StockActual { get; set; }
        public int? StockMinimo { get; set; }
        public int? StockMaximo { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
