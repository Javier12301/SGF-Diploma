using SGF.MODELO.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.MODELO.Negocio
{
    public class Registro
    {
        public int RegistroID { get; set; }
        public DateTime FechayHora { get; set; }
        public string Movimiento { get; set; }
        public string NombreUsuario { get; set; }
        public int Cantidad { get; set; }
        public int CantidadAntes { get; set; }
        public int CantidadDespues { get; set; }
        public string ModuloUsado { get; set; }
        public string Descripcion { get; set; }

        public Registro() { }

        public Registro(string movimiento, string nombreUsuario, int cantidad, int cantidadAntes, int cantidadDespues, string Modulo,string descripcion)
        {
            FechayHora = DateTime.Now;
            Movimiento = movimiento;
            NombreUsuario = nombreUsuario;
            Cantidad = cantidad;
            CantidadAntes = cantidadAntes;
            CantidadDespues = cantidadDespues;
            ModuloUsado = Modulo;
            Descripcion = descripcion;
        }

    }
}
