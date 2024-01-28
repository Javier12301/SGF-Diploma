using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Negocio
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public Categoria Categoria { get; set; }
        public Proveedor Proveedor { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public string NumeroLote { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public bool Refrigerado { get; set; }
        public bool Receta { get; set; }
        public int Stock { get; set; }
        public int CantidadMinima { get; set; }
        public string TipoProducto { get; set; }
        public bool Estado { get; set; }
    }
}
