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
        public Grupo Grupo { get; set; }
        public Accion Accion { get; set; }
        public Modulo Modulo { get; set; }
        public bool Permitido { get; set; }

        public string ObtenerNombre()
        {
            return this.Modulo.Descripcion + @" - " + this.Accion.Descripcion;
        }
    }
}
