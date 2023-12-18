using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.MODELO.Seguridad
{
    public class Permiso
    {
        public int PermisoID { get; set; }
        public string Accion { get; set; }
        public string Formulario { get; set; }
        public string Descripcion { get; set; }

        // Relaciones
        public virtual List<Grupo> Grupos { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
