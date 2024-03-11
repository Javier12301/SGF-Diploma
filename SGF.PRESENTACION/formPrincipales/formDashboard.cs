using SGF.NEGOCIO.Negocio;
using SGF.PRESENTACION.ReportesTableAdapters;
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
    public partial class formDashboard : Form
    {
        ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;
        CategoriaBLL lCategoria = CategoriaBLL.ObtenerInstancia;
        VentaBLL lVenta = VentaBLL.ObtenerInstancia;
        ProveedorBLL lProveedor = ProveedorBLL.ObtenerInstancia;

        public formDashboard()
        {
            InitializeComponent();
        }

        private void formDashboard_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'reportes.Producto_Reporte_MasVendidos' Puede moverla o quitarla según sea necesario.
            this.producto_Reporte_MasVendidosTableAdapter.Fill(this.reportes.Producto_Reporte_MasVendidos);
            // variable datetime
            // fecha inicio, debe ser el mismo año y mes de la fecha inicial, ejemplo estamos en 2024, entonces el mes debe ser enero y el día 1
            DateTime fechaInicio = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime fechaFin = new DateTime(DateTime.Now.Year, 12, 31);
            this.producto_Reporte_VentasPorMesTableAdapter.Fill(this.reportes.Producto_Reporte_VentasPorMes, fechaInicio, fechaFin);
            cargarDashboard();
        }

        private void cargarDashboard()
        {
            try
            {
                lblProductosGeneralVendidos.Text = lVenta.ObtenerVentaRealizada("Producto general").ToString();
            }
            catch (Exception)
            {
                lblProductosGeneralVendidos.Text = "-";
            }

            try
            {
                lblMedicamentosVendidos.Text = lVenta.ObtenerVentaRealizada("Medicamentos").ToString();
            }
            catch (Exception)
            {
                lblMedicamentosVendidos.Text = "-";
            }

            try
            {
                lblProductosGeneralTotal.Text = lProducto.ExistenciaDeProducto("Producto general").ToString();
            }
            catch (Exception)
            {
                lblProductosGeneralTotal.Text = "-";
            }

            try
            {
                lblMedicamentosTotal.Text = lProducto.ExistenciaDeProducto("Medicamentos").ToString();
            }
            catch (Exception)
            {
                lblMedicamentosTotal.Text = "-";
            }

            try
            {
                lblCategoriasTotales.Text = lCategoria.ConteoCategorias().ToString();
            }
            catch (Exception)
            {
                lblCategoriasTotales.Text = "-";
            }

            try
            {
                lblCategoriasUsadas.Text = lCategoria.ConteoCategoriasConProductos().ToString();
            }
            catch (Exception)
            {
                lblCategoriasUsadas.Text = "-";
            }

            try
            {
                lblProveedoresTotales.Text = lProveedor.ConteoProveedores().ToString();
            }
            catch (Exception)
            {
                lblProveedoresTotales.Text = "-";
            }

            try
            {
                lblComprasTotales.Text = lProveedor.ConteoComprasRealizadas(true).ToString();
            }
            catch (Exception)
            {
                lblComprasTotales.Text = "-";
            }

            this.producto_Reporte_VencimientoTempranoTableAdapter.Fill(this.reportes.Producto_Reporte_VencimientoTemprano);

        }
    }
}
