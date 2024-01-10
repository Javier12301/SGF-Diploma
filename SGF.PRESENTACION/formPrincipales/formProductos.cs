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
using SGF.PRESENTACION.formModales;
using System.Windows.Forms;

namespace SGF.PRESENTACION.formPrincipales
{
    public partial class formProductos : Form
    {
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        public formProductos()
        {
            InitializeComponent();
        }

        private void formProductos_Load(object sender, EventArgs e)
        {
            cargarPermisos();
        }

        private void cargarPermisos()
        {
            List<Modulo> modulosPermitidos = lSesion.UsuarioEnSesion().Usuario.ObtenerModulosPermitidos();

            // Módulo 'formProductos' 
            Modulo moduloProductos = modulosPermitidos.FirstOrDefault(m => m.Descripcion == "formProductos");

            // Si se encuentra el módulo 'formProductos', obtener las acciones permitidas
            List<Accion> accionesPermitidas = null;
            if (moduloProductos != null)
            {
                accionesPermitidas = moduloProductos.ListaAcciones;
            }

            // Obtener el nombre del formulario actual
            string nombreFormulario = this.GetType().Name;

            // Buscar el módulo correspondiente al formulario actual
            Modulo moduloActual = modulosPermitidos.FirstOrDefault(m => m.Descripcion == nombreFormulario);

            // Si se encuentra el módulo, cargar las opciones
            if (moduloActual != null)
            {
                foreach (Control control in flpContenedorBotones.Controls)
                {
                    if (control is Button && control.Tag != null)
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

            // Verificar si el módulo 'formCategorias' está permitido
            Modulo moduloCategoria = modulosPermitidos.FirstOrDefault(m => m.Descripcion == "formCategorias");
            if (moduloCategoria != null)
            {
                btnCategorias.Enabled = true;
                btnCategorias.Visible = true;
            }
        }


        private void btnNuevoP_Click(object sender, EventArgs e)
        {

        }

        private void btnModificarP_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarP_Click(object sender, EventArgs e)
        {

        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            if (btnCategorias.Enabled)
            {
                using(var modal = new mdCategorias())
                {
                    var resultado = modal.ShowDialog();
                    if(resultado == DialogResult.OK)
                    {
                        // Actualizar el combobox de categorías
                    }
                }
            }
        }

        private void btnImportarP_Click(object sender, EventArgs e)
        {

        }

        private void btnExportarP_Click(object sender, EventArgs e)
        {

        }
    }
}
