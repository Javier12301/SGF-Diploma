using SGF.DATOS.Negocio;
using SGF.MODELO;
using SGF.NEGOCIO.Seguridad;
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

        // Conteo de categorías
        public int ConteoCategorias()
        {
            int conteo = CategoriaDAO.ConteoCategoriasD();
            return conteo;
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
        public int HabilitarProductos(int categoriaID)
        {
            int productosHabilitados = CategoriaDAO.HabilitarProductos(categoriaID);
            return productosHabilitados;
        }

        // Deshabilitar productos
        public int DeshabilitarProductos(int categoriaID)
        {
            int productosDeshabilitado = CategoriaDAO.DeshabilitarProductos(categoriaID);
            return productosDeshabilitado;
        }

        // Conteo de productos en categoría
        public int ConteoProductosEnCategoria(int categoriaID)
        {
            int conteo = CategoriaDAO.ConteoProductosEnCategoriaD(categoriaID);
            return conteo;
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

        // Conteo categoria con productos
        public int ConteoCategoriasConProductos()
        {
            int conteo = CategoriaDAO.ConteoCategoriasConProductosD();
            return conteo;
        }


    }
}
