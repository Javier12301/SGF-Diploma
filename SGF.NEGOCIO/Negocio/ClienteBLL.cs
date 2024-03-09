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

        // Alta cliente
        public bool AltaCliente(Cliente oCliente)
        {
            if (oCliente != null)
            {
                return ClienteDAO.AltaCliente(oCliente);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el campo de clientes no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }

        // modificar cliente
        public bool ModificarCliente(Cliente oCliente)
        {
            if (oCliente != null)
            {
                return ClienteDAO.ModificarCliente(oCliente);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el campo de clientes no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }

        // baja cliente
        public bool BajaCliente(int clienteID)
        {
            if (clienteID > 0)
            {
                return ClienteDAO.BajaCliente(clienteID);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el campo de clientes no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }

        public int ConteoClientes()
        {
            int conteo = ClienteDAO.ConteoClientesD();
            if (conteo >= 0)
            {
                return conteo;
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar obtener el conteo de clientes. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
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

        // Obtener tipocliente por descripcion
        public TipoCliente ObtenerTipoClientePorDescripcion(string descripcion)
        {
            TipoCliente oTipoCliente = ClienteDAO.ObtenerTipoClientePorDescripcion(descripcion);
            if (oTipoCliente != null)
            {
                return oTipoCliente;
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar obtener el tipo de cliente. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
            }
        }

        // Alta tipocliente
        public int AltaTipoCliente(TipoCliente oTipoCliente)
        {
            if (oTipoCliente != null)
            {
                return ClienteDAO.AltaTipoCliente(oTipoCliente.Descripcion);
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar dar de alta el tipo de cliente. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
            }
        }

        // existe tipo cliente ? bool
        public bool ExisteTipoCliente(string descripcion)
        {
            return ClienteDAO.ExisteTipoCliente(descripcion);
        }

        // Existe cliente comparar con documento y tipodocumento
        public bool ExisteCliente(string documento, string tipoDocumento)
        {
            return ClienteDAO.ExisteDocumentoCliente(tipoDocumento, documento);
        }

        // listar tipo cliente
        public List<TipoCliente> ListarTipoCliente()
        {
            try
            {
                return ClienteDAO.ListarTipoClientes();
            }
            catch (Exception)
            {
                throw new Exception("Se ha producido un error al intentar obtener la lista de tipos de clientes.");
            }
        }

        // obtener cliente por id
        public Cliente ObtenerClientePorID(int clienteID)
        {
            Cliente oCliente = ClienteDAO.ObtenerClientePorIDD(clienteID); 
            if(oCliente != null)
            {
                return oCliente;
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar obtener el cliente. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
            }
        }

    }
}
