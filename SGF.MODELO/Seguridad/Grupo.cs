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

        // Retornaremos el nombre del grupo
        public string ObtenerNombre()
        {
            return Nombre;
        }
    }
}
