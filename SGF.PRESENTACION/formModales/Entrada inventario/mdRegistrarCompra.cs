using SGF.MODELO;
using SGF.MODELO.Negocio;
using SGF.NEGOCIO.Negocio;
using SGF.NEGOCIO.Seguridad;
using SGF.PRESENTACION.UtilidadesComunes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.formModales
{
    public partial class mdRegistrarCompra : Form
    {
        private CompraBLL lCompra = CompraBLL.ObtenerInstancia;
        private ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;
        private ProveedorBLL lProveedor = ProveedorBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;

        private Proveedor proveedorSeleccionado { get; set; }


        private List<Producto> productosSeleccionados { get; set; }

        List<Proveedor> listaProveedores { get; set; }

        public mdRegistrarCompra()
        {
            InitializeComponent();
            listaProveedores = new List<Proveedor>();
            productosSeleccionados = new List<Producto>();
        }

        private void mdRegistrarCompra_Load(object sender, EventArgs e)
        {
            try
            {
                cargarComboboxyDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (cmbProveedor.SelectedIndex > 0)
            {
                proveedorSeleccionado = listaProveedores.FirstOrDefault(prov => prov.RazonSocial == cmbProveedor.SelectedItem.ToString());
                if (lProveedor.ProveedorTieneProductos(proveedorSeleccionado.ProveedorID))
                {
                    using (var modal = new mdCompraProducto(proveedorSeleccionado))
                    {
                        var resultado = modal.ShowDialog();
                        if (resultado == DialogResult.OK)
                        {
                            if (modal.productoSeleccionado != null)
                            {
                                Producto producto = new Producto();
                                producto = modal.productoSeleccionado;

                                DataGridViewRow existeFila = dgvProductos.Rows
                                    .Cast<DataGridViewRow>()
                                    .FirstOrDefault(row => Convert.ToInt32(row.Cells["dgvcID"].Value) == producto.ProductoID);

                                if (existeFila != null)
                                {
                                    // significa que existe el producto en la lista
                                    // aumentar la cantidad, modificar preciocompra y subtotal
                                    int cantidadExistente = Convert.ToInt32(existeFila.Cells["dgvcCantidad"].Value);
                                    decimal precioExistente = Convert.ToDecimal(existeFila.Cells["dgvcPrecioCompra"].Value);

                                    if (precioExistente != producto.PrecioCompra)
                                    {
                                        existeFila.Cells["dgvcPrecioCompra"].Value = producto.PrecioCompra;
                                    }
                                    existeFila.Cells["dgvcCantidad"].Value = cantidadExistente + producto.Stock;
                                    existeFila.Cells["dgvcSubTotal"].Value = (cantidadExistente + producto.Stock) * producto.PrecioCompra;

                                    // modificar lista una vez que se modifica la tabla
                                    productosSeleccionados.FirstOrDefault(prod => prod.ProductoID == producto.ProductoID).Stock = cantidadExistente + producto.Stock;
                                    productosSeleccionados.FirstOrDefault(prod => prod.ProductoID == producto.ProductoID).PrecioCompra = producto.PrecioCompra;
                                }
                                else
                                {
                                    // significa que no existe el producto en la lista
                                    decimal subTotal = producto.PrecioCompra * producto.Stock;
                                    dgvProductos.Rows.Add(producto.ProductoID, producto.Nombre, producto.Stock, producto.PrecioCompra, subTotal);

                                    // Agregar el producto a la lista solo si no existe en el DataGridView
                                    productosSeleccionados.Add(producto);
                                }
                                // calcular total
                                calcularTotal();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El proveedor seleccionado no tiene productos registrados, por favor seleccione otro proveedor.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    proveedorSeleccionado = new Proveedor();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para agregar productos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.SelectedCells.Count > 0)
                {
                    DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar el producto seleccionado?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        foreach (DataGridViewCell celda in dgvProductos.SelectedCells)
                        {
                            int filaIndex = celda.RowIndex;
                            // buscar el producto en la lista y eliminarlo
                            int productoID = Convert.ToInt32(dgvProductos.Rows[filaIndex].Cells["dgvcID"].Value);
                            Producto producto = productosSeleccionados.FirstOrDefault(prod => prod.ProductoID == productoID);
                            if (producto != null)
                            {
                                productosSeleccionados.Remove(producto);
                            }
                            dgvProductos.Rows.RemoveAt(filaIndex);
                            calcularTotal();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar todo el datagridview
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea limpiar el listado de productos?", "Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                dgvProductos.Rows.Clear();
                productosSeleccionados.Clear();
                cmbProveedor.SelectedIndex = 0;
                calcularTotal();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que el proveedor seleccionado tenga productos
                if (cmbProveedor.SelectedIndex > 0)
                {
                    if (productosSeleccionados.Count > 0)
                    {
                        // Detalles de la compra
                        DataTable dtDetalleCompra = new DataTable();
                        dtDetalleCompra.Columns.Add("dgvcID", typeof(int));
                        dtDetalleCompra.Columns.Add("dgvcNombre", typeof(string));
                        dtDetalleCompra.Columns.Add("dgvcCantidad", typeof(int));
                        dtDetalleCompra.Columns.Add("dgvcPrecioCompra", typeof(decimal));

                        foreach(DataGridViewRow fila in dgvProductos.Rows)
                        {
                            dtDetalleCompra.Rows.Add(
                                new object[]
                                {
                                    Convert.ToInt32(fila.Cells["dgvcID"].Value),
                                    fila.Cells["dgvcNombre"].Value.ToString(),
                                    Convert.ToInt32(fila.Cells["dgvcCantidad"].Value),
                                    Convert.ToDecimal(fila.Cells["dgvcPrecioCompra"].Value)
                                });
                        }

                        // Compra
                        Compra compra = new Compra();
                        compra.usuario = lSesion.UsuarioEnSesion().Usuario;
                        compra.proveedor = proveedorSeleccionado;
                        compra.Factura = cmbTipoDeDocumento.Text;
                        compra.FechaCompra = dtpFecha.Value;


                        if (lCompra.RegistrarCompra(compra, dtDetalleCompra))
                        {
                            // modificar los productos seleccionados
                            foreach (Producto producto in productosSeleccionados)
                            {
                                lProducto.ModificarProducto(producto);
                            }
                            MessageBox.Show("La compra se ha registrado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar la compra", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay productos seleccionados para registrar la compra", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un proveedor para registrar la compra", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calcularTotal()
        {
            if (dgvProductos.Rows.Count == 0)
            {
                txtTotal.Text = "0,00";
            }
            else
            {
                decimal total = 0;
                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    // Verifica si el valor es numérico antes de convertirlo
                    if (decimal.TryParse(fila.Cells["dgvcSubTotal"].Value.ToString(), out decimal valor))
                    {
                        total += valor;
                    }
                }
                txtTotal.Text = total.ToString();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea cancelar el registro de la compra?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        // Manejo de Interfaz
        private void cargarComboboxyDatos()
        {
            // obtener folio y sumarle 1
            txtFolio.Text = lCompra.ObtenerFolio().ToString();
            dtpFecha.Value = DateTime.Now;
            // Cargar Combobox
            cmbProveedor.Items.Add("Seleccione un proveedor...");
            listaProveedores = lProveedor.ListaProveedores();
            foreach (var proveedor in listaProveedores)
            {
                if (!cmbProveedor.Items.Contains(proveedor.RazonSocial))
                {
                    cmbProveedor.Items.Add(proveedor.RazonSocial);
                }
            }
            cmbProveedor.SelectedIndex = 0;

            cmbTipoDeDocumento.Items.Add("Factura");
            cmbTipoDeDocumento.Items.Add("Boleta");
            cmbTipoDeDocumento.SelectedIndex = 0;
            txtTotal.Text = "0.00";
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = string.Format(CultureInfo.GetCultureInfo("es-AR"), "{0:N2}", Convert.ToDecimal(txtTotal.Text));
        }

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

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            // si el datagridview no está vacio y productoSeleccionado no está vacio, se le pregunta al usuario si desea cambiar de proveedor
            // si lo cambia, se limpia el datagridview y la lista de productos seleccionados
            if (dgvProductos.Rows.Count > 0 && productosSeleccionados.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro que desea cambiar de proveedor? Se perderán los productos seleccionados.", "Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    dgvProductos.Rows.Clear();
                    productosSeleccionados.Clear();
                    calcularTotal();
                }
                else
                {
                    cmbProveedor.SelectedIndexChanged -= cmbProveedor_SelectedIndexChanged;
                    cmbProveedor.SelectedItem = proveedorSeleccionado.RazonSocial;
                    cmbProveedor.SelectedIndexChanged += cmbProveedor_SelectedIndexChanged;
                }
            }
        }

        
    }
}
