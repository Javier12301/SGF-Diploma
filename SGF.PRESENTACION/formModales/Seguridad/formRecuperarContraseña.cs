using SGF.MODELO;
using SGF.NEGOCIO;
using SGF.PRESENTACION.UtilidadesComunes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.frmModales.Seguridad
{
    public partial class formRecuperarContraseña : Form
    {
        UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        public formRecuperarContraseña()
        {
            InitializeComponent();
        }

        private void frmRecuperarContraseña_Load(object sender, EventArgs e)
        {
            txtUsuario.Select();
        }

        private void txtCredenciales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
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
                        if (UsuarioBLL.ObtenerInstancia.Existe_Usuario_Mail(txtUsuario.Text, txtEmail.Text))
                        {
                            // Enviar mail
                            // Codigo random para enviar al mail de 5 digitos se puede usar numeros y letras                       
                            string codigoGenerado = UsuarioBLL.ObtenerInstancia.GenerarCodigo();
                            CorreoService correoService = new CorreoService();
                            bool mailEnviado = correoService.EnviarMail(txtUsuario.Text, txtEmail.Text, codigoGenerado);
                            if (mailEnviado)
                            {
                                MessageBox.Show("Se envió un email con un código de verificación, por favor revisar su casilla de correo.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // si el mail fue enviado, se activa el modal para verificar el codigo
                                using (var modal = new formVerificarMail(txtUsuario.Text, txtEmail.Text, codigoGenerado))
                                {
                                    if (modal.ShowDialog() == DialogResult.OK && modal.codigoValido)
                                    {
                                        // Abrir formulario para cambiar contraseña
                                        using (var modalCambiar = new frmNuevaContraseña(txtUsuario.Text))
                                        {
                                            if (modalCambiar.ShowDialog() == DialogResult.OK && modalCambiar.contraseñaModificada)
                                            {
                                                MessageBox.Show("Se modificó la contraseña correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                this.Close();
                                            }
                                            else
                                            {
                                                MessageBox.Show("No se pudo modificar la contraseña, consultar con el administrador o intentar nuevamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Operación cancelada.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            MessageBox.Show("Usuario y/o email incorrecto.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
