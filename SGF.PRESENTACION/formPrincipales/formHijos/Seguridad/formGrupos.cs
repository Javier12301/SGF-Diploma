using SGF.NEGOCIO.Seguridad;
using SGF.NEGOCIO;
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
using SGF.MODELO;
using SGF.PRESENTACION.formPrincipales;
using SGF.MODELO.Seguridad;

namespace SGF.PRESENTACION.formModales.Seguridad.formHijosPerfiles
{
    public partial class formGrupos : Form
    {
        private GrupoBLL lGrupo = GrupoBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private UsuarioBLL lUsuario = UsuarioBLL.ObtenerInstancia;
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private Permiso permisoDeUsuario;

        public formGrupos()
        {
            InitializeComponent();
        }

        private void formGrupos_Load(object sender, EventArgs e)
        {
            try
            {
                cargarLista();
                cargarFiltros();
                cargarPermisos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " , si el error persiste contacte al administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarPermisos()
        {
            permisoDeUsuario = new Permiso();
            uiUtilidades.cargarPermisos(this.GetType().Name, flpContenedorBotones, permisoDeUsuario);
        }

        // Alta de Grupo
        private void btnNuevoP_Click(object sender, EventArgs e)
        {
            if (permisoDeUsuario.Alta)
            {
                using (var modal = new mdGrupo())
                {
                    var resultado = modal.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        cargarLista();
                    }
                }
            }
            else
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Modificación de Grupo
        private void btnModificarP_Click(object sender, EventArgs e)
        {
            abrirModalModificar();
        }

        private void dgvGrupos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                abrirModalModificar();
            }
        }

