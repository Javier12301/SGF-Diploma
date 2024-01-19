using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Negocio
{
    public class Proveedor
    {
        public int ProveedorID { get; set; }
        public string RazonSocial { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }
    }
}
