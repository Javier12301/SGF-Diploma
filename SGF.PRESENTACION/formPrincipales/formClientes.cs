using SGF.MODELO.Seguridad;
using SGF.NEGOCIO.Negocio;
using SGF.NEGOCIO.Seguridad;
using SGF.PRESENTACION.formModales;
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
    public partial class formClientes : Form
    {
        private Permiso permisoDeUsuario { get; set; }
        private ClienteBLL lCliente = ClienteBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;

        public formClientes()
        {
            InitializeComponent();
            permisoDeUsuario = new Permiso();
        }

        private void formClientes_Load(object sender, EventArgs e)
        {
            try
            {
                cargarFiltros();
                cargarLista();
                uiUtilidades.cargarPermisos("formClientes", flpContenedorBotones, permisoDeUsuario);
                tsmiID.Checked = false;

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarLista()
        {
            this.clientesTablaTableAdapter.Filtrar(this.negocio.ClientesTabla, cmbFiltroBuscar.Text, txtBuscar.Text, cmbFiltroTipoDocumento.Text, cmbFiltroEstado.Text, cmbFiltroTipoCliente.Text);
       
        }

        // Cargar Filtros
        private void cargarFiltros()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            listaClientes = lCliente.ListarClientes();
            // Combobox buscar por
            cmbFiltroBuscar.Items.Add("Todos");
            cmbFiltroBuscar.Items.Add("Nombre");
            cmbFiltroBuscar.Items.Add("Documento");
            cmbFiltroBuscar.Items.Add("Correo");
            cmbFiltroBuscar.Items.Add("Telefono");
            cmbFiltroBuscar.SelectedIndex = 0;

            // Combobox estado
            cmbFiltroEstado.Items.Add("Todos");
            cmbFiltroEstado.Items.Add("Activo");
            cmbFiltroEstado.Items.Add("Inactivo");
            cmbFiltroEstado.SelectedIndex = 0;

            // filtro tipo documento
            cmbFiltroTipoDocumento.Items.Add("Todos");
            foreach (var item in listaClientes)
            {
                if (!cmbFiltroTipoDocumento.Items.Contains(item.TipoDocumento))
                {
                    cmbFiltroTipoDocumento.Items.Add(item.TipoDocumento);
                }
            }
            cmbFiltroTipoDocumento.SelectedIndex = 0;

            // filtro tipo cliente
            cmbFiltroTipoCliente.Items.Add("Todos");
            foreach (var item in listaClientes)
            {
                if (!cmbFiltroTipoCliente.Items.Contains(item.TipoCliente.Descripcion))
                {
                    cmbFiltroTipoCliente.Items.Add(item.TipoCliente.Descripcion);
                }
            }
            cmbFiltroTipoCliente.SelectedIndex = 0;

        }


        private void btnNuevoP_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (permisoDeUsuario.Alta)
            {
                using(var modal = new mdClientes())
                {
                    Cursor.Current = Cursors.Default;
                    var resultado = modal.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        cargarLista();
                    }
                }
            }
        }

        private void btnModificarP_Click(object sender, EventArgs e)
        {
            abrirModalModificar();
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                abrirModalModificar();
            }
        }

        private void abrirModalModificar()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (permisoDeUsuario.Modificar)
                {
                    if(dgvClientes.CurrentCell != null)
                    {
                        int filaIndex = dgvClientes.CurrentCell.RowIndex;
                        int clienteID = int.Parse(dgvClientes.Rows[filaIndex].Cells["dgvcID"].Value.ToString());
                        if(clienteID > 0)
                        {
                            using(var modal = new mdClientes(true, clienteID))
                            {
                                var resultado = modal.ShowDialog();
                                if(resultado == DialogResult.OK)
                                {
                                    cargarLista();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se ha seleccionado un cliente válido. Por favor, seleccione un cliente de la lista e inténtelo de nuevo.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No tiene permiso para realizar esta acción.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnEliminarP_Click(object sender, EventArgs e)
        {
            bajaCliente();
        }

        private void dgvClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                bajaCliente();
            }
        }

        private void bajaCliente()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (permisoDeUsuario.Baja)
                {
                    if(dgvClientes.SelectedCells.Count == 0)
                    {
                        MessageBox.Show("No se ha seleccionado un cliente válido. Por favor, seleccione un cliente de la lista e inténtelo de nuevo.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    List<int> clientesAEliminar = new List<int>();
                    DialogResult respuesta = MessageBox.Show("¿Estás seguro que desea eliminar los clientes seleccionados?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta != DialogResult.Yes)
                        return;
                    clientesAEliminar.Clear();
                    
                    foreach(DataGridViewCell celda in dgvClientes.SelectedCells)
                    {
                        int clienteID = int.Parse(dgvClientes.Rows[celda.RowIndex].Cells["dgvcID"].Value.ToString());
                        if(clienteID > 0)
                        {
                            clientesAEliminar.Add(clienteID);
                        }
                        else
                        {
                            MessageBox.Show("No se puede eliminar el cliente consumidor final.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }
                    }

                    int clientesEliminados = 0;
                    int cantidadAntes = lCliente.ConteoClientes();
                    foreach(int clienteID in clientesAEliminar)
                    {
                        if (lCliente.BajaCliente(clienteID))
                            clientesEliminados++;                          
                        else
                            MessageBox.Show($"No se pudo eliminar el cliente con ID: {clienteID}", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if(clientesEliminados > 0)
                    {
                        int cantidadDespues = lCliente.ConteoClientes();
                        RegistroBLL.RegistrarMovimiento("Baja", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), clientesEliminados, cantidadAntes, cantidadDespues, "Clientes", $"Se eliminaron {clientesEliminados} clientes");
                        MessageBox.Show(clientesEliminados > 1 ? "Clientes eliminados con éxito." : "Cliente eliminado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarLista();
                    }
                }
                else
                {
                    MessageBox.Show("No tiene permiso para realizar esta acción.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnExportarP_Click(object sender, EventArgs e)
        {
            if (permisoDeUsuario.Exportar)
            {
                try
                {
                    uiUtilidades.ExportarDataGridViewAExcel(dgvClientes, "Lista de clientes", "Informe de clientes", "Clientes");
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No tiene permiso para realizar esta acción.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        // Manejo de interfaz
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
                    dgvClientes.Columns["dgvcID"].Visible = subMenu.Checked;
                    break;
                case "tsmiTipoDocumento":
                    dgvClientes.Columns["dgvcTipoDocumento"].Visible = subMenu.Checked;
                    break;
                case "tsmiDocumento":
                    dgvClientes.Columns["dgvcDocumento"].Visible = subMenu.Checked;
                    break;
                case "tsmiTipoCliente":
                    dgvClientes.Columns["dgvcTipoCliente"].Visible = subMenu.Checked;
                    break;
                case "tsmiNombre":
                    dgvClientes.Columns["dgvcNombre"].Visible = subMenu.Checked;
                    break;
                case "tsmiCorreo":
                    dgvClientes.Columns["dgvcCorreo"].Visible = subMenu.Checked;
                    break;
                case "tsmiTelefono":
                    dgvClientes.Columns["dgvcTelefono"].Visible = subMenu.Checked;
                    break;
                case "tsmiEstado":
                    dgvClientes.Columns["dgvcEstado"].Visible = subMenu.Checked;
                    break;
                default:
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

        private void cmbFiltroTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarLista();
        }

        private void cmbFiltroBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarLista();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cargarLista();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarLista();
        }

        private void dgvClientes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                if (dgvClientes.Rows[e.RowIndex].Cells["dgvcEstado"].Value.ToString() == "True")
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
