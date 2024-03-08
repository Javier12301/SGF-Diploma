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
        public string Modulo { get; set; }
        public string NombreUsuario { get; set; }
        public string Descripcion { get; set; }
        public string Detalles { get; set; }

        public Auditoria() { }

        public Auditoria(string movimiento, string nombreUsuario, string modulo, string descripcion, string detalles)
        {
            FechayHora = DateTime.Now;
            Movimiento = movimiento;
            Modulo = modulo;
            NombreUsuario = nombreUsuario;
            Descripcion = descripcion;
            Detalles = detalles;
        }
    }
}
