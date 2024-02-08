using SGF.MODELO.Negocio;
using SGF.NEGOCIO.Negocio;
using SGF.NEGOCIO.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.formModales.modalesBuscadores
{
    public partial class mdBuscarMoneda : Form
    {
        // Controladoras
        private NegocioBLL lNegocio = NegocioBLL.ObtenerInstancia;
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;


        public Moneda monedaSeleccionada { get; set; }
        private int cantidadAntes { get; set; }
        private int cantidadDespues { get; set; }

        public mdBuscarMoneda()
        {
            InitializeComponent();
            monedaSeleccionada = new Moneda();
        }

        private void mdBuscarMoneda_Load(object sender, EventArgs e)
        {
            cmbFiltroBuscar.Items.Add("Nombre");
            cmbFiltroBuscar.SelectedIndex = 0;
            filtraLista();
        }

        private void filtraLista()
        {
            if (txtBuscar.Text != string.Empty)
            {
                this.monedaTableAdapter.Filtrar(this.negocio.Moneda, txtBuscar.Text);
            }
            else
            {
                this.monedaTableAdapter.Fill(this.negocio.Moneda);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtraLista();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            filtraLista();
        }

        private void dgvMonedas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                string nombreColumna = dgvMonedas.Columns[e.ColumnIndex].Name;

                // Botón modificar
                if (nombreColumna == "btnModificar")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    var w = Properties.Resources.modificar_boton_15.Width;
                    var h = Properties.Resources.modificar_boton_15.Height;
                    var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                    e.Graphics.DrawImage(Properties.Resources.modificar_boton_15, new Rectangle(x, y, w, h));
                    e.Handled = true;
                }

                // Botón eliminar
                if (nombreColumna == "btnEliminar")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    var w = Properties.Resources.eliminar_boton_15.Width;
                    var h = Properties.Resources.eliminar_boton_15.Height;
                    var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                    e.Graphics.DrawImage(Properties.Resources.eliminar_boton_15, new Rectangle(x, y, w, h));
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvMonedas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMonedas.Columns[e.ColumnIndex].Name == "btnModificar")
                {
                    int indice = e.RowIndex;
                    if (indice >= 0)
                    {
                        int monedaID = Convert.ToInt32(dgvMonedas.Rows[indice].Cells["dgvcID"].Value);
                        Moneda oMoneda = lNegocio.ObtenerMonedaPorID(monedaID);
                        if (oMoneda != null)
                        {
                            using (var modal = new mdMoneda(oMoneda))
                            {
                                var resultado = modal.ShowDialog();
                                if (resultado == DialogResult.OK)
                                {
                                    filtraLista();
                                }
                            }
                        }
                    }
                }

                if (dgvMonedas.Columns[e.ColumnIndex].Name == "btnEliminar")
                {
                    int indice = e.RowIndex;
                    if (indice >= 0)
                    {
                        string nombreMoneda = dgvMonedas.Rows[indice].Cells["dgvcNombreMoneda"].Value.ToString();
                        int monedaID = Convert.ToInt32(dgvMonedas.Rows[indice].Cells["dgvcID"].Value);
                        DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar la moneda " + nombreMoneda + "?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (respuesta == DialogResult.Yes)
                        {
                            if (lNegocio.MonedaEnUso(monedaID))
                            {
                                MessageBox.Show("No se puede eliminar la moneda " + nombreMoneda + " porque está en uso.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            cantidadAntes = lNegocio.ConteoMonedas();
                            bool resultado = lNegocio.EliminarMoneda(monedaID);
                            if (resultado)
                            {
                                cantidadDespues = lNegocio.ConteoMonedas();
                                RegistroBLL.RegistrarMovimiento("Baja", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), 1, cantidadAntes, cantidadDespues, "Monedas", $"Se dio de baja con éxito la moneda: {nombreMoneda}");
                                MessageBox.Show("Moneda eliminada correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                filtraLista();
                            }
                            else
                            {
                                MessageBox.Show("Error al eliminar la moneda. Por favor, vuelva a intentarlo y si el problema persiste, pónganse en contacto con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea cancelar la operación?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            int filaIndex = dgvMonedas.CurrentCell.RowIndex;
            if (filaIndex >= 0)
            {
                seleccionarMoneda(filaIndex);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una moneda de la lista.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvMonedas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                seleccionarMoneda(e.RowIndex);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una moneda de la lista.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void seleccionarMoneda(int filaIndex)
        {
            if (filaIndex >= 0)
            {
                int productoID = Convert.ToInt32(dgvMonedas.Rows[filaIndex].Cells["dgvcID"].Value);
                monedaSeleccionada = lNegocio.ObtenerMonedaPorID(productoID);
                if (monedaSeleccionada != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener la moneda seleccionada. Por favor, vuelva a intentarlo y si el problema persiste, pónganse en contacto con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


    }
}
