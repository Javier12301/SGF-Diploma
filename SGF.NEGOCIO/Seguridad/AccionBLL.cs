using SGF.DATOS.Seguridad;
using SGF.MODELO.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Seguridad
{
    public class AccionBLL
    {
        // Singleton de cAccion
        private static AccionBLL _instancia = null;
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private AccionBLL() { }
        public static AccionBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new AccionBLL();
                return _instancia;
            }
        }

        public Accion ObtenerAccion(string NombreModulo, string NombreAccion)
        {
            return AccionDAO.ObtenerAccionD(NombreModulo, NombreAccion);
        }
    }
}
