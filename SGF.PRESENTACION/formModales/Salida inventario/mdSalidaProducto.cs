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

namespace SGF.PRESENTACION.formModales.Salida_inventario
{
    public partial class mdSalidaProducto : Form
    {
        private CategoriaBLL lCategoria = CategoriaBLL.ObtenerInstancia;
        private ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private ProveedorBLL lProveedor = ProveedorBLL.ObtenerInstancia;

        private List<Categoria> listaCategoria { get; set; }

        private Categoria categoriaSeleccionada { get; set; }
        public Producto productoSeleccionado { get; set; }
        public int cantidadSalida { get; set; }

        public mdSalidaProducto()
        {
            InitializeComponent();
            cantidadSalida = 0;
            listaCategoria = lCategoria.ListarCategorias();
            productoSeleccionado = new Producto();
        }

        private void mdSalidaProducto_Load(object sender, EventArgs e)
        {
            try
            {
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

            if(cmbCategoria.SelectedIndex > 0)
                camposValidos &= true;
            else
            {
                errorProvider.SetError(cmbCategoria, "Debe seleccionar una categoría");
                camposValidos &= false;
            }

            if(!string.IsNullOrEmpty(txtCodigo.Text))
                camposValidos &= true;
            else
            {
                errorProvider.SetError(btnbuscar, "El campo no puede estar vacío");
                camposValidos &= false;
            }

            if (!string.IsNullOrEmpty(txtNombre.Text))
                camposValidos &= true;
            else
            {
                errorProvider.SetError(txtNombre, "El campo no puede estar vacío");
                camposValidos &= false;
            }

            if(txtCantidad.Text != "0" && !string.IsNullOrEmpty(txtCantidad.Text))
                camposValidos &= true;
            else
            {
                errorProvider.SetError(txtCantidad, "El campo no puede estar vacío");
                camposValidos &= false;
            }

            // verificar si la cantidad es un número valido
            if(!int.TryParse(txtCantidad.Text, out int cantidad))
            {
                errorProvider.SetError(txtCantidad, "El campo debe ser un número válido");
                camposValidos &= false;
            }
            else
            {
                if(cantidad <= 0)
                {
                    errorProvider.SetError(txtCantidad, "La cantidad debe ser mayor a 0");
                    camposValidos &= false;
                }
            }

            return camposValidos;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if(productoSeleccionado != null && productoSeleccionado.Categoria != null && productoSeleccionado.Proveedor != null)
                {
                    // revisar que la cantidad a eliminar no sea mayor a la cantidad en existencia
                    if(Convert.ToInt32(txtCantidad.Text) <= Convert.ToInt32(txtExistencias.Text))
                    {
                        cantidadSalida = Convert.ToInt32(txtCantidad.Text);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        errorProvider.SetError(txtCantidad, "La cantidad a eliminar no puede ser mayor a la cantidad en existencia");
                        MessageBox.Show("La cantidad a eliminar no puede ser mayor a la cantidad en existencia", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if(cmbCategoria.SelectedIndex > 0)
            {
                categoriaSeleccionada = listaCategoria.FirstOrDefault(cat => cat.Nombre == cmbCategoria.SelectedItem.ToString());
                if (lCategoria.CategoriaTieneProductos(categoriaSeleccionada.CategoriaID))
                {
                    using(var modal = new mdBuscarProducto(null, categoriaSeleccionada))
                    {
                        var resultado = modal.ShowDialog();
                        if(resultado == DialogResult.OK)
                        {
                            productoSeleccionado = modal.productoSeleccionado;
                            productoSeleccionado.Categoria = categoriaSeleccionada;
                            productoSeleccionado.Proveedor = lProveedor.ObtenerProveedorPorID(productoSeleccionado.Proveedor.ProveedorID);
                            txtCodigo.Text = productoSeleccionado.Codigo;
                            txtNombre.Text = productoSeleccionado.Nombre;
                            txtExistencias.Text = lProducto.ObtenerExistencias(productoSeleccionado.ProductoID).ToString();
                            txtCantidad.Focus();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una categoría para buscar el producto", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarCombobox()
        {
            cmbCategoria.Items.Add("Seleccione una categoría...");
            foreach(var categoria in listaCategoria)
            {
                if (!cmbCategoria.Items.Contains(categoria.Nombre))
                {
                    cmbCategoria.Items.Add(categoria.Nombre);
                }
            }
            cmbCategoria.SelectedIndex = 0;
        }

        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text != string.Empty || txtCodigo.Text != string.Empty)
            {
                DialogResult respuesta = MessageBox.Show("¿Seguro que desea cancelar la operación?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
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

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                productoSeleccionado = new Producto();
                txtNombre.Text = string.Empty;
                txtExistencias.Text = string.Empty;
                txtCantidad.Text = string.Empty;
            }
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
                    txtExistencias.Text = string.Empty;
                    txtCantidad.Text = "0";
                }
                else
                {
                    cmbCategoria.SelectedIndexChanged -= cmbCategoria_SelectedIndexChanged;
                    cmbCategoria.SelectedItem = categoriaSeleccionada.Nombre;
                    cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
                }
            }
        }

        private Producto BuscarProductoPorCodigo(string codigo)
        {
            // logica de verificar si proveedorSeleccionado es null y etc    
                Producto producto = lProducto.ObtenerProductoPorCodigo(codigo);
                // verificar si el producto tiene el mismo proveedor
                if (producto != null)
                {             
                        categoriaSeleccionada = listaCategoria.FirstOrDefault(cat => cat.CategoriaID == producto.Categoria.CategoriaID);
                        cmbCategoria.SelectedItem = categoriaSeleccionada.Nombre;
                        productoSeleccionado = producto;
                        productoSeleccionado.Categoria = categoriaSeleccionada;
                        productoSeleccionado.Proveedor = lProveedor.ObtenerProveedorPorID(productoSeleccionado.Proveedor.ProveedorID);
                        txtNombre.Text = productoSeleccionado.Nombre;
                        txtExistencias.Text = lProducto.ObtenerExistencias(productoSeleccionado.ProductoID).ToString();              
                }
                else
                {
                    return null;
                }
            
            return productoSeleccionado;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                {
                    Producto producto = BuscarProductoPorCodigo(txtCodigo.Text);
                    if(producto != null)
                    {
                        txtCantidad.Focus();
                    }
                }
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtCantidad, string.Empty);
        }
    }
}
