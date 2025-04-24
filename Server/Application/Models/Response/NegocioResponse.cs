namespace Application.Models.Response
{
    public class NegocioResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }

        public string? TipoDocumento { get; set; }  
        public string? NumeroDocumento { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }

        public string Moneda { get; set; } 

        public string? TipoFacturacion { get; set; } 

        public int IdPlanSaas { get; set; }

 
        public string? Calle { get; set; }
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }
        public string? Pais { get; set; }
        public string? CodigoPostal { get; set; }
        public string? LogoUrl { get; set; }

        public int RubroId { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
