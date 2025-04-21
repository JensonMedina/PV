using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ClienteDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public TipoDocumento? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public bool EsEmpresa { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }
        public string? CodigoPostal { get; set; }
        public bool EsConsumidorFinal { get; set; }
        public decimal? LimiteCredito { get; set; }
        public decimal? SaldoActual { get; set; }
        public string? Observaciones { get; set; }
        public int? PuntosFidelidad { get; set; }
        public DateTime? UltimaCompra { get; set; }
        public bool Activo { get; set; }
    }
}
