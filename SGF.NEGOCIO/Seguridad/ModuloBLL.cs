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

        public List<Modulo> ObtenerModulosConAcciones()
        {
            List<Modulo> modulos = ModuloDAO.ObtenerModulosDisponiblesD();
            foreach(var modulo in modulos)
            {
                modulo.ListaAcciones = ModuloDAO.ObtenerAccionesDeModuloD(modulo.Descripcion);
            }
            return modulos;
        }

        public Modulo ObtenerModulo(string Descripcion)
        {
            return ModuloDAO.ObtenerModuloD(Descripcion);
        }

        public Modulo ObtenerModuloID(int moduloID)
        {
            Modulo oModulo = ModuloDAO.ObtenerModuloIDD(moduloID);
            if(oModulo != null)
            {
                oModulo.ListaAcciones = ModuloDAO.ObtenerAccionesDeModuloD(oModulo.Descripcion);
                return oModulo;
            }
            else
            {
                throw new Exception("Ocurrió un error inesperado al intentar obtener el módulo, si el problema persiste contacte con el administrador del sistema.");
            }
        }
    }
}
