using SGF.NEGOCIO.Negocio;
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
        ProveedorBLL lProveedor = ProveedorBLL.ObtenerInstancia;

        public formDashboard()
        {
            InitializeComponent();
        }

        private void formDashboard_Load(object sender, EventArgs e)
        {
            cargarDashboard();
        }

        private void cargarDashboard()
        {
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
