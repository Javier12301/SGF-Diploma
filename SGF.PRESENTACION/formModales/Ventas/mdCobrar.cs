using Microsoft.ReportingServices.Interfaces;
using Microsoft.VisualBasic;
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

namespace SGF.PRESENTACION.formModales.Ventas
{
    public partial class mdCobrar : Form
    {
        public Venta ObjectVenta { get; set; }
        private UtilidadesUI utilidadesUI = UtilidadesUI.ObtenerInstancia;
        private UtilidadesComunes.Conversion utilidadesConversion = UtilidadesComunes.Conversion.ObtenerInstancia;
        public mdCobrar(Venta oVenta)
        {
            InitializeComponent();
            this.ObjectVenta = oVenta;
        }

        public enum Opciones
        {
            CobrarEimprimir,
            CobrarYNoImprimir
        }

        public Opciones OpcionSeleccionada;

        private void mdCobrar_Load(object sender, EventArgs e)
        {
            lblTotal.Text = ObjectVenta.MontoTotal.ToString();
            lblNumeroLetra.Text = utilidadesConversion.enletras(ObjectVenta.MontoTotal.ToString()) + " " + ObjectVenta.Moneda.Nombre.ToUpper();
        }


        private Point mousePosicion;
        private void pnlControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int deltaX = e.X - mousePosicion.X;
                int deltaY = e.Y - mousePosicion.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }

        private void pnlControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousePosicion = e.Location;
            }
        }

        private void txtPagoCon_TextChanged(object sender, EventArgs e)
        {
            calcularCambio();
        }

        // contar cambio
        private void calcularCambio()
        {
            decimal total = ObjectVenta.MontoTotal;
            // try parse decimal pago con
            if(decimal.TryParse(txtPagoCon.Text, out decimal pagoCon))
            {
                decimal cambio = pagoCon - total;
                txtCambio.Text = cambio.ToString();
            }
            else if (string.IsNullOrEmpty(txtPagoCon.Text))
            {
                decimal cambio = 0 - total;
                txtCambio.Text = cambio.ToString();
            }else
            {
                MessageBox.Show("El valor ingresado no es un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPagoCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidadesUI.TextboxMoneda_KeyPress(txtPagoCon, e, errorProvider);
        }

        private void txtPagoCon_Leave(object sender, EventArgs e)
        {
            utilidadesUI.TextboxMoneda_Leave(txtPagoCon, e);
            calcularCambio();
        }

        private void btnCobrarSinImprimir_Click(object sender, EventArgs e)
        {
            if(decimal.TryParse(txtPagoCon.Text, out decimal pagoCon))
            {
                decimal cambio = Convert.ToDecimal(txtCambio.Text);
                
                if(pagoCon >= ObjectVenta.MontoTotal)
                {
                    ObjectVenta.MontoPagado = pagoCon;
                    ObjectVenta.MontoCambio = cambio;
                    // se selecciono cobrar sin imprimir entonces el enum es CobrarYNoImprimir
                    OpcionSeleccionada = Opciones.CobrarYNoImprimir;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El monto ingresado es menor al total de la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El valor ingresado no es un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCobrarImprimir_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPagoCon.Text, out decimal pagoCon))
            {
                decimal cambio = Convert.ToDecimal(txtCambio.Text);

                if (pagoCon >= ObjectVenta.MontoTotal)
                {
                    ObjectVenta.MontoPagado = pagoCon;
                    ObjectVenta.MontoCambio = cambio;
                    OpcionSeleccionada = Opciones.CobrarEimprimir;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El monto ingresado es menor al total de la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El valor ingresado no es un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        

        private void txtPagoCon_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DialogResult respuesta = MessageBox.Show("¿Desea imprimir el comprobante?", "Cobrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(respuesta == DialogResult.Yes)
                {
                    btnCobrarImprimir.PerformClick();
                }
                else
                {
                    btnCobrarSinImprimir.PerformClick();
                }
            }

            // si presiona ctrl + enter se hace sinimprimir directamente
            if(e.Control && e.KeyCode == Keys.Enter)
            {
                btnCobrarSinImprimir.PerformClick();
            }
        }
    }
}
