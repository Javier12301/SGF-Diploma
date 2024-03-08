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
        public mdClientes()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

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
    }
}
