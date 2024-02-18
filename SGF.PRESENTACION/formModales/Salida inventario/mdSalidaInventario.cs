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

namespace SGF.PRESENTACION.formModales.Salida_inventario
{
    public partial class mdSalidaInventario : Form
    {
        // Controladora
        private SalidaInventarioBLL lSalidaInventario = SalidaInventarioBLL.ObtenerInstancia;
        private NegocioBLL lNegocio = NegocioBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;

        Permiso permisoDeUsuario;
        public mdSalidaInventario(Permiso permisos)
        {
            InitializeComponent();
            permisoDeUsuario = permisos;
        }

        private void mdSalidaInventario_Load(object sender, EventArgs e)
        {
            cargarFiltros();        
            try
            {
                cargarNegocio();
                if (permisoDeUsuario.SalidaMasiva)
                {
                    btnNuevo.Enabled = true;
                    btnNuevo.Visible = true;
                    btnDetalles.Enabled = true;
                    btnDetalles.Visible = true;
                    if (permisoDeUsuario.Exportar)
                    {
                        btnExportar.Enabled = true;
                        btnExportar.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("No tiene permiso para ingresar a este módulo, si cree que esto es un error contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                filtrarLista();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (permisoDeUsuario.EntradaMasiva)
            {
                using(var modal = new mdRegistrarSalida())
                {
                    var resultado = modal.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        filtrarLista();
                    }
                }
            }
            else
            {
                MessageBox.Show("No tiene permiso para realizar esta acción", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if(dgvSalidas.Rows.Count > 0)
            {
                if(dgvSalidas.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar una salida de inventario realizada de la lista para ver los detalles", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int salidaID = Convert.ToInt32(dgvSalidas.Rows[dgvSalidas.CurrentRow.Index].Cells["dgvcID"].Value);
                SalidaInventario salida = lSalidaInventario.ObtenerSalidaPorID(salidaID);
                using(var modal = new mdDetalleSalidaInventario(salida))
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
            uiUtilidades.ExportarDataGridViewAExcel(dgvSalidas, "Salidas de Inventario", "Informe de salidas de inventario");
        }

        private void filtrarLista()
        {
            this.salidaInventarioTableAdapter.Fill(this.negocio.SalidaInventario, dtpInicio.Value, dtpFin.Value, cmbFiltroEstado.Text);
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

        private void dgvSalidas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSalidas.Rows.Count > 0)
            {
                if (dgvSalidas.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar una salida de inventario realizada de la lista para ver los detalles", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int salidaID = Convert.ToInt32(dgvSalidas.Rows[dgvSalidas.CurrentRow.Index].Cells["dgvcID"].Value);
                SalidaInventario salida = lSalidaInventario.ObtenerSalidaPorID(salidaID);
                using (var modal = new mdDetalleSalidaInventario(salida))
                {
                    var resultado = modal.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        filtrarLista();
                    }
                }
            }
        }
    }
}
