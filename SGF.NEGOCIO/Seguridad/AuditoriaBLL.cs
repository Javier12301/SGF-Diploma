using SGF.DATOS.Seguridad;
using SGF.MODELO.Seguridad;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGF.NEGOCIO.Negocio;

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

        public static void RegistrarMovimiento(string movimiento, string nombreUsuario, string modulo, string descripcion, string detalles = null)
        {
            // Registramos la auditoria
            Auditoria auditoria = new Auditoria(movimiento, nombreUsuario, modulo, descripcion, detalles);
            bool registroRealizado = AuditoriaDAO.RegistrarMovimiento(auditoria);
            if (!registroRealizado)
            {
                throw new Exception("Ocurrió un error al registrar el movimiento, por favor contacte al administrador para solucionar este error.");
            }
        }
      
        public static List<Auditoria> ObtenerListaAuditoria()
        {
            List<Auditoria> listaAuditoria = AuditoriaDAO.ObtenerListaAuditoriaD();
            return listaAuditoria;
        }

        public static Auditoria ObtenerAuditoriaID(int AuditoriaID)
        {
            Auditoria auditoria = AuditoriaDAO.ObtenerAuditoriaIDD(AuditoriaID);
            if(auditoria != null)
            {
                return auditoria;
            }
            else
            {
                throw new Exception("Ocurrió un error al obtener la auditoría, por favor contacte al administrador para solucionar este error.");
            }
        }

        public static DataTable ObtenerMovimientos(string usuario, DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = AuditoriaDAO.ObtenerMovimientosD(usuario, fechaInicio, fechaFin);
            if(dt != null)
            {
                return dt;
            }
            else
            {
                throw new Exception("Ocurrió un error al obtener los movimientos, por favor contacte al administrador para solucionar este error.");
            }
        }

    }
}
