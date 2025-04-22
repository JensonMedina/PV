using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class ClienteRequest
    {
        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [Required, StringLength(100)]
        public string Apellido { get; set; }

        public TipoDocumento? TipoDocumento { get; set; }

        [StringLength(50)]
        public string? NumeroDocumento { get; set; }

        [Phone]
        public string? Telefono { get; set; }

        [StringLength(200)]
        public string? Direccion { get; set; }

        [StringLength(100)]
        public string? Ciudad { get; set; }

        [StringLength(100)]
        public string? Provincia { get; set; }

        [StringLength(20)]
        public string? CodigoPostal { get; set; }

        public bool EsConsumidorFinal { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? LimiteCredito { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? SaldoActual { get; set; }

        [StringLength(500)]
        public string? Observaciones { get; set; }

        [Range(0, int.MaxValue)]
        public int? PuntosFidelidad { get; set; }

        public DateTime? UltimaCompra { get; set; }

        public bool Activo { get; set; }
    }
}
