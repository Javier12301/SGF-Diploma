﻿using SGF.MODELO.Seguridad;
using SGF.NEGOCIO;
using SGF.NEGOCIO.Seguridad;
using SGF.PRESENTACION.UtilidadesComunes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ClosedXML.Excel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.formModales.Seguridad.formHijosPerfiles
{
    public partial class formUsuarios : Form
    {
        private GrupoBLL lGrupo = GrupoBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private UsuarioBLL lUsuario = UsuarioBLL.ObtenerInstancia;
        private AuditoriaBLL lAuditoria = AuditoriaBLL.ObtenerInstancia;
        public formUsuarios()
        {
            InitializeComponent();
        }

        private void formUsuarios_Load(object sender, EventArgs e)
        {
            cargarLista();
            cargarFiltros();
        }

        // Alta de Usuario

        private void btnNuevoP_Click(object sender, EventArgs e)
        {
            using (var modal = new mdUsuario())
            {
                var resultado = modal.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    cargarLista();
                }
            }
        }

        // Modificación de Usuario
        private void btnModificarP_Click(object sender, EventArgs e)
        {
            abrirModalModificar();
        }


        private void dgvUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            abrirModalModificar();
        }

        private void abrirModalModificar()
        {
            try
            {
                if (dgvUsuario.CurrentCell != null)
                {
                    int filaIndex = dgvUsuario.CurrentCell.RowIndex;
                    int usuarioID = Convert.ToInt32(dgvUsuario.Rows[filaIndex].Cells["dgvcID"].Value);
                    if (usuarioID > 0)
                    {
                        using (var modal = new mdUsuario(true, usuarioID))
                        {
                            var resultado = modal.ShowDialog();
                            if (resultado == DialogResult.OK)
                            {
                                cargarLista();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario para modificar.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Baja de Usuario
        private void btnEliminarP_Click(object sender, EventArgs e)
        {
            bajaUsuario();
        }

        private void dgvUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                bajaUsuario();
            }
        }

        private void bajaUsuario()
        {
            try
            {
                // Verificar si hay celdas seleccionadas
                if (dgvUsuario.SelectedCells.Count == 0)
                    return;

                List<int> usuariosAEliminar = new List<int>();

                DialogResult resultado = MessageBox.Show("¿Estás seguro que desea eliminar el/los usuario seleccionados?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado != DialogResult.Yes)
                    return;

                // Limpiar lista de usuarios.
                usuariosAEliminar.Clear();

                // Recorrer las celdas seleccionadas
                foreach (DataGridViewCell celda in dgvUsuario.SelectedCells)
                {
                    // Obtener el ID del usuario
                    int usuarioID = Convert.ToInt32(dgvUsuario.Rows[celda.RowIndex].Cells["dgvcID"].Value);

                    // Verificar si el usuario es el mismo que el logueado o si es el administrador
                    if (usuarioID == Sesion.ObtenerInstancia.Usuario.UsuarioID)
                    {
                        MessageBox.Show("No puede eliminar su propio usuario.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (usuarioID == 1)
                    {
                        MessageBox.Show("No puede eliminar el usuario Admin.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Agregar el ID del usuario a la lista de usuarios a eliminar
                    usuariosAEliminar.Add(usuarioID);
                }
                // Eliminar los usuarios después de recorrer todas las celdas
                int usuariosEliminados = 0;

                foreach (int usuarioID in usuariosAEliminar)
                {
                    if (lUsuario.BajaUsuario(usuarioID))
                        usuariosEliminados++;
                    else
                        MessageBox.Show($"No se pudo eliminar el usuario con ID: {usuarioID}", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Mostrar mensaje de éxito
                if (usuariosEliminados > 0)
                {
                    MessageBox.Show(usuariosEliminados > 1 ? "Usuarios eliminados correctamente." : "Usuario eliminado correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarLista();
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
                uiUtilidades.ExportarDataGridViewAExcel(dgvUsuario, "Lista de Usuarios", "Informe de Usuarios");
                AuditoriaBLL.RegistrarMovimiento("Exportar", SesionBLL.ObtenerInstancia.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), "Se exporto con exito la lista de usuarios.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AuditoriaBLL.RegistrarMovimiento("Exportar", SesionBLL.ObtenerInstancia.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), "Ocurrió un error al exportar la lista de usuarios.");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea limpiar el campo de búsqueda?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                limpiarBusqueda();
            }
        }

        // Manejo de Filtros
        private void cmbChanged_Index(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void cargarLista()
        {
            if (txtBuscar.Text != string.Empty || cmbFiltroGrupo.SelectedIndex > 0 || cmbFiltroEstado.SelectedIndex > 0)
            {
                filtrarLista();
            }
            else
            {
                this.usuarioTableAdapter.Fill(farmaciaDatosDataSet.Usuario);
            }
        }

        private void filtrarLista()
        {
            if (cmbFiltroGrupo.SelectedIndex == 0 && cmbFiltroEstado.SelectedIndex == 0 && cmbFiltroBuscar.SelectedIndex == 0 && string.IsNullOrEmpty(txtBuscar.Text))
            {
                this.usuarioTableAdapter.Fill(farmaciaDatosDataSet.Usuario);
            }
            else
            {
                this.usuarioTableAdapter.Filtrar(this.farmaciaDatosDataSet.Usuario, cmbFiltroBuscar.Text, txtBuscar.Text, cmbFiltroGrupo.Text, cmbFiltroEstado.Text);
            }
        }

        // Manejo de Interfaz


        private void limpiarBusqueda()
        {
            txtBuscar.Text = string.Empty;
        }

        private void cargarFiltros()
        {
            // Filtro de buscar por
            cmbFiltroBuscar.Items.Add("Todos");
            cmbFiltroBuscar.Items.Add("Usuario");
            cmbFiltroBuscar.Items.Add("Nombre");
            cmbFiltroBuscar.Items.Add("Apellido");
            cmbFiltroBuscar.Items.Add("Email");
            cmbFiltroBuscar.Items.Add("DNI");
            cmbFiltroBuscar.SelectedIndex = 0;

            // Filtro de Grupos
            List<Grupo> listaGrupos = lGrupo.ListarGrupos();
            cmbFiltroGrupo.Items.Add("Todos");
            foreach (var grupo in listaGrupos)
            {
                cmbFiltroGrupo.Items.Add(grupo.Nombre);
            }
            cmbFiltroGrupo.SelectedIndex = 0;


            // Filtro de estados
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
                if (dgvUsuario.Rows[e.RowIndex].Cells["dgvcEstado"].Value.ToString() == "True")
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
