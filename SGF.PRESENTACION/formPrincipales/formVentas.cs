using SGF.MODELO.Negocio;
using SGF.NEGOCIO.Negocio;
using SGF.NEGOCIO.Seguridad;
using SGF.PRESENTACION.formModales.Buscadores;
using SGF.PRESENTACION.formModales.Salida_inventario;
using SGF.PRESENTACION.formModales.Ventas;
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
        SesionBLL lSesion = SesionBLL.ObtenerInstancia;

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
                    decimal descuento = modal.descuentoSeleccionado;
                    textboxColorizador(true);
                    cargarGrilla(productoSeleccionado, cantidad, descuento);
                }
            }
        }


        private void cargarVenta()
        {
            datosDelNegocio = lNegocio.NegocioEnSesion().DatosDelNegocio;
            cargarCombobox();
            cargarImpuesto();
            cargarCliente(lCliente.ObtenerClientePorID(0));

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

        private void cargarCliente(Cliente cliente)
        {
            if(cliente != null)
            {
                clienteSeleccionado = cliente;
                if(cliente.ClienteID == 0)
                {
                    lblCliente.Text = cliente.NombreCompleto;
                    lblTipo.Visible = false;
                    lblTipoCliente.Visible = false;
                    lblTipoDocumento.Visible = false;
                    lblDocumento.Visible = false;
                }
                else
                {
                    lblTipo.Visible = true;
                    lblTipoCliente.Visible = true;
                    lblTipoDocumento.Visible = true;
                    lblDocumento.Visible = true;

                    lblTipoCliente.Text = cliente.TipoCliente.Descripcion;
                    lblTipoDocumento.Text = cliente.TipoDocumento+ ": ";
                    lblDocumento.Text = cliente.Documento;
                    lblCliente.Text = cliente.NombreCompleto;
                }
            }
            // Cargar consumidor final

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
                    cargarCliente(clienteSeleccionado);
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
                        cargarGrilla(productoSeleccionado, 1, 0);
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
            // Tamaño de fuente mínimo
            float tamanoMinimo = 6f;

            // Tamaño de fuente máximo
            float tamanoMaximo = fuenteOriginal.Size;

            // Copiar la fuente original para ajustarla
            Font fuente = new Font(fuenteOriginal.FontFamily, fuenteOriginal.Size, fuenteOriginal.Style);

            // Iterar hasta alcanzar el tamaño de fuente adecuado
            while (fuente.Size > tamanoMinimo)
            {
                // Calcular el tamaño del texto con la fuente actual
                SizeF tamanoTexto = TextRenderer.MeasureText(label.Text, fuente);

                // Si el ancho del texto es menor que el ancho del label
                if (tamanoTexto.Width <= label.Width && tamanoTexto.Height <= label.Height)
                {
                    break;
                }

                // Reducir el tamaño de la fuente
                fuente = new Font(fuente.FontFamily, fuente.Size - 1f, fuente.Style);
            }

            // Aplicar la nueva fuente al label
            label.Font = fuente;
        }



        private void cargarGrilla(Producto producto, int cantidadElegida, decimal descuento)
        {
            if (producto == null)
            {
                MessageBox.Show("Seleccione un producto para cargarlo en la grilla de venta.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cantidadElegida <= producto.Stock)
            {
                DataGridViewRow existeFila = dgvVenta.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(row => Convert.ToInt32(row.Cells["dgvcID"].Value) == producto.ProductoID);

                if (existeFila != null)
                {
                    int cantidadExistente = Convert.ToInt32(existeFila.Cells["dgvcCantidad"].Value);
                    if (cantidadExistente + cantidadElegida > producto.Stock)
                    {
                        MessageBox.Show("No se puede cargar el producto, ya que supera el stock registrado disponible en el inventario.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textboxColorizador(false);
                        return;
                    }

                    existeFila.Cells["dgvcCantidad"].Value = cantidadExistente + cantidadElegida;
                    decimal subtotal = (cantidadExistente + cantidadElegida) * producto.PrecioVenta;

                    // Aplicar el descuento
                    // se utilizará la ecuación (Porcentaje de descuento * valor subtotal) / 100
                    subtotal -= subtotal * descuento / 100;

                    // insertar en el dgvcDescuento el valor del descuento y un % para indicar que es un porcentaje
                    string descuentoStr = descuento + "%";
                    existeFila.Cells["dgvcDescuento"].Value = descuentoStr;
                    existeFila.Cells["dgvcSubTotal"].Value = formatoMoneda(subtotal.ToString());

                    if (cantidadExistente + cantidadElegida == 0)
                    {
                        eliminarProducto(producto, existeFila);
                    }
                }
                else
                {
                    decimal subtotal = cantidadElegida * producto.PrecioVenta;
                    // aplicar descuento
                    subtotal -= subtotal * descuento / 100;
                    string descuentoStr = descuento + "%";
                    dgvVenta.Rows.Add(producto.ProductoID, producto.Nombre, cantidadElegida, producto.PrecioVenta, descuentoStr, subtotal);
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

        private void modificarGrilla(Producto producto, int cantidad, decimal descuento)
        {
            // Usar la misma lógica de cargarGrilla, solo que aquí se comprueba si el producto ya está en la grilla y luego se modifica directamente
            // si se pudo abrir esta función significa que el producto ya está en la grilla entonces no se agregará así nomas
            DataGridViewRow existeFila = dgvVenta.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(row => Convert.ToInt32(row.Cells["dgvcID"].Value) == producto.ProductoID);

            if (existeFila != null)
            {
                int cantidadExistente = Convert.ToInt32(existeFila.Cells["dgvcCantidad"].Value);
                if (cantidad > producto.Stock)
                {
                    MessageBox.Show("No se puede cargar el producto, ya que supera el stock registrado disponible en el inventario.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textboxColorizador(false);
                    return;
                }

                existeFila.Cells["dgvcCantidad"].Value = cantidad;
                decimal subtotal = (cantidad) * producto.PrecioVenta;

                // Aplicar el descuento
                // se utilizará la ecuación (Porcentaje de descuento * valor subtotal) / 100
                subtotal -= subtotal * descuento / 100;

                // insertar en el dgvcDescuento el valor del descuento y un % para indicar que es un porcentaje
                string descuentoStr = descuento + "%";
                existeFila.Cells["dgvcDescuento"].Value = descuentoStr;
                existeFila.Cells["dgvcSubTotal"].Value = formatoMoneda(subtotal.ToString());

                if (cantidad == 0)
                {
                    eliminarProducto(producto, existeFila);
                }
                calcularTotal();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al modificar el producto, contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string formatoMoneda(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                texto = "0.00";
            return string.Format(CultureInfo.GetCultureInfo("es-AR"), "{0:N2}", Convert.ToDecimal(texto));
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
            decimal descuento = Convert.ToDecimal(fila.Cells["dgvcDescuento"].Value.ToString().Replace("%", ""));
            cargarGrilla(producto, cantidadElegida, descuento);
        }

        private void decrementarCantidad(Producto producto, DataGridViewRow fila)
        {
            int cantidadElegida = -1;
            decimal descuento = Convert.ToDecimal(fila.Cells["dgvcDescuento"].Value.ToString().Replace("%", ""));
            cargarGrilla(producto, cantidadElegida, descuento);
        }

        private void eliminarProducto(Producto producto, DataGridViewRow fila)
        {
            try
            {
                if (dgvVenta.Rows.Count == 0)
                {
                    MessageBox.Show("No hay productos en la grilla de venta para eliminar.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (producto != null)
                {
                    int filaIndex = fila.Index;
                    listaProductosSeleccionados.Remove(producto);
                    dgvVenta.Rows.RemoveAt(filaIndex);
                    calcularTotal();
                }

            }
            catch (Exception ex)
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
                        eliminarProducto(producto, fila);
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // conteo de filas
            if (dgvVenta.Rows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Desea limpiar la grilla de venta?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    limpiarCampos();
                }
            }
        }

        // privatea void limpiar acmpos
        private void limpiarCampos()
        {
            dgvVenta.Rows.Clear();
            listaProductosSeleccionados.Clear();
            calcularTotal();
            productoEnGrilla = false;
        }

        private void abrirModalModificar(Producto producto, int cantidad, decimal descuento)
        {
            using (var modal = new mdBuscarProductoVenta(true, producto, cantidad, descuento))
            {
                var resultado = modal.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    textboxColorizador(true);
                    cantidad = modal.cantidadSeleccionada;
                    descuento = modal.descuentoSeleccionado;
                    modificarGrilla(producto, cantidad, descuento);
                }

            }
        }

        private void dgvVenta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (dgvVenta.CurrentCell != null)
                    {
                        int filaIndex = dgvVenta.CurrentCell.RowIndex;
                        int productoID = Convert.ToInt32(dgvVenta.Rows[filaIndex].Cells["dgvcID"].Value);
                        int cantidadElegida = Convert.ToInt32(dgvVenta.Rows[filaIndex].Cells["dgvcCantidad"].Value);
                        decimal descuentoElegido = Convert.ToDecimal(dgvVenta.Rows[filaIndex].Cells["dgvcDescuento"].Value.ToString().Replace("%", ""));
                        Producto producto = listaProductosSeleccionados.Find(p => p.ProductoID == productoID);
                        if (producto != null)
                        {
                            abrirModalModificar(producto, cantidadElegida, descuentoElegido);
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al intentar abrir el formulario para modificar el producto. Contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (listaProductosSeleccionados.Count > 0)
            {
                DataTable dtDetalleVenta = new DataTable();
                dtDetalleVenta.Columns.Add("dgvcID", typeof(int));
                dtDetalleVenta.Columns.Add("dgvcProducto", typeof(string));
                dtDetalleVenta.Columns.Add("dgvcCantidad", typeof(int));
                dtDetalleVenta.Columns.Add("dgvcPrecio", typeof(decimal));
                dtDetalleVenta.Columns.Add("dgvcDescuento", typeof(decimal));
                dtDetalleVenta.Columns.Add("dgvcSubTotal", typeof(decimal));

                foreach (DataGridViewRow fila in dgvVenta.Rows)
                {
                    dtDetalleVenta.Rows.Add(
                        new object[]
                        {
                            Convert.ToInt32(fila.Cells["dgvcID"].Value),
                            fila.Cells["dgvcProducto"].Value.ToString(),
                            Convert.ToInt32(fila.Cells["dgvcCantidad"].Value),
                            Convert.ToDecimal(fila.Cells["dgvcPrecio"].Value),
                            Convert.ToDecimal(fila.Cells["dgvcDescuento"].Value.ToString().Replace("%", "")),
                            Convert.ToDecimal(fila.Cells["dgvcSubTotal"].Value)
                        });
                    foreach (Producto producto in listaProductosSeleccionados)
                    {
                        if (producto.ProductoID == Convert.ToInt32(fila.Cells["dgvcID"].Value))
                        {
                            producto.Stock -= Convert.ToInt32(fila.Cells["dgvcCantidad"].Value);
                        }
                    }
                }

                // Venta
                Venta venta = new Venta();
                venta.usuario = lSesion.UsuarioEnSesion().Usuario;
                venta.TipoComprobante = cmbFactura.SelectedItem.ToString();
                venta.TipoDocumento = clienteSeleccionado.TipoDocumento;
                venta.NumeroDocumento = clienteSeleccionado.Documento;
                venta.NombreCliente = clienteSeleccionado.NombreCompleto;
                venta.TipoCliente = clienteSeleccionado.TipoCliente.Descripcion;
                venta.Moneda = (Moneda)cmbMoneda.SelectedItem;
                venta.MontoPagado = 0; // se establecerá en el formulario de cobro
                venta.MontoCambio = 0; // se establecerá en el formulario de cobro
                venta.Impuesto = lblImpuesto.Text;
                venta.MontoTotal = Convert.ToDecimal(lblTotal.Text.Replace(venta.Moneda.Simbolo, ""));
                venta.FechaVenta = DateTime.Now;
                venta.Estado = true;

                using (var modal = new mdCobrar(venta))
                {
                    var resultado = modal.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        venta = modal.ObjectVenta;
                        if (lVenta.RegistrarVenta(venta, dtDetalleVenta))
                        {
                            foreach (Producto producto in listaProductosSeleccionados)
                            {
                                int cantidadAntes = lProducto.ObtenerExistencias(producto.ProductoID);
                                try
                                {
                                    if (lProducto.ModificarProducto(producto))
                                    {
                                        int cantidadDespues = lProducto.ObtenerExistencias(producto.ProductoID);
                                        int cantidadVendida = cantidadAntes - cantidadDespues;
                                        RegistroBLL.RegistrarMovimiento("Venta", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), cantidadVendida, cantidadAntes, cantidadDespues, "Ventas", $"Se realizo de manera exitosa la venta del producto: {producto.Nombre}");
                                    }

                                }
                                catch (Exception)
                                {
                                    MessageBox.Show($"No se pudo actualizar el stock del producto: {producto.Nombre} el cual tiene ID: {producto.ProductoID}, contacte con el administrador del sistema para solucionar este problema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    continue;
                                }
                            }
                            MessageBox.Show("La venta se realizó de manera exitosa.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            venta.VentaID = lVenta.ObtenerUltimaVenta();
                            if (modal.OpcionSeleccionada == mdCobrar.Opciones.CobrarEimprimir)
                            {
                                MessageBox.Show("Se imprimirá el comprobante de venta.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                using (var modalImpresion = new mdDetalleVentas(venta, true))
                                {
                                    modalImpresion.ShowDialog();
                                }
                            }
                            else
                            {
                                using (var modalImpresion = new mdDetalleVentas(venta))
                                {
                                    modalImpresion.ShowDialog();
                                }
                            }
                            DialogResult respuesta = MessageBox.Show("¿Desea limpiar la grilla de venta?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (respuesta == DialogResult.Yes)
                            {
                                limpiarCampos();
                            }
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("No hay productos en la grilla de venta para cobrar.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHistorialDeVenta_Click(object sender, EventArgs e)
        {
            using(var modal = new mdHistorialVentas())
            {
                modal.ShowDialog();
            }
        }

        private void btnImprimirUltimoTicket_Click(object sender, EventArgs e)
        {
            // Buscamos la última venta realizada, por si fue eliminada o cancelada, se deberá revisar la última id, si no es esa se buscara la anterior y así
            // hasta encontrar una venta válida y luego imprimirla, permitiremos imprimir también ventas canceladas.
            try
            {
                int ultimaVentaID = lVenta.ObtenerUltimaVenta();
                if(ultimaVentaID > 0)
                {
                    Venta venta = lVenta.ObtenerVentaPorID(ultimaVentaID);
                    if(venta != null)
                    {
                        using(var modal = new mdDetalleVentas(venta))
                        {
                            modal.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo obtener la última venta, esto se puede deber que no existan ventas registradas en el sistema. Si usted cree que esto es un error, por favor, póngase en contacto con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("No se pudo obtener la última venta, esto se puede deber que no existan ventas registradas en el sistema. Si usted cree que esto es un error, por favor, póngase en contacto con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCierreCja_Click(object sender, EventArgs e)
        {

        }
    }
}
