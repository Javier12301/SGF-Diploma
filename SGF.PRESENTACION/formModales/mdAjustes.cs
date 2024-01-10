using SGF.MODELO.Seguridad;
using SGF.NEGOCIO.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.formModales
{
    public partial class mdAjustes : Form
    {
        public string OpcionSeleccionada { get; set; }
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        public mdAjustes()
        {
            InitializeComponent();
            OpcionSeleccionada = string.Empty;
        }

        private void mdAjustes_Load(object sender, EventArgs e)
        {
            cargarPermisos();
        }

        private void cargarPermisos()
        {
            List<Modulo> modulosPermitidos = lSesion.UsuarioEnSesion().Usuario.ObtenerModulosPermitidos();

            // Módulo 'formAjustes'
            Modulo moduloAjuste = modulosPermitidos.FirstOrDefault(m => m.Descripcion == "formAjustes");

            List<Accion> accionesPermitidas = null;
            if(moduloAjuste != null)
            {
                accionesPermitidas = moduloAjuste.ListaAcciones;
            }

            // Obtener nombre del formulario actual
            string nombreFormulario = "formAjustes";

            // Buscar módulo correspondiente al formulario actual
            Modulo moduloActual = modulosPermitidos.FirstOrDefault(m => m.Descripcion == nombreFormulario);

            // Si se encuentra el módulo, cargar las opciones
            if(moduloActual != null)
            {
                foreach(Control control in flpContenedorBotones.Controls)
                {
                    if(control is Button && control.Tag != null)
                    {
                        // Obtener el nombre de la acción desde el Tag del botón
                        string nombreAccionBoton = control.Tag.ToString();

                        // Verificar si el nombre de la acción está en la lista de acciones del módulo
                        bool tienePermiso = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == nombreAccionBoton);

                        // Activar o desactivar el botón según los permisos
                        control.Enabled = tienePermiso;
                        control.Visible = tienePermiso;
                    }
                }
            }
        }
        private void btnPerfiles_Click(object sender, EventArgs e)
        {
            OpcionSeleccionada = "Perfiles";
            this.Close();
        }


        private void btnNegocio_Click(object sender, EventArgs e)
        {
            OpcionSeleccionada = "Negocio";
            this.Close();
        }

        private void btnBaseDatos_Click(object sender, EventArgs e)
        {
            OpcionSeleccionada = "Database";
            this.Close();
        }


        private void btnOtrasConfiguraciones_Click(object sender, EventArgs e)
        {
            OpcionSeleccionada = "Configuraciones";
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Interfaz
        private Point mousePosicion;
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousePosicion = e.Location;
            }
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int deltaX = e.X - mousePosicion.X;
                int deltaY = e.Y - mousePosicion.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }

       
    }
}
