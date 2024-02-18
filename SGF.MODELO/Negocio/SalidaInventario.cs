using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.MODELO.Negocio
{
    public class SalidaInventario
    {
        public int SalidaID { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaSalida { get; set; }
        public string Observaciones { get; set; }
        public bool Estado { get; set; }
    }
}
