using SGF.MODELO.Seguridad;
using SGF.NEGOCIO.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGF.PRESENTACION.formModales;
using System.Windows.Forms;
using Irony;
using SGF.NEGOCIO.Negocio;

namespace SGF.PRESENTACION.formPrincipales
{
    public partial class formProductos : Form
    {
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;

        public formProductos()
        {
            InitializeComponent();
        }

        private void formProductos_Load(object sender, EventArgs e)
        {
            cargarLista();
            cargarPermisos();
            cargarFiltros();
            tsmiID.Checked = false;
            chkVencimiento.Checked = false;
        }

        private void cargarPermisos()
        {
            List<Modulo> modulosPermitidos = lSesion.UsuarioEnSesion().Usuario.ObtenerModulosPermitidos();
            string nombreFormulario = this.GetType().Name;

            Modulo moduloProductos = modulosPermitidos.FirstOrDefault(m => m.Descripcion == nombreFormulario);

            // Si se encuentra el módulo 'formProductos', obtener las acciones permitidas
            List<Accion> accionesPermitidas = null;
            if (moduloProductos != null)
            {
                accionesPermitidas = moduloProductos.ListaAcciones;
            }

            // Buscar el módulo correspondiente al formulario actual
            Modulo moduloActual = modulosPermitidos.FirstOrDefault(m => m.Descripcion == nombreFormulario);

            // Si se encuentra el módulo, cargar las opciones
            if (moduloActual != null)
            {
                foreach (Control control in flpContenedorBotones.Controls)
                {
                    if (control is Button && control.Tag != null)
                    {
                        // Obtener el nombre de la acción desde el Tag del botón
                        string nombreAccionBoton = control.Tag.ToString();

                        // Verificar si el nombre de la acción está en la lista de acciones del módulo
                        bool tienePermiso = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == nombreAccionBoton);

                        // Activar o desactivar el botón según los permisos
                        control.Enabled = tienePermiso;
                        control.Visible = tienePermiso;
                    }
                }
            }

            // Verificar si el módulo 'formCategorias' está permitido
            Modulo moduloCategoria = modulosPermitidos.FirstOrDefault(m => m.Descripcion == "formCategorias");
            if (moduloCategoria != null)
            {
                btnCategorias.Enabled = true;
                btnCategorias.Visible = true;
            }
        }

