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

        // Relación con grupo de usuarios
        public virtual List<Grupo> Grupos { get; set; }

        public override string ToString()
        {
            // Retornaremos apellido nombre y nombre de usuario
            // se utilizará para mostrar el dato de usuario
            return Apellido + " " + Nombre + " (" + NombreUsuario + ")";
        }
    }
}
