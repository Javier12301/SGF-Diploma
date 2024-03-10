using SGF.NEGOCIO.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.formModales.Buscadores
{
    public partial class mdBuscarCliente : Form
    {
        ClienteBLL lCliente = ClienteBLL.ObtenerInstancia;
        public Cliente clienteSeleccionado { get; set; }
        public mdBuscarCliente()
        {
            InitializeComponent();
            clienteSeleccionado = new Cliente();
        }

        private void mdBuscarCliente_Load(object sender, EventArgs e)
        {
            cargarFiltros();
            cargarLista();
        }

        private void cargarLista()
        {
            this.clientesTablaTableAdapter.Filtrar(this.negocio.ClientesTabla, cmbFiltroBuscar.Text, txtBuscar.Text, "Todos", "Activo", cmbFiltroTipoCliente.Text);
        }

        // cargar filtros
        private void cargarFiltros()
        {
            List<Cliente> listaClientes = lCliente.ListarClientes();
            cmbFiltroBuscar.Items.Add("Todos");
            cmbFiltroBuscar.Items.Add("Nombre");
            cmbFiltroBuscar.Items.Add("Documento");
            cmbFiltroBuscar.Items.Add("Correo");
            cmbFiltroBuscar.Items.Add("Telefono");
            cmbFiltroBuscar.SelectedIndex = 0;

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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            int filaIndex = dgvClientes.CurrentCell.RowIndex;
            if(filaIndex >= 0)
            {
                seleccionarCliente(filaIndex);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente de la lista", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void seleccionarCliente(int filaIndex)
        {
            if(filaIndex >= 0)
            {
                int clienteID = Convert.ToInt32(dgvClientes.Rows[filaIndex].Cells["dgvcID"].Value);
                clienteSeleccionado = lCliente.ObtenerClientePorID(clienteID);
                if(clienteSeleccionado != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el cliente seleccionado, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbFiltroTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
