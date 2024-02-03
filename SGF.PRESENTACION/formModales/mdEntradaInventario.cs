using SGF.MODELO.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.formModales
{
    public partial class mdEntradaInventario : Form
    {
        Permiso permisoDeUsuario;
        public mdEntradaInventario(Permiso permisos)
        {
            InitializeComponent();
            permisoDeUsuario = permisos;
        }

        private void mdEntradaInventario_Load(object sender, EventArgs e)
        {
            btnNuevo.Enabled = false;
            btnNuevo.Visible = false;
            btnDetalles.Enabled = false;
            btnDetalles.Visible = false;
            btnExportar.Enabled = false;
            btnDetalles.Visible = false;
            try
            {
                if (permisoDeUsuario.EntradaMasiva)
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

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        // Alta de entrada de inventario
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (permisoDeUsuario.EntradaMasiva)
            {
                using (var modal = new mdRegistrarCompra())
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

        // Ver detalles
        private void btnDetalles_Click(object sender, EventArgs e)
        {

        }

        // Exportar a Excel
        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void filtrarLista()
        {
            if(txtBusqueda.Text != string.Empty)
            {
                this.detalle_CompraTableAdapter.Filtrar(this.negocio.Detalle_Compra, txtBusqueda.Text);
            }
            else
            {
                this.detalle_CompraTableAdapter.Fill(this.negocio.Detalle_Compra);
            }
        }

        // Filtrar lista
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea cancelar la operación?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(respuesta == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
