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
    public partial class mdProductos : Form
    {

        // Controladoras
        private ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;
        private CategoriaBLL lCategoria = CategoriaBLL.ObtenerInstancia;
        private ProveedorBLL lProveedor = ProveedorBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;

        // Listas y Objetos
        private List<Proveedor> listaProveedores { get; set; }
        private List<Categoria> listaCategorias { get; set; }

        public mdProductos()
        {
            InitializeComponent();
            listaCategorias = lCategoria.ListarCategorias();
            listaProveedores = lProveedor.ListaProveedores();
        }

        private void mdProductos_Load(object sender, EventArgs e)
        {
            cargarCombobox();
            rbProductoGeneral.Checked = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Manejo de responsabilidades
        public bool ValidarCampos()
        {
            bool camposValidos = true;

            camposValidos &= uiUtilidades.VerificarTextbox(txtCodigo, errorProvider, lblCodigo);
            camposValidos &= uiUtilidades.VerificarTextbox(txtNombre, errorProvider, lblNombre);
            if (rbMedicamento.Checked)
                camposValidos &= uiUtilidades.VerificarTextbox(txtLote, errorProvider, lblLote);
            if (chkVencimiento.Checked)
                camposValidos &= uiUtilidades.VerificarFechaVencimiento(dtaVencimiento, errorProvider, lblVencimiento);
            camposValidos &= uiUtilidades.VerificarCombobox(cmbCategoria, errorProvider, lblCategoria);
            camposValidos &= uiUtilidades.VerificarCombobox(cmbProveedor, errorProvider, lblProveedor);
            camposValidos &= uiUtilidades.VerificarTextboxPrecio(txtCosto, errorProvider);
            camposValidos &= uiUtilidades.VerificarTextboxPrecio(txtPrecio, errorProvider);

            // Validaciones de Precio y Costo
            bool PrecioyCosto = true;
            PrecioyCosto &= uiUtilidades.VerificarFormatoMoneda(txtCosto, errorProvider);
            PrecioyCosto &= uiUtilidades.VerificarFormatoMoneda(txtPrecio, errorProvider);

            if (PrecioyCosto)
                camposValidos &= uiUtilidades.VerificarPrecioyCosto(txtCosto, txtPrecio, errorProvider);

            camposValidos &= uiUtilidades.VerificarTextbox(txtCantidadMinima, errorProvider, lblCantidadMinima);
            camposValidos &= txtCantidadMinima.Text != "0";

            return camposValidos && PrecioyCosto;
        }

        private Producto CrearProducto()
        {
            Categoria categoria = listaCategorias.FirstOrDefault(cat => cat.Nombre == cmbCategoria.SelectedItem.ToString());
            Proveedor proveedor = listaProveedores.FirstOrDefault(prov => prov.RazonSocial == cmbProveedor.SelectedItem.ToString());

            Producto producto = new Producto()
            {
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                NumeroLote = txtLote.Text != string.Empty ? txtLote.Text : null,
                Refrigerado = chkRefrigeado.Checked,
                Receta = chkBajoReceta.Checked,
                Categoria = categoria,
                Proveedor = proveedor,
                PrecioCompra = Convert.ToDecimal(txtCosto.Text),
                PrecioVenta = Convert.ToDecimal(txtPrecio.Text),
                Stock = Convert.ToInt32(txtStock.Text),
                CantidadMinima = Convert.ToInt32(txtCantidadMinima.Text),
            };

            if (chkVencimiento.Checked)
                producto.FechaVencimiento = dtaVencimiento.Value;

            return producto;
        }



        // Alta

        // Modificar

        // Baja



        // Cargar Combobox
        private void cargarCombobox()
        {
            // Combobox Categorías
            cmbCategoria.Items.Add("Seleccione una categoría...");
            foreach (Categoria categoria in listaCategorias)
            {
                cmbCategoria.Items.Add(categoria.Nombre);
            }
            cmbCategoria.SelectedIndex = 0;

            // Combobox Proveedores
            cmbProveedor.Items.Add("Seleccione un proveedor...");
            foreach (Proveedor proveedor in listaProveedores)
            {
                cmbProveedor.Items.Add(proveedor.RazonSocial);
            }
            cmbProveedor.SelectedIndex = 0;
        }

        // Manejo de Interfaz


        private void rbMedicamento_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMedicamento.Checked)
            {
                pnlLote.Visible = true;
                chkVencimiento.Checked = true;
            }
        }

        private void rbProductoGeneral_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProductoGeneral.Checked)
            {
                pnlLote.Visible = false;
                chkVencimiento.Checked = false;
            }
        }

        private void chkVencimiento_CheckedChanged(object sender, EventArgs e)
        {
            pnlVencimiento.Enabled = chkVencimiento.Checked;
        }



        // Movimiento de ventana
        private Point mousePosicion;
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousePosicion = e.Location;
            }
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int deltaX = e.X - mousePosicion.X;
                int deltaY = e.Y - mousePosicion.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }


    }
}
