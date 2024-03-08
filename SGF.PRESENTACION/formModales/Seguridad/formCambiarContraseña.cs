using FontAwesome.Sharp;
using SGF.MODELO;
using SGF.NEGOCIO;
using SGF.NEGOCIO.Seguridad;
using SGF.PRESENTACION.UtilidadesComunes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.frmModales.Seguridad
{
    public partial class frmNuevaContraseña : Form
    {
        UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private bool contraseñaVisibleNueva { get; set; }
        private bool contraseñaVisibleConfirmar { get; set; }
        public bool contraseñaModificada { get; set; }
        public string nombreUsario { get; set; }
        UsuarioBLL lUsuario = UsuarioBLL.ObtenerInstancia;
        public frmNuevaContraseña(string nombreUsuario)
        {
            InitializeComponent();
            this.nombreUsario = nombreUsuario;
            contraseñaVisibleNueva = false;
            contraseñaVisibleConfirmar = false;
            contraseñaModificada = false;
        }

        private void frmNuevaContraseña_Load(object sender, EventArgs e)
        {
            txtNuevaContraseña.Select();
            alternarVisibilidadContraseña(txtNuevaContraseña, btnOjoNueva);
            alternarVisibilidadContraseña(txtConfirmarContraseña, btnOjoConfirmar);
        }

        private void btnOjo_Click(object sender, EventArgs e)
        {
            IconButton ojoControl = (IconButton)sender;
            if (ojoControl.Name == "btnOjoNueva")
            {
                alternarVisibilidadContraseña(txtNuevaContraseña, ojoControl);
            }
            else
            {
                alternarVisibilidadContraseña(txtConfirmarContraseña, ojoControl);
            }
        }

        private void btnOjo_Enter(object sender, EventArgs e)
        {
            IconButton ojoControl = (IconButton)sender;
            ojoControl.IconFont = IconFont.Solid;
        }

        private void btnOjo_MouseLeave(object sender, EventArgs e)
        {
            IconButton ojoControl = (IconButton)sender;
            ojoControl.IconFont = IconFont.Regular;
        }

        private void txtCredenciales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cambiarContraseña();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            cambiarContraseña();
        }



        private void cambiarContraseña()
        {
            bool contraseñaValida = uiUtilidades.VerificarTextbox(txtNuevaContraseña, errorProvider, lblNuevaContraseña);
            bool confirmarContraseña = uiUtilidades.VerificarTextbox(txtConfirmarContraseña, errorProvider, lblConfirmarContraseña);
            if (contraseñaValida && confirmarContraseña)
            {
                if (txtNuevaContraseña.Text == txtConfirmarContraseña.Text)
                {
                    Usuario oUsuario = lUsuario.ObtenerUsuarioPorNombre(nombreUsario);
                    oUsuario.Contraseña = lUsuario.EncriptarClave(txtNuevaContraseña.Text);
                    try
                    {
                        contraseñaModificada = lUsuario.ModificarUsuario(oUsuario);
                        AuditoriaBLL.RegistrarMovimiento("Modificación", "Sistema","Login/Logout", $"Se modificó la contraseña del usuario: {oUsuario.NombreUsuario}");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception)
                    {
                        contraseñaModificada = false;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    errorProvider.SetError(lblConfirmarContraseña, "La contraseñas no coincide.");
                    MessageBox.Show("Las contraseñas ingresada no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Utilidades de interfaz
        private void alternarVisibilidadContraseña(TextBox textbox, IconButton ojoControl)
        {
            switch (ojoControl.Name)
            {
                case "btnOjoNueva":
                    if (contraseñaVisibleNueva)
                    {
                        contraseñaVisibleNueva = false;
                        uiUtilidades.MostrarContraseña(textbox, ojoControl);
                    }
                    else
                    {
                        contraseñaVisibleNueva = true;
                        uiUtilidades.OcultarContraseña(textbox, ojoControl);
                    }
                    break;
                case "btnOjoConfirmar":
                    if (contraseñaVisibleConfirmar)
                    {
                        contraseñaVisibleConfirmar = false;
                        uiUtilidades.MostrarContraseña(textbox, ojoControl);
                    }
                    else
                    {
                        contraseñaVisibleConfirmar = true;
                        uiUtilidades.OcultarContraseña(textbox, ojoControl);
                    }
                    break;
                default:
                    break;
            }
        }

        // Control de movimiento de la ventana
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
