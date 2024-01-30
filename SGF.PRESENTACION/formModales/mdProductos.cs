using Irony.Parsing;
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
    public partial class mdProductos : Form
    {

        // Controladoras
        private ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;
        private CategoriaBLL lCategoria = CategoriaBLL.ObtenerInstancia;
        private ProveedorBLL lProveedor = ProveedorBLL.ObtenerInstancia;
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;

        // Listas y Objetos
        private List<Proveedor> listaProveedores { get; set; }
        private List<Categoria> listaCategorias { get; set; }

        private int cantidadAntes { get; set; }
        private int cantidadDespues { get; set; }

        // Modificar Producto
        private bool modificandoProducto { get; set; }
        private int productoID { get; set; }
        private Producto oProducto { get; set; }

        public mdProductos(bool modificar = false, int productoID = 0)
        {
            InitializeComponent();
            modificandoProducto = modificar;
            this.productoID = productoID;
            listaCategorias = lCategoria.ListarCategorias();
            listaProveedores = lProveedor.ListaProveedores();
        }

        private void mdProductos_Load(object sender, EventArgs e)
        {
            try
            {
                cargarCombobox();
                rbProductoGeneral.Checked = true;
                if (modificandoProducto)
                {
                    if(productoID > 0)
                    {
                        oProducto = new Producto();
                        oProducto = lProducto.ObtenerProductoPorID(productoID);
                        // Cargamos categoría y proveedor utilizando la id obtenida de producto
                        Categoria categoria = listaCategorias.FirstOrDefault(cat => cat.CategoriaID == oProducto.Categoria.CategoriaID);
                        Proveedor proveedor = listaProveedores.FirstOrDefault(prov => prov.ProveedorID == oProducto.Proveedor.ProveedorID);
                        oProducto.Categoria = categoria;
                        oProducto.Proveedor = proveedor;
                        cargarDatosDeProducto(oProducto);
                    }
                    else
                    {
                        throw new Exception("Ocurrió un error al intentar modificar el producto, contactar con el administrador del sistema si este error persiste.");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (!modificandoProducto)
                {
                    altaProducto();
                }
                else
                {
                    modificarProducto();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        // Manejo de responsabilidades
        public bool ValidarCampos()
        {
            bool camposValidos = true;

            camposValidos &= uiUtilidades.VerificarTextbox(txtCodigo, errorProvider, lblCodigo);
            camposValidos &= uiUtilidades.VerificarTextbox(txtNombre, errorProvider, lblNombre);
            if (rbMedicamento.Checked)
                camposValidos &= uiUtilidades.VerificarTextbox(txtLote, errorProvider, lblLote);
            if (chkVencimiento.Checked)
                camposValidos &= uiUtilidades.VerificarFechaVencimiento(dtaVencimiento, errorProvider, lblVencimiento);
            camposValidos &= uiUtilidades.VerificarCombobox(cmbCategoria, errorProvider, lblCategoria);
            camposValidos &= uiUtilidades.VerificarCombobox(cmbProveedor, errorProvider, lblProveedor);
            camposValidos &= uiUtilidades.VerificarTextboxPrecio(txtCosto, errorProvider);
            camposValidos &= uiUtilidades.VerificarTextboxPrecio(txtPrecio, errorProvider);
            camposValidos &= uiUtilidades.VerificarTextbox(txtCantidadMinima, errorProvider, lblCantidadMinima);

            // Validaciones de Precio y Costo
            bool PrecioyCosto = true;
            PrecioyCosto &= uiUtilidades.VerificarFormatoMoneda(txtCosto, errorProvider);
            PrecioyCosto &= uiUtilidades.VerificarFormatoMoneda(txtPrecio, errorProvider);

            if (PrecioyCosto)
                camposValidos &= uiUtilidades.VerificarPrecioyCosto(txtCosto, txtPrecio, errorProvider);

            if (PrecioyCosto && camposValidos)
                return true;
            else
                return false;
        }

        private Producto CrearProducto()
        {
            Categoria categoria = listaCategorias.FirstOrDefault(cat => cat.Nombre == cmbCategoria.SelectedItem.ToString());
            Proveedor proveedor = listaProveedores.FirstOrDefault(prov => prov.RazonSocial == cmbProveedor.SelectedItem.ToString());

            Producto producto = new Producto()
            {
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                NumeroLote = !string.IsNullOrEmpty(txtLote.Text) ? txtLote.Text : "-",
                Refrigerado = chkRefrigeado.Checked,
                Receta = chkBajoReceta.Checked,
                Categoria = categoria,
                Proveedor = proveedor,
                PrecioCompra = Convert.ToDecimal(txtCosto.Text),
                PrecioVenta = Convert.ToDecimal(txtPrecio.Text),
                Stock = Convert.ToInt32(txtStock.Text),
                CantidadMinima = Convert.ToInt32(txtCantidadMinima.Text),
                Estado = chkEstado.Checked
            };


            if (rbProductoGeneral.Checked)
                producto.TipoProducto = rbProductoGeneral.Text;
            else
                producto.TipoProducto = rbMedicamento.Text;

            if (chkVencimiento.Checked)
                producto.FechaVencimiento = dtaVencimiento.Value;
            else
                producto.FechaVencimiento = null;

            return producto;
        }

        private Producto CrearProductoModificado()
        {
            Categoria categoria = listaCategorias.FirstOrDefault(cat => cat.Nombre == cmbCategoria.SelectedItem.ToString());
            Proveedor proveedor = listaProveedores.FirstOrDefault(prov => prov.RazonSocial == cmbProveedor.SelectedItem.ToString());

            Producto producto = new Producto()
            {
                ProductoID = Convert.ToInt32(txtID.Text),
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                NumeroLote = !string.IsNullOrEmpty(txtLote.Text) ? txtLote.Text : "-",
                Refrigerado = chkRefrigeado.Checked,
                Receta = chkBajoReceta.Checked,
                Categoria = categoria,
                Proveedor = proveedor,
                PrecioCompra = Convert.ToDecimal(txtCosto.Text),
                PrecioVenta = Convert.ToDecimal(txtPrecio.Text),
                Stock = Convert.ToInt32(txtStock.Text),
                CantidadMinima = Convert.ToInt32(txtCantidadMinima.Text),
                Estado = chkEstado.Checked
            };

            if (rbProductoGeneral.Checked)
                producto.TipoProducto = rbProductoGeneral.Text;
            else
                producto.TipoProducto = rbMedicamento.Text;

            if (chkVencimiento.Checked)
                producto.FechaVencimiento = dtaVencimiento.Value;
            else
                producto.FechaVencimiento = null;

            return producto;
        }

        // Alta
        private void altaProducto()
        {
            if (ValidarCampos())
            {
                Producto producto = CrearProducto();
                bool codigoExiste = lProducto.ExisteCodigo(producto.Codigo);
                if (codigoExiste)
                    errorProvider.SetError(lblCodigo, "El código de barras ingresado ya se encuentra en uso.");

                bool productoExiste = lProducto.ExisteProducto(producto.Nombre);
                if (productoExiste)
                    errorProvider.SetError(lblNombre, "El nombre del producto ingresado ya se encuentra en uso.");

                if (codigoExiste || productoExiste)
                {
                    MessageBox.Show("El código y/o el nombre del producto ingresado ya se encuentran en uso.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cantidadAntes = lProducto.ConteoProductos();
                bool resultado = lProducto.AltaProducto(producto);

                if (resultado)
                {
                    cantidadDespues = lProducto.ConteoProductos();
                    RegistroBLL.RegistrarMovimiento("Alta", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), 1, cantidadAntes, cantidadDespues, "Productos", $"Se dio de alta con éxito el producto: {producto.Nombre}");
                    MessageBox.Show("El producto fue dado de alta con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult respuesta = MessageBox.Show("¿Desea seguir agregando productos?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.No)
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        limpiarCampos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos obligatorios.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Modificar
        private void modificarProducto()
        {
            if (ValidarCampos())
            {
                Producto producto = CrearProductoModificado();
                bool codigoExiste = false;
                bool productoExiste = false;

                if (oProducto.Codigo != producto.Codigo)
                {
                    codigoExiste = lProducto.ExisteCodigo(producto.Codigo);
                    if (codigoExiste)
                        errorProvider.SetError(lblCodigo, "El código de barras ingresado ya se encuentra en uso.");
                }

                if(oProducto.Nombre != producto.Nombre)
                {
                    productoExiste = lProducto.ExisteProducto(producto.Nombre);
                    if(productoExiste)
                        errorProvider.SetError(lblNombre, "El nombre del producto ingresado ya se encuentra en uso.");
                }

                if (codigoExiste || productoExiste)
                {
                    MessageBox.Show("El código y/o el nombre del producto ingresado ya se encuentran en uso.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cantidadAntes = lProducto.ConteoProductos();
                bool resultado = lProducto.ModificarProducto(producto);

                if(resultado)
                {
                    cantidadDespues = lProducto.ConteoProductos();
                    RegistroBLL.RegistrarMovimiento("Modificación", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), 1, cantidadAntes, cantidadDespues, "Productos", $"Se modificó con éxito el producto: {producto.Nombre}");
                    MessageBox.Show("El producto fue modificado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el producto.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void limpiarCampos()
        {
            DialogResult respuesta = MessageBox.Show("¿Desea limpiar los campos?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                uiUtilidades.LimpiarTextbox(txtCodigo, txtNombre, txtLote);
                uiUtilidades.LimpiarCombobox(cmbCategoria, cmbProveedor);
                txtCosto.Text = "0";
                txtPrecio.Text = "0";
                txtStock.Text = "0";
                txtCantidadMinima.Text = "0";
            }
        }

        // Cargar datos de producto
        private void cargarDatosDeProducto(Producto producto)
        {
            if(producto != null)
            {
                if(producto.TipoProducto == rbProductoGeneral.Text)
                    rbProductoGeneral.Checked = true;
                else
                    rbMedicamento.Checked = true;

                txtID.Text = producto.ProductoID.ToString();
                txtCodigo.Text = producto.Codigo;
                txtNombre.Text = producto.Nombre;
                txtLote.Text = producto.NumeroLote;
                chkRefrigeado.Checked = producto.Refrigerado;
                chkVencimiento.Checked = producto.FechaVencimiento != null ? true : false;
                dtaVencimiento.Value = producto.FechaVencimiento != null ? Convert.ToDateTime(producto.FechaVencimiento) : DateTime.Now;
                chkBajoReceta.Checked = producto.Receta;
                cmbCategoria.SelectedItem = producto.Categoria.Nombre;
                cmbProveedor.SelectedItem = producto.Proveedor.RazonSocial;
                txtCosto.Text = producto.PrecioCompra.ToString();
                txtPrecio.Text = producto.PrecioVenta.ToString();
                txtStock.Text = producto.Stock.ToString();
                txtCantidadMinima.Text = producto.CantidadMinima.ToString();
                chkEstado.Checked = producto.Estado;
            }

        }

        // Cargar Combobox
        private void cargarCombobox()
        {
            // Combobox Categorías
            cmbCategoria.Items.Add("Seleccione una categoría...");
            foreach (Categoria categoria in listaCategorias)
            {
                cmbCategoria.Items.Add(categoria.Nombre);
            }
            cmbCategoria.SelectedIndex = 0;

            // Combobox Proveedores
            cmbProveedor.Items.Add("Seleccione un proveedor...");
            foreach (Proveedor proveedor in listaProveedores)
            {
                cmbProveedor.Items.Add(proveedor.RazonSocial);
            }
            cmbProveedor.SelectedIndex = 0;
        }

        // Manejo de Interfaz

        private void rbMedicamento_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMedicamento.Checked)
            {
                pnlLote.Visible = true;
                chkVencimiento.Checked = true;
            }
        }

        private void rbProductoGeneral_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProductoGeneral.Checked)
            {
                pnlLote.Visible = false;
                chkVencimiento.Checked = false;
            }
        }

        private void chkVencimiento_CheckedChanged(object sender, EventArgs e)
        {
            pnlVencimiento.Enabled = chkVencimiento.Checked;
        }

        // Movimiento de ventana
        private Point mousePosicion;
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousePosicion = e.Location;
            }
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int deltaX = e.X - mousePosicion.X;
                int deltaY = e.Y - mousePosicion.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }

        // Función evento para que solo se pueda ingresar una sola vez coma
        private void TextboxMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            uiUtilidades.TextboxMoneda_KeyPress(textbox, e, errorProvider);
            
        }

        private void TextboxMoneda_Leave(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            uiUtilidades.TextboxMoneda_Leave(textbox, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea cancelar la operación?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }
    }
}