        // Alta
        private void btnNuevoP_Click(object sender, EventArgs e)
        {
            using(var modal = new mdProductos())
            {
                var resultado = modal.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    cargarLista();
                }
            }
        }

        // Modificar
        private void btnModificarP_Click(object sender, EventArgs e)
        {

        }

        // Baja
        private void btnEliminarP_Click(object sender, EventArgs e)
        {

        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            if (btnCategorias.Enabled)
            {
                using (var modal = new mdCategorias())
                {
                    var resultado = modal.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        cargarLista();
                    }
                }
            }
        }

        private void btnImportarP_Click(object sender, EventArgs e)
        {

        }

        private void btnExportarP_Click(object sender, EventArgs e)
        {

        }

        // Maenjo de filtros
        private void cargarLista()
        {
            if(txtBuscar.Text != string.Empty || cmbFiltroBuscar.SelectedIndex > 0 || cmbFiltroCategoria.SelectedIndex >  0 || cmbFiltroTipoProducto.SelectedIndex > 0 || cmbFiltroEstado.SelectedIndex > 0)
            {
                filtrarLista();
            }
            else
            {
                this.productoTableAdapter.Fill(this.negocio.Producto);
            }
        }

        private void filtrarLista()
        {
            if (cmbFiltroBuscar.SelectedIndex == 0 && cmbFiltroCategoria.SelectedIndex == 0 && cmbFiltroTipoProducto.SelectedIndex == 0 && cmbFiltroEstado.SelectedIndex == 0 && string.IsNullOrEmpty(txtBuscar.Text))
            {
                this.productoTableAdapter.Fill(this.negocio.Producto);
            }
            else
            {
                aplicarFiltro();
            }
        }

        private void aplicarFiltro()
        {
            if (flpVencimiento.Enabled)
            {
                this.productoTableAdapter.Filtrar(this.negocio.Producto, cmbFiltroBuscar.Text, txtBuscar.Text, cmbFiltroTipoProducto.Text, cmbFiltroCategoria.Text, cmbFiltroEstado.Text, dtpInicio.Value, dtpFin.Value);
            }
            else
            {
                this.productoTableAdapter.Filtrar(this.negocio.Producto, cmbFiltroBuscar.Text, txtBuscar.Text, cmbFiltroTipoProducto.Text, cmbFiltroCategoria.Text, cmbFiltroEstado.Text, null, null);
            }
        }
      
        private void cargarFiltros()
        {
            // Filtro de buscar por
            cmbFiltroBuscar.Items.Add("Todo");
            cmbFiltroBuscar.Items.Add("Código");
            cmbFiltroBuscar.Items.Add("Nombre");
            cmbFiltroBuscar.Items.Add("Proveedor");
            cmbFiltroBuscar.Items.Add("Lote");
            cmbFiltroBuscar.SelectedIndex = 0;

            // Filtro fecha de vencimiento
            dtpInicio.Value = DateTime.Now.AddYears(-2);
            dtpFin.Value = DateTime.Now.AddYears(1);

            // Filtro estado
            cmbFiltroEstado.Items.Add("Todos");
            cmbFiltroEstado.Items.Add("Activo");
            cmbFiltroEstado.Items.Add("Inactivo");
            cmbFiltroEstado.SelectedIndex = 0;

            // Filtro Categoría
            cmbFiltroCategoria.Items.Add("Todos");
            // Obtener las categorías existentes referenciada en la tabla Producto
            List<Categoria> listaCategorias = lProducto.ObtenerCategoriasExistentes();
            foreach(var categoria in listaCategorias)
            {
                // Comprobar que no exista la categoría en el combobox
                if (!cmbFiltroCategoria.Items.Contains(categoria.Nombre))
                {
                    cmbFiltroCategoria.Items.Add(categoria.Nombre);
                }
            }
            cmbFiltroCategoria.SelectedIndex = 0;

            // Filtro tipo de productos
            cmbFiltroTipoProducto.Items.Add("Todos");
            cmbFiltroTipoProducto.Items.Add("Producto general");
            cmbFiltroTipoProducto.Items.Add("Medicamentos");
            cmbFiltroTipoProducto.SelectedIndex = 0;
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarLista();
        }

        private void cmbFiltro_SelecteIndexChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            aplicarFiltro();
        }

        private void chkVencimiento_CheckedChanged(object sender, EventArgs e)
        {
            flpVencimiento.Enabled = chkVencimiento.Checked;
            aplicarFiltro();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        // Manejo de Interfaz
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
                    dgvProductos.Columns["dgvcID"].Visible = subMenu.Checked;
                    break;
                case "tsmiCodigo":
                    dgvProductos.Columns["dgvcCodigo"].Visible = subMenu.Checked;
                    break;
                case "tsmiNombre":
                    dgvProductos.Columns["dgvcNombre"].Visible = subMenu.Checked;
                    break;
                case "tsmiProveedor":
                    dgvProductos.Columns["dgvcProveedor"].Visible = subMenu.Checked;
                    break;
                case "tsmiNombreCategoria":
                    dgvProductos.Columns["dgvcCategoria"].Visible = subMenu.Checked;
                    break;
                case "tsmiStock":
                    dgvProductos.Columns["dgvcStock"].Visible = subMenu.Checked;
                    break;
                case "tsmiLote":
                    dgvProductos.Columns["dgvcLote"].Visible = subMenu.Checked;
                    break;
                case "tsmiVencimiento":
                    dgvProductos.Columns["dgvcVencimiento"].Visible = subMenu.Checked;
                    break;
                case "tsmiTipoProducto":
                    dgvProductos.Columns["dgvcTipoProducto"].Visible = subMenu.Checked;
                    break;
                case "tsmiPrecioVenta":
                    dgvProductos.Columns["dgvcPrecioVenta"].Visible = subMenu.Checked;
                    break;
                case "tsmiPrecioCompra":
                    dgvProductos.Columns["dgvcPrecioCompra"].Visible = subMenu.Checked;
                    break;
                case "tsmiRefrigerado":
                    dgvProductos.Columns["dgvcRefrigerado"].Visible = subMenu.Checked;
                    break;
                case "tsmiReceta":
                    dgvProductos.Columns["dgvcReceta"].Visible = subMenu.Checked;
                    break;
                case "tsmiEstado":
                    dgvProductos.Columns["dgvcEstado"].Visible = subMenu.Checked;
                    break;
                default:
                    break;
            }
        }

        private void dgvProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Comprobar si la celda es mayor a 0
            if (e.RowIndex >= 0)
            {
                if (dgvProductos.Rows[e.RowIndex].Cells["dgvcEstado"].Value.ToString() == "True")
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
