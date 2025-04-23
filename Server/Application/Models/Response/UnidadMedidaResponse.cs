using Domain.Enum;

namespace Application.Models.Response
{
    public class UnidadMedidaResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public TipoUnidadMedida TipoUnidadMedida { get; set; }
        public bool Activo { get; set; }
    }
}
