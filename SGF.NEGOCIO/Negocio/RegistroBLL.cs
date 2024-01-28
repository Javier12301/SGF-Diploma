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

    }
}
