using ClosedXML.Excel;
using SGF.MODELO.Negocio;
using SGF.MODELO.Seguridad;
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

namespace SGF.PRESENTACION.formPrincipales.formHijos.Reportes.Inventario.formHijo
{
    public partial class formExistencia : Form
    {
        // Controladora
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private NegocioBLL lNegocio = NegocioBLL.ObtenerInstancia;
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;

        private List<Categoria> listaCategorias { get; set; }
        private List<Proveedor> listaProveedores { get; set; }
        private NegocioModelo NegocioDatos { get; set; }

        private Permiso permisosReporteInventario { get; set; }

        public formExistencia(Permiso permisosUsuario)
        {
            InitializeComponent();
            permisosReporteInventario = permisosUsuario;
            NegocioDatos = lNegocio.NegocioEnSesion().DatosDelNegocio;
            listaCategorias = new List<Categoria>();
            listaProveedores = new List<Proveedor>();
        }

        private void formExistencia_Load(object sender, EventArgs e)
        {
            try
            {
                cargarFiltros();
                filtrarLista();
                if(permisosReporteInventario.Imprimir)
                    btnImprimir.Enabled = true;
                if(permisosReporteInventario.Exportar)
                    btnExportar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarFiltros()
        {
            listaCategorias = lProducto.ObtenerCategoriasExistentes();
            listaProveedores = lProducto.ObtenerProveedoresExistentes();


            cmbFiltroCategoria.Items.Add("Todos");
            foreach (Categoria categoria in listaCategorias)
            {
                if (!cmbFiltroCategoria.Items.Contains(categoria.Nombre))
                {
                    cmbFiltroCategoria.Items.Add(categoria.Nombre);
                }
            }
            cmbFiltroCategoria.SelectedIndex = 0;

            cmbFiltroProveedor.Items.Add("Todos");
            foreach (Proveedor proveedor in listaProveedores)
            {
                if (!cmbFiltroProveedor.Items.Contains(proveedor.RazonSocial))
                {
                    cmbFiltroProveedor.Items.Add(proveedor.RazonSocial);
                }
            }
            cmbFiltroProveedor.SelectedIndex = 0;

            cmbFiltroExistencias.Items.Add("Todos");
            cmbFiltroExistencias.Items.Add("Con existencia");
            cmbFiltroExistencias.Items.Add("Sin existencia");
            cmbFiltroExistencias.SelectedIndex = 0;

            cmbFiltroTipoProducto.Items.Add("Todos");
            cmbFiltroTipoProducto.Items.Add("Producto general");
            cmbFiltroTipoProducto.Items.Add("Medicamentos");
            cmbFiltroTipoProducto.SelectedIndex = 0;
        }

        private void filtrarLista()
        {
            this.productoTableAdapter.FiltrarReporteExistencia(this.negocio.Producto, cmbFiltroTipoProducto.Text, cmbFiltroCategoria.Text, cmbFiltroProveedor.Text, "Activo", cmbFiltroExistencias.Text);
            cargarReporte();
        }

        private void cargarReporte()
        {
            int existenciaTotal = 0;
            decimal costoTotal = 0;
            decimal precioTotal = 0;
            if (dgvProductos.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    existenciaTotal += Convert.ToInt32(fila.Cells["dgvcStock"].Value);
                }

                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    costoTotal += Convert.ToDecimal(fila.Cells["dgvcPrecioCompra"].Value);
                }

                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    precioTotal += Convert.ToDecimal(fila.Cells["dgvcPrecioVenta"].Value);
                }
                Cursor.Current = Cursors.Default;
            }
            txtExistencia.Text = existenciaTotal.ToString();
            txtCostodeInventario.Text = uiUtilidades.FormatearMoneda(costoTotal, NegocioDatos);
            txtPrecioDeInventario.Text = uiUtilidades.FormatearMoneda(precioTotal, NegocioDatos);
        }

        private void combobox_SelecteIndexChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (permisosReporteInventario.Exportar)
                {
                    ExportarDataGridViewAExcel(dgvProductos, "Reporte de existencias", "Existencias");
                }
                else
                {
                    MessageBox.Show("No tiene permiso para exportar datos.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarDataGridViewAExcel(DataGridView dgv, string nombreArchivo, string nombreHoja)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dgv.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in dgv.Columns)
                {
                    dt.Columns.Add(columna.HeaderText, columna.ValueType);
                }

                // Agregar columnas para los totales
                dt.Columns.Add("Existencia Total", typeof(string));
                dt.Columns.Add("Costo Total", typeof(string));
                dt.Columns.Add("Precio Total", typeof(string));

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(row.Cells.Cast<DataGridViewCell>().Select(c => c.Value).ToArray());
                    }
                }

