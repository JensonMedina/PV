using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class HistoricoPrecioDto
    {
        public int ProductoNegocioId { get; set; }
        public decimal PrecioAnterior { get; set; }
        public DateTime FechaCambio { get; set; }
    }
}
