using DocumentFormat.OpenXml.Packaging;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.html;
using Microsoft.Vbe.Interop;
using SGF.MODELO.Negocio;
using SGF.MODELO.Seguridad;
using SGF.NEGOCIO.Negocio;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace SGF.PRESENTACION.formPrincipales.formHijos.Reportes.Ventas
{
    public partial class mdReporteResumen : Form
    {
        // controladoras
        ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;
        ProveedorBLL lProveedor = ProveedorBLL.ObtenerInstancia;
        ClienteBLL lCliente = ClienteBLL.ObtenerInstancia;
        CompraBLL lCompra = CompraBLL.ObtenerInstancia;
        VentaBLL lVenta = VentaBLL.ObtenerInstancia;
        UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        NegocioBLL lNegocio = NegocioBLL.ObtenerInstancia;

        NegocioModelo negocioDatos { get; set; }


        Permiso permisoDeUsuario { get; set; }
        public mdReporteResumen()
        {
            InitializeComponent();
            negocioDatos = lNegocio.NegocioEnSesion().DatosDelNegocio;

        }

        private void mdReporteResumen_Load(object sender, EventArgs e)
        {
            try
            {
                uiUtilidades.cargarPermisos("formReporteResumenTotal", flpContenedorBotones, permisoDeUsuario);
                cargarDescripcionyDatos();
                btnUltimoAño.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carga de descripciones
        private void cargarDescripcionyDatos()
        {
            // Cargar ventas de productos general y medicamentos
            lblVenProd.Text = lVenta.ObtenerVentaRealizada("Producto general").ToString();
            lblVenMedic.Text = lVenta.ObtenerVentaRealizada("Medicamentos").ToString();
            // Canceladas
            lblVenCanceladas.Text = lVenta.ConteoVentasCanceladas().ToString();

            // Compras
            lblComprProd.Text = lCompra.ObtenerCompraRealizada("Producto general").ToString();
            lblComprMed.Text = lCompra.ObtenerCompraRealizada("Medicamentos").ToString();
            lblComprCanceladas.Text = lCompra.ObtenerCompraCancelada().ToString();

            // Cargar Clientes, número de clientes, activos, inactivo/baja
            lblClienNumero.Text = lCliente.ConteoClientes().ToString();
            lblClienActivos.Text = lCliente.ConteoClientesActivos().ToString();
            lblClienBaja.Text = lCliente.ConteoClientesInactivos().ToString();

            // Inventario
            lblInvProductos.Text = lProducto.ExistenciaDeProducto("Producto general").ToString();
            lblInvMedicamentos.Text = lProducto.ExistenciaDeProducto("Medicamentos").ToString();
            // costo de inventario y precio de inventario
            lblInvCostoInventario.Text = uiUtilidades.FormatearMoneda(lProducto.ObtenerCostoInventario(), negocioDatos);
            lblInvPrecioInventario.Text = uiUtilidades.FormatearMoneda(lProducto.ObtenerPrecioInventario(), negocioDatos);
            lblInvExistenciaTotal.Text = lProducto.ConteoProductos().ToString();
            lblInvInactivoBaja.Text = lProducto.ConteoProductosInactivosYDadosDeBaja().ToString();

            // Proveedores
            lblProvNumero.Text = lProveedor.ConteoProveedores().ToString();
            lblProvActivos.Text = lProveedor.ConteoProveedoresActivos().ToString();
            lblProvInactivos.Text = lProveedor.ConteoProveedoresInactivos().ToString();


        }

        private void cargarGraficoPorMes()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                // cargar chart con datatable
                cVentas.DataSource = lVenta.ObtenerVentasPorFechas(dtpInicio.Value, dtpFin.Value);

                cVentas.Series[0].XValueMember = "Month";
                cVentas.Series[0].YValueMembers = "NumeroDeVentas";
                cVentas.Series[0].IsValueShownAsLabel = true;
                cVentas.Series[0].LabelFormat = "{0}";
                cVentas.Series[0].LabelForeColor = Color.White;
                cVentas.Series[0].LabelBackColor = Color.Black;
                cVentas.Series[0].LabelBorderColor = Color.Black;
                cVentas.Series[0].LabelBorderWidth = 1;
            }
            else
            {
                cCompras.DataSource = lCompra.ObtenerComprasPorFecha(dtpInicio.Value, dtpFin.Value);
                /*uery.AppendLine("SELECT YEAR(FechaCompra) AS Year, FORMAT(FechaCompra, 'MMMM', 'es-ES') AS Month, COUNT(*) AS NumeroDeCompras FROM Compra WHERE FechaCompra BETWEEN @FechaInicio AND @FechaHasta GROUP BY YEAR(FechaCompra), MONTH(FechaCompra), FORMAT(FechaCompra, 'MMMM', 'es-ES') ORDER BY Year, MONTH(FechaCompra)");*/
                // usando la query de referencia configurar chart
                cCompras.Series[0].XValueMember = "Month";
                cCompras.Series[0].YValueMembers = "NumeroDeCompras";
                cCompras.Series[0].IsValueShownAsLabel = true;
                cCompras.Series[0].LabelFormat = "{0}";
                cCompras.Series[0].LabelForeColor = Color.White;
                cCompras.Series[0].LabelBackColor = Color.Black;
                cCompras.Series[0].LabelBorderColor = Color.Black;
                cCompras.Series[0].LabelBorderWidth = 1;
            }
        }


        private void cargarGraficoCirculoProductoGeneral(string tipoProducto)
        {
            cProductos.DataSource = lVenta.ObtenerTipoProductosMasVendidos(tipoProducto, dtpInicio.Value, dtpFin.Value);
            cProductos.Series[0].XValueMember = "Nombre";
            cProductos.Series[0].YValueMembers = "NumeroDeVentas";
            cProductos.Series[0].IsValueShownAsLabel = true;
            cProductos.Series[0].LabelFormat = "{0}";
            cProductos.Series[0].LabelForeColor = Color.White;
            cProductos.Series[0].LabelBackColor = Color.Black;
            cProductos.Series[0].LabelBorderColor = Color.Black;
            cProductos.Series[0].LabelBorderWidth = 1;

        }

        private void cargarGraficoCirculoMedicamentos(string tipoProducto)
        {
            cMedicamentos.DataSource = lVenta.ObtenerTipoProductosMasVendidos(tipoProducto, dtpInicio.Value, dtpFin.Value);
            cMedicamentos.Series[0].XValueMember = "Nombre";
            cMedicamentos.Series[0].YValueMembers = "NumeroDeVentas";
            cMedicamentos.Series[0].IsValueShownAsLabel = true;
            cMedicamentos.Series[0].LabelFormat = "{0}";
            cMedicamentos.Series[0].LabelForeColor = Color.White;
            cMedicamentos.Series[0].LabelBackColor = Color.Black;
            cMedicamentos.Series[0].LabelBorderColor = Color.Black;
            cMedicamentos.Series[0].LabelBorderWidth = 1;

        }

        private void cargarGraficoPorDiaSemana()
        {
            DataTable dt = new DataTable();
            if (tabControl1.SelectedIndex == 0)
            {
                dt = lVenta.ObtenerVentasPorSemana(dtpInicio.Value, dtpFin.Value);
            }
            else
            {
                dt = lCompra.ObtenerComprasPorSemana(dtpInicio.Value, dtpFin.Value);
            }
            // traducir los nombres de los días de la semana
            foreach (DataRow row in dt.Rows)
            {
                switch (row["DiaSemana"].ToString())
                {
                    case "Monday":
                        row["DiaSemana"] = "Lunes";
                        break;
                    case "Tuesday":
                        row["DiaSemana"] = "Martes";
                        break;
                    case "Wednesday":
                        row["DiaSemana"] = "Miércoles";
                        break;
                    case "Thursday":
                        row["DiaSemana"] = "Jueves";
                        break;
                    case "Friday":
                        row["DiaSemana"] = "Viernes";
                        break;
                    case "Saturday":
                        row["DiaSemana"] = "Sábado";
                        break;
                    case "Sunday":
                        row["DiaSemana"] = "Domingo";
                        break;
                }
            }
            if (tabControl1.SelectedIndex == 0)
            {
                cVentas.DataSource = dt;

                cVentas.Series[0].XValueMember = "DiaSemana";
                cVentas.Series[0].YValueMembers = "NumeroDeVentas";
                cVentas.Series[0].IsValueShownAsLabel = true;
                cVentas.Series[0].LabelFormat = "{0}";
                cVentas.Series[0].LabelForeColor = Color.White;
                cVentas.Series[0].LabelBackColor = Color.Black;
                cVentas.Series[0].LabelBorderColor = Color.Black;
                cVentas.Series[0].LabelBorderWidth = 1;
            }
            else
            {
                cCompras.DataSource = dt;
                cCompras.Series[0].XValueMember = "DiaSemana";
                cCompras.Series[0].YValueMembers = "NumeroDeCompras";
                cCompras.Series[0].IsValueShownAsLabel = true;
                cCompras.Series[0].LabelFormat = "{0}";
                cCompras.Series[0].LabelForeColor = Color.White;
                cCompras.Series[0].LabelBackColor = Color.Black;
                cCompras.Series[0].LabelBorderColor = Color.Black;
                cCompras.Series[0].LabelBorderWidth = 1;
            }
        }

        private void flowLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUltimoAño_Click(object sender, EventArgs e)
        {
            // configurar fecha inicio y hasta con el año actual o sea un anual
            DateTime fechaInicio = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime fechaFin = new DateTime(DateTime.Now.Year, 12, 31);
            dtpInicio.Value = fechaInicio;
            dtpFin.Value = fechaFin;
            if (tabControl1.SelectedIndex == 0)
            {
                cargarGraficoPorMes();
                cargarGraficoCirculoProductoGeneral("Producto general");
                cargarGraficoCirculoMedicamentos("Medicamentos");
                cVentas.Titles[0].Text = "Ventas por mes del año " + DateTime.Now.Year;
            }
            else
            {
                cargarGraficoPorMes();
                cCompras.Titles[0].Text = "Compras por mes del año " + DateTime.Now.Year;
            }
        }



        private void btnUltimoMes_Click(object sender, EventArgs e)
        {
            // configurar fecha inicio y hasta con el mes actual o sea un mensual
            DateTime fechaInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime fechaFin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            dtpInicio.Value = fechaInicio;
            dtpFin.Value = fechaFin;
            if (tabControl1.SelectedIndex == 0)
            {
                cargarGraficoPorMes();
                cargarGraficoCirculoProductoGeneral("Producto general");
                cargarGraficoCirculoMedicamentos("Medicamentos");
                cVentas.Titles[0].Text = "Ventas por mes del " + DateTime.Now.ToString("MMMM") + " del año " + DateTime.Now.Year;
            }
            else
            {
                cargarGraficoPorMes();
                cCompras.Titles[0].Text = "Compras por mes del " + DateTime.Now.ToString("MMMM") + " del año " + DateTime.Now.Year;
            }
        }

        private void btnUltimaSemana_Click(object sender, EventArgs e)
        {
            // configurar fecha inicio y hasta con la semana actual o sea un semanal
            DateTime fechaInicio = DateTime.Now.AddDays(-7);
            DateTime fechaFin = DateTime.Now;
            dtpInicio.Value = fechaInicio;
            dtpFin.Value = fechaFin;
            if (tabControl1.SelectedIndex == 0)
            {
                cargarGraficoPorDiaSemana();
                cargarGraficoCirculoProductoGeneral("Producto general");
                cargarGraficoCirculoMedicamentos("Medicamentos");
                cVentas.Titles[0].Text = "Ventas por semana del " + DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy") + " al " + DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                cargarGraficoPorDiaSemana();
                cCompras.Titles[0].Text = "Compras por semana del " + DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy") + " al " + DateTime.Now.ToString("dd/MM/yyyy");
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUltimoAño.PerformClick();
            if (tabControl1.SelectedIndex == 1)
            {
                this.producto_Reporte_SinStockTableAdapter.Fill(this.reportes.Producto_Reporte_SinStock);
                this.producto_Reporte_VencimientoTempranoTableAdapter.Fill(this.reportes.Producto_Reporte_VencimientoTemprano);

            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                GenerarPDF_Ventas();
            }
            else
            {
                GenerarPDF_Compras();
            }
        }

        private string modificarPlantilla(string html)
        {
            // Información de Negocio
            html = html.Replace("@NombreNegocio", negocioDatos.Nombre);
            html = html.Replace("@TipoMovimiento", "Detalle de venta");
            html = html.Replace("@DireccionNegocio", negocioDatos.Direccion);
            html = html.Replace("@TelefonoNegocio", negocioDatos.Telefono);
            html = html.Replace("@TipoDocumentoNegocio", negocioDatos.TipoDocumento);
            html = html.Replace("@DocumentoNegocio", negocioDatos.Documento);

            // Información de la entrada de inventario
            html = html.Replace("@TipoComprobante", "Reporte");

            // Totales
            html = html.Replace("@VentasRealizadasProductos", lblVenProd.Text);
            html = html.Replace("@VentasRealizadasMedicamentos", lblVenMedic.Text);
            html = html.Replace("@VentasCanceladas", lblVenCanceladas.Text);
            html = html.Replace("@ComprasRealizadasProductos", lblComprProd.Text);
            html = html.Replace("@ComprasRealizadasMedicamentos", lblComprMed.Text);
            html = html.Replace("@ComprasCanceladas", lblComprCanceladas.Text);
            html = html.Replace("@NumeroDeClientes", lblClienNumero.Text);
            html = html.Replace("@ClientesActivos", lblClienActivos.Text);
            html = html.Replace("@ClientesInactivos", lblClienBaja.Text);
            html = html.Replace("@NumeroDeProveedores", lblProvNumero.Text);
            html = html.Replace("@ProveedoresActivos", lblProvActivos.Text);
            html = html.Replace("@ProveedoresInactivos", lblProvInactivos.Text);
            html = html.Replace("@ExistenciaProducto", lblInvProductos.Text);
            html = html.Replace("@ExistenciaMedicamentos", lblInvMedicamentos.Text);
            html = html.Replace("@CostoInventario", lblInvCostoInventario.Text);
            html = html.Replace("@PrecioInventario", lblInvPrecioInventario.Text);
            html = html.Replace("@ExistenciaTotal", lblInvExistenciaTotal.Text);
            html = html.Replace("@ProductosInactivos", lblInvInactivoBaja.Text);

            return html;
        }


        private void GenerarPDF_Ventas()
        {
            try
            {
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.Filter = "Archivo PDF|*.pdf";
                guardar.FileName = "Resumen total de ventas.pdf";
                string paginaHTML = Properties.Resources.Plantilla_Reporte_Ventas;
                paginaHTML = modificarPlantilla(paginaHTML);
                if(guardar.ShowDialog() == DialogResult.OK)
                {

                    using(System.IO.FileStream stream = new System.IO.FileStream(guardar.FileName, FileMode.Create))
                    {
                        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 0f);
                        PdfWriter writer = PdfWriter.GetInstance(document, stream);
                        document.Open();
                        using(StringReader sr = new StringReader(paginaHTML))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);
                        }

                        MemoryStream imagenChartCVentas = ConvertirChartAImagen(cVentas);
                        // aplicar una logica similar pero con imagen chartcventas                     iTextSharp.text.Image chartImage1 = iTextSharp.text.Image.GetInstance(imagenChartSolicitudes.ToArray());
                        iTextSharp.text.Image chartImage1 = iTextSharp.text.Image.GetInstance(imagenChartCVentas.ToArray());
                        chartImage1.ScaleToFit(iTextSharp.text.PageSize.A4.Width, iTextSharp.text.PageSize.A4.Height);
                        document.Add(chartImage1);

                        // ahora cProductos y luego con cMedicamentos de la misma forma
                        MemoryStream imagenChartCProductos = ConvertirChartAImagen(cProductos);
                        iTextSharp.text.Image chartImage2 = iTextSharp.text.Image.GetInstance(imagenChartCProductos.ToArray());
                        chartImage2.ScaleToFit(iTextSharp.text.PageSize.A4.Width, iTextSharp.text.PageSize.A4.Height);
                        document.Add(chartImage2);

                        MemoryStream imagenChartCMedicamentos = ConvertirChartAImagen(cMedicamentos);
                        iTextSharp.text.Image chartImage3 = iTextSharp.text.Image.GetInstance(imagenChartCMedicamentos.ToArray());
                        chartImage3.ScaleToFit(iTextSharp.text.PageSize.A4.Width, iTextSharp.text.PageSize.A4.Height);
                        document.Add(chartImage3);

                        document.Close();
                        stream.Close();
                        MessageBox.Show("Reporte generado con éxito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public MemoryStream ConvertirChartAImagen(Chart chart)
        {
            Bitmap bmp = new Bitmap(chart.Width, chart.Height);
            chart.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, chart.Width, chart.Height));

            MemoryStream stream = new MemoryStream();
            bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

            return stream;
        }

        // Convertir panel con todos sus controles a imagen
        public MemoryStream ConvertirPanelAImagen(Panel panel)
        {
            Bitmap bmp = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, panel.Width, panel.Height));

            MemoryStream stream = new MemoryStream();
            bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

            return stream;
        }

        private void GenerarPDF_Compras()
        {
           
            try
            {
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.Filter = "Archivo PDF|*.pdf";
                guardar.FileName = "Resumen total de compras.pdf";
                string paginaHTML = Properties.Resources.Plantilla_Reporte_Ventas;
                paginaHTML = modificarPlantilla(paginaHTML);
                if (guardar.ShowDialog() == DialogResult.OK)
                {

                    using (System.IO.FileStream stream = new System.IO.FileStream(guardar.FileName, FileMode.Create))
                    {
                        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 0f);
                        PdfWriter writer = PdfWriter.GetInstance(document, stream);
                        document.Open();
                        using (StringReader sr = new StringReader(paginaHTML))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);
                        }

                        MemoryStream imagenChartCCompras = ConvertirChartAImagen(cCompras);
                        iTextSharp.text.Image chartImage1 = iTextSharp.text.Image.GetInstance(imagenChartCCompras.ToArray());
                        chartImage1.ScaleToFit(iTextSharp.text.PageSize.A4.Width, iTextSharp.text.PageSize.A4.Height);
                        document.Add(chartImage1);

                        // convertir los paneles  pnlProductosPorVencer y pnlSinStock, escalarlo según el tamaño que tengan y que no se salga del tamaño de la hoja
                        // para que no ocupen toda las hojas girarlo a horizontal
                        MemoryStream imagenPanelProductosPorVencer = ConvertirPanelAImagen(pnlProductosPorVencer);
                        iTextSharp.text.Image panelImage1 = iTextSharp.text.Image.GetInstance(imagenPanelProductosPorVencer.ToArray());
                        panelImage1.ScaleToFit(iTextSharp.text.PageSize.A4.Width * 0.8f, iTextSharp.text.PageSize.A4.Height * 0.8f);
                        document.Add(panelImage1);


                        MemoryStream imagenPanelSinStock = ConvertirPanelAImagen(pnlSinStock);
                        iTextSharp.text.Image panelImage2 = iTextSharp.text.Image.GetInstance(imagenPanelSinStock.ToArray());
                        panelImage2.ScaleToFit(iTextSharp.text.PageSize.A4.Width * 0.8f, iTextSharp.text.PageSize.A4.Height * 0.8f);
                        document.Add(panelImage2);

                        



                        document.Close();
                        stream.Close();
                        MessageBox.Show("Reporte generado con éxito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
