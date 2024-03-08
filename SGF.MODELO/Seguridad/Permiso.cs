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

        // Permisos Alta, Modificar y Baja //
        // Este modelo será utilizado para manejo de interfaz//
        // No son valores de base de datos //
        public bool Alta { get; set; }
        public bool Modificar { get; set; }
        public bool Baja { get; set; }
        public bool Detalles { get; set; }
        public bool Importar { get; set; }
        public bool Exportar { get; set; }
        public bool Imprimir { get; set; }
        public bool Grafico { get; set; }
        public bool Cancelar { get; set; }
        public bool EntradaMasiva { get; set; }
        public bool SalidaMasiva { get; set; }
        public bool GenerarReporte { get; set; }
        public bool GenerarRegistro { get; set; }



        public string ObtenerNombre()
        {
            return this.Modulo.Descripcion + @" - " + this.Accion.Descripcion;
        }
    }
}
