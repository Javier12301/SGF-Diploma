using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SGF.MODELO.Seguridad
{
    public class Modulo
    {
        public int ModuloID { get; set; }
        public string Descripcion { get; set; }
        public List<Accion> ListaAcciones { get; set; }
    }
}
