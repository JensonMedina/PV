using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CategoriaDto
    {
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Activa { get; set; }
        public string? ImagenUrl { get; set; }
    }
}
