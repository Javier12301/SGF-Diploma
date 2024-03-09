using SGF.MODELO.Negocio;
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

namespace SGF.PRESENTACION.formPrincipales
{
    public partial class formVentas : Form
    {
        // Controladora
        NegocioBLL lNegocio = NegocioBLL.ObtenerInstancia;
        ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;
        UtilidadesUI lUtilidades = UtilidadesUI.ObtenerInstancia;
        ClienteBLL lCliente = ClienteBLL.ObtenerInstancia;

        public formVentas()
        {
            InitializeComponent();
        }

        private void formVentas_Load(object sender, EventArgs e)
        {
            cargarCombobox();
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

        }
    }
}
