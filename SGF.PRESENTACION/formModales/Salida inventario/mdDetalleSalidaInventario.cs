using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2016.Presentation.Command;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Wordprocessing;
using PdfSharp;
using SGF.MODELO.Negocio;
using SGF.MODELO.Seguridad;
using SGF.NEGOCIO;
using SGF.NEGOCIO.Negocio;
using SGF.NEGOCIO.Seguridad;
using SGF.PRESENTACION.UtilidadesComunes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.formModales.Salida_inventario
{
    public partial class mdDetalleSalidaInventario : Form
    {
        //Controladora
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private ProveedorBLL lProveedor = ProveedorBLL.ObtenerInstancia;
        private UsuarioBLL lUsuario = UsuarioBLL.ObtenerInstancia;
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private SalidaInventarioBLL lSalidaInventario = SalidaInventarioBLL.ObtenerInstancia;
        private NegocioBLL lNegocio = NegocioBLL.ObtenerInstancia;

        private NegocioModelo NegocioDatos { get; set; }
        private Permiso permisoDeUsuario;
        private SalidaInventario oSalida { get; set; }

        public mdDetalleSalidaInventario(SalidaInventario salida = null)
        {
            InitializeComponent();
            oSalida = salida;
            NegocioDatos = lNegocio.NegocioEnSesion().DatosDelNegocio;
            permisoDeUsuario = new Permiso();
        }

        private void mdDetalleSalidaInventario_Load(object sender, EventArgs e)
        {
            try
            {
                cargarCombobox();
                cargarNegocio();
                uiUtilidades.cargarPermisos("formDetallesInventario", flpContenedorBotones, permisoDeUsuario);
                if (oSalida != null && oSalida.SalidaID > 0)
                {
                    cargarDetalledeSalida(oSalida);
                    cargarLista();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al cargar los detalles de la salida de inventario, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (oSalida != null)
            {
                detalle_SalidaTableAdapter.Fill(this.negocio.Detalle_Salida, oSalida.SalidaID, cmbFiltroBuscar.Text, txtBuscar.Text);
                if (dgvDetallesSalidas.Rows.Count > 0)
                {
                    int total = 0;
                    foreach (DataGridViewRow row in dgvDetallesSalidas.Rows)
                    {
                        total += Convert.ToInt32(row.Cells["dgvcCantidad"].Value);
                    }
                    txtTotal.Text = total.ToString();
                }
            }
        }

        private void cargarDetalledeSalida(SalidaInventario salida)
        {
            txtTotal.Text = "0";
            if (salida != null)
            {
                salida.Usuario = lUsuario.ObtenerUsuarioPorID(salida.Usuario.UsuarioID);
                txtFolio.Text = salida.SalidaID.ToString();
                txtFecha.Text = salida.FechaSalida.ToString("dd/MM/yyyy");
                txtUsuario.Text = salida.Usuario.ObtenerNombreUsuario();
                pbCancelado.Visible = !salida.Estado;
            }
        }

        private void filtrarLista()
        {
            detalle_SalidaTableAdapter.Fill(this.negocio.Detalle_Salida, oSalida.SalidaID, cmbFiltroBuscar.Text, txtBuscar.Text);
        }

        private void cargarCombobox()
        {
            cmbFiltroBuscar.Items.Add("Todo");
            cmbFiltroBuscar.Items.Add("Código");
            cmbFiltroBuscar.Items.Add("Nombre");
            cmbFiltroBuscar.Items.Add("Proveedor");
            cmbFiltroBuscar.Items.Add("Categoría");
            cmbFiltroBuscar.SelectedIndex = 0;

            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void cmbFiltroBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void dgvDetallesSalidas_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private string modificarPlantilla(string html)
        {
            // Información de Negocio
            html = html.Replace("@NombreNegocio", NegocioDatos.Nombre);
            html = html.Replace("@TipoDocumentoNegocio", NegocioDatos.TipoDocumento);
            html = html.Replace("@TipoMovimiento", "Detalle de Salida de Inventario");
            html = html.Replace("@DocumentoNegocio", NegocioDatos.Documento);
            html = html.Replace("@DireccionNegocio", NegocioDatos.Direccion);
            html = html.Replace("@TelefonoNegocio", NegocioDatos.Telefono);



            // Información salida
            html = html.Replace("@TipoComprobante", "Comprobante");
            html = html.Replace("@NumeroFolio", oSalida.SalidaID.ToString());

            // Información del usuario que realizo el movimiento
            html = html.Replace("@NombreUsuario", oSalida.Usuario.ObtenerNombreyApellido());
            html = html.Replace("@DocumentoUsuario", oSalida.Usuario.DNI);
            html = html.Replace("@FechaDelMovimiento", oSalida.FechaSalida.ToString("dd/MM/yyyy"));

            // Cargar detalle de salida
            StringBuilder filas = new StringBuilder();
            decimal total = 0;
            foreach (DataGridViewRow row in dgvDetallesSalidas.Rows)
            {
                filas.AppendLine("<tr>");
                filas.AppendLine("<td>" + row.Cells["dgvcCodigoBarras"].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells["dgvcNombreProducto"].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells["dgvcProveedor"].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells["dgvcCategoria"].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells["dgvcCantidad"].Value.ToString() + "</td>");
                filas.AppendLine("</tr>");
                total += int.Parse(row.Cells["dgvcCantidad"].Value.ToString());
            }

            html = html.Replace("@FILAS", filas.ToString());
            html = html.Replace("@Total", total.ToString());

            return html;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (permisoDeUsuario.Exportar)
                {
                    if (dgvDetallesSalidas.Rows.Count > 0)
                    {
                        SaveFileDialog guardar = new SaveFileDialog();
                        guardar.Filter = "Archivo PDF|*.pdf";
                        guardar.FileName = "Detalle de salida, folio " + oSalida.SalidaID + ".pdf";
                        string paginaHTML = string.Empty;
                        if (oSalida.Estado)
                        {
                            guardar.FileName = "Detalle de salida, folio " + oSalida.SalidaID + ".pdf";
                            paginaHTML = Properties.Resources.detalle_salida;
                        }
                        else
                        {
                            guardar.FileName = "Detalle de salida, folio " + oSalida.SalidaID + " (Cancelado).pdf";
                            paginaHTML = Properties.Resources.detalle_salida_cancelado;
                        }
                        paginaHTML = modificarPlantilla(paginaHTML);

                        if (guardar.ShowDialog() == DialogResult.OK)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            uiUtilidades.HtmlToPdf(paginaHTML, guardar.FileName, NegocioDatos);
                            MessageBox.Show("El archivo PDF se ha guardado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cursor.Current = Cursors.Default;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay datos para imprimir", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (permisoDeUsuario.Cancelar)
            {
                if(oSalida != null)
                {
                    if (oSalida.Estado)
                    {
                        if (MessageBox.Show("¿Está seguro de cancelar la compra?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (lSalidaInventario.CancelarSalidadeProductos(oSalida.SalidaID))
                            {
                                pbCancelado.Visible = true;
                                MessageBox.Show("La salida de productos del inventario ha sido cancelada.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show("Ocurrió un error al cancelar salida de productos del inventario, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("La salida de productos del inventario ya ha sido cancelada.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    throw new Exception("Ocurrió un error al intentar cancelar la salida de productos del inventario, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.");
                }
            }
            else
            {
                MessageBox.Show("No tiene permiso para realizar esta acción, si cree que esto es un error contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
