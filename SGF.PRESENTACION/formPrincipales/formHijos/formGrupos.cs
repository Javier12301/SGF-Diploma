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

namespace SGF.PRESENTACION.formModales.Seguridad.formHijosPerfiles
{
    public partial class formGrupos : Form
    {
        private GrupoBLL lGrupo = GrupoBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private UsuarioBLL lUsuario = UsuarioBLL.ObtenerInstancia;
        public formGrupos()
        {
            InitializeComponent();
        }

        private void formGrupos_Load(object sender, EventArgs e)
        {
            cargarLista();
            cargarFiltros();
        }

        // Alta de Grupo
        private void btnNuevoP_Click(object sender, EventArgs e)
        {
            using(var modal = new mdGrupo())
            {
                var resultado = modal.ShowDialog();
                if(resultado == DialogResult.OK)
                {
                    cargarLista();
                }
            }
        }
        // Modificación de Grupo
        private void btnModificarP_Click(object sender, EventArgs e)
        {

        }
        // Baja de Grupo
        private void btnEliminarP_Click(object sender, EventArgs e)
        {

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
            if(txtBuscar.Text != string.Empty || cmbFiltroEstado.SelectedIndex > 0)
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
            if(cmbFiltroEstado.SelectedIndex == 0 && txtBuscar.Text == string.Empty)
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
                if (dgvProductos.Rows[e.RowIndex].Cells["dgvcEstado"].Value.ToString() == "True")
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
