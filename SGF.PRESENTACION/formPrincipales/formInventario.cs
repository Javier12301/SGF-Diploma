using SGF.MODELO.Negocio;
using SGF.MODELO.Seguridad;
using SGF.NEGOCIO.Negocio;
using SGF.NEGOCIO.Seguridad;
using SGF.PRESENTACION.formModales;
using SGF.PRESENTACION.formModales.Salida_inventario;
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
    public partial class formInventario : Form
    {
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;
        private CategoriaBLL lCategoria = CategoriaBLL.ObtenerInstancia;

        private Permiso permisoDeUsuario;

        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        public formInventario()
        {
            InitializeComponent();
        }


        private void formInventario_Load(object sender, EventArgs e)
        {
            try
            {
                cargarFiltros();
                filtrarLista();
                chkVencimiento.Checked = false;
                cargarGrillaInventario();
                permisoDeUsuario = new Permiso();
                uiUtilidades.cargarPermisos(this.GetType().Name, flpContenedorBotones, permisoDeUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEntradaMasiva_Click(object sender, EventArgs e)
        {
            if (permisoDeUsuario.EntradaMasiva)
            {
                using(var modal = new mdEntradaInventario(permisoDeUsuario))
                {
                    var resultado = modal.ShowDialog();
                    if(resultado == DialogResult.OK)
                    {
                        filtrarLista();
                    }
                }

            }
            else
            {
                MessageBox.Show("No tiene permiso para realizar esta acción", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalidaMasiva_Click(object sender, EventArgs e)
        {
            if (permisoDeUsuario.SalidaMasiva)
            {
                if (permisoDeUsuario.SalidaMasiva)
                {
                    using(var modal = new mdSalidaInventario(permisoDeUsuario))
                    {
                        var resultado = modal.ShowDialog();
                        if(resultado == DialogResult.OK)
                        {
                            filtrarLista();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No tiene permiso para realizar esta acción", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnExportarP_Click(object sender, EventArgs e)
        {
            try
            {
                if (permisoDeUsuario.Exportar)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    uiUtilidades.ExportarDataGridViewAExcel(dgvInventario, "Inventario de productos", "Informe de inventario", "Inventario");
                }
                else
                {
                    MessageBox.Show("No tiene permiso para realizar esta acción", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filtrarLista()
        {
            if (flpVencimiento.Enabled)
            {
                this.productoTableAdapter.Filtrar(this.negocio.Producto, cmbFiltroBuscar.Text, txtBuscar.Text, cmbFiltroTipoProducto.Text, cmbFiltroCategoria.Text, "Activo", dtpInicio.Value, dtpFin.Value);
            }
            else
            {
                this.productoTableAdapter.Filtrar(this.negocio.Producto, cmbFiltroBuscar.Text, txtBuscar.Text, cmbFiltroTipoProducto.Text, cmbFiltroCategoria.Text, "Activo", null, null);
            }
        }

        private void cargarFiltros()
        {
            // Filtro buscar por
            cmbFiltroBuscar.Items.Add("Todo");
            cmbFiltroBuscar.Items.Add("Código");
            cmbFiltroBuscar.Items.Add("Nombre");
            cmbFiltroBuscar.Items.Add("Proveedor");
            cmbFiltroBuscar.Items.Add("Lote");
            cmbFiltroBuscar.SelectedIndex = 0;

            // Filtro fecha de vencimiento
            dtpInicio.Value = DateTime.Now.AddYears(-2);
            dtpFin.Value = DateTime.Now.AddYears(5);

            // Filtro Categoría
            cmbFiltroCategoria.Items.Add("Todos");
            List<Categoria> listaCategorias = lProducto.ObtenerCategoriasExistentes();
            foreach (Categoria categoria in listaCategorias)
            {
                if (!cmbFiltroCategoria.Items.Contains(categoria.Nombre))
                {
                    cmbFiltroCategoria.Items.Add(categoria.Nombre);
                }
            }
            cmbFiltroCategoria.SelectedIndex = 0;

            cmbFiltroTipoProducto.Items.Add("Todos");
            cmbFiltroTipoProducto.Items.Add("Producto general");
            cmbFiltroTipoProducto.Items.Add("Medicamentos");
            cmbFiltroTipoProducto.SelectedIndex = 0;
        }



        // Manejo de filtros
        private void cmbFiltroBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void chkVencimiento_CheckedChanged(object sender, EventArgs e)
        {
            flpVencimiento.Enabled = chkVencimiento.Checked;
            filtrarLista();
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            filtrarLista();
        }

        // Manejo de Interfaz

        private void cargarGrillaInventario()
        {
            tsmiID.Checked = false;
            tsmiPrecioCompra.Checked = false;
            tsmiPrecioVenta.Checked = false;
            tsmiRefrigerado.Checked = false;
            tsmiReceta.Checked = false;
            tsmiEstado.Checked = false;
        }

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
                    dgvInventario.Columns["dgvcID"].Visible = subMenu.Checked;
                    break;
                case "tsmiCodigo":
                    dgvInventario.Columns["dgvcCodigo"].Visible = subMenu.Checked;
                    break;
                case "tsmiNombre":
                    dgvInventario.Columns["dgvcNombre"].Visible = subMenu.Checked;
                    break;
                case "tsmiProveedor":
                    dgvInventario.Columns["dgvcProveedor"].Visible = subMenu.Checked;
                    break;
                case "tsmiNombreCategoria":
                    dgvInventario.Columns["dgvcCategoria"].Visible = subMenu.Checked;
                    break;
                case "tsmiStock":
                    dgvInventario.Columns["dgvcStock"].Visible = subMenu.Checked;
                    break;
                case "tsmiLote":
                    dgvInventario.Columns["dgvcLote"].Visible = subMenu.Checked;
                    break;
                case "tsmiVencimiento":
                    dgvInventario.Columns["dgvcVencimiento"].Visible = subMenu.Checked;
                    break;
                case "tsmiTipoProducto":
                    dgvInventario.Columns["dgvcTipoProducto"].Visible = subMenu.Checked;
                    break;
                case "tsmiPrecioVenta":
                    dgvInventario.Columns["dgvcPrecioVenta"].Visible = subMenu.Checked;
                    break;
                case "tsmiPrecioCompra":
                    dgvInventario.Columns["dgvcPrecioCompra"].Visible = subMenu.Checked;
                    break;
                case "tsmiRefrigerado":
                    dgvInventario.Columns["dgvcRefrigerado"].Visible = subMenu.Checked;
                    break;
                case "tsmiReceta":
                    dgvInventario.Columns["dgvcReceta"].Visible = subMenu.Checked;
                    break;
                case "tsmiEstado":
                    dgvInventario.Columns["dgvcEstado"].Visible = subMenu.Checked;
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
            // cargar de recursos la imagen checlist blanca
            tsdMostrar.Image = Properties.Resources.checkList_Blanco;
        }


    }
}
