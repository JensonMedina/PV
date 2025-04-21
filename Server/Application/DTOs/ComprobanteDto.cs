using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ComprobanteDto
    {
        public TipoComprobante TipoComprobante { get; set; }
        public DateTime FechaAlta { get; set; }
        public string? MotivoAnulacion { get; set; }
    }
}
