using SGF.DATOS.Seguridad;
using SGF.MODELO;
using SGF.MODELO.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Seguridad
{
    public class PermisoBLL
    {
        // Singleton de cPermiso
        private static PermisoBLL _instancia = null;
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private PermisoBLL() { }
        public static PermisoBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new PermisoBLL();
                return _instancia;
            }
        }

        // Agregar Permiso a Grupo
        public bool AgregarPermisos(List<Permiso> listaPermisos)
        {
            if (listaPermisos != null && listaPermisos.Count > 0)
            {
                bool resultado = true;
                foreach(var permiso in listaPermisos)
                {
                    resultado &= PermisoDAO.AltaPermisoD(permiso);
                }
                return resultado;
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: la lista de permisos no puede ser nula o vacía, contacte con el administrador si este error persiste.");
            }
        }

    }
}
