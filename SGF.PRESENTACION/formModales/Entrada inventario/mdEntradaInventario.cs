using SGF.MODELO.Negocio;
using SGF.MODELO.Seguridad;
using SGF.NEGOCIO.Negocio;
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

namespace SGF.PRESENTACION.formModales
{
    public partial class mdEntradaInventario : Form
    {
        // Controladora
        private CompraBLL lCompra = CompraBLL.ObtenerInstancia;
        private NegocioBLL lNegocio = NegocioBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;

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
                cargarNegocio();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarNegocio()
        {
            NegocioModelo negocio = lNegocio.NegocioEnSesion().DatosDelNegocio;
            if (negocio.Logo != null)
            {
                // cambiar icono del formulario
                this.Icon = uiUtilidades.ByteArrayToIcon(negocio.Logo);
            }
            else
            {
                this.Icon = uiUtilidades.ImageToIcon(uiUtilidades.LogoPorDefecto());
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
            // verificar si hay tablas en el datagridview 
            if (dgvCompras.Rows.Count > 0)
            {
                // verificar si hay una fila seleccionada
                if (dgvCompras.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar una compra realizada de la lista para ver los detalles.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // obtener el id de la compra seleccionada
                int compraID = Convert.ToInt32(dgvCompras.Rows[dgvCompras.CurrentRow.Index].Cells["dgvcID"].Value);
                Compra compra = lCompra.ObtenerCompraPorID(compraID);
                using (var modal = new mdDetalleCompraEntrada(compra))
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
                MessageBox.Show("No hay datos por mostrar.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Exportar a Excel
        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void filtrarLista()
        {
            this.compraTableAdapter.Fill(this.negocio.Compra, txtBusqueda.Text);
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
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
