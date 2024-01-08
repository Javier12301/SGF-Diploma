using SGF.DATOS.Seguridad;
using SGF.MODELO.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Seguridad
{
    public class ModuloBLL
    {
        // Singleton de cSeguridad
        private static ModuloBLL _instancia = null;
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private ModuloBLL() { }
        public static ModuloBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new ModuloBLL();
                return _instancia;
            }
        }

        public List<Modulo> ObtenerListaModulosDisponibles()
        {
            List<Modulo> modulos = ModuloDAO.ObtenerModulosDisponiblesD();
            if(modulos != null || modulos.Count > 0)
            {
                return modulos;
            }
            else
            {
                throw new Exception("Ocurrió un error al obtener los modulos disponibles en el sistema, si este error persiste contacte con el administrador del sistema.");
            }
        }


    }
}
