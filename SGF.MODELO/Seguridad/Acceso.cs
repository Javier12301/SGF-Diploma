using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.MODELO.Seguridad
{
    public class Acceso
    {
        public int AccesoID { get; set; }
        public string NombreUsuario { get; set; }
        public string Login { get; set; }
        public DateTime FechayHoraEntrada { get; set; }
        public string Logout { get; set; }
        public DateTime FechayHoraSalida { get; set; }    }
}
