using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.MODELO.Negocio
{
    public class NegocioModelo
    {
        public int NegocioID { get; set; }
        public string Nombre { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool Impuestos { get; set; }
        public byte[] Logo { get; set; }
        public Moneda moneda { get; set; }
        public Impuesto impuesto { get; set; }
    }
}
