using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class ComprobanteRequest
    {
        [Required]
        public TipoComprobante TipoComprobante { get; set; }

        [Required]
        public DateTime FechaAlta { get; set; }

        [StringLength(250)]
        public string? MotivoAnulacion { get; set; }
    }
}
