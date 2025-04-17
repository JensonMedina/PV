namespace Domain.Entities
{
    public class UsuarioPuesto
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int PuestoId { get; set; }
        public Puesto Puesto { get; set; }
    }
}
