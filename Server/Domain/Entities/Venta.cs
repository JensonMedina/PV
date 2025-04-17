using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Domain.Entities
{
    public class Venta
    {
        
        public int Id { get; set; }
        public bool AfectaCaja { get; set; } = true;

        #region Relaciones

        //Comprobante
        public int ComprobanteId { get; set; }
        public Comprobante Comprobante { get; set; }

        //Negocio
        public int NegocioId { get; set; }
        public Negocio Negocio { get; set; }

        //Puesto
        public int PuestoId { get; set; }
        public Puesto Puesto { get; set; }

        //Empleado
        public int EmpleadoId { get; set; }
        public Usuario Empleado { get; set; } //Usuario de tipo Empleado logueado al momento de registrar la venta

        //Cliente
        public int? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        #endregion

        #region Datos Comerciales
        public DateTime FechaAlta { get; set; } = DateTime.Now;
        public decimal? Subtotal { get; set; }
        public decimal? DescuentoTotal { get; set; }
        public decimal? Impuestos { get; set; }
        public decimal Total { get; set; }
        public FormaPago FormaPago { get; set; }
        #endregion

        #region Relación con VentaDetalle
        public List<VentaDetalle> Detalles { get; set; }
        #endregion

        #region Anulacion
        public int? ComprobanteAnulacionId { get; set; }
        public Comprobante? ComprobanteAnulacion { get; set; }
        #endregion

        //Manejar Concurrencia
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

}
