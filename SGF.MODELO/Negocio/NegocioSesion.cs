using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.MODELO.Negocio
{
    public class NegocioSesion
    {
        // La clase negocio sesión tiene la responsabilidad de manejar los datos del negocio apenas se inicie la aplicación
        // Esto es distinto a la clase sesion que maneja los datos del usuario que inicia sesión
        // esta maneja por así decilor los datos de la empresa, y se carga apenas se inicia la aplicación

        private static NegocioSesion _instancia = null;
        // en vez de almacenar Usuario, esta clase almacena un objeto de tipo NegocioModelo
        public NegocioModelo DatosDelNegocio { get; set; }

        private NegocioSesion()
        {       
        }

        public static NegocioSesion ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new NegocioSesion();
                }
                return _instancia;
            }
        }

        public static void CargarDatos(NegocioModelo negocio)
        {
            if(negocio != null)
            {
                NegocioSesion negocioSesion = NegocioSesion.ObtenerInstancia;
                negocioSesion.DatosDelNegocio = negocio;
            }
            else
            {
                throw new Exception("Ocurrió un error al cargar los datos del negocio, por favor contacte con el administrador del sistema para solucionar el problema.");
            }
        }

        public static void ModificarDatos(NegocioModelo negocio)
        {
            if(negocio != null)
            {
                NegocioSesion negocioSesion = NegocioSesion.ObtenerInstancia;
                if(negocioSesion.DatosDelNegocio != null)
                {
                    negocioSesion.DatosDelNegocio = negocio;
                }
                else
                {
                    throw new Exception("Los datos del negocio no han sido cargados.");
                }
            }
            else
            {
                throw new Exception("Ocurrió un error al modificar los datos del negocio, por favor contacte con el administrador del sistema para solucionar el problema.");
            }
        }
    }
}
