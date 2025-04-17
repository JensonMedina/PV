using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain.Entities
{
    public class UnidadMedida
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }       // Ej: Kilogramo
        [Column(TypeName = "varchar(10)")]
        public string Abreviatura { get; set; }  // Ej: kg
        public TipoUnidadMedida TipoUnidadMedida { get; set; }         // Ej: Peso, Volumen, Unidad, etc.
        public bool Activo { get; set; } = true;
    }
}