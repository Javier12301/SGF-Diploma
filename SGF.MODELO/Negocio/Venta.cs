using SGF.NEGOCIO.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.MODELO.Negocio
{
    public class Venta
    {
        public int VentaID { get; set; }
        public Usuario usuario { get; set; }
        public string TipoComprobante { get; set; }
        // datos del cliente
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreCliente { get; set; }
        public string TipoCliente { get; set; }
        public Moneda Moneda { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal MontoCambio { get; set; }
        public string Impuesto { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaVenta { get; set; }
        public bool Estado { get; set; }
    }
}
