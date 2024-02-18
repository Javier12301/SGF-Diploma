using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Guna.UI.WinForms;
using SGF.PRESENTACION.UtilidadesComunes;
using SGF.NEGOCIO;
using SGF.MODELO;
using SGF.PRESENTACION.frmModales.Seguridad;
using SGF.NEGOCIO.Seguridad;
using SGF.PRESENTACION.formPrincipales;
using SGF.NEGOCIO.Negocio;
using SGF.MODELO.Negocio;

namespace SGF.PRESENTACION
{
    public partial class frmLogin : Form
    {
        // Controladoras
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private UsuarioBLL lUsuario = UsuarioBLL.ObtenerInstancia;
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private GrupoBLL lGrupo = GrupoBLL.ObtenerInstancia;
        private NegocioBLL lNegocio = NegocioBLL.ObtenerInstancia;

        private bool contraseñaVisible { get; set; }
        
        public frmLogin()
        {
            InitializeComponent();
            lNegocio.CargarDatos();
            contraseñaVisible = false;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            cargarNegocio();
            txtUsuarioG.Select();
            alternarVisibilidadContraseña();
        }

        private void cargarNegocio()
        {
            NegocioModelo negocio = lNegocio.NegocioEnSesion().DatosDelNegocio;
            if(negocio.Logo != null)
            {
                pbLogoEmpresa.Image = uiUtilidades.ByteArrayToImage(negocio.Logo);
            }
            else
            {
                pbLogoEmpresa.Image = uiUtilidades.LogoPorDefecto();
            }
            lblNombreEmpresa.Text = negocio.Nombre;
        }


        private void btnOjo_Click(object sender, EventArgs e)
        {
            alternarVisibilidadContraseña();
        }


        private void btnOjo_MouseEnter(object sender, EventArgs e)
        {
            btnOjo.IconFont = IconFont.Solid;

        }

        private void btnOjo_MouseLeave(object sender, EventArgs e)
        {
            btnOjo.IconFont = IconFont.Regular;
        }

        private void txtCredenciales_Enter(object sender, EventArgs e)
        {
            GunaLineTextBox textbox = (GunaLineTextBox)sender;
            textbox.LineColor = Color.Gainsboro;
        }

        private void txtCredenciales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                IniciarSesion();
            }
        }

        private void btnContraseña_Click(object sender, EventArgs e)
        {
            // Abrir formulario de recuperación de contraseña
            using (var modal = new formRecuperarContraseña())
            {
                modal.ShowDialog();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            IniciarSesion();
            Cursor.Current = Cursors.Default;
        }



        private void IniciarSesion()
        {
            try
            {
                // Validaciones
                bool txtUsuarioValido = uiUtilidades.VerificarTextboxG(txtUsuarioG);
                bool txtContraseñaValido = uiUtilidades.VerificarTextboxG(txtContraseñaG);

                if (txtUsuarioValido && txtContraseñaValido)
                {
                    // Comprobar si existe el usuario
                    if (lUsuario.ExisteUsuario(txtUsuarioG.Text))
                    {
                        Usuario oUsuario = lUsuario.ObtenerUsuarioPorNombre(txtUsuarioG.Text);
                        // Permisos de cada modulo
                        oUsuario.ModulosPermitidos = lGrupo.ObtenerModulosPermitidos(oUsuario.ObtenerGrupoID());
                        string contraseña = lUsuario.EncriptarClave(txtContraseñaG.Text);

                        if (oUsuario.Grupo.Estado)
                        {
                            if (oUsuario.Estado)
                            {
                                if (oUsuario.Contraseña == contraseña)
                                {
                                    // Iniciar sesión utilizando el SessionManager
                                    lSesion.Login(oUsuario);
                                    // Registrar auditoria (si lo deseas)
                                    abrirFormMain();
                                }
                                else
                                {
                                    MessageBox.Show("Usuario y/o contraseña incorrecta.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("El usuario ingresado se encuentra inactivo, consultar al administrador", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                uiUtilidades.errorTextboxG(txtUsuarioG, true);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El grupo al que pertenece el usuario se encuentra inactivo, consultar al administrador", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            uiUtilidades.errorTextboxG(txtUsuarioG, true);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario no existe.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        uiUtilidades.errorTextboxG(txtUsuarioG, true);
                    }
                }
                else
                {
                    MessageBox.Show("Completar los campos vacíos.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargarNegocio();
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void abrirFormMain()
        {
            if (lSesion != null)
            {
                using (var frmMain = new formMain())
                {
                    this.Hide();
                    var resultado = frmMain.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        this.Show();
                    }
                    else
                    {
                        Application.Exit();
                    }

                }
            }
            else
            {
                // En caso de que un usuario encuentre un bug y logre abrir el formulario principal sin iniciar sesión, se le mostrará un mensaje de error.
                MessageBox.Show("No se ha iniciado sesión", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Utilidades de Interfaz
        private void alternarVisibilidadContraseña()
        {
            if (contraseñaVisible)
            {
                contraseñaVisible = false;
                uiUtilidades.MostrarContraseñaG(txtContraseñaG, btnOjo);
            }
            else
            {
                contraseñaVisible = true;
                uiUtilidades.OcultarContraseñaG(txtContraseñaG, btnOjo);
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
