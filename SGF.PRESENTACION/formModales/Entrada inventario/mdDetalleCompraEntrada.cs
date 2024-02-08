using SGF.MODELO.Negocio;
using SGF.MODELO.Seguridad;
using SGF.NEGOCIO;
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;


namespace SGF.PRESENTACION.formModales
{
    public partial class mdDetalleCompraEntrada : Form
    {

        // Controladora
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private ProveedorBLL lProveedor = ProveedorBLL.ObtenerInstancia;
        private UsuarioBLL lUsuario = UsuarioBLL.ObtenerInstancia;

        private Permiso permisosDeUsuario;
        private Compra oCompra { get; set; }

        public mdDetalleCompraEntrada(Compra compra = null)
        {
            InitializeComponent();
            oCompra = compra;
            permisosDeUsuario = new Permiso();
        }

        private void mdDetalleCompraEntrada_Load(object sender, EventArgs e)
        {
            try
            {
                uiUtilidades.cargarPermisos("formDetallesInventario", flpContenedorBotones, permisosDeUsuario);
                if (oCompra != null && oCompra.CompraID > 0)
                {
                    cargarDetalledeCompras(oCompra);
                    cargarLista();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al cargar los detalles de la compra, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarLista()
        {
            if (oCompra != null)
            {
                detalle_CompraTableAdapter.Fill(this.negocio.Detalle_Compra, oCompra.CompraID);
                if (dgvDetallesCompras.Rows.Count > 0)
                {
                    decimal total = 0;
                    foreach (DataGridViewRow row in dgvDetallesCompras.Rows)
                    {
                        total += Convert.ToDecimal(row.Cells[4].Value);
                    }
                    txtTotal.Text = total.ToString("C2");
                }
            }
        }
        private void cargarDetalledeCompras(Compra compra)
        {
            txtTotal.Text = "0.00";
            if (compra != null)
            {
                compra.proveedor = lProveedor.ObtenerProveedorPorID(compra.proveedor.ProveedorID);
                compra.usuario = lUsuario.ObtenerUsuarioPorID(compra.usuario.UsuarioID);
                txtFolio.Text = compra.CompraID.ToString();
                txtFecha.Text = compra.FechaCompra.ToString("dd/MM/yyyy");
                txtProveedor.Text = compra.proveedor.RazonSocial;
                txtUsuario.Text = compra.usuario.NombreUsuario;
            }

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (permisosDeUsuario.Imprimir)
            {
                if(dgvDetallesCompras.Rows.Count > 0)
                {
                    SaveFileDialog guardar = new SaveFileDialog();
                    guardar.Filter = "Archivo PDF|*.pdf";
                    guardar.FileName = "Detalle de compra, folio " + oCompra.CompraID + ".pdf";
                    guardar.ShowDialog();

                    string paginaHTML;
                }
                else
                {
                    MessageBox.Show("No hay datos para imprimir.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("No tiene permiso para realizar esta acción, si cree que esto es un error contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (permisosDeUsuario.Cancelar)
            {

            }
            else
            {
                MessageBox.Show("No tiene permiso para realizar esta acción, si cree que esto es un error contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDetallesCompras_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new System.Drawing.Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void printDatagrid_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dgvDetallesCompras.Width, this.dgvDetallesCompras.Height);
            dgvDetallesCompras.DrawToBitmap(bm, new System.Drawing.Rectangle(0, 0, this.dgvDetallesCompras.Width, this.dgvDetallesCompras.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }
    }
}
