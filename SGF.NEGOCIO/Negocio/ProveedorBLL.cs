using SGF.DATOS.Negocio;
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
    }
}
