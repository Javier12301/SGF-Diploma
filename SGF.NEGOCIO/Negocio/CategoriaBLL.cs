using SGF.DATOS.Negocio;
using SGF.MODELO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Negocio
{
    public class CategoriaBLL
    {
        // Singleton de cCategoria
        private static CategoriaBLL _instancia = null;
        private CategoriaBLL() { }
        public static CategoriaBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CategoriaBLL();
                return _instancia;
            }
        }

        // Alta
        public bool AltaCategoria(Categoria oCategoria)
        {
            if (oCategoria != null)
            {
                return CategoriaDAO.AltaCategoriaD(oCategoria);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el campo de categorías no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }

        // Modificar
        public bool ModificarCategoria(Categoria oCategoria)
        {
            if (oCategoria != null)
            {
                return CategoriaDAO.ModificarCategoriaD(oCategoria);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el campo de categorías no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }

        // Baja
        public bool BajaCategoria(Operacion operacion)
        {
            bool resultado = true;
            switch (operacion.NombreOperacion)
            {
                case "EliminarCategoria":
                    return EliminarCategoria(operacion);
                case "AsignarProductosSinCategoria":
                    resultado &= AsignarProductosSinCategoria(operacion);
                    resultado &= EliminarCategoria(operacion);
                    return resultado;
                case "EliminarCategoriaYProductos":
                    List<int> listaProductosID = ListarProductosIDEnCategoria(operacion.ID);
                    foreach (var productoID in listaProductosID)
                    {
                        resultado &= ProductoBLL.ObtenerInstancia.BajaProducto(productoID);
                    }
                    resultado &= EliminarCategoria(operacion);
                    return resultado;
                default:
                    throw new Exception("Ocurrió un error inesperado al intentar eliminar la categoría, contactar con el administrador del sistema si el error persiste.");
            }
        }

        private List<int> ListarProductosIDEnCategoria(int categoriaID)
        {
            List<int> listaProductosID = CategoriaDAO.ListarProductosEnCategoriaID(categoriaID);
            return listaProductosID;
        }

        private bool AsignarProductosSinCategoria(Operacion operacion)
        {
            bool resultado = true;
            List<int> listaProductoID = ListarProductosIDEnCategoria(operacion.ID);
            foreach (var productoID in listaProductoID)
            {
                resultado &= CategoriaDAO.AsignarProductosSinCategoriaD(productoID);
            }
            return resultado;
        }

        private bool EliminarCategoria(Operacion operacion)
        {
            return CategoriaDAO.BajaCategoriaD(operacion.ID);
        }

        // Habilitar productos
        public bool HabilitarProductos(int categoriaID)
        {
            bool habilitado = CategoriaDAO.HabilitarProductos(categoriaID);
            return habilitado;
        }

        // Deshabilitar productos
        public bool DeshabilitarProductos(int categoriaID)
        {
            bool deshabilitado = CategoriaDAO.DeshabilitarProductos(categoriaID);
            return deshabilitado;
        }

        // Comprobar si la categoría tiene productos asignados
        public bool CategoriaTieneProductos(int categoriaID)
        {
            bool tieneProductos = CategoriaDAO.CategoriaTieneProductosD(categoriaID);
            return tieneProductos;
        }

        // Comprobar existencia
        public bool ExisteCategoria(string nombre)
        {
            bool existeCategoria = CategoriaDAO.ExisteCategoriaD(nombre);
            return existeCategoria;
        }

        // Obtener lista categorías
        public List<Categoria> ListarCategorias()
        {
            List<Categoria> listaCategorias = CategoriaDAO.ListarCategoriasD();
            if (listaCategorias != null)
            {
                return listaCategorias;
            }
            else
            {
                throw new Exception("Ocurrió un error inesperado al intentar listar las categorías, contactar con el administrador del sistema si el error persiste.");
            }
        }

        // Obtener por ID
        public Categoria ObtenerCategoriaPorID(int categoriaID)
        {
            Categoria oCategoria = CategoriaDAO.ObtenerCategoriaPorIDD(categoriaID);
            if (oCategoria != null)
            {
                return oCategoria;
            }
            else
            {
                throw new Exception("Ocurrió un error inesperado al intentar obtener la categoría, contactar con el administrador del sistema si el error persiste.");
            }
        }
    }
}
