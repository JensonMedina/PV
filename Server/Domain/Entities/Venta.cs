using Domain.Enum;

namespace Domain.Entities
{
    public class Venta
    {
        
        public int Id { get; set; }

        #region Relaciones

        //Comprobante
        public int IdComprobante { get; set; }
        public Comprobante Comprobante { get; set; }

        //Negocio
        public int NegocioId { get; set; }
        public Negocio Negocio { get; set; }

        //Puesto
        public int PuestoId { get; set; }
        public Puesto Puesto { get; set; }

        //Empleado
        public int EmpleadoId { get; set; }
        public Usuario Empleado { get; set; }

        //Cliente
        public int? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        #endregion

        #region Datos Comerciales
        public DateTime Fecha { get; set; }
        public decimal Subtotal { get; set; }
        public decimal DescuentoTotal { get; set; }
        public decimal? Impuestos { get; set; }
        public decimal Total { get; set; }
        public FormaPago FormaPago { get; set; }
        #endregion

        #region Anulacion
        public int? ComprobanteAnulacionId { get; set; }
        public Comprobante? ComprobanteAnulacion { get; set; }
        #endregion
    }

}
