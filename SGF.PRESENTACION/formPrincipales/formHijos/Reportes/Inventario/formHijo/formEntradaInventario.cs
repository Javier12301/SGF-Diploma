using SGF.MODELO.Negocio;
using SGF.MODELO.Seguridad;
using SGF.NEGOCIO.Negocio;
using SGF.PRESENTACION.formModales;
using SGF.PRESENTACION.formModales.Salida_inventario;
using SGF.PRESENTACION.UtilidadesComunes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SGF.PRESENTACION.formPrincipales.formHijos.Reportes.Inventario.formHijo
{
    public partial class formEntradaInventario : Form
    {
        // Controladoras
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private NegocioBLL lNegocio = NegocioBLL.ObtenerInstancia;


        Permiso permisoUsuarioInventario { get; set; }
        Permiso permisosReporteInventario { get; set; }
        private NegocioModelo NegocioDatos { get; set; }

        private int topMayorStock { get; set; }

        public formEntradaInventario(Permiso permisosUsuario)
        {
            InitializeComponent();
            permisosReporteInventario = permisosUsuario;
            permisoUsuarioInventario = new Permiso();
            NegocioDatos = lNegocio.NegocioEnSesion().DatosDelNegocio;
            topMayorStock = 5;
        }

        private void formEntradaInventario_Load(object sender, EventArgs e)
        {
            try
            {
                uiUtilidades.cargarPermisos("formInventario", flpContenedorBotones, permisoUsuarioInventario);
                if (permisoUsuarioInventario.EntradaMasiva)
                    btnEntradaMasiva.Enabled = true;
                listarReportes();
                if(permisosReporteInventario.Imprimir)
                    btnImprimir.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cargar reportes
        private void listarReportes()
        {
            try
            {
                txtTopMayorStock.Text = topMayorStock.ToString();
                this.producto_Reporte_MayorStockTableAdapter.Fill(this.reportes.Producto_Reporte_MayorStock, Convert.ToInt32(txtTopMayorStock.Text));
                
                // se mostrarán 5 productos más comprados
                this.producto_Reporte_MasCompradosTableAdapter.Fill(this.reportes.Producto_Reporte_MasComprados, 5);
                chartProductosMasComprados.Series["Productos"].IsValueShownAsLabel = true; // Muestra la cantidad comprada en los labels de las barras
                chartProductosMasComprados.Legends[0].Enabled = true;
                chartProductosMasComprados.Series["Productos"].LabelForeColor = Color.White;
                chartProductosMasComprados.Series["Productos"].LabelBackColor = Color.Black;
                chartProductosMasComprados.Series["Productos"].LabelBorderColor = Color.Black;
                chartProductosMasComprados.Series["Productos"].LabelBorderWidth = 1;
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filtrarReportes()
        {
            try
            {
                if (string.IsNullOrEmpty(txtTopMayorStock.Text))
                {
                    txtTopMayorStock.Text = topMayorStock.ToString();
                    return;
                }
                else
                {
                    topMayorStock = Convert.ToInt32(txtTopMayorStock.Text);
                    this.producto_Reporte_MayorStockTableAdapter.Fill(this.reportes.Producto_Reporte_MayorStock, Convert.ToInt32(txtTopMayorStock.Text));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtTopMayorStock_Leave(object sender, EventArgs e)
        {
            filtrarReportes();
        }

        private void btnEntradaMasiva_Click(object sender, EventArgs e)
        {
            if (permisoUsuarioInventario.EntradaMasiva)
            {
                using (var modal = new mdEntradaInventario(permisoUsuarioInventario))
                {
                    modal.ShowDialog();
                }
                listarReportes();
            }
            else
            {
                MessageBox.Show("No tienes permiso para realizar esta acción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalidaMasiva_Click(object sender, EventArgs e)
        {
            if (permisoUsuarioInventario.SalidaMasiva)
            {
                using (var modal = new mdSalidaInventario(permisoUsuarioInventario))
                {
                    modal.ShowDialog();
                }
            }
            listarReportes();

        }

        private void btnGrafico_Click(object sender, EventArgs e)
        {

        }

        private void btnKey_Press(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                filtrarReportes();
            }
            uiUtilidades.SoloNumero(e);
        }

        private string modificarPlantilla(string html)
        {
            html = html.Replace("@NombreNegocio", NegocioDatos.Nombre);
            html = html.Replace("@TipoDocumentoNegocio", NegocioDatos.TipoDocumento);
            html = html.Replace("@TipoMovimiento", "Resumen de inventario");
            html = html.Replace("@DocumentoNegocio", NegocioDatos.Documento);
            html = html.Replace("@DireccionNegocio", NegocioDatos.Direccion);
            html = html.Replace("@TelefonoNegocio", NegocioDatos.Telefono);

            // Información del reporte
            html = html.Replace("@TipoComprobante", "Inventario");
            html = html.Replace("@FechaMovimiento", DateTime.Now.ToString("dd/MM/yyyy"));

            StringBuilder filas = new StringBuilder();
            int cantidadTotal = 0;
            foreach(DataGridViewRow row in dgvProducosConMayorCantidad.Rows)
            {
                filas.AppendLine("<tr>");
                filas.AppendLine("<td>" + row.Cells[1].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells[2].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells[3].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells[4].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells[5].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells[6].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells[7].Value.ToString() + "</td>");
                filas.AppendLine("</tr>");

                cantidadTotal += Convert.ToInt32(row.Cells["dgvcCantidad"].Value.ToString());
            }

            html = html.Replace("@FILAS", filas.ToString());
            html = html.Replace("@TotalCantidad", cantidadTotal.ToString());

            return html;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (permisosReporteInventario.Imprimir)
                {
                    if (dgvProducosConMayorCantidad.Rows.Count > 0)
                    {
                        SaveFileDialog guardar = new SaveFileDialog();
                        guardar.Filter = "Archivo PDF|*.pdf";
                        guardar.FileName = "Resumen de inventario.pdf";
                        string paginaHTML = Properties.Resources.reporte_productos_mayor_stock;
                        paginaHTML = modificarPlantilla(paginaHTML);

                        if (guardar.ShowDialog() == DialogResult.OK)
                        {
                            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                            uiUtilidades.HtmlToPdf(paginaHTML, guardar.FileName, NegocioDatos);
                            MessageBox.Show("El archivo PDF se ha guardado correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            System.Windows.Forms.Cursor.Current = Cursors.Default;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay datos para imprimir", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No tiene permiso para imprimir los datos del reporte.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
