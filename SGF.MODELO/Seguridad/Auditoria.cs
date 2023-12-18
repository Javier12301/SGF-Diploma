using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.MODELO.Seguridad
{
    public class Auditoria
    {
        public int AuditoriaID { get; set; }
        public DateTime FechayHora { get; set; }
        public string Movimiento { get; set; } 
        public string NombreUsuario { get; set; }
        public string Descripcion { get; set; }
        public string Permiso { get; set; }
    }
}
