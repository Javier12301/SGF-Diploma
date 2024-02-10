using SGF.NEGOCIO.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.MODELO.Negocio
{
    public class Compra
    {
        public int CompraID { get; set; }
        public Usuario usuario { get; set; }
        public Proveedor proveedor { get; set; }
        public string TipoComprobante { get; set; }
        public DateTime FechaCompra { get; set; }
        public bool Estado { get; set; }
    }
}
