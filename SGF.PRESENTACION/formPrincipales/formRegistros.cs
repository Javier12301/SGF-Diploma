using SGF.MODELO;
using SGF.MODELO.Negocio;
using SGF.MODELO.Seguridad;
using SGF.NEGOCIO;
using SGF.NEGOCIO.Negocio;
using SGF.NEGOCIO.Seguridad;
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
    public partial class formRegistros : Form
    {
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private UsuarioBLL lUsuario = UsuarioBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;

        private Permiso permisoDeUsuario;

        int cantidadAntes { get; set; }
        int cantidadDespues { get; set; }

        public formRegistros()
        {
            InitializeComponent();
        }

        private void formRegistros_Load(object sender, EventArgs e)
        {
            cargarPermisos();
            if (permisoDeUsuario.GenerarRegistro)
            {
                cargarFiltros();
                cargarLista();
            }
            else
            {
                MessageBox.Show("No tiene permiso para revisar los registros del sistema", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            tsmiID.Checked = false;
            chkFecha.Checked = false;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (permisoDeUsuario.Exportar)
                {
                    uiUtilidades.ExportarDataGridViewAExcel(dgvRegistros, "Registro de sistema", "Acciones realizadas en el sistema");
                }
                else
                {
                    MessageBox.Show("No tiene permiso para realizar esta acción", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bajaRegistro();
        }

        private void dgvRegistro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                bajaRegistro();
            }
        }

        private void bajaRegistro()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (permisoDeUsuario.Baja)
                {
                    if(dgvRegistros.SelectedCells.Count == 0)
                    {
                        MessageBox.Show("Seleccione uno de los registros de la lista antes de intentar de dar de baja", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    List<int> registrosAEliminar = new List<int>();
                    DialogResult resultado = MessageBox.Show("¿Estás seguro que desea dar de baja los registros seleccionados?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado != DialogResult.Yes)
                        return;

                    registrosAEliminar.Clear();

                    foreach(DataGridViewCell celda in dgvRegistros.SelectedCells)
                    {
                        int registroID = Convert.ToInt32(dgvRegistros.Rows[celda.RowIndex].Cells["dgvcID"].Value);
                        if(registroID > 0)
                        {
                            registrosAEliminar.Add(registroID);
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un registro válido de la lista para dar de baja", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                    }

                    cantidadAntes = RegistroBLL.ConteoRegistros();
                    int registrosEliminados = 0;

                    foreach(int registroID in registrosAEliminar)
                    {
                        if (RegistroBLL.BajaRegistro(registroID))
                            registrosEliminados++;
                        else
                            MessageBox.Show($"Ocurrió un error al intentar eliminar el registro con ID: {registroID}, contacte con el administrador del sistema para solucionar este error.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if(registrosEliminados > 0)
                    {
                        cantidadDespues = RegistroBLL.ConteoRegistros();
                        AuditoriaBLL.RegistrarMovimiento("Baja", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), $"Se eliminaron {registrosEliminados} registros del sistema.");
                        MessageBox.Show(registrosEliminados > 1 ? $"Se eliminaron {registrosEliminados} registros del sistema con éxito." : "Se eliminó un registro del sistema con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarLista();
                    }         
                }
                else
                {
                    MessageBox.Show("No tiene permiso para realizar esta acción", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void cargarPermisos()
        {
            permisoDeUsuario = new Permiso();
            uiUtilidades.cargarPermisos(this.GetType().Name, flpContenedorBotones, permisoDeUsuario);
        }

        private void cargarLista()
        {
            if (txtBuscar.Text != string.Empty || cmbFiltroBuscar.SelectedIndex > 0 || cmbFiltroMovimiento.SelectedIndex > 0 || cmbFiltroUsuario.SelectedIndex > 0)
            {
                filtrarLista();
            }
            else
            {
                this.registroTableAdapter.Fill(this.negocio.Registro);
            }
        }

        private void filtrarLista()
        {
            if (cmbFiltroBuscar.SelectedIndex == 0 && cmbFiltroMovimiento.SelectedIndex == 0 && cmbFiltroUsuario.SelectedIndex == 0 && string.IsNullOrEmpty(txtBuscar.Text))
            {
                this.registroTableAdapter.Fill(this.negocio.Registro);
            }
            else
            {
                aplicarFiltro();
            }
        }

        private void aplicarFiltro()
        {
            if (flpFecha.Enabled)
            {
                this.registroTableAdapter.Filtrar(this.negocio.Registro, cmbFiltroBuscar.Text, txtBuscar.Text, cmbFiltroMovimiento.Text, cmbFiltroUsuario.Text, dtpInicio.Value, dtpFin.Value);
            }
            else
            {
                this.registroTableAdapter.Filtrar(this.negocio.Registro, cmbFiltroBuscar.Text, txtBuscar.Text, cmbFiltroMovimiento.Text, cmbFiltroUsuario.Text, null, null);
            }
        }

        private void cargarFiltros()
        {
            cmbFiltroBuscar.Items.Add("Todo");
            cmbFiltroBuscar.Items.Add("Módulo");
            cmbFiltroBuscar.Items.Add("Descripción");
            cmbFiltroBuscar.SelectedIndex = 0;

            dtpInicio.Value = DateTime.Now.AddYears(-5);
            dtpFin.Value = DateTime.Now.AddYears(5);

            cmbFiltroMovimiento.Items.Add("Todos");
            List<Registro> listaRegistros = RegistroBLL.ListarRegistros();
            foreach (Registro registro in listaRegistros)
            {
                if (!cmbFiltroMovimiento.Items.Contains(registro.Movimiento))
                {
                    cmbFiltroMovimiento.Items.Add(registro.Movimiento);
                }
            }
            cmbFiltroMovimiento.SelectedIndex = 0;

            cmbFiltroUsuario.Items.Add("Todos");
            List<Usuario> listaUsuarios = lUsuario.ListarUsuario();
            foreach (Usuario usuario in listaUsuarios)
            {
                if (!cmbFiltroUsuario.Items.Contains(usuario.NombreUsuario))
                {
                    cmbFiltroUsuario.Items.Add(usuario.NombreUsuario);
                }
            }
            cmbFiltroUsuario.SelectedIndex = 0;
        }

        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            flpFecha.Enabled = chkFecha.Checked;
            aplicarFiltro();
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            aplicarFiltro();
        }

        private void tsmiButtons_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            item.Checked = !item.Checked;
        }

        private void tsmiMenu_CheckChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            foreach (ToolStripMenuItem subItem in item.DropDownItems)
            {
                subItem.Checked = item.Checked;
            }
        }

        private void tsmi_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem subMenu = (ToolStripMenuItem)sender;
            switch (subMenu.Name)
            {
                case "tsmiID":
                    dgvRegistros.Columns["dgvcID"].Visible = subMenu.Checked;
                    break;
                case "tsmiNombreUsuario":
                    dgvRegistros.Columns["dgvcNombreUsuario"].Visible = subMenu.Checked;
                    break;
                case "tsmiFechayHora":
                    dgvRegistros.Columns["dgvcFechayHora"].Visible = subMenu.Checked;
                    break;
                case "tsmiMovimiento":
                    dgvRegistros.Columns["dgvcMovimiento"].Visible = subMenu.Checked;
                    break;
                case "tsmiModulo":
                    dgvRegistros.Columns["dgvcModulo"].Visible = subMenu.Checked;
                    break;
                case "tsmiDescripcion":
                    dgvRegistros.Columns["dgvcDescripcion"].Visible = subMenu.Checked;
                    break;
                case "tsmiCantidad":
                    dgvRegistros.Columns["dgvcCantidad"].Visible = subMenu.Checked;
                    break;
                case "tsmiCantidadAntes":
                    dgvRegistros.Columns["dgvcCantidadAntes"].Visible = subMenu.Checked;
                    break;
                case "tsmiCantidadDespues":
                    dgvRegistros.Columns["dgvcCantidadDespues"].Visible = subMenu.Checked;
                    break;
            }
        }

        private void tsdMostrar_DropDownOpened(object sender, EventArgs e)
        {
            tsdMostrar.ForeColor = Color.Black;
            tsdMostrar.Image = Properties.Resources.checkList_Negro;
        }

        private void tsdMostrar_DropDownClosed(object sender, EventArgs e)
        {
            tsdMostrar.ForeColor = Color.White;
            // cargar de recursos la imagen checlist blanca
            tsdMostrar.Image = Properties.Resources.checkList_Blanco;
        }

        private void cmbFiltroBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            filtrarLista();
        }


    }
}
