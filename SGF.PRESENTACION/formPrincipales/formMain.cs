using SGF.MODELO;
using SGF.MODELO.Negocio;
using SGF.MODELO.Seguridad;
using SGF.NEGOCIO;
using SGF.NEGOCIO.Negocio;
using SGF.NEGOCIO.Seguridad;
using SGF.PRESENTACION.formModales;
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
    public partial class formMain : Form
    {
        private Form formularioActivo;
        private ToolStripButton botonActivo;

        // Controladoras
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private UsuarioBLL lUsuario = UsuarioBLL.ObtenerInstancia;
        private NegocioBLL lNegocio = NegocioBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;

        // Usuario que inicio sesión      
        public formMain()
        {
            InitializeComponent();
        }

        // Función para cargar el usuario que inicio sesión
        private void formMain_Load(object sender, EventArgs e)
        {
            try
            {
                cargarNegocio();
                cargarSesion();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarNegocio()
        {
            NegocioModelo negocio = lNegocio.NegocioEnSesion().DatosDelNegocio;
            if(negocio.Logo != null)
            {
                // cambiar icono del formulario
                this.Icon = uiUtilidades.ByteArrayToIcon(negocio.Logo);
            }
            else
            {
                this.Icon = uiUtilidades.ImageToIcon(uiUtilidades.LogoPorDefecto());
            }
            this.Text = negocio.Nombre;
        }

        private void cargarSesion()
        {
            lblUsuario.Text = lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario();
            lblGrupo.Text = lSesion.UsuarioEnSesion().Usuario.GrupoPerteneciente();
            List<Modulo> modulosPermitidos = lSesion.UsuarioEnSesion().Usuario.ObtenerModulosPermitidos();

            foreach (ToolStripItem item in tsSuperior.Items)
            {
                if (item is ToolStripButton && ((ToolStripButton)item).Tag != null)
                {
                    // Descripción del módulo del tag del botón
                    string descripcionModulo = ((ToolStripButton)item).Tag.ToString();
                    // Verificar los modulos permitidos, los que no desactivar.
                    bool moduloPermitido = modulosPermitidos.Any(modulo => modulo.Descripcion == descripcionModulo);

                    if (moduloPermitido)
                    {
                        ((ToolStripButton)item).Enabled = true;
                        ((ToolStripButton)item).Visible = true;
                    }
                    else
                    {
                        ((ToolStripButton)item).Enabled = false;
                        ((ToolStripButton)item).Visible = false;
                    }
                }
            }
            btnLogOut.Enabled = true;
            btnLogOut.Visible = true;
        }


        private void activarBoton(ToolStripButton btnSender)
        {
            if (btnSender != null)
            {
                if (botonActivo != btnSender)
                {
                    // Desactiva el botón que estaba activo
                    if (botonActivo != null)
                    {
                        desactivarBoton(botonActivo);
                    }

                    // Activamos el botón que fue presionado
                    botonActivo = btnSender;
                    // Color azul predeterminado del sistema
                    botonActivo.BackColor = Color.FromArgb(4, 127, 176);
                    // cambiamos el color del borde
                    // Color blanco para el texto
                    botonActivo.ForeColor = Color.White;
                }
            }
        }

        private void desactivarBoton(ToolStripButton btnSender)
        {
            // Color blanco predeterminado del sistema
            btnSender.BackColor = Color.FromArgb(242, 248, 255);
            // cambiamos el color del borde a silver
            btnSender.ForeColor = Color.Black;
        }

        // Abrir Formularios dentro del panel padre
        private void abrirFormularioHijo(Form formularioHijo, ToolStripButton btnSender)
        {
            Cursor.Current = Cursors.WaitCursor;
            // Resaltamos el botón activado
            activarBoton(btnSender);

            // Si hay un formulario abierto, lo cerramos
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }
            // Abrimos el formulario hijo
            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            pnlPadre.Controls.Add(formularioHijo);
            pnlPadre.Tag = formularioHijo;
            // Ponemos al frente el formulario hijo
            formularioHijo.BringToFront();

            // Abrimos el formulario
            formularioHijo.Show();
            Cursor.Current = Cursors.Default;
        }

        // Configuramos la barra de navegación
        private void btnVentas_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new formVentas(), btnVentas);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new formProductos(), btnProductos);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new formProveedores(), btnProveedor);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new formInventario(), btnInventario);
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new formRegistros(), btnRegistro);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new formReportes(), btnReportes);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Cerrar_Sesion();
        }

        public void Cerrar_Sesion()
        {
            try
            {
                lSesion.Logout();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            using(var formModal = new mdAjustes())
            {
                formModal.ShowDialog();
                switch (formModal.OpcionSeleccionada)
                {
                    case "Perfiles":
                        abrirFormularioHijo(new formPerfiles(), btnAjustes);
                        break;
                    case "Negocio":
                        using(var formNegocio = new formNegocio())
                        {
                            formNegocio.ShowDialog();
                            cargarNegocio();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void tHorayFecha_Tick(object sender, EventArgs e)
        {
            txtFechayHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        
    }
}
