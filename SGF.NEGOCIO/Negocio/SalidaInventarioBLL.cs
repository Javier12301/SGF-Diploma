using SGF.DATOS.Negocio;
using SGF.MODELO.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Negocio
{
    public class SalidaInventarioBLL
    {
        private static SalidaInventarioBLL _instancia = null;
        private SalidaInventarioBLL() { }
        public static SalidaInventarioBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SalidaInventarioBLL();
                return _instancia;
            }
        }

        // Cancear Salida de productos
        public bool CancelarSalidadeProductos(int salidaID)
        {
            if(salidaID > 0)
            {
                List<int> productosID = SalidaInventarioDAO.ObtenerProductosIDPorSalidaID(salidaID);
                List<Producto> listaProductos = new List<Producto>();
                ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;
                foreach(int productoID in productosID)
                {
                    Producto producto = lProducto.ObtenerProductoPorID(productoID);
                    listaProductos.Add(producto);
                }
                foreach(Producto producto in listaProductos)
                {
                    int cantidad = SalidaInventarioDAO.ObtenerCantidadProductosQueSalieron(producto.ProductoID, salidaID);
                    producto.Stock += cantidad;
                    lProducto.ModificarProducto(producto);
                }
                return SalidaInventarioDAO.CancelarSalidaD(salidaID);
            }
            else
            {
                throw new ArgumentException("Se ha producido un error: el campo de salida de inventario no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }

        public int ObtenerFolio()
        {
            return SalidaInventarioDAO.ObtenerFolio();
        }

        public bool RegistrarSalida(SalidaInventario oSalida, DataTable DetalleSalida)
        {
            if(oSalida != null && DetalleSalida != null)
            {
                return SalidaInventarioDAO.RegistrarSalidaD(oSalida, DetalleSalida);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el campo de productos no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }

        // Obtener salida de inventario por id
        public SalidaInventario ObtenerSalidaPorID(int salidaID)
        {
            if(salidaID > 0)
            {
                return SalidaInventarioDAO.ObtenerSalidaPorIDD(salidaID);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el campo de productos no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }


    }
}
