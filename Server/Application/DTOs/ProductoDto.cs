using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProductoDto
    {
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Marca { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaDto Categoria { get; set; }
        public int RubroId { get; set; }
        public RubroDto Rubro { get; set; }
        public int UnidadMedidaId { get; set; }
        public UnidadMedidaDto UnidadMedida { get; set; }
        public string? ImagenUrl { get; set; }
        public bool EsPrivado { get; set; }
        public int? NegocioId { get; set; }
    }
}
