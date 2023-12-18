using SGF.MODELO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SGF.BLL.Seguridad
{
    public class SeguridadLogica
    {
        // Testearemos el sistema, haremos una instancia del contexto de la base de datos
        DAL.FarmaciaContext oFarmaciaContext;

        // Singleton de cSeguridad
        private static SeguridadLogica _instancia = null;
        private SeguridadLogica() { }
        public static SeguridadLogica ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SeguridadLogica();
                return _instancia;
            }
        }

        // Obtener tabla de Usuarios
        public List<Usuario> ObtenerUsuarios()
        {
            using (oFarmaciaContext = new DAL.FarmaciaContext())
            {
                return oFarmaciaContext.Usuarios.ToList();
            }

        }

    }
}
