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
    public class VentaBLL
    {
        // Singleton de cVenta
        private static VentaBLL _instancia = null;
        private VentaBLL() { }
        public static VentaBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new VentaBLL();
                return _instancia;
            }
        }

        // conteo ventas canceladas
        public int ConteoVentasCanceladas()
        {
            return VentaDAO.ObtenerVentaCancelada();
        }

        // obtener ultima venta
        public int ObtenerUltimaVenta()
        {
            int ultimaVenta = VentaDAO.ObtenerUltimaVentaD();
            if (ultimaVenta > 0)
            {
                return ultimaVenta;
            }
            else
            {
                throw new Exception("No se pudo obtener la última venta, esto se puede deber que no existan ventas registradas en el sistema. Si usted cree que esto es un error, por favor, póngase en contacto con el administrador del sistema.");
            }
        }

        // Obtener venta por id
        public Venta ObtenerVentaPorID(int id)
        {
            Venta oVenta = VentaDAO.ObtenerVentarPorIDD(id);
            if(oVenta != null)
            {
                return oVenta;
            }
            else
            {
                throw new Exception("No se pudo obtener la venta. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
            }
        }

        // Registrar Venta
        public bool RegistrarVenta(Venta oVenta, DataTable DetalleVenta)
        {
            if (oVenta != null && DetalleVenta != null)
            {
                return VentaDAO.RegistrarVentaD(oVenta, DetalleVenta);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el campo de ventas no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }

        public bool CancelarVenta(int ventaID)
        {
            if (ventaID > 0)
            {
                List<int> productosID = VentaDAO.ObtenerProductosIDPorVentaID(ventaID);
                List<Producto> listaProductos = new List<Producto>();
                ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;
                foreach (int productoID in productosID)
                {
                    Producto producto = lProducto.ObtenerProductoPorID(productoID);
                    listaProductos.Add(producto);
                }
                foreach (Producto producto in listaProductos)
                {
                    int cantidad = VentaDAO.ObtenerCantidadProductosQueSeVendieron(producto.ProductoID, ventaID);
                    producto.Stock += cantidad;
                    lProducto.ModificarProducto(producto);
                }
                return VentaDAO.CancelarVentad(ventaID);
            }
            else
            {
                throw new ArgumentException("Se ha producido un error: el campo de salida de inventario no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }



        // Contador de numero de venta si es 0000 poner como 0001
        public string ContadorDeVenta()
        {
            string numeroVenta = VentaDAO.ContadorDeVenta();
            if (numeroVenta != null)
            {
                return numeroVenta;
            }
            else
            {
                throw new Exception("Error al obtener el contador de venta. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
            }
        }

        // reporte
        public int ObtenerVentaRealizada(string tipoProducto)
        {
            return VentaDAO.ObtenerCantidadDeVentasPorTipoProducto(tipoProducto);
        }


        // OBTENER DATATABLE VENTAS POR FECHAS
        public DataTable ObtenerVentasPorFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return VentaDAO.ObtenerVentasPorFecha(fechaInicio, fechaFin);
        }

        // obtener dia de semana
        public DataTable ObtenerVentasPorSemana(DateTime fechaInici, DateTime fechaFin)
        {
            return VentaDAO.ObtenerVentasPorDiaDeLaSemana(fechaInici, fechaFin);
        }

        // ObtenerTipoProductosMasVendidos
        public DataTable ObtenerTipoProductosMasVendidos(string tipoProducto, DateTime fechaInicio, DateTime fechaFin)
        {
            return VentaDAO.ObtenerTipoProductosMasVendidos(tipoProducto, fechaInicio, fechaFin);
        }
    }
}
