using SGF.MODELO.Seguridad;
using SGF.NEGOCIO.Seguridad;
using SGF.PRESENTACION.formModales.Seguridad;
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

namespace SGF.PRESENTACION.formPrincipales.formHijos
{
    public partial class formAuditoria : Form
    {
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        List<Auditoria> listaAuditoria;
        private Permiso permisoDeUsuario;

        private bool graficoActivo { get; set; }
        public formAuditoria()
        {
            InitializeComponent();
            listaAuditoria = new List<Auditoria>();
            graficoActivo = false;
        }

        private void formAuditoria_Load(object sender, EventArgs e)
        {
            uiUtilidades.cargarPermisos(this.GetType().Name, flpContenedorBotones);
            cargarLista();
            cargarFiltros();
            cargarPermisos();
            AlternarContainer();
        }

        private void dgvAuditoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (permisoDeUsuario.Detalles)
                {
                    abrirModalDetalles();
                }
                else
                {
                    MessageBox.Show("No tiene permisos para ver los detalles de la auditoría", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (permisoDeUsuario.Detalles)
            {
                abrirModalDetalles();
            }
            else
            {
                MessageBox.Show("No tiene permisos para ver los detalles de la auditoría", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void abrirModalDetalles()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (dgvAuditoria.CurrentCell != null)
                {
                    int filaIndex = dgvAuditoria.CurrentCell.RowIndex;
                    int auditoriaID = Convert.ToInt32(dgvAuditoria.Rows[filaIndex].Cells["dgvcID"].Value);
                    if (auditoriaID > 0)
                    {
                        using (var modal = new mdDetalleAuditoria(permisoDeUsuario, auditoriaID))
                        {
                            var resultado = modal.ShowDialog();
                            if (resultado == DialogResult.OK)
                            {
                                cargarLista();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void AlternarContainer()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (graficoActivo)
                {
                    tlpContainer.ColumnCount = 2;
                    chartResumenMovimientos.Visible = true;
                    filtrarGrafico();
                }
                else
                {
                    tlpContainer.ColumnCount = 1;
                    chartResumenMovimientos.Visible = false;
                }
                graficoActivo = !graficoActivo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void cargarPermisos()
        {
            permisoDeUsuario = new Permiso();
            uiUtilidades.cargarPermisos(this.GetType().Name, flpContenedorBotones, permisoDeUsuario);
        }

        // Manejo de filtros
        private void cargarLista()
        {
            if (txtBuscar.Text != string.Empty || cmbFiltroBuscar.SelectedIndex > 0 || cmbFiltroModulo.SelectedIndex > 0 || cmbFiltroMovimiento.SelectedIndex > 0 || cmbFiltroUsuario.SelectedIndex > 0)
            {
                filtrarLista();
            }
            else
            {
                this.auditoriaTableAdapter.Fill(this.farmaciaDatosDataSet.Auditoria);
            }
            filtrarGrafico();
        }

        private void filtrarLista()
        {
            if (cmbFiltroBuscar.SelectedIndex == 0 && cmbFiltroMovimiento.SelectedIndex == 0 && cmbFiltroModulo.SelectedIndex == 0 && cmbFiltroUsuario.SelectedIndex == 0 && string.IsNullOrEmpty(txtBuscar.Text))
            {
                this.auditoriaTableAdapter.Fill(this.farmaciaDatosDataSet.Auditoria);
            }
            else
            {
                this.auditoriaTableAdapter.Filtrar(farmaciaDatosDataSet.Auditoria, cmbFiltroUsuario.Text, cmbFiltroMovimiento.Text, cmbFiltroModulo.Text, cmbFiltroBuscar.Text, txtBuscar.Text, dtpInicio.Value, dtpFin.Value);
            }
            filtrarGrafico();
        }

        private DataTable obtenerMovimientos()
        {
            DataTable dt = AuditoriaBLL.ObtenerMovimientos(cmbFiltroUsuario.Text, dtpInicio.Value, dtpFin.Value);
            return dt;
        }

        private void filtrarGrafico()
        {
            // si hay 2 o más columnas es porque se activarn los gráficos
            try
            {
                if (tlpContainer.ColumnCount >= 2)
                {
                    DataTable dt = obtenerMovimientos();
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            chartResumenMovimientos.DataSource = dt;
                            chartResumenMovimientos.Series[0].XValueMember = "Movimiento";
                            chartResumenMovimientos.Series[0].YValueMembers = "Cantidad";
                            chartResumenMovimientos.DataBind();
                            // Modificar texto de chart, si es Todos se mostrará Resumen de movimientos de todos los usuarios
                            // si es un usuario en específico se mostrará Resumen de movimientos de usuario: nombreUsuario
                            Random random = new Random();

                            if (cmbFiltroUsuario.Text == "Todos")
                                chartResumenMovimientos.Titles[0].Text = "Resumen de movimientos de todos los usuarios";
                            else
                                chartResumenMovimientos.Titles[0].Text = "Resumen de movimientos de usuario: " + cmbFiltroUsuario.Text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrafico_Click(object sender, EventArgs e)
        {
            if (permisoDeUsuario.Grafico)
            {
                AlternarContainer();
            }
            else
            {
                MessageBox.Show("No tiene permisos para ver el gráfico de auditoria.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Cargar lista Auditoria
        private List<Auditoria> ObtenerListaAuditoria()
        {
            listaAuditoria = AuditoriaBLL.ObtenerListaAuditoria();
            return listaAuditoria;
        }

        private void cargarFiltros()
        {
            ObtenerListaAuditoria();
            // Filtro de buscar por
            cmbFiltroBuscar.Items.Add("Todo");
            cmbFiltroBuscar.Items.Add("Nombre Usuario");
            cmbFiltroBuscar.Items.Add("Movimiento");
            cmbFiltroBuscar.Items.Add("Descripcion");
            cmbFiltroBuscar.SelectedIndex = 0;

            // Filtro de fecha
            dtpInicio.Value = DateTime.Now.AddYears(-2);
            dtpFin.Value = DateTime.Now.AddYears(1);

            // Filtro de modulos
            cmbFiltroModulo.Items.Add("Todos");
            foreach (var lista in listaAuditoria)
            {
                if (!cmbFiltroModulo.Items.Contains(lista.Modulo))
                {
                    cmbFiltroModulo.Items.Add(lista.Modulo);
                }
            }
            cmbFiltroModulo.SelectedIndex = 0;

            // Filtro de movimiento
            cmbFiltroMovimiento.Items.Add("Todos");
            foreach (var lista in listaAuditoria)
            {
                // Comprobar que no exista el movimiento en el combobox
                if (!cmbFiltroMovimiento.Items.Contains(lista.Movimiento))
                {
                    cmbFiltroMovimiento.Items.Add(lista.Movimiento);
                }
            }
            cmbFiltroMovimiento.SelectedIndex = 0;

            // Filtro de Nombre Usuario
            cmbFiltroUsuario.Items.Add("Todos");
            foreach (var lista in listaAuditoria)
            {
                // Comprobar que no exista el movimiento en el combobox
                if (!cmbFiltroUsuario.Items.Contains(lista.NombreUsuario))
                {
                    cmbFiltroUsuario.Items.Add(lista.NombreUsuario);
                }
            }
            cmbFiltroUsuario.SelectedIndex = 0;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarLista();
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            this.auditoriaTableAdapter.Filtrar(farmaciaDatosDataSet.Auditoria, cmbFiltroUsuario.Text, cmbFiltroMovimiento.Text, cmbFiltroModulo.Text, cmbFiltroBuscar.Text, txtBuscar.Text, dtpInicio.Value, dtpFin.Value);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void dtpFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.auditoriaTableAdapter.Filtrar(farmaciaDatosDataSet.Auditoria, cmbFiltroUsuario.Text, cmbFiltroMovimiento.Text, cmbFiltroModulo.Text, cmbFiltroBuscar.Text, txtBuscar.Text, dtpInicio.Value, dtpFin.Value);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (permisoDeUsuario.Exportar)
                {
                    uiUtilidades.ExportarDataGridViewAExcel(dgvAuditoria, "Lista Auditoria", "Informe de Auditoria", "Auditoria");
                }
                else
                {
                    MessageBox.Show("No tiene permisos para exportar la lista de auditoria.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AuditoriaBLL.RegistrarMovimiento("Exportar", SesionBLL.ObtenerInstancia.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), "Auditoria", "Ocurrió un error al exportar la lista de usuarios.");
            }
        }

        private void tlpContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvAuditoria_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAuditoria.CurrentRow.Cells["Modulo"].Value.ToString() == "Productos")
            {
                btnDetalles.Enabled = true;
            }
            else
            {
                btnDetalles.Enabled = false;
            }
        }


    }
}
