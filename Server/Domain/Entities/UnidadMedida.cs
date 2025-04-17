using Domain.Enum;

namespace Domain.Entities
{
    public class UnidadMedida
    {
        public int Id { get; set; }
        public string Nombre { get; set; }       // Ej: Kilogramo
        public string Abreviatura { get; set; }  // Ej: kg
        public TipoUnidadMedida TipoUnidadMedida { get; set; }         // Ej: Peso, Volumen, Unidad, etc.
        public bool Activo { get; set; } = true;
    }
}