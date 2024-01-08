using FontAwesome.Sharp;
using SGF.MODELO;
using SGF.MODELO.Seguridad;
using SGF.NEGOCIO;
using SGF.NEGOCIO.Seguridad;
using SGF.PRESENTACION.UtilidadesComunes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SGF.PRESENTACION.formModales
{
    public partial class mdUsuario : Form
    {
        UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;

        private bool contraseñaVisibleNueva { get; set; }
        private bool contraseñaVisibleConfirmar { get; set; }
        private GrupoBLL lGrupo = GrupoBLL.ObtenerInstancia;
        private UsuarioBLL lUsuario = UsuarioBLL.ObtenerInstancia;
        private bool modificandoUsuario { get; set; }
        private int usuarioID { get; set; }
        private Usuario oUsuario { get; set; }

        public mdUsuario(bool modificar = false, int usuarioID = 0)
        {
            InitializeComponent();
            modificandoUsuario = modificar;
            this.usuarioID = usuarioID;
            contraseñaVisibleNueva = false;
            contraseñaVisibleConfirmar = false;
        }


        private void mdUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                chkCambiarContraseña.Visible = modificandoUsuario;
                chkCambiarContraseña.Enabled = modificandoUsuario;
                cargarGrupos();
                alternarVisibilidadContraseña(txtContraseña, btnOjo);
                alternarVisibilidadContraseña(txtContraseñaConfirmar, btnOjoConfirmar);
                if (modificandoUsuario)
                {
                    if (usuarioID > 0)
                    {
                        oUsuario = new Usuario();
                        oUsuario = lUsuario.ObtenerUsuarioPorID(usuarioID);
                        cargarDatosDeUsuario(oUsuario);
                        alternarPanelesContraseña(false);
                    }
                    else
                    {
                        throw new Exception("Ocurrió un error al modificar el usuario, contactar con el administrador si este error persiste.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!modificandoUsuario)
                {
                    altaUsuario();
                }
                else
                {
                    modificarUsuario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Manejo de responsabilidades
        private bool ValidarCampos()
        {
            bool camposValidos = true;

            camposValidos &= uiUtilidades.VerificarTextbox(txtNombreUsuario, errorProvider, lblUsuario);
            camposValidos &= uiUtilidades.VerificarMail(txtEmail, errorProvider, lblEmail);
            camposValidos &= uiUtilidades.VerificarTextbox(txtNombre, errorProvider, lblNombre);
            camposValidos &= uiUtilidades.VerificarTextbox(txtApellido, errorProvider, lblApellido);
            camposValidos &= uiUtilidades.VerificarTextbox(txtDni, errorProvider, lblDni);
            camposValidos &= uiUtilidades.VerificarCombobox(cmbGrupo, errorProvider, lblGrupo);
            camposValidos &= uiUtilidades.VerificarTextbox(txtContraseña, errorProvider, lblContraseña);
            camposValidos &= uiUtilidades.VerificarTextbox(txtContraseñaConfirmar, errorProvider, lblContraseñaConfirmar);

            return camposValidos;
        }


        private Usuario CrearUsuario()
        {
            return new Usuario
            {
                NombreUsuario = txtNombreUsuario.Text,
                Contraseña = lUsuario.EncriptarClave(txtContraseña.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Email = txtEmail.Text,
                DNI = txtDni.Text,
                Grupo = lGrupo.ObtenerGrupoPorNombre(cmbGrupo.SelectedItem.ToString()),
                Estado = chkEstado.Checked
            };
        }

        private Usuario CrearUsuarioModificado()
        {
            return new Usuario
            {
                UsuarioID = int.Parse(txtID.Text),
                NombreUsuario = txtNombreUsuario.Text,
                Contraseña = txtContraseña.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Email = txtEmail.Text,
                DNI = txtDni.Text,
                Grupo = lGrupo.ObtenerGrupoPorNombre(cmbGrupo.SelectedItem.ToString()),
                Estado = chkEstado.Checked
            };
        }

        // Manejo de usuario y email ya existentes

        // Alta Usuario
        private void altaUsuario()
        {
            if (ValidarCampos())
            {
                if (txtContraseña.Text == txtContraseñaConfirmar.Text)
                {
                    Usuario usuario = CrearUsuario();

                    bool usuarioExiste = lUsuario.ExisteUsuario(usuario.NombreUsuario);
                    if (usuarioExiste)
                        errorProvider.SetError(lblUsuario, "El Usuario ingresado ya se encuentra en uso.");

                    bool emailExiste = lUsuario.ExisteEmail(usuario.Email);
                    if (emailExiste)
                        errorProvider.SetError(lblEmail, "El correo electrónico ingresado ya se encuentra en uso.");

                    if(usuarioExiste || emailExiste)
                    {
                        MessageBox.Show("El usuario o el correo electrónico ingresado ya se encuentra en uso.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }                                       

                    bool resultado = lUsuario.AltaUsuario(usuario);

                    if (resultado)
                    {
                        MessageBox.Show("El usuario fue dado de alta con éxito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al dar de alta al usuario. Por favor, inténtelo de nuevo.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas ingresadas no coinciden", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider.SetError(lblContraseñaConfirmar, "Las contraseñas no coinciden.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete los campos obligatorios correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Modificar Usuario
        private void modificarUsuario()
        {
            if (ValidarCampos())
            {
                // Obtener usuario con los datos actualizados
                Usuario usuario = CrearUsuarioModificado();

                if (chkCambiarContraseña.Checked)
                {
                    if (txtContraseña.Text == txtContraseñaConfirmar.Text)
                    {
                        // Encriptar la nueva contraseña si se va a cambiar
                        usuario.Contraseña = lUsuario.EncriptarClave(txtContraseña.Text);
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas ingresadas no coinciden", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorProvider.SetError(lblContraseñaConfirmar, "Las contraseñas no coinciden.");
                    }
                }
                bool emailExiste = false;
                bool usuarioExiste = false;

                // Se verifica si el usuario realizo una modificación en el nombre de usuario o en el email
                if(oUsuario.NombreUsuario != usuario.NombreUsuario)
                {
                    // esto significa que si se modifico el nombre de usuario, entonces hay que verificar si ya existe
                    usuarioExiste = lUsuario.ExisteUsuario(usuario.NombreUsuario);
                    if(usuarioExiste)
                        errorProvider.SetError(lblUsuario, "El Usuario ingresado ya se encuentra en uso.");
                }

                if (oUsuario.Email != usuario.Email)
                {
                    // esto significa que si se modifico el email, entonces hay que verificar si ya existe
                    emailExiste = lUsuario.ExisteEmail(usuario.Email);
                    if(emailExiste)
                        errorProvider.SetError(lblEmail, "El correo electrónico ingresado ya se encuentra en uso.");
                }

                if (usuarioExiste || emailExiste)
                {
                    MessageBox.Show("El usuario o el correo electrónico ingresado ya se encuentra en uso.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool resultado = lUsuario.ModificarUsuario(usuario);

                if (resultado)
                {
                    MessageBox.Show("El usuario fue modificado con éxito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al modificar el usuario. Por favor, inténtelo de nuevo.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Por favor, complete los campos obligatorios correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea limpiar todo los campos?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                uiUtilidades.LimpiarTextbox(txtNombreUsuario, txtEmail, txtNombre, txtApellido, txtDni, txtContraseña, txtContraseñaConfirmar);
                uiUtilidades.LimpiarCombobox(cmbGrupo);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Manejo de Interfaz
        private void chkCambiarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            alternarPanelesContraseña(chkCambiarContraseña.Checked);
        }

        private void alternarPanelesContraseña(bool mostrarPanel)
        {
            pnlContraseña.Enabled = mostrarPanel;
            pnlConfirmarContraseña.Visible = mostrarPanel;
            btnOjo.Visible = mostrarPanel;
            btnOjoConfirmar.Visible = mostrarPanel;
            if (mostrarPanel)
            {
                txtContraseña.Text = string.Empty;
                txtContraseñaConfirmar.Text = string.Empty;
            }
            else
            {
                txtContraseña.Text = oUsuario.Contraseña;
            }
        }

        private void cargarDatosDeUsuario(Usuario oUsuario)
        {
            if (oUsuario != null)
            {
                txtID.Text = oUsuario.UsuarioID.ToString();
                txtNombreUsuario.Text = oUsuario.NombreUsuario;
                txtEmail.Text = oUsuario.Email;
                txtNombre.Text = oUsuario.Nombre;
                txtApellido.Text = oUsuario.Apellido;
                txtDni.Text = oUsuario.DNI;
                cmbGrupo.SelectedItem = oUsuario.Grupo.Nombre;
                txtContraseña.Text = oUsuario.Contraseña;
                txtContraseñaConfirmar.Text = oUsuario.Contraseña;
                chkEstado.Checked = oUsuario.Estado;
            }
        }

        private void cargarGrupos()
        {
            List<Grupo> listaGrupos = lGrupo.ListarGrupos();
            cmbGrupo.Items.Add("Seleccione una opción...");
            foreach (var grupo in listaGrupos)
            {
                cmbGrupo.Items.Add(grupo.Nombre);
            }
            cmbGrupo.SelectedIndex = 0;
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

        private void btnOjo_Click(object sender, EventArgs e)
        {
            IconButton ojoControl = (IconButton)sender;
            if (ojoControl.Name == "btnOjo")
            {
                alternarVisibilidadContraseña(txtContraseña, ojoControl);
            }
            else
            {
                alternarVisibilidadContraseña(txtContraseñaConfirmar, ojoControl);
            }
        }

        private void alternarVisibilidadContraseña(TextBox textbox, IconButton ojoControl)
        {
            switch (ojoControl.Name)
            {
                case "btnOjo":
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

        // Movimiento de ventana
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
