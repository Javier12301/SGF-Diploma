using SGF.DATOS.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Negocio
{
    public class VentaBLL
    {
        // Singleton de cVenta
        private static VentaBLL _instancia = null;
        private VentaBLL() { }
        public static VentaBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new VentaBLL();
                return _instancia;
            }
        }

        // Contador de numero de venta si es 0000 poner como 0001
        public string ContadorDeVenta()
        {
            string numeroVenta = VentaDAO.ContadorDeVenta();
            if (numeroVenta != null)
            {
                return numeroVenta;
            }
            else
            {
                throw new Exception("Error al obtener el contador de venta. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
            }
        }
    }
}
