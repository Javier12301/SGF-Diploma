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
    public partial class mdProveedores : Form
    {
        // Controladoras
        private ProveedorBLL lProveedor = ProveedorBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;

        //Listas
        private List<Proveedor> listaProveedores = new List<Proveedor>();

        // Registro
        int cantidadAntes { get; set; }
        int cantidadDespues { get; set; }

        // Modificar proveedor
        private bool modificandoProveedor { get; set; }
        private int proveedorID { get; set; }
        private Proveedor oProveedor { get; set; }

        public mdProveedores(bool modificar = false, int proveedorID = 0)
        {
            InitializeComponent();
            cantidadAntes = lProveedor.ConteoProveedores();
            modificandoProveedor = modificar;
            this.proveedorID = proveedorID;
            listaProveedores = lProveedor.ListaProveedores();
        }

        private void mdProveedores_Load(object sender, EventArgs e)
        {
            txtRazonSocial.Select();
            chkOtroDocumento.Checked = false;
            try
            {
                cargarCombobox();
                if (modificandoProveedor)
                {
                    if (proveedorID > 0)
                    {
                        oProveedor = new Proveedor();
                        oProveedor = lProveedor.ObtenerProveedorPorID(proveedorID);
                        if (oProveedor != null)
                        {
                            cargarDatosDeProveedor(oProveedor);
                        }
                        else
                        {
                            throw new Exception("No se encontró el proveedor que se desea modificar, contactar con el administrador del sistema para solucionar este problema.");
                        }
                    }
                    else
                    {
                        throw new Exception("Ocurrió un error al intentar modificar el proveedor, contactar con el administrador del sistema para solucionar este problema.");
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
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (!modificandoProveedor)
                {
                    altaProveedor();
                }
                else
                {
                    modificarProveedor();
                }
                txtRazonSocial.Select();
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

        // Manejo de responsabilidades
        private bool ValidarCampos()
        {
            bool camposValidos = true;

            camposValidos &= uiUtilidades.VerificarTextbox(txtRazonSocial, errorProvider, lblRazonSocial);
            if (chkOtroDocumento.Checked)
            {
                camposValidos &= uiUtilidades.VerificarTextbox(txtOtroTipo, errorProvider, lblTipoDocumento);
            }
            else
            {
                camposValidos &= uiUtilidades.VerificarCombobox(cmbTipoDocumento, errorProvider, lblTipoDocumento);
            }
            camposValidos &= uiUtilidades.VerificarTextbox(txtDocumento, errorProvider, lblDocumento);
            camposValidos &= uiUtilidades.VerificarTextbox(txtDireccion, errorProvider, lblDireccion);

            if (!string.IsNullOrEmpty(txtCorreo.Text))
                camposValidos &= uiUtilidades.VerificarMail(txtCorreo, errorProvider, lblCorreo);

            return camposValidos;
        }

        private Proveedor CrearProveedor()
        {
            return new Proveedor()
            {
                RazonSocial = txtRazonSocial.Text,
                TipoDocumento = chkOtroDocumento.Checked ? txtOtroTipo.Text : cmbTipoDocumento.Text,
                Documento = txtDocumento.Text,
                Direccion = txtDireccion.Text,
                // telefono es opcional, si no ingreso nada se pone un "-"
                Telefono = string.IsNullOrEmpty(txtTelefono.Text) ? "-" : txtTelefono.Text,
                Correo = string.IsNullOrEmpty(txtCorreo.Text) ? "-" : txtCorreo.Text,
                Estado = chkEstado.Checked
            };
        }

        private Proveedor CrearProveedorModificado()
        {
            return new Proveedor()
            {
                ProveedorID = Convert.ToInt32(txtID.Text),
                RazonSocial = txtRazonSocial.Text,
                TipoDocumento = chkOtroDocumento.Checked ? txtOtroTipo.Text : cmbTipoDocumento.Text,
                Documento = txtDocumento.Text,
                Direccion = txtDireccion.Text,
                // telefono es opcional, si no ingreso nada se pone un "-"
                Telefono = string.IsNullOrEmpty(txtTelefono.Text) ? "-" : txtTelefono.Text,
                Correo = string.IsNullOrEmpty(txtCorreo.Text) ? "-" : txtCorreo.Text,
                Estado = chkEstado.Checked
            };
        }

        // Alta
        private void altaProveedor()
        {
            if (ValidarCampos())
            {
                Proveedor proveedor = CrearProveedor();
                bool razonSocialExistente = lProveedor.ExisteRazonSocial(proveedor.RazonSocial);
                if (razonSocialExistente)
                {
                    errorProvider.SetError(lblRazonSocial, "La razón social ingresada ya existe.");
                    MessageBox.Show("La razón social ingresada ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool resultado = lProveedor.AltaProveedor(proveedor);

                if (resultado)
                {
                    cantidadDespues = lProveedor.ConteoProveedores();
                    RegistroBLL.RegistrarMovimiento("Alta", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), 1, cantidadAntes, cantidadDespues, "Proveedores", $"Se dio de alta con éxito el proveedor: {proveedor.RazonSocial}");
                    MessageBox.Show("El proveedor fue dado de alta con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult respuesta = MessageBox.Show("¿Desea seguir agregando proveedores?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.No)
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        limpiarCampos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos obligatorios.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Modificación
        private void modificarProveedor()
        {
            if (ValidarCampos())
            {

                bool razonSocialExistente = false;
                Proveedor proveedor = CrearProveedorModificado();
                if(oProveedor.RazonSocial != proveedor.RazonSocial)
                {
                    razonSocialExistente = lProveedor.ExisteRazonSocial(proveedor.RazonSocial);
                    if(razonSocialExistente)
                    {
                        errorProvider.SetError(lblRazonSocial, "La razón social ingresada ya existe.");
                        MessageBox.Show("La razón social ingresada ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                cantidadAntes = lProveedor.ConteoProveedores();
                bool resultado = lProveedor.ModificarProveedor(proveedor);

                if (resultado)
                {
                    cantidadDespues = lProveedor.ConteoProveedores();
                    RegistroBLL.RegistrarMovimiento("Modificación", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), 1, cantidadAntes, cantidadDespues, "Proveedores", $"Se modificó con éxito el proveedor: {proveedor.RazonSocial} cuya ID es: {oProveedor.ProveedorID}");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el proveedor.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Manejo de Interfaz
        private void cargarCombobox()
        {
            cmbTipoDocumento.Items.Add("Seleccione una opción...");
            // utilizar la lista de proveedores, e insertar los tipos de documentos existentes
            cmbTipoDocumento.Items.Add("DNI");
            cmbTipoDocumento.Items.Add("CUIL");
            cmbTipoDocumento.Items.Add("CUIT");
            foreach(var proveedor in listaProveedores)
            {
                if(!cmbTipoDocumento.Items.Contains(proveedor.TipoDocumento) && proveedor.TipoDocumento != "N/A")
                {
                    cmbTipoDocumento.Items.Add(proveedor.TipoDocumento);
                }
            }
            cmbTipoDocumento.SelectedIndex = 0;
        }

        private void cargarDatosDeProveedor(Proveedor proveedor)
        {
            if(proveedor != null)
            {
                txtID.Text = proveedor.ProveedorID.ToString();
                // para el tipo de documento se hará una cosa, si no se encuentra en el combobox, se cargará en el textbox, primero se tildará checked el checkbox y se cargará el texto
                if(!cmbTipoDocumento.Items.Contains(proveedor.TipoDocumento))
                {
                    chkOtroDocumento.Checked = true;
                    txtOtroTipo.Text = proveedor.TipoDocumento;
                }
                else
                {
                    cmbTipoDocumento.SelectedItem = proveedor.TipoDocumento;
                }
                txtRazonSocial.Text = proveedor.RazonSocial;
                txtDocumento.Text = proveedor.Documento;
                txtDireccion.Text = proveedor.Direccion;
                txtTelefono.Text = proveedor.Telefono;
                txtCorreo.Text = proveedor.Correo;
                chkEstado.Checked = proveedor.Estado;
            }
        }

        private void chkOtroDocumento_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtroDocumento.Checked)
            {
                cmbTipoDocumento.Enabled = false;
                cmbTipoDocumento.Visible = false;

                txtOtroTipo.Enabled = true;
                txtOtroTipo.Visible = true;
                txtOtroTipo.Focus();
            }
            else
            {
                cmbTipoDocumento.Enabled = true;
                cmbTipoDocumento.Visible = true;
                cmbTipoDocumento.Focus();

                txtOtroTipo.Enabled = false;
                txtOtroTipo.Visible = false;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            uiUtilidades.TextboxTelefono(e);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            DialogResult respuesta = MessageBox.Show("¿Desea limpiar los campos?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                uiUtilidades.LimpiarTextbox(txtRazonSocial, txtDocumento, txtDireccion, txtTelefono, txtCorreo, txtOtroTipo);
                uiUtilidades.LimpiarCombobox(cmbTipoDocumento);
                chkOtroDocumento.Checked = false;
                txtRazonSocial.Select();
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
    
        private void cmbSiguienteIndex_Enter(object sender, KeyPressEventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;
            uiUtilidades.Combobox_ShortcutSiguienteIndex(combobox, e);
        }

        private void chkOtroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            // al presionar enter, se cambia el estado del checkbox
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (checkbox.Checked)
                {
                    checkbox.Checked = false;
                }
                else
                {
                    checkbox.Checked = true;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea cancelar la operación?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
