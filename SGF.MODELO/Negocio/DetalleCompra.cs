using SGF.NEGOCIO.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.MODELO.Negocio
{
    public class DetalleCompra
    {
        public int DetalleCompraID { get; set; }
        public Compra compra { get; set; }
        public Producto producto { get; set; }
        public decimal PrecioCompra { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
