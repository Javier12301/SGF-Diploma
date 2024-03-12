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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.formModales.Ventas
{
    public partial class mdHistorialVentas : Form
    {
        // Controladora
        UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        VentaBLL lVenta = VentaBLL.ObtenerInstancia;
        NegocioBLL lNegocio = NegocioBLL.ObtenerInstancia;

        private Permiso permisoUsuario { get; set; }
        public mdHistorialVentas(Permiso permisoDeUsuario)
        {
            InitializeComponent();
            this.permisoUsuario = permisoDeUsuario;
        }

        private void mdHistorialVentas_Load(object sender, EventArgs e)
        {
            cargarFiltros();
            try
            {
                cargarNegocio();
                filtrarLista();
                if (permisoUsuario.Detalles)
                {
                    btnDetalles.Enabled = true;
                    btnDetalles.Visible = true;
                }
                else
                {
                    btnDetalles.Enabled = false;
                    btnDetalles.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (dgvVenta.Rows.Count > 0)
            {
                if (dgvVenta.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar una venta de inventario realizada de la lista para ver los detalles", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int ventaID = Convert.ToInt32(dgvVenta.Rows[dgvVenta.CurrentRow.Index].Cells["dgvcID"].Value);
                Venta venta = lVenta.ObtenerVentaPorID(ventaID);
                using (var modal = new mdDetalleVentas(venta))
                {
                    var resultado = modal.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        filtrarLista();
                    }
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            uiUtilidades.ExportarDataGridViewAExcel(dgvVenta, "Historial de venta", "Informe de ventas", "Ventas");
        }

        private void filtrarLista()
        {
            this.historialVentaTableAdapter.Filtrar(this.negocio.HistorialVenta, cmbFiltroEstado.Text, dtpInicio.Value, dtpFin.Value);
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void cargarFiltros()
        {
            cmbFiltroEstado.Items.Add("Activo");
            cmbFiltroEstado.Items.Add("Cancelado");
            cmbFiltroEstado.Items.Add("Todos");
            cmbFiltroEstado.SelectedIndex = 0;

            dtpInicio.Value = DateTime.Now.AddYears(-5);
            dtpFin.Value = DateTime.Now.AddYears(5);
        }

        private void cargarNegocio()
        {
            NegocioModelo negocio = lNegocio.NegocioEnSesion().DatosDelNegocio;
            if (negocio.Logo != null)
                this.Icon = uiUtilidades.ByteArrayToIcon(negocio.Logo);
            else
                this.Icon = uiUtilidades.ImageToIcon(uiUtilidades.LogoPorDefecto());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgvVenta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVenta.Rows.Count > 0)
            {
                if (dgvVenta.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar una venta de inventario realizada de la lista para ver los detalles", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int ventaID = Convert.ToInt32(dgvVenta.Rows[dgvVenta.CurrentRow.Index].Cells["dgvcID"].Value);
                Venta venta = lVenta.ObtenerVentaPorID(ventaID);
                using (var modal = new mdDetalleVentas(venta))
                {
                    var resultado = modal.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        filtrarLista();
                    }
                }
            }
        }

        private void mdHistorialVentas_KeyDown(object sender, KeyEventArgs e)
        {
            // al presionar ESC se cierra el formulario
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
