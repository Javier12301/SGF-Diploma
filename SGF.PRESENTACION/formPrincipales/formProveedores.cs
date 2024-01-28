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
    public partial class formProveedores : Form
    {
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private Permiso permisosDeUsuario;

        public formProveedores()
        {
            InitializeComponent();
        }

        private void formProveedores_Load(object sender, EventArgs e)
        {
            cargarPermisos();
        }

        private void cargarPermisos()
        {
            permisosDeUsuario = new Permiso();
            // NO OLVIDARSE DE CAMBIAR LA FUNCIÓN A TODOS LOS FORMS
            uiUtilidades.cargarPermisos(this.GetType().Name, flpContenedorBotones, permisosDeUsuario);
        }

        private void btnNuevoP_Click(object sender, EventArgs e)
        {

        }
    }
}
