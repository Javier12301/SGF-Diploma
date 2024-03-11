using SGF.MODELO.Negocio;
using SGF.MODELO.Seguridad;
using SGF.NEGOCIO.Negocio;
using SGF.NEGOCIO;
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
using SGF.MODELO;

namespace SGF.PRESENTACION.formModales.Salida_inventario
{
    public partial class mdDetalleVentas : Form
    {
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private ProveedorBLL lProveedor = ProveedorBLL.ObtenerInstancia;
        private UsuarioBLL lUsuario = UsuarioBLL.ObtenerInstancia;
        private NegocioBLL lNegocio = NegocioBLL.ObtenerInstancia;
        private VentaBLL lVenta = VentaBLL.ObtenerInstancia;

        private NegocioModelo NegocioDatos { get; set; }

        private Venta oVenta { get; set; }
        private bool imprimirDetalle { get; set; }

        public mdDetalleVentas(Venta venta = null, bool imprimir = false)
        {
            InitializeComponent();
            imprimirDetalle = imprimir;
            oVenta = venta;
            oVenta.Moneda = lNegocio.ObtenerMonedaPorID(oVenta.Moneda.MonedaID);
            oVenta.usuario = lUsuario.ObtenerUsuarioPorID(oVenta.usuario.UsuarioID);
            NegocioDatos = lNegocio.NegocioEnSesion().DatosDelNegocio;
        }

