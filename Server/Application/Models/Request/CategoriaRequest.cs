using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class CategoriaRequest
    {
        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(250)]
        public string? Descripcion { get; set; }

        public bool Activa { get; set; }

        [Url, StringLength(200)]
        public string? ImagenUrl { get; set; }
    }
}
