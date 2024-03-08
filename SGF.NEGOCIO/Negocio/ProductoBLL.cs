using SGF.DATOS.Negocio;
using SGF.NEGOCIO.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Negocio
{
    public class ProductoBLL
    {
        // Singleton de cProducto
        private static ProductoBLL _instancia = null;

        private ProductoBLL() { }
        public static ProductoBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ProductoBLL();
                return _instancia;
            }
        }

        // Conteo de productos
        public int ConteoProductos()
        {
            int conteo = ProductoDAO.ConteoProductosD();
            return conteo;
        }

        // Obtener existencias
        public int ObtenerExistencias(int productoID)
        {
            int existencias = ProductoDAO.ObtenerExistenciasD(productoID);
            return existencias;
        }

        // Alta
        public bool AltaProducto(Producto oProducto)
        {
            if (oProducto != null)
            {                          
                return ProductoDAO.AltaProductoD(oProducto);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el campo de productos no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }

        // Modificar
        public bool ModificarProducto(Producto oProducto)
        {
            if(oProducto != null)
            {
                return ProductoDAO.ModificarProductoD(oProducto);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el campo de productos no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }

        // Baja
        public bool BajaProducto(int productoID)
        {
            if(productoID > 0)
            {
                return ProductoDAO.BajaProductoD(productoID);
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar dar de baja el producto. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
            }
        }

        // Obtener producto por ID
        public Producto ObtenerProductoPorID(int productoID)
        {
            Producto oProducto = ProductoDAO.ObtenerProductoPorIDD(productoID);

            if(oProducto != null)
            {
                return oProducto;
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar obtener el producto. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
            }
        }

        // Obtener producto usando código barras
        public Producto ObtenerProductoPorCodigo(string codigo)
        {
            Producto oProducto = ProductoDAO.ObtenerProductoPorCodigoD(codigo);
            // se manejará por interfaz si es null
            return oProducto;
        }

        public List<Categoria> ObtenerCategoriasExistentes()
        {
            List<Categoria> listaCategorias = ProductoDAO.CategoriasExistentes();
            if (listaCategorias != null)
            {
                return listaCategorias;
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar obtener las categorías existentes. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
            }
        }

        public List<Proveedor> ObtenerProveedoresExistentes()
        {
            List<Proveedor> listaProveedores = ProductoDAO.ProveedoresExistentes();
            if(listaProveedores != null)
            {
                return listaProveedores;
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar obtener los proveedores existentes. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
            }
        }

        public bool ExisteCodigo(string codigo)
        {
            bool existeCodigo = ProductoDAO.ExisteCodigoD(codigo);
            return existeCodigo;
        }

        public bool ExisteProducto(string nombre)
        {
            bool existeProducto = ProductoDAO.ExisteProductoD(nombre);
            return existeProducto;
        }

        public int ExistenciaDeProducto(string tipoProducto)
        {
            int existencia = ProductoDAO.ExistenciaProductosPorTipoProductoD(tipoProducto);
            return existencia;
        }

    }
}
