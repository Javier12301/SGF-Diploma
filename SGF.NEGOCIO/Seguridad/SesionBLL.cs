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
    public class SesionBLL
    {
        private static SesionBLL _instancia = null;
        private SesionBLL() { }
        public static SesionBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SesionBLL();
                return _instancia;
            }
        }

        public Sesion UsuarioEnSesion()
        {
            Sesion _sesionON = Sesion.ObtenerInstancia;
            return _sesionON;
        }

        public void Login(Usuario usuario)
        {
            Sesion.IniciarSesion(usuario);
            AuditoriaBLL.RegistrarMovimiento("Inicio de sesión", usuario.NombreUsuario, "Inicio de sesión exitoso");
        }

        public void Logout()
        {
            AuditoriaBLL.RegistrarMovimiento("Sesión cerrada", UsuarioEnSesion().Usuario.NombreUsuario, "Sesión cerrada con éxito");
            Sesion.CerrarSesion();
        }
    }
}
