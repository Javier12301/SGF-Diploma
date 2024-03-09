using SGF.NEGOCIO.Negocio;
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

namespace SGF.PRESENTACION.formModales
{
    public partial class mdClientes : Form
    {
        UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        ClienteBLL lCliente = ClienteBLL.ObtenerInstancia;
        SesionBLL lSesion = SesionBLL.ObtenerInstancia;

        // Registro
        int cantidadAntes { get; set; }
        int cantidadDespues { get; set; }

        // Modificar cliente
        private bool modificandoCliente { get; set; }
        private int clienteID { get; set; }
        private Cliente oCliente { get; set; }

        public mdClientes(bool modificar = false, int clienteID = 0)
        {
            InitializeComponent();
            cantidadAntes = lCliente.ConteoClientes();
            modificandoCliente = modificar;
            this.clienteID = clienteID;
        }

        private void mdClientes_Load(object sender, EventArgs e)
        {
            try
            {
                cmbTipoCliente.Focus();
                chkOtroCliente.Checked = false;
                chkOtroDocumento.Checked = false;
                cargarCombobox();
                if (modificandoCliente)
                {
                    if (clienteID > 0)
                    {
                        oCliente = new Cliente();
                        oCliente = lCliente.ObtenerClientePorID(clienteID);
                        if (oCliente != null)
                        {
                            cargarDatosDeCliente(oCliente);
                        }
                        else
                        {
                            throw new Exception("No se encontró el cliente que se desea modificar, contactar con el administrador si el problema persiste.");
                        }
                    }
                    else
                    {
                        throw new Exception("El ID del cliente no es válido.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cargarDatosDeCliente(Cliente cliente)
        {
            if(cliente != null)
            {
                txtID.Text = cliente.ClienteID.ToString();
                txtTipoClienteID.Text = cliente.TipoCliente.TipoClienteID.ToString();
                if (!cmbTipoCliente.Items.Contains(cliente.TipoCliente)){
                    chkOtroCliente.Checked = true;
                    txtTipoCliente.Text = cliente.TipoCliente.Descripcion;
                }
                else
                {
                    cmbTipoCliente.Text = cliente.TipoCliente.Descripcion;
                }
                if(!cmbTipoDocumento.Items.Contains(cliente.TipoDocumento))
                {
                    chkOtroDocumento.Checked = true;
                    txtTipoDocumento.Text = cliente.TipoDocumento;
                }
                else
                {
                    cmbTipoDocumento.Text = cliente.TipoDocumento;
                }
                txtNombreCompleto.Text = cliente.NombreCompleto;
                txtDocumento.Text = cliente.Documento;
                // si telefono tiene "-" se limpiará
                txtTelefono.Text = cliente.Telefono == "-" ? "" : cliente.Telefono;
                txtCorreo.Text = cliente.Correo == "-" ? "" : cliente.Correo;
                chkEstado.Checked = cliente.Estado;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (!modificandoCliente)
                {
                    altaCliente();
                }
                else
                {
                    modificarCliente();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        // manejo de responsabilidades
        private bool ValidarCampos()
        {
            bool camposValidos = true;

            if (chkOtroCliente.Checked)
                camposValidos &= uiUtilidades.VerificarTextbox(txtTipoCliente, errorProvider, lblTipoCliente);
            else
                camposValidos &= uiUtilidades.VerificarCombobox(cmbTipoCliente, errorProvider, lblTipoCliente);

            if (chkOtroDocumento.Checked)
                camposValidos &= uiUtilidades.VerificarTextbox(txtTipoDocumento, errorProvider, lblTipoDocumento);
            else
                camposValidos &= uiUtilidades.VerificarCombobox(cmbTipoDocumento, errorProvider, lblTipoDocumento);

            camposValidos &= uiUtilidades.VerificarTextbox(txtNombreCompleto, errorProvider, lblNombreApellido);
            camposValidos &= uiUtilidades.VerificarTextbox(txtDocumento, errorProvider, lblDocumento);
            if (!string.IsNullOrEmpty(txtTelefono.Text))
                camposValidos &= uiUtilidades.VerificarTextbox(txtTelefono, errorProvider, lblTelefono);
            if (!string.IsNullOrEmpty(txtCorreo.Text) && txtCorreo.Text != "-")
                camposValidos &= uiUtilidades.VerificarMail(txtCorreo, errorProvider, lblCorreo);

            return camposValidos;

        }

        private Cliente CrearCliente()
        {
            TipoCliente tipoCliente = new TipoCliente();
            tipoCliente.Descripcion = chkOtroCliente.Checked ? txtTipoCliente.Text : cmbTipoCliente.Text;

            return new Cliente()
            {
                TipoDocumento = chkOtroDocumento.Checked ? txtTipoDocumento.Text : cmbTipoDocumento.Text,
                NombreCompleto = txtNombreCompleto.Text,
                Documento = txtDocumento.Text,
                Telefono = string.IsNullOrEmpty(txtTelefono.Text) ? "-" : txtTelefono.Text,
                Correo = string.IsNullOrEmpty(txtCorreo.Text) ? "-" : txtCorreo.Text,
                Estado = chkEstado.Checked,
                TipoCliente = tipoCliente
            };
        }

        private Cliente CrearClienteModificado()
        {
            TipoCliente tipoCliente = new TipoCliente();
            tipoCliente.Descripcion = chkOtroCliente.Checked ? txtTipoCliente.Text : cmbTipoCliente.Text;
            return new Cliente()
            {
                ClienteID = Convert.ToInt32(txtID.Text),
                TipoDocumento = chkOtroDocumento.Checked ? txtTipoDocumento.Text : cmbTipoDocumento.Text,
                NombreCompleto = txtNombreCompleto.Text,
                Documento = txtDocumento.Text,
                Telefono = string.IsNullOrEmpty(txtTelefono.Text) ? "-" : txtTelefono.Text,
                Correo = string.IsNullOrEmpty(txtCorreo.Text) ? "-" : txtCorreo.Text,
                Estado = chkEstado.Checked,
                TipoCliente = tipoCliente
            };
        }

        private void altaCliente()
        {
            if (ValidarCampos())
            {
                Cliente cliente = CrearCliente();
                bool documentoExiste = lCliente.ExisteCliente(cliente.Documento, cliente.TipoDocumento);
                if (documentoExiste)
                {
                    errorProvider.SetError(lblDocumento, "El documento ingresado ya existe.");
                    MessageBox.Show("El documento ingresado ya existe.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool TipoClienteExiste = lCliente.ExisteTipoCliente(cliente.TipoCliente.Descripcion);
                int TipoClienteID = 0;
                if (!TipoClienteExiste)
                {
                    TipoClienteID = lCliente.AltaTipoCliente(cliente.TipoCliente);
                }
                else
                {
                    TipoClienteID = lCliente.ObtenerTipoClientePorDescripcion(cliente.TipoCliente.Descripcion).TipoClienteID;
                }
                cliente.TipoCliente.TipoClienteID = TipoClienteID;

                bool resultado = lCliente.AltaCliente(cliente);

                if (resultado)
                {
                    cantidadDespues = lCliente.ConteoClientes();
                    RegistroBLL.RegistrarMovimiento("Alta", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), 1, cantidadAntes, cantidadDespues, "Clientes", $"Se dió de alta con éxito el cliente {cliente.NombreCompleto}");
                    MessageBox.Show("El cliente fue dado de alta con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult respuesta = MessageBox.Show("¿Desea seguir agregando clientes?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        limpiarCampos();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos obligatorios.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void modificarCliente()
        {
            if (ValidarCampos())
            {
                bool documentoExiste = false;
                Cliente cliente = CrearClienteModificado();
                if (cliente.Documento != oCliente.Documento || cliente.TipoDocumento != oCliente.TipoDocumento)
                {
                    documentoExiste = lCliente.ExisteCliente(cliente.Documento, cliente.TipoDocumento);
                    if (documentoExiste)
                    {
                        errorProvider.SetError(lblDocumento, "El documento ingresado ya existe.");
                        MessageBox.Show("El documento ingresado ya existe.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                bool TipoClienteExiste = lCliente.ExisteTipoCliente(cliente.TipoCliente.Descripcion);
                int TipoClienteID = 0;
                if (!TipoClienteExiste)
                {
                    TipoClienteID = lCliente.AltaTipoCliente(cliente.TipoCliente);
                }
                else
                {
                    TipoClienteID = lCliente.ObtenerTipoClientePorDescripcion(cliente.TipoCliente.Descripcion).TipoClienteID;
                }
                cliente.TipoCliente.TipoClienteID = TipoClienteID;
                cantidadAntes = lCliente.ConteoClientes();
                bool resultado = lCliente.ModificarCliente(cliente);

                if (resultado)
                {
                    cantidadDespues = lCliente.ConteoClientes();
                    RegistroBLL.RegistrarMovimiento("Modificación", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), 1, cantidadAntes, cantidadDespues, "Clientes", $"Se modificó con éxito el cliente {cliente.NombreCompleto}");
                    MessageBox.Show("El cliente fue modificado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el cliente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cancelar la operación?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

        }

        private void limpiarCampos()
        {
            DialogResult result = MessageBox.Show("¿Desea limpiar los campos?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                uiUtilidades.LimpiarTextbox(txtTipoCliente, txtDocumento, txtNombreCompleto, txtDocumento, txtCorreo, txtTelefono);
                uiUtilidades.LimpiarCombobox(cmbTipoDocumento, cmbTipoCliente);
                chkOtroDocumento.Checked = false;
                chkOtroCliente.Checked = false;
                cmbTipoCliente.Focus();
            }
        }

        private void chkOtroCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtroCliente.Checked)
            {
                cmbTipoCliente.Enabled = false;
                cmbTipoCliente.Visible = false;
                txtTipoCliente.Enabled = true;
                txtTipoCliente.Visible = true;
                txtTipoCliente.Focus();
            }
            else
            {
                cmbTipoCliente.Enabled = true;
                cmbTipoCliente.Visible = true;
                txtTipoCliente.Enabled = false;
                txtTipoCliente.Visible = false;
                cmbTipoCliente.Focus();
            }
        }

        private void chkOtroDocumento_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtroDocumento.Checked)
            {
                cmbTipoDocumento.Enabled = false;
                cmbTipoDocumento.Visible = false;
                txtTipoDocumento.Enabled = true;
                txtTipoDocumento.Visible = true;
                txtTipoDocumento.Focus();
            }
            else
            {
                cmbTipoDocumento.Enabled = true;
                cmbTipoDocumento.Visible = true;
                txtTipoDocumento.Enabled = false;
                txtTipoDocumento.Visible = false;
                cmbTipoDocumento.Focus();
            }
        }

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

        // Cargar combobox
        private void cargarCombobox()
        {
            List<Cliente> listaCliente = lCliente.ListarClientes();
            List<TipoCliente> listaTipoCliente = lCliente.ListarTipoCliente();

            if (listaCliente != null)
            {
                cmbTipoDocumento.Items.Add("Seleccionar un tipo de documento.");
                cmbTipoDocumento.Items.Add("DNI");
                cmbTipoDocumento.Items.Add("Pasaporte");
                cmbTipoDocumento.Items.Add("CUIT/CUIL");
                cmbTipoDocumento.Items.Add("Cédula de identidad");
                foreach (Cliente cliente in listaCliente)
                {
                    if (!cmbTipoDocumento.Items.Contains(cliente.TipoDocumento))
                    {
                        cmbTipoDocumento.Items.Add(cliente.TipoDocumento);
                    }
                }
                cmbTipoDocumento.SelectedIndex = 0;

                cmbTipoCliente.Items.Add("Seleccionar un tipo de cliente.");
                foreach (TipoCliente tipoCliente in listaTipoCliente)
                {
                    cmbTipoCliente.Items.Add(tipoCliente.Descripcion);
                }
                cmbTipoCliente.SelectedIndex = 0;

            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar cargar los tipos de documentos, contactar con el administrador si el problema persiste.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void chkOtroCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                chkOtroCliente.Checked = !chkOtroCliente.Checked;
            }
        }

        private void chkOtroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                chkOtroDocumento.Checked = !chkOtroDocumento.Checked;
            }
        }
    }
}
