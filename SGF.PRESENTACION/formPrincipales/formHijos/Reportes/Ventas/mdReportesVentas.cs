using SGF.MODELO.Negocio;
using SGF.MODELO.Seguridad;
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
            if(tabControl1.SelectedIndex == 0)
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
            if(tabControl1.SelectedIndex == 0)
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
            if(tabControl1.SelectedIndex == 0)
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
            if(tabControl1.SelectedIndex == 0)
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
            if(tabControl1.SelectedIndex == 0)
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
            if(tabControl1.SelectedIndex == 0)
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
            if(tabControl1.SelectedIndex== 1)
            {
                this.producto_Reporte_SinStockTableAdapter.Fill(this.reportes.Producto_Reporte_SinStock);
                this.producto_Reporte_VencimientoTempranoTableAdapter.Fill(this.reportes.Producto_Reporte_VencimientoTemprano);
               
            }
        }
    }
}
