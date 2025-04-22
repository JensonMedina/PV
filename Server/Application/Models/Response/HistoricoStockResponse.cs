using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response
{
    public class HistoricoStockResponse
    {
        public int Id { get; set; }
        public int ProductoNegocioId { get; set; }
        public int StockAnterior { get; set; }
        public DateTime FechaCambio { get; set; }
    }
}
