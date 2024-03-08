using SGF.MODELO.Negocio;
using SGF.NEGOCIO.Negocio;
using SGF.NEGOCIO.Seguridad;
using SGF.PRESENTACION.formModales.modalesBuscadores;
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

namespace SGF.PRESENTACION.formPrincipales
{
    public partial class formNegocio : Form
    {
        //Controladora
        private NegocioBLL lNegocio = NegocioBLL.ObtenerInstancia;
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;


        private Moneda monedaSeleccionada { get; set; }
        private NegocioModelo negocioDatos { get; set; }
        private bool logoModificado = false;


        public formNegocio()
        {
            InitializeComponent();
            monedaSeleccionada = null;
            negocioDatos = lNegocio.NegocioEnSesion().DatosDelNegocio;
        }

        private void formNegocio_Load(object sender, EventArgs e)
        {
            try
            {
                chkOtroDocumento.Checked = false;
                cargarCombobox();
                cargarDatosNegocio();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Manejo de Responsabilidades
        private bool ValidarCampos()
        {
            bool camposValidos = true;

            // Datos del negocio
            camposValidos &= uiUtilidades.VerificarTextbox(txtNombreNegocio, errorProvider, lblNombreNegocio);
            camposValidos &= uiUtilidades.VerificarTextbox(txtDireccionNegocio, errorProvider, lblDireccionNegocio);
            if (string.IsNullOrEmpty(txtDireccionNegocio.Text))
                txtDireccionNegocio.Text = "-";
            if (string.IsNullOrEmpty(txtTelefonoNegocio.Text))
                txtTelefonoNegocio.Text = "-";
            if (string.IsNullOrEmpty(txtCorreoNegocio.Text))
                txtCorreoNegocio.Text = "-";

            // Datos personales
            if (chkOtroDocumento.Checked)
                camposValidos &= uiUtilidades.VerificarTextbox(txtOtroDocumento, errorProvider, lblTipoDocumento);
            else
                camposValidos &= uiUtilidades.VerificarCombobox(cmbTipoDocumento, errorProvider, lblTipoDocumento);

            camposValidos &= uiUtilidades.VerificarTextbox(txtDocumentoDueño, errorProvider, lblDocumento);

            // Monedas
            camposValidos &= uiUtilidades.VerificarTextbox(txtNombreMoneda, errorProvider, lblNombreMoneda);
            camposValidos &= uiUtilidades.VerificarTextbox(txtSimboloMoneda, errorProvider, lblSimboloMoneda);

            // Impuestos
            if (rbImpuestoSi.Checked)
            {
                camposValidos &= uiUtilidades.VerificarTextbox(txtNombreImpuesto, errorProvider, lblAbreviacion);
                camposValidos &= uiUtilidades.VerificarTextbox(txtPorcentajeImpuesto, errorProvider, lblPorcentaje);
            }

            return camposValidos;
        }

        private NegocioModelo CrearNegocioModificado()
        {
            NegocioModelo negocio = new NegocioModelo();

            negocio.Logo = negocioDatos.Logo;
            negocio.Nombre = txtNombreNegocio.Text;
            negocio.Direccion = txtDireccionNegocio.Text;
            negocio.Telefono = txtTelefonoNegocio.Text;
            negocio.Correo = txtCorreoNegocio.Text;
            negocio.TipoDocumento = chkOtroDocumento.Checked ? txtOtroDocumento.Text : cmbTipoDocumento.SelectedItem.ToString();
            negocio.Documento = txtDocumentoDueño.Text;

            // Monedas
            if (monedaSeleccionada == null)
            {
                bool monedaExiste = lNegocio.ExisteMoneda(txtNombreMoneda.Text);
                if (monedaExiste)
                {
                    monedaSeleccionada = lNegocio.ObtenerMonedaPorNombre(txtNombreMoneda.Text);
                }
                else if (altaMoneda())
                {
                    monedaSeleccionada = lNegocio.ObtenerMonedaPorNombre(txtNombreMoneda.Text);
                }
                else
                {
                    // moneda default id 1
                    monedaSeleccionada = lNegocio.ObtenerMonedaPorID(1);
                }
            }
            if(rbAntes.Checked)
                monedaSeleccionada.Posicion = "Antes";
            else
                monedaSeleccionada.Posicion = "Después";
            monedaSeleccionada.Simbolo = txtSimboloMoneda.Text;
            lNegocio.ModificarMoneda(monedaSeleccionada);
            negocio.Moneda = monedaSeleccionada;

            // Impuestos
            Impuesto impuesto = rbImpuestoSi.Checked ? new Impuesto
            {
                Nombre = txtNombreImpuesto.Text,
                Porcentaje = Convert.ToDecimal(txtPorcentajeImpuesto.Text)
            } : lNegocio.ObtenerImpuestoPorID(1);

            if (rbImpuestoSi.Checked)
            {
                lNegocio.ModificarImpuesto(impuesto);
            }
            negocio.Impuesto = impuesto;

            return negocio;
        }


        // Alta moneda
        private bool altaMoneda()
        {
            Moneda moneda = new Moneda
            {
                Nombre = txtNombreMoneda.Text,
                Simbolo = txtSimboloMoneda.Text,
                Posicion = rbAntes.Checked ? "Antes" : "Después"
            };
            bool resultado = lNegocio.AltaMoneda(moneda);
            return resultado;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (logoModificado)
                    GuardarImagen();
                NegocioModelo oNegocio = CrearNegocioModificado();
                bool resultado = lNegocio.ModificarNegocio(oNegocio);
                if (resultado)
                {
                    AuditoriaBLL.RegistrarMovimiento("Modificación", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(),"Negocio",  "Se modificarón con éxito los datos del negocio.");
                    

                    MessageBox.Show("Negocio modificado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    AuditoriaBLL.RegistrarMovimiento("Modificación", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(),"Negocio", "Error al modificar los datos del negocio.");
                    MessageBox.Show("Ocurrió un error al modificar el negocio, contacte con el administrador del sistema si este error persiste.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cargarCombobox()
        {
            cmbTipoDocumento.Items.Add("Seleccione una opción...");
            // utilizar la lista de proveedores, e insertar los tipos de documentos existentes
            cmbTipoDocumento.Items.Add("DNI");
            cmbTipoDocumento.Items.Add("CUIL");
            cmbTipoDocumento.Items.Add("CUIT");
            if (!cmbTipoDocumento.Items.Contains(negocioDatos.TipoDocumento))
            {
                cmbTipoDocumento.Items.Add(negocioDatos.TipoDocumento);
            }
            cmbTipoDocumento.SelectedIndex = 0;
        }

        private void cargarDatosNegocio()
        {
            if (negocioDatos != null)
            {
                Moneda moneda = lNegocio.ObtenerMonedaPorID(negocioDatos.Moneda.MonedaID);
                Impuesto impuesto = lNegocio.ObtenerImpuestoPorID(negocioDatos.Impuesto.ImpuestoID);

                // Cargar Datos de negocio
                if (negocioDatos.Logo == null)
                {
                    pbLogo.Image = uiUtilidades.LogoPorDefecto();
                }
                else
                {
                    pbLogo.Image = uiUtilidades.ByteArrayToImage(negocioDatos.Logo);
                }

                txtNombreNegocio.Text = negocioDatos.Nombre;
                txtDireccionNegocio.Text = negocioDatos.Direccion;
                txtTelefonoNegocio.Text = negocioDatos.Telefono;
                txtCorreoNegocio.Text = negocioDatos.Correo;

                // Datos personales
                cmbTipoDocumento.SelectedItem = negocioDatos.TipoDocumento;
                txtDocumentoDueño.Text = negocioDatos.Documento;

                // Monedas
                txtNombreMoneda.Text = moneda.Nombre;
                txtSimboloMoneda.Text = moneda.Simbolo;
                if (moneda.Posicion == "Antes")
                    rbAntes.Checked = true;
                else
                    rbDespues.Checked = true;

                // Impuestos
                if (negocioDatos.Impuestos)
                    rbImpuestoSi.Checked = true;
                else
                    rbImpuestoNo.Checked = true;
                txtNombreImpuesto.Text = impuesto.Nombre;
                txtPorcentajeImpuesto.Text = impuesto.Porcentaje.ToString();

            }
            else
            {
                throw new Exception("Ocurrió un error al obtener los datos del negocio, contacte con el administrador del sistema si este error persiste.");
            }
        }

        private void btnBuscarMoneda_Click(object sender, EventArgs e)
        {
            using (var modal = new mdBuscarMoneda())
            {
                DialogResult resultado = modal.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    if (modal.monedaSeleccionada != null)
                    {
                        txtNombreMoneda.Text = modal.monedaSeleccionada.Nombre;
                        txtSimboloMoneda.Text = modal.monedaSeleccionada.Simbolo;
                        monedaSeleccionada = modal.monedaSeleccionada;
                        // posicion de moneda radiobuttons 
                        lblMuestraMoneda_Formato();
                    }
                    else
                    {
                        MessageBox.Show("No se seleccionó ninguna moneda", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
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

        private void radioButtos_CheckedChanged(object sender, EventArgs e)
        {
            lblMuestraMoneda_Formato();
        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            // Eliminar imagen
            if (negocioDatos.Logo != null)
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar la imagen?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    pbLogo.Image = uiUtilidades.LogoPorDefecto();
                    logoModificado = true;
                }
            }
            else
            {
                MessageBox.Show("No hay ninguna imagen para eliminar", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AbrirImagen()
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Archivo de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            abrir.Title = "Seleccione una imagen";
            abrir.ShowDialog();

            if (!string.IsNullOrEmpty(abrir.FileName))
            {
                pbLogo.Image = Image.FromFile(abrir.FileName);
                logoModificado = true;
            }
        }

        private void GuardarImagen()
        {
            try
            {
                string logoFileName = "logo.png";
                string directoryPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SGF.PRESENTACION", "Recursos", "Logo negocio");
                Directory.CreateDirectory(directoryPath);
                string path = System.IO.Path.Combine(directoryPath, logoFileName);
                pbLogo.Image.Save(path);
                negocioDatos.Logo = uiUtilidades.ImageToByteArray(pbLogo.Image);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {
            // abrir savefiledialog para seleccionar imagen
            try
            {
                if (negocioDatos.Logo != null)
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro que desea cambiar la imagen?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        logoModificado = true;
                        AbrirImagen();
                    }
                }
                else
                {
                    AbrirImagen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "contacte con el administrador del sistema si el error persiste.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tipo de documento

        private void chkOtroDocumento_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtroDocumento.Checked)
            {
                cmbTipoDocumento.Enabled = false;
                cmbTipoDocumento.Visible = false;

                txtOtroDocumento.Enabled = true;
                txtOtroDocumento.Visible = true;
                txtOtroDocumento.Focus();
            }
            else
            {
                cmbTipoDocumento.Enabled = true;
                cmbTipoDocumento.Visible = true;
                cmbTipoDocumento.Focus();

                txtOtroDocumento.Enabled = false;
                txtOtroDocumento.Visible = false;
            }
        }

        // Impuestos
        private void radioButtonsImpuestos_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Name == rbImpuestoSi.Name)
            {
                pnlNombreDeImpuesto.Enabled = true;
                txtNombreImpuesto.Enabled = true;
                txtPorcentajeImpuesto.Enabled = true;
            }
            else
            {
                pnlNombreDeImpuesto.Enabled = false;
                txtNombreImpuesto.Enabled = false;
                txtPorcentajeImpuesto.Enabled = false;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea salir del formulario?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void lblMuestraMoneda_Formato()
        {
            // cada vez que se activa un evento, este deberá cambiar según el formato de la moneda
            string simboLoMoneda = string.IsNullOrEmpty(txtSimboloMoneda.Text) ? "$" : txtSimboloMoneda.Text;
            if (rbAntes.Checked)
            {
                lblMuestraMoneda.Text = txtSimboloMoneda.Text + " 543.21";
            }
            else
            {
                lblMuestraMoneda.Text = "543.21 " + txtSimboloMoneda.Text;
            }
        }

        private void txtSimboloMoneda_TextChanged(object sender, EventArgs e)
        {
            lblMuestraMoneda_Formato();
        }
    }
}
