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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;


namespace SGF.PRESENTACION.formModales
{
    public partial class mdDetalleCompraEntrada : Form
    {

        // Controladora
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private ProveedorBLL lProveedor = ProveedorBLL.ObtenerInstancia;
        private UsuarioBLL lUsuario = UsuarioBLL.ObtenerInstancia;
        private NegocioBLL lNegocio = NegocioBLL.ObtenerInstancia;

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
                        total += Convert.ToDecimal(row.Cells[4].Value);
                    }
                    txtTotal.Text = total.ToString("C2");
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
                txtUsuario.Text = compra.usuario.NombreUsuario;
            }

        }

        private string crearReporteDeImpresion(string paginaHTML)
        {
            // Información de negocio
            paginaHTML = paginaHTML.Replace("@NombreNegocio", NegocioDatos.Nombre);
            paginaHTML = paginaHTML.Replace("@DireccionNegocio", NegocioDatos.Direccion);
            paginaHTML = paginaHTML.Replace("@TelefonoNegocio", NegocioDatos.Telefono);
            paginaHTML = paginaHTML.Replace("@EmailNegocio", NegocioDatos.Correo);

            // Información del usuario que realizo compra
            // @Nombre @Apellido
            paginaHTML = paginaHTML.Replace("@NombreyApellido", oCompra.usuario.ObtenerNombreyApellido());
            paginaHTML = paginaHTML.Replace("@TipoDocumentoUsuario", NegocioDatos.TipoDocumento);
            paginaHTML = paginaHTML.Replace("@DocumentoUsuario", NegocioDatos.Documento);

            // Detalles de la compra
            paginaHTML = paginaHTML.Replace("@TipodeComprobante", txtTipoComprobante.Text);
            paginaHTML = paginaHTML.Replace("@FolioCompra", txtFolio.Text);
            paginaHTML = paginaHTML.Replace("@ProveedorCompra", txtProveedor.Text);
            paginaHTML = paginaHTML.Replace("@DocumentoProveedor", txtDocumento.Text);
            paginaHTML = paginaHTML.Replace("@FechaCompra", txtFecha.Text);

            // Se remplazará esto porque ocurre un error de lectura por el acento.
            paginaHTML = paginaHTML.Replace("@ColumnaCodigo", "Código");

            StringBuilder filas = new StringBuilder();
            decimal total = 0;
            foreach(DataGridViewRow row in dgvDetallesCompras.Rows)
            {
                filas.Append("<tr>");
                filas.Append("<td>" + row.Cells["dgvcCodigo"].Value.ToString() + "</td>");
                filas.Append("<td>" + row.Cells["dgvcProducto"].Value.ToString() + "</td>");
                filas.Append("<td>" + row.Cells["dgvcCantidadComprada"].Value.ToString() + "</td>");
                filas.Append("<td>" + row.Cells["dgvcPrecioCompra"].Value.ToString() + "</td>");
                filas.Append("<td>" + row.Cells["dgvcSubTotal"].Value.ToString() + "</td>");
                filas.Append("</tr>");
                total += decimal.Parse(row.Cells["dgvcSubTotal"].Value.ToString());
            }
            // transformar moneda usando los datos establecido del negocio
            string moneda = string.Empty;
            if(NegocioDatos.Moneda.Posicion == "Antes")
            {
                moneda = NegocioDatos.Moneda.Simbolo + " " + total.ToString("N2");
            }
            else
            {
                moneda = total.ToString("N2") + " " + NegocioDatos.Moneda.Simbolo;
            }
            paginaHTML = paginaHTML.Replace("@FILAS", filas.ToString());
            paginaHTML = paginaHTML.Replace("@TOTAL", moneda);

            return paginaHTML;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (permisosDeUsuario.Imprimir)
            {
                if (dgvDetallesCompras.Rows.Count > 0)
                {
                    SaveFileDialog guardar = new SaveFileDialog();
                    guardar.Filter = "Archivo PDF|*.pdf";
                    guardar.FileName = "Detalle de compra, folio " + oCompra.CompraID + ".pdf";
                    string paginaHTML = Properties.Resources.plantillaDetalle_Compras;
                    paginaHTML = crearReporteDeImpresion(paginaHTML);

                    if (guardar.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(new Phrase(""));
                                using (StringReader sr = new StringReader(paginaHTML))
                                {
                                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                                }
                                pdfDoc.Close();
                                stream.Close();
                            }
                            MessageBox.Show("El archivo se ha guardado correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No hay datos para imprimir.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No tiene permiso para realizar esta acción, si cree que esto es un error contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (permisosDeUsuario.Cancelar)
            {

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
            this.DialogResult = DialogResult.Cancel;
        }

        private void printDatagrid_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dgvDetallesCompras.Width, this.dgvDetallesCompras.Height);
            dgvDetallesCompras.DrawToBitmap(bm, new System.Drawing.Rectangle(0, 0, this.dgvDetallesCompras.Width, this.dgvDetallesCompras.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }
    }
}
