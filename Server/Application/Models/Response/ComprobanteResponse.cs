using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response
{
    public class ComprobanteResponse
    {
        public int Id { get; set; }
        public TipoComprobante TipoComprobante { get; set; }
        public DateTime FechaAlta { get; set; }
        public string? MotivoAnulacion { get; set; }
    }
}
