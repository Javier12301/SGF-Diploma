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
                foreach (var permiso in listaPermisos)
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

        public List<Permiso> ObtenerPermisosActivos(int grupoID)
        {
            if (grupoID > 0)
            {
                return PermisoDAO.ObtenerListaPermisosActivosD(grupoID);
            }
            else
            {
                throw new Exception("Ocurrió un error al obtener los permisos, contacte con el administrador del sistema si este error persiste.");
            }
        }

        // Función para comprobar si un grupo tiene permisos asignados
        public bool GrupoTienePermisos(int grupoID)
        {
            if (grupoID > 0)
            {
                return PermisoDAO.GrupoTienePermisosD(grupoID);
            }
            else
            {
                throw new Exception("Ocurrió un error al comprobar si el grupo tiene permisos asignados, contacte con el administrador del sistema si este error persiste.");
            }
        }

        // Desactivar Permisos
        public void DesactivarPermisos(int grupoID)
        {
            if (grupoID > 0)
            {
                bool resultado = GrupoTienePermisos(grupoID);
                if (resultado)
                {
                    // Si el grupo tiene permisos, se desactivaran estos
                    PermisoDAO.DesactivarPermisosD(grupoID);
                }
                return;
            }
            else
            {
                throw new Exception("Ocurrió un error al desactivar permisos, contacte con el administrador del sistema si este error persiste.");
            }
        }

        // Obtener permisos activos
        public bool EstadoDePermiso(Permiso oPermiso)
        {
            if (oPermiso != null)
            {
                return PermisoDAO.EstadoPermisoD(oPermiso);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el grupo no puede ser nulo, contacte con el administrador si este error persiste.");
            }
        }

    }
}
