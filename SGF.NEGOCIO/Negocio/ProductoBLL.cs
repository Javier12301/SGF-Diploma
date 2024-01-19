using SGF.DATOS.Negocio;
using SGF.NEGOCIO.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        // Alta

        // Modificar

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

    }
}