        private void mdDetalleVentas_Load(object sender, EventArgs e)
        {
            try
            {
                cargarNegocio();
                if (oVenta != null)
                {
                    cargarDetalleDeVenta(oVenta);
                    cargarLista();
                    if (imprimirDetalle)
                    {
                        btnImprimir.PerformClick();
                        btnSalir.Focus();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al cargar los detalles de la venta, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cargarLista()
        {
            if (oVenta != null)
            {
                detalle_Ventas_HistorialTableAdapter.Filtrar(this.negocio.Detalle_Ventas_Historial, oVenta.VentaID);
                if (dgvDetallesVentas.Rows.Count > 0)
                {
                    decimal total = 0;
                    foreach (DataGridViewRow row in dgvDetallesVentas.Rows)
                    {
                        total += Convert.ToDecimal(row.Cells["dgvcSubTotal"].Value);
                    }

                    // aplicar impuesto
                    decimal impuesto = Convert.ToDecimal(lblImpuestoAplicado.Text.Replace("%", ""));
                    total = total + (total * (impuesto / 100));

                    txtTotal.Text = uiUtilidades.FormatearMonedaPersonalizada(total, oVenta.Moneda);
                }
            }
        }

        private void cargarDetalleDeVenta(Venta venta)
        {
            txtTotal.Text = "0.00";
            if (venta != null)
            {
                txtFolio.Text = venta.VentaID.ToString("0000");
                txtCliente.Text = venta.NombreCliente;
                txtDocumento.Text = venta.NumeroDocumento;
                txtTipoCliente.Text = venta.TipoCliente;
                txtTipoComprobante.Text = venta.TipoComprobante;
                Usuario usuario = lUsuario.ObtenerUsuarioPorID(venta.usuario.UsuarioID);
                txtUsuario.Text = usuario.ObtenerNombreUsuario();
                txtFecha.Text = venta.FechaVenta.ToString("dd/MM/yyyy");
                lblImpuestoAplicado.Text = venta.Impuesto.ToString();
                pbCancelado.Visible = !venta.Estado;
            }
        }

        private void cargarNegocio()
        {
            if (NegocioDatos.Logo != null)
            {
                this.Icon = uiUtilidades.ByteArrayToIcon(NegocioDatos.Logo);
            }
            else
            {
                this.Icon = uiUtilidades.ImageToIcon(uiUtilidades.LogoPorDefecto());
            }
        }

        private string modificarPlantilla(string html)
        {
            // Información de Negocio
            html = html.Replace("@NombreNegocio", NegocioDatos.Nombre);
            html = html.Replace("@TipoDocumentoNegocio", NegocioDatos.TipoDocumento);
            html = html.Replace("@TipoMovimiento", "Detalle de venta");
            html = html.Replace("@DocumentoNegocio", NegocioDatos.Documento);
            html = html.Replace("@DireccionNegocio", NegocioDatos.Direccion);
            html = html.Replace("@TelefonoNegocio", NegocioDatos.Telefono);

            // Información del usuario que realizo compra
            html = html.Replace("@NombreApellidoUsuario", oVenta.usuario.ObtenerNombreyApellido());
            html = html.Replace("@DocumentoUsuario", oVenta.usuario.DNI);

            // Información de la entrada de inventario
            html = html.Replace("@TipoComprobante", oVenta.TipoComprobante);
            html = html.Replace("@NumeroFolio", oVenta.VentaID.ToString("0000"));

            // Detalles de la compra
            html = html.Replace("@NombreCliente", oVenta.NombreCliente);
            string tipoDocumentoCliente = string.IsNullOrEmpty(oVenta.TipoDocumento) || oVenta.TipoDocumento == "-" ? "Documento" : oVenta.TipoDocumento;
            html = html.Replace("@TipoDocumentoCliente", tipoDocumentoCliente);
            string DocumentoCliente = string.IsNullOrEmpty(oVenta.NumeroDocumento) || oVenta.NumeroDocumento == "-" ? "N/A" : oVenta.NumeroDocumento;
            html = html.Replace("@DocumentoCliente", DocumentoCliente);
            html = html.Replace("@TipoCliente", oVenta.TipoCliente);
            html = html.Replace("@Fecha", oVenta.FechaVenta.ToString("dd/MM/yyyy"));

            StringBuilder filas = new StringBuilder();
            decimal total = 0;
            foreach (DataGridViewRow row in dgvDetallesVentas.Rows)
            {
                filas.AppendLine("<tr>");
                filas.AppendLine("<td>" + row.Cells["dgvcCodigo"].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells["dgvcProducto"].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells["dgvcCantidadVendida"].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells["dgvcPrecioVenta"].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells["dgvcDescuento"].Value.ToString() + "%</td>");
                filas.AppendLine("<td>" + row.Cells["dgvcSubTotal"].Value.ToString() + "</td>");
                filas.AppendLine("</tr>");
                total += decimal.Parse(row.Cells["dgvcSubTotal"].Value.ToString());
            }
            // transformar moneda usando los datos establecido del negocio
            decimal impuesto = Convert.ToDecimal(lblImpuestoAplicado.Text.Replace("%", ""));
            total = total + (total * (impuesto / 100));
            string moneda = uiUtilidades.FormatearMonedaPersonalizada(total, oVenta.Moneda);
            html = html.Replace("@Impuesto", oVenta.Impuesto);
            html = html.Replace("@FILAS", filas.ToString());
            html = html.Replace("@Total", moneda);

            return html;
        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetallesVentas.Rows.Count > 0)
                {
                    SaveFileDialog guardar = new SaveFileDialog();
                    guardar.Filter = "Archivo PDF|*.pdf";
                    guardar.FileName = "Detalle de venta " + oVenta.VentaID.ToString("0000") + ".pdf";
                    string paginaHTML = string.Empty;
                    if (oVenta.Estado)
                    {
                        paginaHTML = Properties.Resources.detalle_venta;
                    }
                    else
                    {
                        guardar.FileName = "Detalle de venta " + oVenta.VentaID.ToString("0000") + "(Cancelada).pdf";
                        paginaHTML = Properties.Resources.detalle_venta_cancelado;
                    }
                    paginaHTML = modificarPlantilla(paginaHTML);

                    if (guardar.ShowDialog() == DialogResult.OK)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        uiUtilidades.HtmlToPdf(paginaHTML, guardar.FileName, NegocioDatos);
                        MessageBox.Show("El archivo PDF se ha guardado correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {
                    MessageBox.Show("No hay datos para imprimir.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (oVenta != null)
            {
                if (oVenta.Estado)
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro de cancelar la venta?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        if (lVenta.CancelarVenta(oVenta.VentaID))
                        {
                            pbCancelado.Visible = true;
                            oVenta.Estado = false;
                            MessageBox.Show("La venta fue cancelada correctamente, todo los productos que se vendieron fueron devueltos al inventario.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnSalir.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La venta ya fue cancelada.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar cancelar la venta, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dgvDetallesVentas_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new System.Drawing.Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void mdDetalleVentas_KeyDown(object sender, KeyEventArgs e)
        {
            // si presiona ESC se cierra
            if (e.KeyCode == Keys.Escape)
            {
                btnSalir.PerformClick();
            }
        }
    }
}
