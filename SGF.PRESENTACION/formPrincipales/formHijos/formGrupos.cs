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

namespace SGF.PRESENTACION.formModales.Seguridad.formHijosPerfiles
{
    public partial class formGrupos : Form
    {
        private GrupoBLL lGrupo = GrupoBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private UsuarioBLL lUsuario = UsuarioBLL.ObtenerInstancia;
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
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
                uiUtilidades.cargarPermisos(this.GetType().Name, flpContenedorBotones);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " , si el error persiste contacte al administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Alta de Grupo
        private void btnNuevoP_Click(object sender, EventArgs e)
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
        // Modificación de Grupo
        private void btnModificarP_Click(object sender, EventArgs e)
        {
            abrirModalModificar();
        }

        private void dgvGrupos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            abrirModalModificar();
        }

        private void abrirModalModificar()
        {
            try
            {
                if (dgvGrupos.CurrentCell != null)
                {
                    int filaIndex = dgvGrupos.CurrentCell.RowIndex;
                    int grupoID = Convert.ToInt32(dgvGrupos.Rows[filaIndex].Cells["dgvcID"].Value);
                    if (grupoID > 0)
                    {
                        if (grupoID != lSesion.UsuarioEnSesion().Usuario.ObtenerGrupoID())
                        {
                            using (var modal = new mdGrupo(true, grupoID))
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
                            MessageBox.Show("No puede modificar el grupo al que pertenece.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un grupo para modificar.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        }


        private void dgvGrupos_KeyDown(object sender, KeyEventArgs e)
        {

        }

        // FALTA TERMINAR
        private void bajaGrupo()
        {
            try
            {
                // Verificar si hay celdas seleccionadas
                if(dgvGrupos.SelectedCells.Count == 0)
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
                foreach(DataGridViewCell celda in dgvGrupos.SelectedCells)
                {
                    int grupoID = Convert.ToInt32(dgvGrupos.Rows[celda.RowIndex].Cells["dgvcID"].Value);
                    string operacion = string.Empty;
                    // Comprobar si no se está por eliminar el grupo al que pertenece el usuario en sesión
                    if(grupoID == lSesion.UsuarioEnSesion().Usuario.ObtenerGrupoID())
                    {
                        MessageBox.Show("No puede eliminar el grupo al que pertenece.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }else if(grupoID == 1)
                    {
                        MessageBox.Show("No puede eliminar al grupo Admin.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Comprobar si el grupo tiene usuarios asignados
                    if(lGrupo.GrupoTieneUsuarios(grupoID))
                    {
                        DialogResult respuesta = MessageBox.Show($"El grupo seleccionado: ( {dgvGrupos.Rows[celda.RowIndex].Cells["dgvcNombre"].Value} ) tiene usuarios asignados, ¿desea asignar a los usuarios de este grupo como sin grupo?", "Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if(DialogResult.Yes == respuesta)
                        {
                            operacion = "AsignarUsuariosSinGrupo";
                        }
                        else if(DialogResult.No == respuesta)
                        {
                            respuesta = MessageBox.Show($"¿Desea eliminar el grupo: ( {dgvGrupos.Rows[celda.RowIndex].Cells["dgvcNombre"].Value} ) y los usuarios asignados a este?", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            if(DialogResult.Yes == respuesta)
                            {
                                operacion = "EliminarGrupoYUsuarios";
                            }
                            else
                            {
                                MessageBox.Show($"Operación cancelada para el grupo: ( {dgvGrupos.Rows[celda.RowIndex].Cells["dgvcNombre"].Value} )", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Operación cancelada para el grupo: ( {dgvGrupos.Rows[celda.RowIndex].Cells["dgvcNombre"].Value} )", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        operacion = "EliminarGrupo";
                    }
                    gruposAEliminar.Add(new Operacion { ID = grupoID, NombreOperacion = operacion });
                }
                int gruposEliminados = 0;


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Exportar a Excel
        private void btnExportarP_Click(object sender, EventArgs e)
        {

        }





        // Manejo de Filtros
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtrarLista();
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

        // Manejo de Interfaz
        private void limpiarBusqueda()
        {
            txtBuscar.Text = string.Empty;
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

        private void dgvProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Comprobar si la celda es mayor a 0
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
