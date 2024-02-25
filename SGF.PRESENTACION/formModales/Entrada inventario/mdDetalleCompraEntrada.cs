using SGF.MODELO.Negocio;
using SGF.MODELO.Seguridad;
using SGF.NEGOCIO;
using SGF.NEGOCIO.Negocio;
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
using System.IO;
using System.Drawing.Imaging;
using iTextSharp.tool.xml.html;


namespace SGF.PRESENTACION.formModales
{
    public partial class mdDetalleCompraEntrada : Form
    {

        // Controladora
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private ProveedorBLL lProveedor = ProveedorBLL.ObtenerInstancia;
        private UsuarioBLL lUsuario = UsuarioBLL.ObtenerInstancia;
        private NegocioBLL lNegocio = NegocioBLL.ObtenerInstancia;
        private CompraBLL lCompra = CompraBLL.ObtenerInstancia;

        private NegocioModelo NegocioDatos { get; set; }

        private Permiso permisosDeUsuario;
        private Compra oCompra { get; set; }

        public mdDetalleCompraEntrada(Compra compra = null)
        {
            InitializeComponent();
            oCompra = compra;
            NegocioDatos = lNegocio.NegocioEnSesion().DatosDelNegocio;
            permisosDeUsuario = new Permiso();
        }

        private void mdDetalleCompraEntrada_Load(object sender, EventArgs e)
        {
            try
            {
                cargarNegocio();
                uiUtilidades.cargarPermisos("formDetallesInventario", flpContenedorBotones, permisosDeUsuario);
                if (oCompra != null && oCompra.CompraID > 0)
                {
                    cargarDetalledeCompras(oCompra);
                    cargarLista();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al cargar los detalles de la compra, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cargarLista()
        {
            if (oCompra != null)
            {
                detalle_CompraTableAdapter.Fill(this.negocio.Detalle_Compra, oCompra.CompraID);
                if (dgvDetallesCompras.Rows.Count > 0)
                {
                    decimal total = 0;
                    foreach (DataGridViewRow row in dgvDetallesCompras.Rows)
                    {
                        total += Convert.ToDecimal(row.Cells["dgvcSubTotal"].Value);
                    }
                    txtTotal.Text = uiUtilidades.FormatearMoneda(total, NegocioDatos);
                }
            }
        }
        private void cargarDetalledeCompras(Compra compra)
        {
            txtTotal.Text = "0.00";
            if (compra != null)
            {
                compra.proveedor = lProveedor.ObtenerProveedorPorID(compra.proveedor.ProveedorID);
                compra.usuario = lUsuario.ObtenerUsuarioPorID(compra.usuario.UsuarioID);
                txtFolio.Text = compra.CompraID.ToString();
                txtFecha.Text = compra.FechaCompra.ToString("dd/MM/yyyy");
                txtProveedor.Text = compra.proveedor.RazonSocial;
                txtDocumento.Text = compra.proveedor.Documento;
                txtTipoComprobante.Text = compra.TipoComprobante;
                txtUsuario.Text = compra.usuario.ObtenerNombreUsuario();
                pbCancelado.Visible = !compra.Estado;
            }

        }

        private string modificarPlantilla(string html)
        {
            // Información de Negocio
            html = html.Replace("@NombreNegocio", NegocioDatos.Nombre);
            html = html.Replace("@TipoDocumentoNegocio", NegocioDatos.TipoDocumento);
            html = html.Replace("@TipoMovimiento", "Detalle de compra");
            html = html.Replace("@DocumentoNegocio", NegocioDatos.Documento);
            html = html.Replace("@DireccionNegocio", NegocioDatos.Direccion);
            html = html.Replace("@TelefonoNegocio", NegocioDatos.Telefono);

            // Información del usuario que realizo compra
            html = html.Replace("@NombreApellidoUsuario", oCompra.usuario.ObtenerNombreyApellido());
            html = html.Replace("@DocumentoUsuario", oCompra.usuario.DNI);

            // Información de la entrada de inventario
            html = html.Replace("@TipoComprobante", oCompra.TipoComprobante);
            html = html.Replace("@NumeroFolio", oCompra.CompraID.ToString());

            // Detalles de la compra
            html = html.Replace("@NombreProveedor", oCompra.proveedor.RazonSocial);
            html = html.Replace("@TipoDocumentoProveedor", oCompra.proveedor.TipoDocumento);
            html = html.Replace("@DocumentoProveedor", oCompra.proveedor.Documento);
            html = html.Replace("@Fecha", oCompra.FechaCompra.ToString("dd/MM/yyyy"));

            StringBuilder filas = new StringBuilder();
            decimal total = 0;
            foreach (DataGridViewRow row in dgvDetallesCompras.Rows)
            {
                filas.AppendLine("<tr>");
                filas.AppendLine("<td>" + row.Cells["dgvcCodigo"].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells["dgvcProducto"].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells["dgvcCantidadComprada"].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells["dgvcPrecioCompra"].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells["dgvcSubTotal"].Value.ToString() + "</td>");
                filas.AppendLine("</tr>");
                total += decimal.Parse(row.Cells["dgvcSubTotal"].Value.ToString());
            }
            // transformar moneda usando los datos establecido del negocio
            string moneda = uiUtilidades.FormatearMoneda(total, NegocioDatos);
            html = html.Replace("@FILAS", filas.ToString());
            html = html.Replace("@Total", moneda);

            return html;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (permisosDeUsuario.Imprimir)
                {
                    if(dgvDetallesCompras.Rows.Count > 0)
                    {
                        SaveFileDialog guardar = new SaveFileDialog();
                        guardar.Filter = "Archivo PDF|*.pdf";
                        guardar.FileName = "Detalle de compra " + oCompra.CompraID + ".pdf";
                        string paginaHTML = string.Empty;
                        if (oCompra.Estado)
                        {
                            guardar.FileName = "Detalle de compra " + oCompra.CompraID + ".pdf";
                            paginaHTML = Properties.Resources.detalle_compra;
                        }
                        else
                        {
                            guardar.FileName = "Detalle de compra " + oCompra.CompraID + " (Cancelada).pdf";
                            paginaHTML = Properties.Resources.detalle_compra_cancelado;
                        }
                        paginaHTML = modificarPlantilla(paginaHTML);

                        if(guardar.ShowDialog() == DialogResult.OK)
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
                else
                {
                    MessageBox.Show("No tiene permiso para realizar esta acción, si cree que esto es un error contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (permisosDeUsuario.Cancelar)
            {
                // Cancelar un detalle de compra, provoca que se elimine el stock de los productos comprados
                // la compra quedará como estado cancelada.
                if (oCompra != null)
                {
                    if (MessageBox.Show("¿Está seguro de cancelar la compra?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (lCompra.CancelarCompra(oCompra.CompraID))
                        {
                            pbCancelado.Visible = true;
                            MessageBox.Show("La compra ha sido cancelada.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al cancelar la compra, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    throw new Exception("Ocurrió un error al intentar cancelar la compra, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.");
                }
            }
            else
            {
                MessageBox.Show("No tiene permiso para realizar esta acción, si cree que esto es un error contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDetallesCompras_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void printDatagrid_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dgvDetallesCompras.Width, this.dgvDetallesCompras.Height);
            dgvDetallesCompras.DrawToBitmap(bm, new System.Drawing.Rectangle(0, 0, this.dgvDetallesCompras.Width, this.dgvDetallesCompras.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }
    }
}
