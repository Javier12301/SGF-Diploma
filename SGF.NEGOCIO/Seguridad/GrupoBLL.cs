using SGF.DATOS.Seguridad;
using SGF.MODELO.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Seguridad
{
    public class GrupoBLL
    {
        // Singleton de cGrupo
        private static GrupoBLL _instancia = null;
        private GrupoBLL() { }
        public static GrupoBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new GrupoBLL();
                return _instancia;
            }
        }

        // Permisos que tiene este grupo
        public static List<Accion> ListarAccionesDisponibles(int usuarioID, Modulo descripcion)
        {
            List<Accion> acciones = new List<Accion>();
            return  acciones;
        }

        // Obtener los modulos permitido del grupo
        public List<Modulo> ObtenerModulosPermitidos(int usuarioID)
        {
            List<Modulo> modulosPermitidos = UsuarioDAO.ObtenerModulosPermitidosD(usuarioID);
            if (modulosPermitidos != null)
            {
                return modulosPermitidos;
            }
            else
            {
                throw new Exception("Ocurrió un error inesperado al intentar obtener los permisos, contactar con el administrador si el error persiste.");
            }
        }
    }
}
