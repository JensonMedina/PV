using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PuestoDto
    {
        public string Nombre { get; set; }
        public string DireccionIP { get; set; }
        public string DireccionMAC { get; set; }
        public TipoImpresora? TipoImpresora { get; set; }
        public string? ImpresoraConfigurada { get; set; }
        public bool Activo { get; set; }

    }
}
