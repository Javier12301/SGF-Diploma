using Microsoft.AnalysisServices;
using SGF.MODELO.Seguridad;
using SGF.NEGOCIO.Negocio;
using SGF.PRESENTACION.UtilidadesComunes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.formModales.Seguridad.formHijosAuditoria
{
    public partial class formDetalleProductos : Form
    {
        // controladora
        UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;

        private Auditoria oAuditoria { get; set; }
        public formDetalleProductos(Auditoria auditoria = null)
        {
            InitializeComponent();
            oAuditoria = auditoria;
        }

        private void formDetalleProductos_Load(object sender, EventArgs e)
        {
            try
            {
                // Deserializar el objeto auditoria
                Producto oProducto = new Producto();
                oProducto = uiUtilidades.DeserializarJSON<Producto>(oAuditoria.Detalles);
                cargarDatos(oProducto);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void cargarDatos(Producto producto)
        {
            if(producto != null)
            {
                if (producto.TipoProducto == rbProductoGeneral.Text)
                    rbProductoGeneral.Checked = true;
                else
                    rbMedicamento.Checked = true;

                txtID.Text = producto.ProductoID.ToString();
                txtCodigo.Text = producto.Codigo;
                txtNombre.Text = producto.Nombre;
                txtLote.Text = producto.NumeroLote;
                chkRefrigeado.Checked = producto.Refrigerado;
                chkVencimiento.Checked = producto.FechaVencimiento != null ? true : false;
                dtaVencimiento.Value = producto.FechaVencimiento != null ? Convert.ToDateTime(producto.FechaVencimiento) : DateTime.Now;
                chkBajoReceta.Checked = producto.Receta;
                txtCategoria.Text = producto.Categoria.Nombre;
                txtProveedor.Text = producto.Proveedor.RazonSocial;
                txtCosto.Text = producto.PrecioCompra.ToString();
                txtPrecio.Text = producto.PrecioVenta.ToString();
                txtStock.Text = producto.Stock.ToString();
                txtCantidadMinima.Text = producto.CantidadMinima.ToString();
                chkEstado.Checked = producto.Estado;
            }
            else
            {
                throw new Exception("Ocurrió un error al cargar los datos del producto, por favor contacte al administrador para solucionar este error.");
            }
        }   

        private void rbProductoGeneral_CheckedChanged_1(object sender, EventArgs e)
        {
            // no cambiar el estado del radio button
            rbProductoGeneral.Checked = rbProductoGeneral.Checked;
        }

        private void rbMedicamento_CheckedChanged(object sender, EventArgs e)
        {
            rbMedicamento.Checked = rbMedicamento.Checked;
        }
    }
}
