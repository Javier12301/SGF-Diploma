using SGF.DATOS.Negocio;
using SGF.MODELO.Negocio;
using SGF.NEGOCIO.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Negocio
{
    public class CompraBLL
    {
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        // Singleton de cCompra
        private static CompraBLL _instancia = null;
        private CompraBLL() { }
        public static CompraBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CompraBLL();
                return _instancia;
            }
        }

        // Manejo de Compras
        public bool RegistrarCompra(Compra oCompra, DataTable DetalleCompra)
        {
            if (oCompra != null && DetalleCompra != null)
            {
                return CompraDAO.RegistrarCompraD(oCompra, DetalleCompra);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el campo de compras no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }

        // Cancelar Compra y devolver productos
        public bool CancelarCompra(int compraID)
        {
            if (compraID > 0)
            {
                List<int> productosID = CompraDAO.ObtenerProductosIDPorCompraID(compraID);
                List<Producto> listaProductos = new List<Producto>();
                ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;
                foreach (int productoID in productosID)
                {
                    Producto producto = lProducto.ObtenerProductoPorID(productoID);
                    listaProductos.Add(producto);
                }

                // Una vez obtenido, se procede a devolver los productos usando la cantidad comprada que sale en el detalle de compra
                foreach (Producto producto in listaProductos)
                {
                    int cantidad = CompraDAO.ObtenerCantidadProductosComprados(producto.ProductoID, compraID);
                    // los productos pueden quedar como negativos si es que se realizo ventas o salidas de inventario con ellos.
                    producto.Stock -= cantidad;
                    lProducto.ModificarProducto(producto);
                }

                // Finalmente se cancela la compra
                return CompraDAO.CancelarCompraD(compraID);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el campo de compras no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }

        // Obtener Folio
        public int ObtenerFolio()
        {
            return CompraDAO.ObtenerFolioD();
        }

        // Obtener compra por id
        public Compra ObtenerCompraPorID(int compraID)
        {
            if (compraID > 0)
            {
                return CompraDAO.ObtenerCompraPorIDD(compraID);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el campo de compras no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }

        // Listar cantidad comprada por proveedor
        public DataTable ListarCantidadCompradaPorProveedor()
        {
            DataTable dt = CompraDAO.ListarCantidadCompradaD();
            if (dt != null)
            {
                return dt;
            }
            else
            {
                throw new Exception("Se ha producido un error al listar el reporte, contacte con el administrador para que solucione este problema.");
            }
        }

        public DataTable ListarGastoTotal()
        {
            DataTable dt = CompraDAO.ListarGastoTotalD();
            if (dt != null)
            {
                return dt;
            }
            else
            {
                throw new Exception("Se ha producido un error al listar el reporte, contacte con el administrador para que solucione este problema.");
            }
        }

        public int ObtenerCompraRealizada(string tipo)
        {
            return CompraDAO.ObtenerCantidadDeComprasPorTipoProducto(tipo);
        }

        // compras canceladsa
        public int ObtenerCompraCancelada()
        {
            return CompraDAO.ObtenerCompraCancelada();
        }

        // ObtenerComprasPorFecha
        public DataTable ObtenerComprasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return CompraDAO.ObtenerComprasPorFecha(fechaInicio, fechaFin);
        }

        // obtenercompra semana
        public DataTable ObtenerComprasPorSemana(DateTime fechaInicio, DateTime fechaFin)
        {
            return CompraDAO.ObtenerComprasPorDiaDeLaSemana(fechaInicio, fechaFin);
        }


    }
}
