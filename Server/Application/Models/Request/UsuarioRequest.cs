using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class UsuarioRequest
    {
        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [Required, StringLength(100)]
        public string Apellido { get; set; }

        [Url]
        public string? AvatarUrl { get; set; }

        [Required, MinLength(1)]
        public List<int> PuestosIds { get; set; }
    }
}
