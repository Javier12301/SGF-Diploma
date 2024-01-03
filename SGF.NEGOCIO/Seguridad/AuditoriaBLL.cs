using SGF.DATOS.Seguridad;
using SGF.MODELO.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Seguridad
{
    public class AuditoriaBLL
    {
        // Singleton de cAuditoria
        private static AuditoriaBLL _instancia = null;
        private AuditoriaBLL() { }
        public static AuditoriaBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new AuditoriaBLL();
                return _instancia;
            }
        }

        public static void RegistrarMovimiento(string movimiento, string nombreUsuario, string descripcion)
        {
            // Registramos la auditoria
            Auditoria auditoria = new Auditoria(movimiento, nombreUsuario, descripcion);
            bool registroRealizado = AuditoriaDAO.RegistrarMovimiento(auditoria);
            if (!registroRealizado)
            {
                throw new Exception("Ocurrió un error al registrar el movimiento, por favor contacte al administrador para solucionar este error.");
            }

        }

    }
}
