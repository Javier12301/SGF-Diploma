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
using SGF.PRESENTACION.UtilidadesComunes;

namespace SGF.PRESENTACION.formPrincipales
{
    public partial class formProductos : Form
    {
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;

        private int cantidadAntes { get; set; }
        private int cantidadDespues { get; set; }

        private Permiso permisosDeUsuario;

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
            permisosDeUsuario = new Permiso();
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
                // Cargar permisos disponibles
                permisosDeUsuario.Alta = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Alta");
                permisosDeUsuario.Modificar = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Modificar");
                permisosDeUsuario.Baja = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Baja");
                permisosDeUsuario.Importar = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Importar");
                permisosDeUsuario.Exportar = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Exportar");
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
            if (permisosDeUsuario.Alta)
            {
                using (var modal = new mdProductos())
                {
                    var resultado = modal.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        cargarLista();
                    }
                }
            }
            else
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Modificar
        private void btnModificarP_Click(object sender, EventArgs e)
        {
            abrirModalModificar();
        }

        private void dgvProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Se debe ignorar la celda de cabecera
            if (e.RowIndex >= 0)
            {
                abrirModalModificar();
            }
        }

        private void abrirModalModificar()
        {
            try
            {
                if (permisosDeUsuario.Modificar)
                {
                    if (dgvProductos.CurrentCell != null)
                    {
                        int filaIndex = dgvProductos.CurrentCell.RowIndex;
                        int productoID = Convert.ToInt32(dgvProductos.Rows[filaIndex].Cells["dgvcID"].Value.ToString());
                        if (productoID > 0)
                        {
                            using (var modal = new mdProductos(true, productoID))
                            {
                                var resultado = modal.ShowDialog();
                                if (resultado == DialogResult.OK)
                                {
                                    cargarLista();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se ha seleccionado ningún producto. Por favor, seleccione un producto de la lista e inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No tiene permiso para realizar esta acción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Baja
        private void btnEliminarP_Click(object sender, EventArgs e)
        {
            bajaProducto();
        }


        private void dgvProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                bajaProducto();
            }
        }

        private void bajaProducto()
        {
            try
            {
                if (permisosDeUsuario.Baja)
                {
                    if (dgvProductos.SelectedCells.Count == 0)
                    {
                        MessageBox.Show("Seleccione por lo menos un producto para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    List<int> productosAEliminar = new List<int>();
                    DialogResult resultado = MessageBox.Show("¿Estás seguro que desea eliminar los productos seleccionados?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado != DialogResult.Yes)
                        return;

                    productosAEliminar.Clear();

                    foreach (DataGridViewCell celda in dgvProductos.SelectedCells)
                    {
                        int productoID = Convert.ToInt32(dgvProductos.Rows[celda.RowIndex].Cells["dgvcID"].Value);

                        if (productoID > 0)
                        {
                            productosAEliminar.Add(productoID);
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un producto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    cantidadAntes = lProducto.ConteoProductos();
                    int productosEliminados = 0;

                    foreach (int productosID in productosAEliminar)
                    {
                        if (lProducto.BajaProducto(productosID))
                            productosEliminados++;
                        else
                            MessageBox.Show($"Ocurrió un error al intentar eliminar el producto con ID: {productosID}, contacte con el administardor del sistema para solucionar este error.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (productosEliminados > 0)
                    {
                        cantidadDespues = lProducto.ConteoProductos();
                        RegistroBLL.RegistrarMovimiento("Baja", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), productosEliminados, cantidadAntes, cantidadDespues, "Productos", $"Se eliminaron {productosEliminados} productos.");
                        MessageBox.Show(productosEliminados > 1 ? $"Se eliminaron {productosEliminados} productos con éxito." : "Producto eliminado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarLista();
                    }
                }
                else
                {
                    MessageBox.Show("No tiene permiso para realizar esta acción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Desea importar los productos desde un archivo de Excel?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(respuesta == DialogResult.Yes)
                {
                    MessageBox.Show("Se creará una planilla de Excel con el formato necesario para importar los productos. Por favor, complete la planilla con los datos de los productos deseados cumpliendo con el formato indicado.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarP_Click(object sender, EventArgs e)
        {
            try
            {
                if (permisosDeUsuario.Exportar)
                {
                    uiUtilidades.ExportarDataGridViewAExcel(dgvProductos, "Lista de productos", "Informe de productos");

                }
                else
                {
                    MessageBox.Show("No tiene permiso para realizar esta acción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Maenjo de filtros
        private void cargarLista()
        {
            if (txtBuscar.Text != string.Empty || cmbFiltroBuscar.SelectedIndex > 0 || cmbFiltroCategoria.SelectedIndex > 0 || cmbFiltroTipoProducto.SelectedIndex > 0 || cmbFiltroEstado.SelectedIndex > 0)
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
            dtpFin.Value = DateTime.Now.AddYears(5);

            // Filtro estado
            cmbFiltroEstado.Items.Add("Todos");
            cmbFiltroEstado.Items.Add("Activo");
            cmbFiltroEstado.Items.Add("Inactivo");
            cmbFiltroEstado.SelectedIndex = 0;

            // Filtro Categoría
            cmbFiltroCategoria.Items.Add("Todos");
            // Obtener las categorías existentes referenciada en la tabla Producto
            List<Categoria> listaCategorias = lProducto.ObtenerCategoriasExistentes();
            foreach (var categoria in listaCategorias)
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
