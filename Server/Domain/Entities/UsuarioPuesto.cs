using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class UsuarioPuesto
    {
        [Key, Column(Order = 0)]
        public int UsuarioId { get; set; }

        [Key, Column(Order = 1)]
        public int PuestoId { get; set; }

        public Usuario Usuario { get; set; }
        public Puesto Puesto { get; set; }
    }
}
