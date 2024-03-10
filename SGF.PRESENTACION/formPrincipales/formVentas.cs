using SGF.MODELO.Negocio;
using SGF.NEGOCIO.Negocio;
using SGF.PRESENTACION.formModales.Buscadores;
using SGF.PRESENTACION.formModales.Ventas;
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
    public partial class formVentas : Form
    {
        // Controladora
        NegocioBLL lNegocio = NegocioBLL.ObtenerInstancia;
        ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;
        UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        ClienteBLL lCliente = ClienteBLL.ObtenerInstancia;
        VentaBLL lVenta = VentaBLL.ObtenerInstancia;

        // Fuentes usadas, lblSubTotal, lblTotal y lblImpuesto
        private Font fuenteTotal { get; set; }
        private Font fuenteSubTotal { get; set; }
        private Font fuenteImpuesto { get; set; }

        // Variables de seleccion
        private Cliente clienteSeleccionado { get; set; }
        private Producto productoSeleccionado { get; set; }
        private List<Producto> listaProductosSeleccionados { get; set; }
        public bool productoEnGrilla { get; set; }
        NegocioModelo datosDelNegocio { get; set; }

        public formVentas()
        {
            InitializeComponent();
            clienteSeleccionado = new Cliente();
            productoSeleccionado = new Producto();
            listaProductosSeleccionados = new List<Producto>();
            datosDelNegocio = new NegocioModelo();
        }

        private void formVentas_Load(object sender, EventArgs e)
        {
            try
            {
                cargarFuentes();
                cargarVenta();
                txtBuscarProducto.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarFuentes()
        {
            // obtener fuente de lblSubTotal
            fuenteSubTotal = lblSubTotal.Font;
            // obtener fuente de lblTotal
            fuenteTotal = lblTotal.Font;
            // obtener fuente de lblImpuesto
            fuenteImpuesto = lblImpuesto.Font;
        }

        private void btnBuscadorProducto_Click(object sender, EventArgs e)
        {
            using (var modal = new mdBuscarProductoVenta())
            {
                var resultado = modal.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    productoSeleccionado = modal.productoSeleccionado;
                    int cantidad = modal.cantidadSeleccionada == 0 ? 1 : modal.cantidadSeleccionada;
                    textboxColorizador(true);
                    cargarGrilla(productoSeleccionado, cantidad);
                }
            }
        }

        private void cargarVenta()
        {
            datosDelNegocio = lNegocio.NegocioEnSesion().DatosDelNegocio;
            cargarCombobox();
            cargarImpuesto();
            cargarCliente();

            // Cargar datos del negocio
            lblNombreEmpresa.Text = datosDelNegocio.Nombre;
            if (datosDelNegocio.Logo != null)
            {
                pbLogoEmpresa.Image = uiUtilidades.ByteArrayToImage(datosDelNegocio.Logo);
            }
            else
            {
                pbLogoEmpresa.Image = uiUtilidades.LogoPorDefecto();
            }
            // Cargar el número de venta
            lblNumerodeVenta.Text = lVenta.ContadorDeVenta();
        }

        private void cargarCliente()
        {
            // Cargar consumidor final
            clienteSeleccionado = lCliente.ObtenerClientePorID(0);
        }

        private void cargarImpuesto()
        {
            // Impuestos es un booleano, si es si se cargan los impuestos, sino se pone como 0%
            if (datosDelNegocio.Impuestos)
            {
                Impuesto impuesto = lNegocio.ObtenerImpuestoPorID(1);
                lblImpuesto.Text = impuesto.Porcentaje.ToString() + "%";
            }
            else
            {
                lblImpuesto.Text = "0%";
            }
        }

        private void cargarCombobox()
        {
            // Boleta, lo usaremos para una venta al consumidor final quien no requiere factura para hacer el reembolso de un crédito fiscal.
            // ya que no es contribuyente del IVA.
            cmbFactura.Items.Add("Boleta");
            // Factura, lo usaremos para una venta a un cliente que requiere factura para hacer el reembolso de un crédito fiscal.
            // Utilizado en transacciones con otrs empresas que son contribuyentes del IVA.
            cmbFactura.Items.Add("Factura");
            cmbFactura.SelectedIndex = 0;

            List<Moneda> listaMonedas = lNegocio.ObtenerMonedasDisponibles();

            cmbMoneda.DataSource = listaMonedas;
            cmbMoneda.DisplayMember = "Nombre";
            cmbMoneda.ValueMember = "MonedaID";
        }

        // Formulario de clientes
        private void btnClientes_Click(object sender, EventArgs e)
        {
            using (var modal = new mdBuscarCliente())
            {
                var resultado = modal.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    clienteSeleccionado = modal.clienteSeleccionado;
                    lblCliente.Text = clienteSeleccionado.NombreCompleto;
                }
            }
        }

        private void cmbMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            uiUtilidades.Combobox_ShortcutSiguienteIndex(cmbMoneda, e);
        }

        // Agregar producto en el datagridview


        // Buscar textbox
        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscarProducto.Text))
            {
                productoSeleccionado = new Producto();
                textboxColorizador();
            }
        }

        private void contarGrilla()
        {
            int filasTotales = dgvVenta.Rows.Count;
            if (filasTotales > 0)
            {
                productoEnGrilla = true;
            }
            else
            {
                productoEnGrilla = false;
            }
        }

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtBuscarProducto.Text))
                {
                    productoSeleccionado = lProducto.ObtenerProductoPorCodigo(txtBuscarProducto.Text);
                    if (productoSeleccionado != null)
                    {
                        cargarGrilla(productoSeleccionado, 1);
                        textboxColorizador(true);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el producto con el código ingresado, verifique si está bien escrito e intente de nuevo.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textboxColorizador(false);
                    }
                }
            }
        }


        private void textboxColorizador(bool productoEncontrado = false)
        {
            if (productoEncontrado && !string.IsNullOrEmpty(txtBuscarProducto.Text))
            {
                txtBuscarProducto.BackColor = Color.LightGreen;
            }
            else if (!productoEncontrado && !string.IsNullOrEmpty(txtBuscarProducto.Text))
            {
                txtBuscarProducto.BackColor = Color.LightCoral;
            }
            else
            {
                txtBuscarProducto.BackColor = Color.FromArgb(255, 254, 196);
            }

        }

        private void AjustarTamanoFuente(Label label, Font fuenteOriginal)
        {
            // Crear una nueva fuente basada en la fuente original
            Font fuente = new Font(fuenteOriginal.FontFamily, fuenteOriginal.Size, fuenteOriginal.Style);

            // Calcular el tamaño del texto con la fuente actual
            SizeF tamanoTexto = TextRenderer.MeasureText(label.Text, fuente);

            // Si el ancho del texto es mayor que el ancho del label
            while (tamanoTexto.Width > label.Width)
            {
                // Reducir el tamaño de la fuente
                fuente = new Font(fuente.FontFamily, fuente.Size - 0.5f, fuente.Style);

                // Volver a calcular el tamaño del texto
                tamanoTexto = TextRenderer.MeasureText(label.Text, fuente);
            }

            // Si el ancho del texto es menor que el ancho del label y la fuente es menor que el tamaño original
            while (tamanoTexto.Width < label.Width && fuente.Size < fuenteOriginal.Size)
            {
                // Aumentar el tamaño de la fuente
                fuente = new Font(fuente.FontFamily, fuente.Size + 0.5f, fuente.Style);

                // Volver a calcular el tamaño del texto
                tamanoTexto = TextRenderer.MeasureText(label.Text, fuente);
            }

            // Si el texto es "0.00", restablecer al tamaño de fuente original
            if (label.Text == "0.00")
            {
                fuente = new Font(fuente.FontFamily, fuenteOriginal.Size, fuente.Style);
            }

            // Aplicar la nueva fuente al label
            label.Font = fuente;
        }

        private void cargarGrilla(Producto producto, int cantidadElegida)
        {
            if (producto == null)
            {
                MessageBox.Show("Seleccione un producto para cargarlo en la grilla de venta.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si el producto ya está en la lista
            int descuento = 0;
            if (cantidadElegida <= producto.Stock)
            {
                DataGridViewRow existeFila = dgvVenta.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(row => Convert.ToInt32(row.Cells["dgvcID"].Value) == producto.ProductoID);

                if (existeFila != null)
                {
                    // entero de sumar cantidadExistente y la elegida verificando con el stock del producto real
                    descuento = Convert.ToInt32(existeFila.Cells["dgvcDescuento"].Value);
                    int cantidadExistente = Convert.ToInt32(existeFila.Cells["dgvcCantidad"].Value);
                    if (cantidadExistente + cantidadElegida > producto.Stock)
                    {
                        MessageBox.Show("No se puede cargar el producto, ya que supera el stock registrado disponible en el inventario.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textboxColorizador(false);
                        return;
                    }

                    existeFila.Cells["dgvcCantidad"].Value = cantidadExistente + cantidadElegida;
                    //existeFila.Cells["dgvcSubTotal"].Value = (cantidadExistente + cantidadElegida) * producto.PrecioVenta;
                    // existeFila.cells de subtotal usando la ecuación pero agregando descuento
                    existeFila.Cells["dgvcSubTotal"].Value = (cantidadExistente + cantidadElegida) * producto.PrecioVenta - descuento;

                    if(cantidadExistente + cantidadElegida == 0)
                    {
                        eliminarProducto(producto, existeFila);
                    }
                }
                else
                {
                    decimal subTotal = cantidadElegida * producto.PrecioVenta - descuento;
                    dgvVenta.Rows.Add(producto.ProductoID, producto.Nombre, cantidadElegida, producto.PrecioVenta, descuento, subTotal);
                    listaProductosSeleccionados.Add(producto);
                }
                calcularTotal();
                contarGrilla();
            }
            else
            {
                MessageBox.Show("No se puede cargar la cantidad de productos seleccionada, ya que supera el stock disponible.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textboxColorizador(false);
                return;
            }
        }

        private void calcularTotal()
        {
            Moneda monedaSeleccionada = (Moneda)cmbMoneda.SelectedItem;
            if (dgvVenta.Rows.Count == 0)
            {
                lblTotal.Text = uiUtilidades.FormatearMonedaPersonalizada(0, monedaSeleccionada);
                lblSubTotal.Text = uiUtilidades.FormatearMonedaPersonalizada(0, monedaSeleccionada);
            }
            else
            {
                decimal total = 0;
                foreach (DataGridViewRow fila in dgvVenta.Rows)
                {
                    if (decimal.TryParse(fila.Cells["dgvcSubTotal"].Value.ToString(), out decimal subTotal))
                    {
                        total += subTotal;
                    }
                }
                // aplicar subtotal sin impuesto
                lblSubTotal.Text = uiUtilidades.FormatearMonedaPersonalizada(total, monedaSeleccionada);
                AjustarTamanoFuente(lblSubTotal, fuenteSubTotal);
                if (decimal.TryParse(lblImpuesto.Text.Replace("%", ""), out decimal impuestoPorcentaje))
                {
                    decimal impuesto = total * impuestoPorcentaje / 100; // Calcular el impuesto como un porcentaje del total
                    total += impuesto;
                }
                else
                {
                    // si ocurre un error en intentar transformar el impuesto, se le avisará al usuario y se hará el calculo con un porcentaje 0
                    MessageBox.Show("Error al intentar calcular el impuesto, se usará un porcentaje de 0%", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    decimal impuesto = total * 0 / 100; // Calcular el impuesto como un porcentaje del total
                }
                lblTotal.Text = uiUtilidades.FormatearMonedaPersonalizada(total, monedaSeleccionada);
            }
            AjustarTamanoFuente(lblTotal, fuenteTotal);
            AjustarTamanoFuente(lblSubTotal, fuenteSubTotal);
        }


        private void aumentarCantidad(Producto producto, DataGridViewRow fila)
        {
            int cantidadElegida = 1;
            cargarGrilla(producto, cantidadElegida);
        }

        private void decrementarCantidad(Producto producto, DataGridViewRow fila)
        {
            int cantidadElegida = -1;
            cargarGrilla(producto, cantidadElegida);
        }

        private void eliminarProducto(Producto producto,DataGridViewRow fila)
        {
            try
            {
                // verificar si el datagridview tiene filas
                if(dgvVenta.Rows.Count == 0)
                {
                    MessageBox.Show("No hay productos en la grilla de venta para eliminar.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Eliminar producto solo eliminará un producto de la filla correspondiente
                if(producto != null)
                {
                    int filaIndex = fila.Index;
                    listaProductosSeleccionados.Remove(producto);
                    dgvVenta.Rows.RemoveAt(filaIndex);
                    calcularTotal();
                }
                
            }catch(Exception ex)
            {
                throw new Exception("Error al intentar eliminar el producto de la grilla de venta: " + ex.Message);
            }
        }

        private void dgvVenta_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;



                string nombreColumna = dgvVenta.Columns[e.ColumnIndex].Name;

                if (nombreColumna == "btnAumentar")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    var w = Properties.Resources.Aumentar_15.Width;
                    var h = Properties.Resources.Aumentar_15.Height;
                    var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                    // dibujar
                    e.Graphics.DrawImage(Properties.Resources.Aumentar_15, new Rectangle(x, y, w, h));
                    e.Handled = true;
                }

                // btnDecrementar
                if (nombreColumna == "btnDecrementar")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    var w = Properties.Resources.Decrementar_15.Width;
                    var h = Properties.Resources.Decrementar_15.Height;
                    var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                    // dibujar
                    e.Graphics.DrawImage(Properties.Resources.Decrementar_15, new Rectangle(x, y, w, h));
                    e.Handled = true;
                }

                // btn eliminar
                if (nombreColumna == "btnEliminar")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    var w = Properties.Resources.eliminar_boton_15.Width;
                    var h = Properties.Resources.eliminar_boton_15.Height;
                    var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                    // dibujar
                    e.Graphics.DrawImage(Properties.Resources.eliminar_boton_15, new Rectangle(x, y, w, h));
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    DataGridViewRow fila = dgvVenta.Rows[indice];
                    Producto producto = listaProductosSeleccionados.Find(p => p.ProductoID == Convert.ToInt32(fila.Cells["dgvcID"].Value));

                    if (dgvVenta.Columns[e.ColumnIndex].Name == "btnAumentar")
                    {
                        aumentarCantidad(producto, fila);
                    }
                    else if (dgvVenta.Columns[e.ColumnIndex].Name == "btnDecrementar")
                    {
                        decrementarCantidad(producto, fila);
                    }
                    else if (dgvVenta.Columns[e.ColumnIndex].Name == "btnEliminar")
                    {
                        eliminarProducto(producto,fila);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcularTotal();
        }

        

        private void dgvVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvVenta.CurrentCell != null)
            {
                int indice = dgvVenta.CurrentCell.RowIndex;
                DataGridViewRow fila = dgvVenta.Rows[indice];
                Producto producto = listaProductosSeleccionados.Find(p => p.ProductoID == Convert.ToInt32(fila.Cells["dgvcID"].Value));

                switch (e.KeyCode)
                {
                    case Keys.Add:
                    case Keys.Oemplus:
                        // Si se presionó la tecla "+", aumentar la cantidad
                        aumentarCantidad(producto, fila);
                        break;
                    case Keys.Subtract:
                    case Keys.OemMinus:
                        // Si se presionó la tecla "-", disminuir la cantidad
                        decrementarCantidad(producto, fila);
                        break;
                    case Keys.Delete:
                        // Si se presionó la tecla "Suprimir", eliminar el producto
                        eliminarProducto(producto, fila);
                        break;
                }
            }
        }
    }
}
