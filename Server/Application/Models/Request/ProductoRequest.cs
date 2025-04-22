using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class ProductoRequest
    {
        [Required, StringLength(150)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string? Descripcion { get; set; }

        [StringLength(100)]
        public string? Marca { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int CategoriaId { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int RubroId { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int UnidadMedidaId { get; set; }

        [Url, StringLength(200)]
        public string? ImagenUrl { get; set; }

        public bool EsPrivado { get; set; }

        [Range(1, int.MaxValue)]
        public int? NegocioId { get; set; }
    }
}
