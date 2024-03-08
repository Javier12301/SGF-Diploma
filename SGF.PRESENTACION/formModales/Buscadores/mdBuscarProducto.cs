using SGF.NEGOCIO.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.formModales.modalesBuscadores
{
    public partial class mdBuscarProducto : Form
    {
        private ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;

        private string filtroProveedor;
        private string filtroCategoria;
        public Producto productoSeleccionado;

        public mdBuscarProducto(Proveedor proveedorSeleccionado, Categoria categoriaSeleccionada)
        {
            InitializeComponent();
            if (proveedorSeleccionado == null)
                filtroProveedor = "Todos";
            else
                filtroProveedor = proveedorSeleccionado.RazonSocial;

            if(categoriaSeleccionada == null)
                filtroCategoria = "Todos";
            else
                filtroCategoria = categoriaSeleccionada.Nombre;
      
            productoSeleccionado = new Producto();
        }

        private void mdBuscarProducto_Load(object sender, EventArgs e)
        {
            try
            {
                cargarCombobox();
                filtrarTabla();
                int filasTotales = dgvProductos.Rows.Count;
                if(filasTotales == 0)
                {
                    MessageBox.Show("No se encontrarón productos con el proveedor y categoría seleccionados, por favor intente de nuevo.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            int filaIndex = dgvProductos.CurrentCell.RowIndex;
            if (filaIndex >= 0)
            {
                seleccionarProducto(filaIndex);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto de la lista", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void seleccionarProducto(int filaIndex)
        {
            if (filaIndex >= 0)
            {
                int productoID = Convert.ToInt32(dgvProductos.Rows[filaIndex].Cells["dgvcID"].Value);
                productoSeleccionado = lProducto.ObtenerProductoPorID(productoID);
                if (productoSeleccionado != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el producto seleccionado, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cargarCombobox()
        {
            cmbFiltroBuscar.Items.Add("Todo");
            cmbFiltroBuscar.Items.Add("Código");
            cmbFiltroBuscar.Items.Add("Nombre");
            cmbFiltroBuscar.Items.Add("Lote");
            cmbFiltroBuscar.SelectedIndex = 0;
        }

        private void filtrarTabla()
        {
            this.productoTableAdapter.FiltrarBuscarProducto(this.negocio.Producto, cmbFiltroBuscar.Text, txtBuscar.Text, filtroProveedor, "Todos", filtroCategoria, "Activo", null, null);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtrarTabla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            filtrarTabla();
        }

        private void cmbFiltroBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarTabla();
        }

        // Manejo de interfaz
        private Point mousePosicion;
        private void pnlControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int deltaX = e.X - mousePosicion.X;
                int deltaY = e.Y - mousePosicion.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }

        private void pnlControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousePosicion = e.Location;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                seleccionarProducto(e.RowIndex);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto de la lista", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
