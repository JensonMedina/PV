using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class HistoricoStockDto
    {
        public int ProductoNegocioId { get; set; }
        public int StockAnterior { get; set; }
        public DateTime FechaCambio { get; set; }
    }
}
