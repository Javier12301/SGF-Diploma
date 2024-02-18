using SGF.DATOS.Negocio;
using SGF.MODELO.Negocio;
using SGF.NEGOCIO.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Negocio
{
    public class RegistroBLL
    {
        // Singleton de cAuditoria
        private static RegistroBLL _instancia = null;
        private RegistroBLL() { }
        public static RegistroBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new RegistroBLL();
                return _instancia;
            }
        }

        // Conteo de registros
        public static int ConteoRegistros()
        {
            int conteo = RegistroDAO.ConteoRegistrosD();
            return conteo;
        }

        public static void RegistrarMovimiento(string movimiento, string NombreUsuario, int cantidad, int cantidadAntes, int cantidadDespues, string modulo,string descripcion)
        {
            // Registramos la auditoria
            Registro registro = new Registro(movimiento, NombreUsuario, cantidad, cantidadAntes, cantidadDespues, modulo ,descripcion);
            bool registroRealizado = RegistroDAO.RegistrarMovimiento(registro);
            if (!registroRealizado)
            {
                throw new Exception("Ocurrió un error al registrar el movimiento, por favor contacte al administrador para solucionar este error.");
            }
        }

        public static List<Registro> ListarRegistros()
        {
            List<Registro> listaRegistro = RegistroDAO.ListarRegistrosD();
            if(listaRegistro != null)
            {
                return listaRegistro;
            }
            else
            {
                throw new Exception("Ocurrió un error inesperado al intentar listar los registros, contactar con el administrador del sistema si el error persiste.");
            }
        }

        // baja registro
        public static bool BajaRegistro(int idRegistro)
        {
            if (idRegistro > 0)
            {
                return RegistroDAO.BajaRegistroD(idRegistro);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el campo de registros no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }
    }
}
