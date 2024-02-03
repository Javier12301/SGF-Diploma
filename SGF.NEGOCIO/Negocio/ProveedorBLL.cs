using SGF.DATOS.Negocio;
using SGF.MODELO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Negocio
{
    public class ProveedorBLL
    {
        // Singleton de cPrveedor
        private static ProveedorBLL _instancia = null;
        private ProveedorBLL() { }
        public static ProveedorBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ProveedorBLL();
                return _instancia;
            }
        }

        // Conteo de proveedores
        public int ConteoProveedores()
        {
            int conteo = ProveedorDAO.ConteoProveedoresD();
            if (conteo >= 0)
            {
                return conteo;
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar obtener el conteo de proveedores. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
            }
        }

        // Alta
        public bool AltaProveedor(Proveedor oProveedor)
        {
            if (oProveedor != null)
            {
                return ProveedorDAO.AltaProveedorD(oProveedor);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el campo de proveedores no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }

        // Modificar
        public bool ModificarProveedor(Proveedor oProveedor)
        {
            if (oProveedor != null)
            {
                return ProveedorDAO.ModificarProveedorD(oProveedor);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el campo de proveedores no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }

        // Baja
        public bool BajaProveedor(Operacion operacion)
        {
            bool resultado = true;
            switch (operacion.NombreOperacion)
            {
                case "EliminarProveedor":
                    return EliminarProveedor(operacion);
                case "AsignarProductosSinProveedor":
                    resultado &= AsignarProductosSinProveedor(operacion);
                    resultado &= EliminarProveedor(operacion);
                    return resultado;
                case "EliminarProveedorYProductos":
                    List<int> listaProductoID = ListarProductosIDEnProveedor(operacion.ID);
                    foreach (var productoID in listaProductoID)
                    {
                        resultado &= ProductoBLL.ObtenerInstancia.BajaProducto(productoID);
                    }
                    resultado &= EliminarProveedor(operacion);
                    return resultado;
                default:
                    throw new Exception("Ocurrió un error al intentar eliminar el proveedor, contacte con el administrador del sistema si este error persiste.");
            }
        } 

        public List<int> ListarProductosIDEnProveedor(int proveedorID)
        {
            List<int> listaProductosID = ProveedorDAO.ListarProductosEnProveedorD(proveedorID);
            return listaProductosID;
        }

        private bool AsignarProductosSinProveedor(Operacion operacion)
        {
            bool resultado = true;
            List<int> listaProductoID = ListarProductosIDEnProveedor(operacion.ID);
            foreach (var productoID in listaProductoID)
            {
                resultado &= ProveedorDAO.AsignarProductosSinProveedorD(productoID);
            }
            return resultado;
        }

        private bool EliminarProveedor(Operacion operacion)
        {
            int proveedorID = operacion.ID;
            return ProveedorDAO.BajaProveedorD(proveedorID);
        }

        // Obtener lista proveedores
        public List<Proveedor> ListaProveedores()
        {
            List<Proveedor> listaProveedores = ProveedorDAO.ListaProveedoresD();
            if (listaProveedores != null)
            {
                return listaProveedores;
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar obtener la lista de proveedores. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
            }
        }

        // Comprobar si proveedor tiene produtos asignados
        public bool ProveedorTieneProductos(int proveedorID)
        {
            bool tieneProductos = ProveedorDAO.ProveedorTieneProductosD(proveedorID);
            return tieneProductos;
        }

        // Razón social existente
        public bool ExisteRazonSocial(string razonSocial)
        {
            bool existe = ProveedorDAO.RazonSocialExistenteD(razonSocial);
            if (existe)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Obtener proveedor por ID
        public Proveedor ObtenerProveedorPorID(int proveedorID)
        {
            Proveedor oProveedor = ProveedorDAO.ObtenerProvedorPorIDD(proveedorID);
            if (oProveedor != null)
            {
                return oProveedor;
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar obtener el proveedor. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
            }
        }
    }
}
