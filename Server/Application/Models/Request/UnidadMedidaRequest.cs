using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class UnidadMedidaRequest
    {
        [Required, StringLength(50)]
        public string Nombre { get; set; }

        [Required, StringLength(10)]
        public string Abreviatura { get; set; }

        [Required]
        public TipoUnidadMedida TipoUnidadMedida { get; set; }

        public bool Activo { get; set; }
    }
}
