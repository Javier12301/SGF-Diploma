using SGF.MODELO.Seguridad;
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

namespace SGF.PRESENTACION.formPrincipales
{
    public partial class formProveedores : Form
    {
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private ProveedorBLL lProveedor = ProveedorBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private Permiso permisosDeUsuario;

        public formProveedores()
        {
            InitializeComponent();
        }

        private void formProveedores_Load(object sender, EventArgs e)
        {
            try
            {
                cargarLista();
                cargarPermisos();
                cargarFiltros();
                tsmiID.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarPermisos()
        {
            permisosDeUsuario = new Permiso();
            uiUtilidades.cargarPermisos(this.GetType().Name, flpContenedorBotones, permisosDeUsuario);
        }

        // Alta
        private void btnNuevoP_Click(object sender, EventArgs e)
        {

        }

        // Modificación
        private void btnModificarP_Click(object sender, EventArgs e)
        {

        }
        // Baja
        private void btnEliminarP_Click(object sender, EventArgs e)
        {

        }

        // Exportar
        private void btnExportarP_Click(object sender, EventArgs e)
        {
            try
            {
                if (permisosDeUsuario.Exportar)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    uiUtilidades.ExportarDataGridViewAExcel(dgvProveedores, "Lista de proveedores", "Informe de proveedores");
                }
                else
                {
                    MessageBox.Show("No tiene permisos para realizar esta acción.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Manejo de filtros
        private void cargarLista()
        {
            if (txtBuscar.Text != string.Empty || cmbFiltroBuscar.SelectedIndex > 0 || cmbFiltroEstado.SelectedIndex > 0 || cmbFiltroTipoDocumento.SelectedIndex > 0)
            {
                filtrarLista();
            }
            else
            {
                this.proveedorTableAdapter.Fill(this.negocio.Proveedor);
            }
        }

        private void filtrarLista()
        {
            if (cmbFiltroBuscar.SelectedIndex == 0 && cmbFiltroEstado.SelectedIndex == 0 && cmbFiltroTipoDocumento.SelectedIndex == 0 && string.IsNullOrEmpty(txtBuscar.Text))
            {
                this.proveedorTableAdapter.Fill(this.negocio.Proveedor);
            }
            else
            {
                aplicarFiltro();
            }
        }

        private void aplicarFiltro()
        {
            this.proveedorTableAdapter.Filtrar(this.negocio.Proveedor, cmbFiltroBuscar.Text, txtBuscar.Text, cmbFiltroTipoDocumento.Text, cmbFiltroEstado.Text);
        }

        private void cargarFiltros()
        {
            cmbFiltroBuscar.Items.Add("Todo");
            cmbFiltroBuscar.Items.Add("Razón social");
            cmbFiltroBuscar.Items.Add("Documento");
            cmbFiltroBuscar.Items.Add("Dirección");
            cmbFiltroBuscar.Items.Add("Teléfono");
            cmbFiltroBuscar.SelectedIndex = 0;

            cmbFiltroEstado.Items.Add("Todos");
            cmbFiltroEstado.Items.Add("Activo");
            cmbFiltroEstado.Items.Add("Inactivo");
            cmbFiltroEstado.SelectedIndex = 0;

            // Filtro tipo de documento
            List<Proveedor> listaProveedores = lProveedor.ListaProveedores();
            // Obtener los tipos documentos y cargarlos en el combo, si ya existe en el combo el tipo de documento no se agrega
            cmbFiltroTipoDocumento.Items.Add("Todos");
            foreach (Proveedor proveedor in listaProveedores)
            {
                if (!cmbFiltroTipoDocumento.Items.Contains(proveedor.TipoDocumento) && proveedor.TipoDocumento != "N/A")
                {
                    cmbFiltroTipoDocumento.Items.Add(proveedor.TipoDocumento);
                }
            }
            cmbFiltroTipoDocumento.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarLista();
        }

        private void cmbFiltroBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        // Manejo de interfaz
        private void tsmiButtons_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            item.Checked = !item.Checked;
        }

        private void tsmiMenu_CheckChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            foreach (ToolStripMenuItem subItem in item.DropDownItems)
            {
                subItem.Checked = item.Checked;
            }
        }

        private void tsmi_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem subMenu = (ToolStripMenuItem)sender;
            switch (subMenu.Name)
            {
                case "tsmiID":
                    dgvProveedores.Columns["dgvcID"].Visible = subMenu.Checked;
                    break;
                case "tsmiRazonSocial":
                    dgvProveedores.Columns["dgvcRazonSocial"].Visible = subMenu.Checked;
                    break;
                case "tsmiTipoDocumento":
                    dgvProveedores.Columns["dgvcTipoDocumento"].Visible = subMenu.Checked;
                    break;
                case "tsmiDocumento":
                    dgvProveedores.Columns["dgvcDocumento"].Visible = subMenu.Checked;
                    break;
                case "tsmiDireccion":
                    dgvProveedores.Columns["dgvcDireccion"].Visible = subMenu.Checked;
                    break;
                case "tsmiTelefono":
                    dgvProveedores.Columns["dgvcTelefono"].Visible = subMenu.Checked;
                    break;
                case "tsmiCorreo":
                    dgvProveedores.Columns["dgvcCorreo"].Visible = subMenu.Checked;
                    break;
                case "tsmiEstado":
                    dgvProveedores.Columns["dgvcEstado"].Visible = subMenu.Checked;
                    break;
                default:
                    break;
            }
        }

        private void tsdMostrar_DropDownOpened(object sender, EventArgs e)
        {
            tsdMostrar.ForeColor = Color.Black;
            tsdMostrar.Image = Properties.Resources.checkList_Negro;
        }

        private void tsdMostrar_DropDownClosed(object sender, EventArgs e)
        {
            tsdMostrar.ForeColor = Color.White;
            tsdMostrar.Image = Properties.Resources.checkList_Blanco;
        }

        private void dgvProveedores_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvProveedores.Rows[e.RowIndex].Cells["dgvcEstado"].Value.ToString() == "True")
                {
                    lblEstado.Text = "Activo";
                    lblEstado.ForeColor = Color.Blue;
                }
                else
                {
                    lblEstado.Text = "Inactivo";
                    lblEstado.ForeColor = Color.Red;
                }
            }
        }
    }
}
