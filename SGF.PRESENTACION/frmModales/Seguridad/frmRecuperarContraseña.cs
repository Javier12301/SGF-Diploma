using SGF.MODELO;
using SGF.NEGOCIO;
using SGF.PRESENTACION.UtilidadesComunes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.frmModales.Seguridad
{
    public partial class frmRecuperarContraseña : Form
    {
        UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        public frmRecuperarContraseña()
        {
            InitializeComponent();
        }

        private void frmRecuperarContraseña_Load(object sender, EventArgs e)
        {
            txtUsuario.Select();
        }

        private void txtCredenciales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                recuperarContraseña();
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            recuperarContraseña();
        }

        private void recuperarContraseña()
        {
            bool usuarioValido = uiUtilidades.VerificarTextbox(txtUsuario, errorProvider, lblUsuario);
            bool emailValido = uiUtilidades.VerificarTextbox(txtEmail, errorProvider, lblEmail);
            // Comprobar si contiene un email válido
            try
            {
                if (usuarioValido && emailValido)
                {
                    if (uiUtilidades.VerificarMail(txtEmail, errorProvider, lblEmail))
                    {
                        // Comprobamos si existe el usuario
                        if (N_Usuario.ObtenerInstancia.Existe_Usuario_Mail(txtUsuario.Text, txtEmail.Text))
                        {
                            Usuario oUsuario = N_Usuario.ObtenerInstancia.ObtenerUsuario(txtUsuario.Text);
                            // Enviar mail
                            // Codigo random para enviar al mail de 5 digitos se puede usar numeros y letras                       
                            string codigoGenerado = N_Usuario.ObtenerInstancia.GenerarCodigo();
                            bool mailEnviado = N_Usuario.ObtenerInstancia.EnviarMail(txtUsuario.Text, txtEmail.Text, codigoGenerado);
                            if (mailEnviado)
                            {
                                using(var modal = new frmVerificarMail())
                                {
                                    if(modal.ShowDialog() == DialogResult.OK)
                                    {
                                        
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se pudo enviar el email, consultar con el administrador o intentar nuevamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El usuario no existe.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El email no es válido.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Completar los campos vacíos.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error inesperado, por favor intentar nuevamente o contactar con el administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Utilidades de interfaz
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
