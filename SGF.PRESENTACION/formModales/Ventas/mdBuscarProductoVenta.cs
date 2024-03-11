using SGF.NEGOCIO.Negocio;
using SGF.PRESENTACION.formModales.modalesBuscadores;
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

namespace SGF.PRESENTACION.formModales.Ventas
{
    public partial class mdBuscarProductoVenta : Form
    {
        // controladora
        CategoriaBLL lCategoria = CategoriaBLL.ObtenerInstancia;
        ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;
        UtilidadesUI uiUtilidades =UtilidadesUI.ObtenerInstancia;

        public Producto productoSeleccionado { get; set; }
        public int cantidadSeleccionada { get; set; }
        public decimal descuentoSeleccionado { get; set; }

        private bool modificandoProducto { get; set; }

        public mdBuscarProductoVenta(bool modificar = false, Producto producto = null, int cantidad = 0, decimal descuento = 0)
        {
            InitializeComponent();
            modificandoProducto = modificar;
            productoSeleccionado = producto;
            cantidadSeleccionada = cantidad;
            descuentoSeleccionado = descuento;
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

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if(productoSeleccionado != null)
            {
                DialogResult respuesta = MessageBox.Show("¿Desea buscar otro producto? se descartará el producto seleccionado.", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(respuesta == DialogResult.Yes)
                {
                    productoSeleccionado = null;
                    txtCodigo.Text = "";
                    txtNombre.Text = "";
                    txtPrecio.Text = "";
                    txtDescuento.Text = "";
                    txtCantidad.Text = "";
                    txtExistencia.Text = "";
                    cmbCategoria.SelectedIndex = 0;
                }
                else
                {
                    return;
                }
            }
            if (cmbCategoria.SelectedIndex >= 0)
            {
                // if si es categoria Todas enviar null, si no poner en el string el nombre de la categoria
                Categoria categoria = (Categoria)cmbCategoria.SelectedItem;
                if (categoria.Nombre == "Todas")
                {
                    categoria = null;
                }
                else
                {
                    categoria = (Categoria)cmbCategoria.SelectedItem;
                }

                using (var modal = new mdBuscarProducto(null, categoria))
                {
                    var resultado = modal.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        productoSeleccionado = new Producto();
                        productoSeleccionado = modal.productoSeleccionado;
                        txtCodigo.Text = productoSeleccionado.Codigo;
                        txtNombre.Text = productoSeleccionado.Nombre;
                        txtCantidad.Text = "1";
                        // usar productoSeleccionado.Categoria.CategoriaID para cargar el combobox
                        cmbCategoria.SelectedValue = productoSeleccionado.Categoria.CategoriaID;
                        txtPrecio.Text = productoSeleccionado.PrecioVenta.ToString();
                        txtExistencia.Text = productoSeleccionado.Stock.ToString();
                        txtDescuento.Text = "0";
                        txtCantidad.Focus();
                    }

                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una categoría para buscar los productos.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mdBuscarProductoVenta_Load(object sender, EventArgs e)
        {
            cargarCombobox();
            if (modificandoProducto)
            {
                txtCodigo.Text = productoSeleccionado.Codigo;
                txtNombre.Text = productoSeleccionado.Nombre;
                txtCantidad.Text = cantidadSeleccionada.ToString();
                txtPrecio.Text = productoSeleccionado.PrecioVenta.ToString();
                txtExistencia.Text = productoSeleccionado.Stock.ToString();
                txtDescuento.Text = descuentoSeleccionado.ToString();

                // Deshabilitar campos buscador
                btnbuscar.Enabled = false;
                cmbCategoria.Enabled = false;
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cargarCombobox()
        {
            List<Categoria> listaCategorias = lCategoria.ListarCategoriasConProductos();
            Categoria categoria = new Categoria();
            categoria.CategoriaID = -1;
            categoria.Nombre = "Todas";
            listaCategorias.Insert(0, categoria);
            cmbCategoria.DataSource = listaCategorias;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "CategoriaID";
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            uiUtilidades.SoloNumero(e);
        }

        private bool ValidarCampos()
        {
            bool camposValidos = true;

            if(productoSeleccionado != null)
            {
                if (!string.IsNullOrEmpty(txtCantidad.Text))
                {
                    if(!int.TryParse(txtCantidad.Text, out int cantidad))
                    {
                        camposValidos &= false;
                        errorProvider.SetError(txtCantidad, "Debe ingresar un número entero.");
                    }
                    else
                    {
                        if(cantidad <= 0)
                        {
                            camposValidos &= false;
                            errorProvider.SetError(txtCantidad, "La cantidad debe ser mayor a 0.");
                        }
                    }
                }
                else
                {
                    camposValidos &= false;
                    errorProvider.SetError(txtCantidad, "Debe ingresar la cantidad del producto.");
                }
            }
            else
            {
                camposValidos &= false;
                MessageBox.Show("Debe seleccionar un producto para continuar.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errorProvider.SetError(txtNombre, "Debe seleccionar un producto.");
            }
            return camposValidos;
                
        }

        private void textboxColorizador(bool error = false)
        {
            if (error)
            {
                txtDescuento.BackColor = Color.LightCoral;
            }
            else
            {
                txtDescuento.BackColor = Color.White;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if(productoSeleccionado != null)
                {
                    int cantidadVenta = int.Parse(txtCantidad.Text);
                    if (cantidadVenta <= productoSeleccionado.Stock)
                    {
                        cantidadSeleccionada = cantidadVenta;
                        // descuento solo será porcentaje, no se permite > 100%
                        descuentoSeleccionado = decimal.Parse(txtDescuento.Text);
                        if (descuentoSeleccionado > 100)
                        {
                            MessageBox.Show("El descuento no puede ser mayor al 100%.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textboxColorizador(true);
                            return;
                        }
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("La cantidad de productos a vender no puede ser mayor a la cantidad en inventario.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        errorProvider.SetError(txtCantidad, "La cantidad de productos a vender no puede ser mayor a la cantidad en inventario.");
                    }
                }
            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Formato regional de Argentina
            if (e.KeyChar == '.')
            {
                e.Handled = true;
                SendKeys.Send(",");
            }

            // Solo puede haber una coma en el textbox
            if (e.KeyChar == ',')
            {
                if (txtDescuento.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }

            // Solo permite números y control keys (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '.' || e.KeyChar == ','))
            {
                e.Handled = true;
            }

        }
 
        private void txtDescuento_Leave(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtDescuento.Text))
                txtDescuento.Text = "0.00";
            txtDescuento.Text = string.Format(CultureInfo.GetCultureInfo("es-AR"), "{0:N2}", Convert.ToDecimal(txtDescuento.Text));
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            textboxColorizador();
        }
    }
}
