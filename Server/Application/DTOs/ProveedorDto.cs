using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProveedorDto
    {
        public string Nombre { get; set; }
        public string? RazonSocial { get; set; }
        public TipoDocumento? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public RubroDto Rubro { get; set; }
        public decimal? LimiteCredito { get; set; }
        public int? DiasPlazoPago { get; set; }
        public string? Observaciones { get; set; }
        public bool Activo { get; set; }
    }
}
