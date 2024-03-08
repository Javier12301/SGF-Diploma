using SGF.DATOS.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Negocio
{
    public class ClienteBLL
    {
        private static ClienteBLL _instancia = null;
        private ClienteBLL() { }
        public static ClienteBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ClienteBLL();
                return _instancia;
            }
        }

        // listar cliente
        public List<Cliente> ListarClientes()
        {
            try
            {
                return ClienteDAO.ListarClientes();
            }
            catch (Exception)
            {
                throw new Exception("Se ha producido un error al intentar obtener la lista de clientes.");
            }
        }

    }
}
