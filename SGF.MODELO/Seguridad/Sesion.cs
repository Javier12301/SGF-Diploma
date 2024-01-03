using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SGF.MODELO.Seguridad
{
    public class Sesion
    {
        public Usuario Usuario { get; set; }

        private Sesion()
        {
        }

        // Método para obtener la instancia actual
        public static Sesion ObtenerInstancia
        {
            get
            {
                return _session;
            }
        }

        private static Sesion _session;
        // Iniciar la sesión
        public static void IniciarSesion(Usuario usuario)
        {
            if (_session == null)
            {
                _session = new Sesion();
            }

            if (_session.Usuario == null)
            {
                // Si no hay un usuario actualmente en sesión, se establece el nuevo usuario
                _session.Usuario = usuario;
            }
            else if (_session.Usuario.NombreUsuario == usuario.NombreUsuario)
            {
                // Si el mismo usuario intenta iniciar sesión nuevamente, lanza una excepción
                throw new Exception("Este usuario ya ha iniciado sesión.");
            }
            else
            {
                // Si otro usuario intenta iniciar sesión mientras hay una sesión activa, lanza una excepción
                throw new Exception("Otro usuario ya ha iniciado sesión.");
            }
        }

        // Cerrar la sesión
        public static void CerrarSesion()
        {
            if (_session != null)
            {
                _session = null;
            }
            else
            {
                throw new Exception("No hay sesión iniciada.");
            }
        }
    }

}