        private void abrirModalModificar()
        {
            try
            {
                if (permisoDeUsuario.Modificar)
                {
                    if (dgvGrupos.CurrentCell != null)
                    {
                        int filaIndex = dgvGrupos.CurrentCell.RowIndex;
                        int grupoID = Convert.ToInt32(dgvGrupos.Rows[filaIndex].Cells["dgvcID"].Value);
                        if (grupoID > 0)
                        {
                            if (grupoID == lSesion.UsuarioEnSesion().Usuario.ObtenerGrupoID() && grupoID != 1)
                            {
                                MessageBox.Show("No puede modificar el grupo al que pertenece.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // El unico que puede modificar el grupo Administradores es el usuario Admin
                            if (grupoID == 1 && lSesion.UsuarioEnSesion().Usuario.ObtenerUsuarioID() != 1)
                            {
                                MessageBox.Show("No puede modificar el grupo de Administradores", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            using (var modal = new mdGrupo(true, grupoID))
                            {
                                var resultado = modal.ShowDialog();
                                if (resultado == DialogResult.OK)
                                {
                                    if (grupoID == 1)
                                    {
                                        AuditoriaBLL.RegistrarMovimiento("Modificación", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), "El usuario Admin modifico el grupo Administradores.");
                                        MessageBox.Show("Se cerrará la sesión para aplicar los cambios.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        // Obtenemos la instancia del formulario principal que es el padre de todos y luego cerramos la sesión
                                        // haciendo uso de su función encargada de cerrar la sesión.
                                        formMain formMain = (formMain)Application.OpenForms["formMain"];
                                        formMain.Cerrar_Sesion();
                                    }
                                    else
                                    {
                                        cargarLista();

                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un grupo para modificar.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No tiene permisos para realizar esta acción.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Baja de Grupo
        private void btnEliminarP_Click(object sender, EventArgs e)
        {
            bajaGrupo();
        }


        private void dgvGrupos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                bajaGrupo();
            }
        }

        private void bajaGrupo()
        {
            try
            {
                if (permisoDeUsuario.Baja)
                {
                    // Verificar si hay celdas seleccionadas
                    if (dgvGrupos.SelectedCells.Count == 0)
                    {
                        MessageBox.Show("Seleccione por lo menos un grupo para eliminar.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    List<Operacion> gruposAEliminar = new List<Operacion>();

                    DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar los grupos seleccionados?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado != DialogResult.Yes)
                        return;

                    gruposAEliminar.Clear();

                    // Recorrer celdas seleccionadas
                    foreach (DataGridViewCell celda in dgvGrupos.SelectedCells)
                    {
                        int grupoID = Convert.ToInt32(dgvGrupos.Rows[celda.RowIndex].Cells["dgvcID"].Value);
                        string nombreGrupo = dgvGrupos.Rows[celda.RowIndex].Cells["dgvcNombre"].Value.ToString();
                        string operacion = string.Empty;
                        // Comprobar si no se está por eliminar el grupo al que pertenece el usuario en sesión
                        if (grupoID == lSesion.UsuarioEnSesion().Usuario.ObtenerGrupoID())
                        {
                            MessageBox.Show("No puede eliminar el grupo al que pertenece.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else if (grupoID == 1)
                        {
                            MessageBox.Show("No puede eliminar al grupo Admin.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Comprobar si el grupo tiene usuarios asignados
                        if (lGrupo.GrupoTieneUsuarios(grupoID))
                        {
                            DialogResult respuesta = MessageBox.Show($"El grupo seleccionado: ( {dgvGrupos.Rows[celda.RowIndex].Cells["dgvcNombre"].Value} ) tiene usuarios asignados, ¿desea asignar a los usuarios de este grupo como sin grupo?", "Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            if (DialogResult.Yes == respuesta)
                            {
                                operacion = "AsignarUsuariosSinGrupo";
                            }
                            else if (DialogResult.No == respuesta)
                            {
                                respuesta = MessageBox.Show($"¿Desea eliminar el grupo: ( {dgvGrupos.Rows[celda.RowIndex].Cells["dgvcNombre"].Value} ) y los usuarios asignados a este?", "Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                                if (DialogResult.Yes == respuesta)
                                {
                                    operacion = "EliminarGrupoYUsuarios";
                                }
                                else
                                {
                                    MessageBox.Show($"Operación cancelada para el grupo: ( {dgvGrupos.Rows[celda.RowIndex].Cells["dgvcNombre"].Value} )", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    continue;
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Operación cancelada para el grupo: ( {dgvGrupos.Rows[celda.RowIndex].Cells["dgvcNombre"].Value} )", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                continue;
                            }
                        }
                        else
                        {
                            operacion = "EliminarGrupo";
                        }
                        gruposAEliminar.Add(new Operacion { ID = grupoID, Nombre = nombreGrupo, NombreOperacion = operacion });
                    }
                    int gruposEliminados = 0;

                    foreach (var grupo in gruposAEliminar)
                    {
                        if (lGrupo.BajaGrupo(grupo))
                            gruposEliminados++;
                        else
                        {
                            MessageBox.Show($"No se pudo eliminar el grupo con ID: ( {grupo.ID} )", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                    }

                    if (gruposEliminados > 0)
                    {
                        MessageBox.Show(gruposEliminados > 1 ? "Grupos eliminados con éxito." : "Grupo eliminado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarLista();
                    }
                }
                else
                {
                    MessageBox.Show("No tiene permisos para realizar esta acción.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Exportar a Excel
        private void btnExportarP_Click(object sender, EventArgs e)
        {
            try
            {
                if (permisoDeUsuario.Exportar)
                {
                    uiUtilidades.ExportarDataGridViewAExcel(dgvGrupos, "Lista de Grupos", "Informe de Grupos");
                    AuditoriaBLL.RegistrarMovimiento("Exportar", SesionBLL.ObtenerInstancia.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), "Se exporto con éxito la lista de grupos.");
                }
                else
                {
                    MessageBox.Show("No tiene permisos para realizar esta acción.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AuditoriaBLL.RegistrarMovimiento("Exportar", SesionBLL.ObtenerInstancia.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), "Ocurrió un error al exportar la lista de grupos.");
            }
        }

        // Manejo de Filtros
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea limpiar el campo de búsqueda?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                LimpiarBusqueda();
            }
        }

        private void LimpiarBusqueda()
        {
            txtBuscar.Text = string.Empty;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void cmbFiltroBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void cargarLista()
        {
            if (txtBuscar.Text != string.Empty || cmbFiltroEstado.SelectedIndex > 0)
            {
                filtrarLista();
            }
            else
            {
                this.grupoTableAdapter.Fill(this.farmaciaDatosDataSet.Grupo);
            }
        }

        private void filtrarLista()
        {
            if (cmbFiltroEstado.SelectedIndex == 0 && txtBuscar.Text == string.Empty)
            {
                this.grupoTableAdapter.Fill(this.farmaciaDatosDataSet.Grupo);
            }
            else
            {
                this.grupoTableAdapter.Filtrar(farmaciaDatosDataSet.Grupo, cmbFiltroBuscar.Text, txtBuscar.Text, cmbFiltroEstado.Text);
            }
        }

        private void cargarFiltros()
        {
            cmbFiltroBuscar.Items.Add("Nombre");
            cmbFiltroBuscar.SelectedIndex = 0;

            cmbFiltroEstado.Items.Add("Todos");
            cmbFiltroEstado.Items.Add("Activo");
            cmbFiltroEstado.Items.Add("Inactivo");
            cmbFiltroEstado.SelectedIndex = 0;
        }

        private void dgvGrupos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvGrupos.Rows[e.RowIndex].Cells["dgvcEstado"].Value.ToString() == "True")
                {
                    lblEstado.Text = "Activo";
                    lblEstado.ForeColor = Color.Blue;
                }
                else
                {
                    lblEstado.Text = "Inactivo";
                    lblEstado.ForeColor = Color.Red;
                }
            }
        }


    }
}
