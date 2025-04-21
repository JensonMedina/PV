using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class NegocioDto
    {
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public TipoDocumento? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public Moneda Moneda { get; set; }
        public bool? UsaFacturacion { get; set; }
        public TipoFacturacion TipoFacturacion { get; set; }
        public int IdPlanSaas { get; set; }
    }
}
