using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.MODELO.Seguridad
{
    public class Grupo
    {
        public int GrupoID { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }

        // Relaciones con otras tablas
        public virtual List<Usuario> Usuarios { get; set; }
        public virtual List<Permiso> Permisos { get; set; }

        // Retornaremos el nombre del grupo
        public override string ToString()
        {
            return Nombre;
        }
    }
}
