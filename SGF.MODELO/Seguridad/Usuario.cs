using SGF.MODELO.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.MODELO
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }

        // Información de la persona
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int DNI { get; set; }
        public bool Estado { get; set; }

        public Grupo Grupo { get; set; }
        public List<Modulo> ModulosPermitidos { get; set; }

        public string ObtenerNombreUsuario()
        {
            return NombreUsuario;
        }

        public string ObtenerNombreyApellido()
        {
            return $"{Nombre} {Apellido}";
        }

        public List<Modulo> ObtenerModulosPermitidos()
        {
            return ModulosPermitidos;
        }

        public string GrupoPerteneciente()
        {
            return Grupo.ObtenerNombre();
        }
    }

}
