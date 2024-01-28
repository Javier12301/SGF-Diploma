using SGF.MODELO.Seguridad;
using SGF.NEGOCIO.Seguridad;
using SGF.PRESENTACION.UtilidadesComunes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.formPrincipales
{
    public partial class formReportes : Form
    {
        SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        Permiso permisoDeUsuario;
        public formReportes()
        {
            InitializeComponent();
        }

        private void formReportes_Load(object sender, EventArgs e)
        {
            cargarPermisos();
        }

        private void cargarPermisos()
        {
            permisoDeUsuario = new Permiso();
            uiUtilidades.cargarPermisos(this.GetType().Name, flpContenedorBotones, permisoDeUsuario);
        }

    }
}
