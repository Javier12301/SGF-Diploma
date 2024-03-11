using SGF.NEGOCIO.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.MODELO.Negocio
{
    public class DetalleVenta
    {
        public int DetalleVentaID { get; set; }
        public Venta venta { get; set; }
        public Producto producto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
