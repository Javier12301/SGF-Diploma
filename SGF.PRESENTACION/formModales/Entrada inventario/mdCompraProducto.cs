using SGF.NEGOCIO.Negocio;
using SGF.PRESENTACION.formModales.modalesBuscadores;
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
    public partial class mdCompraProducto : Form
    {
        private CategoriaBLL lCategoria = CategoriaBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;

        private List<Categoria> listaCategoria { get; set; }

        private Proveedor proveedorSeleccionado { get; set; }
        private Categoria categoriaSeleccionada { get; set; }
        public Producto productoSeleccionado { get; set; }

        public mdCompraProducto(Proveedor proveedor)
        {
            InitializeComponent();
            listaCategoria = new List<Categoria>();
            proveedorSeleccionado = proveedor;
            productoSeleccionado = new Producto();
        }

        private void mdCompraProducto_Load(object sender, EventArgs e)
        {
            try
            {
                listaCategoria = lCategoria.ListarCategorias();
                cargarCombobox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            bool camposValidos = true;

            if (cmbCategoria.SelectedIndex > 0)
                camposValidos &= true;
            else
            {
                errorProvider.SetError(cmbCategoria, "Debe seleccionar una categoría.");
                camposValidos &= false;
            }

            if (!string.IsNullOrEmpty(txtCodigo.Text))
                camposValidos &= true;
            else
            {
                errorProvider.SetError(btnbuscar, "El campo no puede estar vacío.");
                camposValidos &= false;
            }

            if (!string.IsNullOrEmpty(txtNombre.Text))
                camposValidos &= true;
            else
            {
                errorProvider.SetError(txtNombre, "El campo no puede estar vacío.");
                camposValidos &= false;
            }

            if (txtCantidad.Text != "0" && !string.IsNullOrEmpty(txtCantidad.Text))
                camposValidos &= true;
            else
            {
                errorProvider.SetError(txtCantidad, "El campo no puede estar vacío.");
                camposValidos &= false;
            }

            // Verificar si cantidad es un número válido
            if (!int.TryParse(txtCantidad.Text, out int cantidad))
            {
                errorProvider.SetError(txtCantidad, "El campo debe ser un número válido.");
                camposValidos &= false;
            }
            else
            {
                if (cantidad <= 0)
                {
                    errorProvider.SetError(txtCantidad, "El campo debe ser un número mayor a 0.");
                    camposValidos &= false;
                }
            }

            if (!string.IsNullOrEmpty(txtPrecio.Text))
                camposValidos &= true;
            else
            {
                errorProvider.SetError(txtPrecio, "El campo no puede estar vacío.");
                camposValidos &= false;
            }

            return camposValidos;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if(productoSeleccionado != null && productoSeleccionado.Categoria != null && productoSeleccionado.Proveedor != null)
                {
                    if(productoSeleccionado.PrecioCompra != Convert.ToDecimal(txtPrecio.Text))
                    {
                        decimal precioCompra = Convert.ToDecimal(txtPrecio.Text);
                        decimal precioVenta = productoSeleccionado.PrecioVenta;
                        if(precioCompra > precioVenta)
                        {
                            // Precio de compra mayor al precio de venta, es un error
                            errorProvider.SetError(txtPrecio, $"El precio de compra no puede ser mayor al precio de venta el cual es: {productoSeleccionado.PrecioVenta}");
                            MessageBox.Show("El precio de compra no puede ser mayor al precio de venta.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    if (productoSeleccionado.CantidadMinima != 0)
                    {
                        if (productoSeleccionado.CantidadMinima > Convert.ToInt32(txtCantidad.Text))
                        {
                            errorProvider.SetError(txtCantidad, $"La cantidad ingresada no puede ser menor a la cantidad mínima la cual es: {productoSeleccionado.CantidadMinima}");
                            MessageBox.Show($"La cantidad ingresada no puede ser menor a la cantidad mínima la cual es: {productoSeleccionado.CantidadMinima}", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    productoSeleccionado.Stock += Convert.ToInt32(txtCantidad.Text);
                    productoSeleccionado.PrecioCompra = Convert.ToDecimal(txtPrecio.Text);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al seleccionar el producto, por favor intente de nuevo y , si el problema persiste, contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, asegúrese de llenar los campos correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if(proveedorSeleccionado != null)
            {
                if (cmbCategoria.SelectedIndex > 0)
                {
                    categoriaSeleccionada = listaCategoria.FirstOrDefault(cat => cat.Nombre == cmbCategoria.SelectedItem.ToString());
                    // Comprobar si la categoria seleccionada tiene productos
                    if (lCategoria.CategoriaTieneProductos(categoriaSeleccionada.CategoriaID))
                    {
                        using (var modal = new mdBuscarProducto(proveedorSeleccionado, categoriaSeleccionada))
                        {
                            var resultado = modal.ShowDialog();
                            if (resultado == DialogResult.OK)
                            {
                                productoSeleccionado = modal.productoSeleccionado;
                                productoSeleccionado.Categoria = categoriaSeleccionada;
                                productoSeleccionado.Proveedor = proveedorSeleccionado;
                                txtCodigo.Text = productoSeleccionado.Codigo;
                                txtNombre.Text = productoSeleccionado.Nombre;
                                txtPrecio.Text = productoSeleccionado.PrecioCompra.ToString();
                                txtCantidad.Focus();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("La categoría seleccionada no tiene productos registrados, por favor seleccione otra categoría.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else
                {
                    MessageBox.Show("Seleccione una categoría para buscar el producto.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado un proveedor, por favor seleccione uno.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void cargarCombobox()
        {
            cmbCategoria.Items.Add("Seleccione una categoría...");
            foreach (var categoria in listaCategoria)
            {
                if (!cmbCategoria.Items.Contains(categoria.Nombre))
                {
                    cmbCategoria.Items.Add(categoria.Nombre);
                }
            }
            cmbCategoria.SelectedIndex = 0;
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

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(productoSeleccionado != null && productoSeleccionado.Categoria != null)
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro que desea cambiar de categoría? Si lo hace perderá el producto seleccionado.", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(DialogResult.Yes == respuesta)
                {
                    productoSeleccionado = new Producto();
                    txtNombre.Text = string.Empty;
                    txtCodigo.Text = string.Empty;
                    txtPrecio.Text = string.Empty;
                    txtCantidad.Text = string.Empty;
                }
                else
                {
                    // no activar el evento cuando se cambia el índice
                    cmbCategoria.SelectedIndexChanged -= cmbCategoria_SelectedIndexChanged;
                    cmbCategoria.SelectedItem = categoriaSeleccionada.Nombre;
                    cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
                }
            }
        }

        

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            uiUtilidades.TextboxMoneda_KeyPress(txtPrecio, e, errorProvider);
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            uiUtilidades.TextboxMoneda_Leave(txtPrecio, e);
        }
    }
}