                // Agregar los totales como una nueva fila al final del DataTable
                DataRow totalRow = dt.NewRow();
                totalRow["Existencia Total"] = txtExistencia.Text;
                totalRow["Costo Total"] = txtCostodeInventario.Text;
                totalRow["Precio Total"] = txtPrecioDeInventario.Text;
                dt.Rows.Add(totalRow);

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format($"{nombreArchivo}.xlsx");
                savefile.Filter = "Excel Files | *.xlsx";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var hoja = wb.Worksheets.Add(dt, nombreHoja);
                            hoja.ColumnsUsed().AdjustToContents();

                            // La ultima columna siempre ponerle tamaño 15
                            int columnasTotales = hoja.ColumnsUsed().Count();
                            hoja.Column(columnasTotales).Width = 15;

                            wb.SaveAs(savefile.FileName);
                            AuditoriaBLL.RegistrarMovimiento("Exportar", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), $"Archivo excel con nombre ({nombreArchivo}) fue exportado con éxito.");
                            MessageBox.Show("Datos exportados correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    // Catch cuando el archivo está abierto
                    catch (System.IO.IOException)
                    {
                        throw new Exception("El archivo está abierto, por favor cierre el archivo y vuelva a intentarlo.");
                    }
                    catch (Exception)
                    {
                        throw new Exception("Ocurrió un error al exportar los datos, por favor contacte al administrador para solucionar este error.");
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private string modificarPlantilla(string html)
        {
            // Información de Negocio
            html = html.Replace("@NombreNegocio", NegocioDatos.Nombre);
            html = html.Replace("@TipoDocumentoNegocio", NegocioDatos.TipoDocumento);
            html = html.Replace("@TipoMovimiento", "Reporte de existencias");
            html = html.Replace("@DocumentoNegocio", NegocioDatos.Documento);
            html = html.Replace("@DireccionNegocio", NegocioDatos.Direccion);
            html = html.Replace("@TelefonoNegocio", NegocioDatos.Telefono);

            // Información del reporte
            html = html.Replace("@TipoComprobante", "Inventario");
            html = html.Replace("@FechaMovimiento", DateTime.Now.ToString("dd/MM/yyyy"));
            // Si tipo de producto es Todos, deberá mostrar Producto general y Medicamentos
            string tipoProducto = cmbFiltroTipoProducto.Text == "Todos" ? "Producto general y/o Medicamentos" : cmbFiltroTipoProducto.Text;
            html = html.Replace("@TipoProducto", tipoProducto);

            // Tablas
            StringBuilder filas = new StringBuilder();
            int existenciaTotal = 0;
            decimal costoTotal = 0;
            decimal precioTotal = 0;
            foreach(DataGridViewRow row in dgvProductos.Rows)
            {
                filas.AppendLine("<tr>");
                filas.AppendLine("<td>" + row.Cells["dgvcCodigo"].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells["dgvcLote"].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells["dgvcNombreProducto"].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells["dgvcStock"].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells["dgvcPrecioCompra"].Value.ToString() + "</td>");
                filas.AppendLine("<td>" + row.Cells["dgvcPrecioVenta"].Value.ToString() + "</td>");
                filas.AppendLine("</tr>");

                existenciaTotal += Int32.Parse(row.Cells["dgvcStock"].Value.ToString());
                costoTotal += decimal.Parse(row.Cells["dgvcPrecioCompra"].Value.ToString());
                precioTotal += decimal.Parse(row.Cells["dgvcPrecioVenta"].Value.ToString());
            }
            string monedaCosto = uiUtilidades.FormatearMoneda(costoTotal, NegocioDatos);
            string monedaPrecio = uiUtilidades.FormatearMoneda(precioTotal, NegocioDatos);
            html = html.Replace("@FILAS", filas.ToString());
            html = html.Replace("@ExistenciaTotal", existenciaTotal.ToString());
            html = html.Replace("@CostoTotal", monedaCosto);
            html = html.Replace("@PrecioTotal", monedaPrecio);
            return html;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (permisosReporteInventario.Imprimir)
                {
                    if(dgvProductos.Rows.Count > 0)
                    {
                        SaveFileDialog guardar = new SaveFileDialog();
                        guardar.Filter = "Archivo PDF|*.pdf";
                        guardar.FileName = "Reporte de existencias.pdf";
                        string paginaHTML = Properties.Resources.reporte_existencias_inventario;
                        paginaHTML = modificarPlantilla(paginaHTML);

                        if (guardar.ShowDialog() == DialogResult.OK)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            uiUtilidades.HtmlToPdf(paginaHTML, guardar.FileName, NegocioDatos);
                            MessageBox.Show("El archivo PDF se ha guardado correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cursor.Current = Cursors.Default;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay datos para imprimir", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No tiene permiso para imprimir los datos del reporte.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
