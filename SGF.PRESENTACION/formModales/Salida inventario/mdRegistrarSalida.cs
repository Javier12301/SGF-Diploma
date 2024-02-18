using SGF.MODELO.Negocio;
using SGF.NEGOCIO.Negocio;
using SGF.NEGOCIO.Seguridad;
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

namespace SGF.PRESENTACION.formModales.Salida_inventario
{
    public partial class mdRegistrarSalida : Form
    {
        // Controladora
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private SalidaInventarioBLL lSalidaInventario = SalidaInventarioBLL.ObtenerInstancia;
        private ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;

        private List<Producto> productosSeleccionados { get; set; }

        public mdRegistrarSalida()
        {
            InitializeComponent();
            productosSeleccionados = new List<Producto>();
        }

        private void mdRegistrarSalida_Load(object sender, EventArgs e)
        {
            try
            {
                cargarDatos();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarDatos()
        {
            txtFolio.Text = lSalidaInventario.ObtenerFolio().ToString();
            dtpFecha.Value = DateTime.Now;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                using (var modal = new mdSalidaProducto())
                {
                    var resultado = modal.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        Producto producto = new Producto();
                        producto = modal.productoSeleccionado;
                        int cantidadSalida = modal.cantidadSalida;

                        DataGridViewRow existeFila = dgvProductos.Rows
                            .Cast<DataGridViewRow>()
                            .FirstOrDefault(row => Convert.ToInt32(row.Cells["dgvcID"].Value) == producto.ProductoID);

                        if (existeFila != null)
                        {
                            int cantidadExistente = Convert.ToInt32(existeFila.Cells["dgvcCantidad"].Value);
                            existeFila.Cells["dgvcCantidad"].Value = cantidadExistente + cantidadSalida;
                        }
                        else
                        {
                            dgvProductos.Rows.Add(producto.ProductoID, producto.Nombre ,producto.Proveedor.RazonSocial, producto.Categoria.Nombre, cantidadSalida);
                            productosSeleccionados.Add(producto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.SelectedCells.Count > 0)
                {
                    DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar el producto seleccionado?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        foreach (DataGridViewCell celda in dgvProductos.SelectedCells)
                        {
                            int filaIndex = celda.RowIndex;
                            int productoID = Convert.ToInt32(dgvProductos.Rows[filaIndex].Cells["dgvcID"].Value);
                            Producto producto = productosSeleccionados.FirstOrDefault(prod => prod.ProductoID == productoID);
                            if (producto != null)
                            {
                                productosSeleccionados.Remove(producto);
                            }
                            dgvProductos.Rows.RemoveAt(filaIndex);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea limpiar el listado de productos?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                dgvProductos.Rows.Clear();
                productosSeleccionados.Clear();
                txtObservacion.Text = string.Empty;
            }
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (productosSeleccionados.Count > 0)
                {
                    int cantidadTotal = 0;
                    DataTable dtDetalleSalida = new DataTable();
                    dtDetalleSalida.Columns.Add("dgvcID", typeof(int));
                    dtDetalleSalida.Columns.Add("dgvcNombre", typeof(string));
                    dtDetalleSalida.Columns.Add("dgvcProveedor", typeof(string));
                    dtDetalleSalida.Columns.Add("dgvcCategoria", typeof(string));
                    dtDetalleSalida.Columns.Add("dgvcCantidad", typeof(int));

                    foreach (DataGridViewRow fila in dgvProductos.Rows)
                    {
                        dtDetalleSalida.Rows.Add(
                            new object[]
                            {
                            Convert.ToInt32(fila.Cells["dgvcID"].Value),
                            fila.Cells["dgvcNombre"].Value.ToString(),
                            fila.Cells["dgvcProveedor"].Value.ToString(),
                            fila.Cells["dgvcCategoria"].Value.ToString(),
                            Convert.ToInt32(fila.Cells["dgvcCantidad"].Value)
                            });
                        foreach (Producto producto in productosSeleccionados)
                        {
                            if (producto.ProductoID == Convert.ToInt32(fila.Cells["dgvcID"].Value))
                            {
                                cantidadTotal += Convert.ToInt32(fila.Cells["dgvcCantidad"].Value);
                                producto.Stock -= Convert.ToInt32(fila.Cells["dgvcCantidad"].Value);
                            }
                        }
                    }
                    // Salida de inventario
                    SalidaInventario salida = new SalidaInventario();
                    salida.Usuario = lSesion.UsuarioEnSesion().Usuario;
                    salida.FechaSalida = dtpFecha.Value;
                    salida.Observaciones = string.IsNullOrEmpty(txtObservacion.Text) ? "-" : txtObservacion.Text;

                    if (lSalidaInventario.RegistrarSalida(salida, dtDetalleSalida))
                    {
                        foreach (Producto produco in productosSeleccionados)
                        {
                            // Ecuación -> Cantidad antes (x) - Cantidad salida (y) = Cantidad después (z)
                            int cantidadAntes = lProducto.ObtenerExistencias(produco.ProductoID);
                            try
                            {
                                if (lProducto.ModificarProducto(produco))
                                {
                                    int cantidadDespues = lProducto.ObtenerExistencias(produco.ProductoID);
                                    int cantidadSalida = cantidadAntes - cantidadDespues;
                                    RegistroBLL.RegistrarMovimiento("Salida de inventario", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), cantidadSalida, cantidadAntes, cantidadDespues, "Inventario", $"Salida de inventario del producto: {produco.Nombre}.");

                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"No se pudo actualizar el stock del producto: {produco.Nombre} el cual tiene ID: {produco.ProductoID}, contacte con el administrador del sistema para solucionar este problema.");
                                continue;
                            }
                        }

                        MessageBox.Show("La salida de inventario se ha registrado correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // registrar error en consola de depuración
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro que desea cancelar el registro de salida de productos?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        
    }
}
