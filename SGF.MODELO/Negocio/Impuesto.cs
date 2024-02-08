using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.MODELO.Negocio
{
    public class Impuesto
    {
        public int ImpuestoID { get; set; }
        public string Nombre { get; set; }
        public decimal Porcentaje { get; set; }
    }
}
