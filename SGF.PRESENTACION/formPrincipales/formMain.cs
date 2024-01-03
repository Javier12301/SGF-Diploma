using SGF.MODELO;
using SGF.MODELO.Seguridad;
using SGF.NEGOCIO;
using SGF.NEGOCIO.Seguridad;
using SGF.PRESENTACION.formModales;
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
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private UsuarioBLL lUsuario = UsuarioBLL.ObtenerInstancia;
        // Usuario que inicio sesión      
        public formMain()
        {
            InitializeComponent();
        }

        // Función para cargar el usuario que inicio sesión
        private void formMain_Load(object sender, EventArgs e)
        {
            cargarSesion();
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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                lSesion.Logout();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }catch(Exception ex)
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
