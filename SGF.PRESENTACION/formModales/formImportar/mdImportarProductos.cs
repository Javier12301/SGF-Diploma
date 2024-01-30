using ClosedXML.Excel;
using ExcelDataReader;
using SGF.NEGOCIO.Negocio;
using SGF.PRESENTACION.Recursos.Planillas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.formModales.formImportar
{
    public partial class mdImportarProductos : Form
    {
        // Controladoras
        private CategoriaBLL lCategoria = CategoriaBLL.ObtenerInstancia;
        private ProveedorBLL lProveedor = ProveedorBLL.ObtenerInstancia;
        private ProductoBLL lProducto = ProductoBLL.ObtenerInstancia;

        // los dataset almancenan número de tablas, columnas y filas
        private DataSet dtsProductos;

        // Listas
        private List<Proveedor> listaProveedores { get; set; }
        private List<Categoria> listaCategorias { get; set; }

        public mdImportarProductos()
        {
            InitializeComponent();
            dtsProductos = new DataSet();
            listaProveedores = lProveedor.ListaProveedores();
            listaCategorias = lCategoria.ListarCategorias();
        }

        // Manejo de responsabilidades
        private Producto CrearProducto(DataRow fila)
        {
            Categoria categoria = listaCategorias.FirstOrDefault(cat => cat.Nombre == fila["Categoria"].ToString());
            Proveedor proveedor = listaProveedores.FirstOrDefault(prov => prov.RazonSocial == fila["Proveedor"].ToString());

            Producto producto = new Producto()
            {
                Codigo = fila["Código"].ToString(),
                Nombre = fila["Nombre"].ToString(),
                Proveedor = proveedor,
                Categoria = categoria,
                Stock = Convert.ToInt32(fila["Stock"]),
                CantidadMinima = Convert.ToInt32(fila["Cantidad mínima"]),
                NumeroLote = !string.IsNullOrEmpty(fila["Lote"].ToString()) ? fila["Lote"].ToString() : "-",
                TipoProducto = fila["Tipo Producto"].ToString(),
                PrecioVenta = Convert.ToDecimal(fila["Precio Venta"]),
                PrecioCompra = Convert.ToDecimal(fila["Precio Compra"]),
                Refrigerado = Convert.ToBoolean(fila["Refrigerado"]),
                Receta = Convert.ToBoolean(fila["Receta"]),
                Estado = Convert.ToBoolean(fila["Estado"])
            };

            if (fila["Vencimiento"].ToString() != "-")
                producto.FechaVencimiento = Convert.ToDateTime(fila["Vencimiento"]);
            else
                producto.FechaVencimiento = null;

            return producto;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(dgvImportar.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                altaProducto();
                Cursor.Current = Cursors.Default;
                // Si no ocurrió ningun error, se le pregunta al usuario si desea seguir importando productos o salir del módulo
                DialogResult respuesta = MessageBox.Show("¿Desea seguir importando productos?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.No)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            { 
                MessageBox.Show("No hay datos para importar. Por favor, seleccione una hoja de Excel y vuelva a intentarlo.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Alta de productos
        private void altaProducto()
        {
            // Convertir los datos del DataGridView a un DataTable
            DataTable tabla = (DataTable)dgvImportar.DataSource;

            // Crear una nueva tabla para almacenar las filas con errores
            DataTable tablaErrores = tabla.Clone();

            int productosAlta = 0;
            int productoError = 0;

            foreach (DataRow fila in tabla.Rows)
            {
                try
                {
                    Producto producto = CrearProducto(fila);

                    if (producto != null && producto.Codigo != null && producto.Nombre != null)
                    {
                        bool codigoExiste = lProducto.ExisteCodigo(producto.Codigo);
                        bool nombreExiste = lProducto.ExisteProducto(producto.Nombre);
                        

                        if (codigoExiste || nombreExiste)
                        {
                            string mensajeError = "El producto de la fila " + fila["#"].ToString() + " no se pudo dar de alta porque ya existe un producto con el mismo ";
                            mensajeError += codigoExiste ? "código" : "nombre";
                            MessageBox.Show(mensajeError, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            productoError++;

                            // Agregar la fila a la tabla de errores
                            tablaErrores.ImportRow(fila);
                            continue;
                        }

                        bool resultado = lProducto.AltaProducto(producto);
                        if (resultado)
                        {
                            productosAlta++;
                        }
                        else
                        {
                            MessageBox.Show("El producto de la fila " + fila["#"].ToString() + " no se pudo dar de alta, por favor, revise los datos ingresados y vuelva a intentarlo.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            productoError++;

                            // Agregar la fila a la tabla de errores
                            tablaErrores.ImportRow(fila);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El producto de la fila " + fila["#"].ToString() + " no se pudo dar de alta porque no tiene código o nombre", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        productoError++;

                        // Agregar la fila a la tabla de errores
                        tablaErrores.ImportRow(fila);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la fila " + fila["#"].ToString() + ": " + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    productoError++;

                    // Agregar la fila a la tabla de errores
                    tablaErrores.ImportRow(fila);
                }             
            }

            // Asignar la tabla de errores al DataGridView
            dgvImportar.DataSource = tablaErrores;

            MessageBox.Show($"Se dieron de alta {productosAlta} productos y no se pudieron dar de alta {productoError} productos.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void mdImportarProductos_Load(object sender, EventArgs e)
        {
            DiseñoInicial();
            this.productoTableAdapter.Fill(this.negocio.Producto);
            crearPlanilla();
        }

        private void btnPlanilla_Click(object sender, EventArgs e)
        {
            crearPlanilla();
        }

        private bool ValidarHoja(DataTable tabla)
        {
            // Se validará si la hoja seleccionada tiene los datos necesarios para importar productos
            bool hojaValida = true;
            hojaValida &= tabla.Columns.Contains("Código");
            hojaValida &= tabla.Columns.Contains("Nombre");
            hojaValida &= tabla.Columns.Contains("Proveedor");
            hojaValida &= tabla.Columns.Contains("Categoria");
            hojaValida &= tabla.Columns.Contains("Stock");
            hojaValida &= tabla.Columns.Contains("Cantidad mínima");
            hojaValida &= tabla.Columns.Contains("Lote");
            hojaValida &= tabla.Columns.Contains("Vencimiento");
            hojaValida &= tabla.Columns.Contains("Tipo Producto");
            hojaValida &= tabla.Columns.Contains("Precio Venta");
            hojaValida &= tabla.Columns.Contains("Precio Compra");
            hojaValida &= tabla.Columns.Contains("Refrigerado");
            hojaValida &= tabla.Columns.Contains("Receta");
            hojaValida &= tabla.Columns.Contains("Estado");
            return hojaValida;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if(cmbHoja.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    // Obtenemos la tabla
                    DataTable tabla = dtsProductos.Tables[cmbHoja.SelectedIndex];
                    // Columna para enumerar las filas
                    // Verificamos si la columna "#" ya existe
                    if (!tabla.Columns.Contains("#"))
                    {
                        // Si no existe, la agregamos
                        tabla.Columns.Add("#", typeof(int));
                        tabla.Columns["#"].SetOrdinal(0);
                    }

                    // Recorremos las filas de la tabla
                    foreach (DataRow fila in tabla.Rows)
                    {
                        // Se asigna el número de fila a la columna "#"
                        fila["#"] = tabla.Rows.IndexOf(fila) + 1;
                    }

                    // Comprobar si la tabla tiene en su headers los datos correspondientes para importar productos
                    if (ValidarHoja(tabla))
                    {
                        // Creamos una nueva tabla con la misma estructura
                        DataTable tablaClon = tabla.Clone();

                        // Cambiamos el tipo de datos de las columnas "Vencimiento" y "Lote" a string
                        tablaClon.Columns["Vencimiento"].DataType = typeof(string);
                        tablaClon.Columns["Lote"].DataType = typeof(string);

                        // Copiamos los datos de la tabla original a la tabla clonada
                        foreach (DataRow fila in tabla.Rows)
                        {
                            tablaClon.ImportRow(fila);
                        }

                        // Recorremos las filas de la tabla clonada
                        foreach (DataRow fila in tablaClon.Rows)
                        {
                            // Revisamos si proveedor y categoría son null o empty
                            // si es así, le insertamos como N/A
                            if (fila["Proveedor"] == DBNull.Value || string.IsNullOrEmpty(fila["Proveedor"].ToString()))
                            {
                                fila["Proveedor"] = "N/A";
                            }
                            if (fila["Categoria"] == DBNull.Value || string.IsNullOrEmpty(fila["Categoria"].ToString()))
                            {
                                fila["Categoria"] = "N/A";
                            }
                            // Revisamos si es null o empty Stock y cantidad mínima
                            // si es así, le insertamos 0
                            if (fila["Stock"] == DBNull.Value || string.IsNullOrEmpty(fila["Stock"].ToString()))
                            {
                                fila["Stock"] = 0;
                            }

                            if (fila["Cantidad mínima"] == DBNull.Value || string.IsNullOrEmpty(fila["Cantidad mínima"].ToString()))
                            {
                                fila["Cantidad mínima"] = 0;
                            }

                            // Si "Lote" o "Vencimiento" son cadenas vacías, les asignamos "-"
                            if (string.IsNullOrEmpty(fila["Lote"].ToString()))
                            {
                                fila["Lote"] = "-";
                            }
                            if (string.IsNullOrEmpty(fila["Vencimiento"].ToString()))
                            {
                                fila["Vencimiento"] = "-";
                            }
                            // Si "Tipo Producto" es cadena vacía, le asignamos "Producto general"
                            if (string.IsNullOrEmpty(fila["Tipo Producto"].ToString()))
                            {
                                fila["Tipo Producto"] = "Producto general";
                            }

                            // Si "Precio Venta" o "Precio Compra" son cadenas vacías, les asignamos 0
                            if (string.IsNullOrEmpty(fila["Precio Venta"].ToString()))
                            {
                                fila["Precio Venta"] = 0;
                            }

                            if (string.IsNullOrEmpty(fila["Precio Compra"].ToString()))
                            {
                                fila["Precio Compra"] = 0;
                            }
                        }

                        // Asignamos la tabla clonada al DataGridView
                        dgvImportar.DataSource = tablaClon;
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        MessageBox.Show("La hoja seleccionada no cumple con el formato para importar productos. Por favor, seleccione otra hoja o cree una nueva planilla y vuelva a intentarlo.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cursor.Current = Cursors.Default;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show("No hay hojas por mostrar, por favor, seleccione una hoja de Excel y vuelva a intentarlo.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DiseñoInicial()
        {
            dgvImportar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvImportar.MultiSelect = false;
            dgvImportar.ReadOnly = true;
            dgvImportar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvImportar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvImportar.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvImportar.AllowUserToAddRows = false;
        }

        private void crearPlanilla()
        {
            MessageBox.Show("Se creará una planilla de Excel con el formato necesario para importar los productos. Por favor, complete la planilla con los datos de los productos deseados cumpliendo con el formato indicado.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // cursos de espera
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = "Planilla de productos.xlsx";
            saveFile.Filter = "Excel File|*.xlsx";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Caso de error, se debe modificar la ruta entrando a la clase de plainllasDirectorios
                    string rutaPlanilla = planillasDirectorios.planillaProductos;
                    string rutaDestino = saveFile.FileName;

                    System.IO.File.Copy(rutaPlanilla, rutaDestino, true);
                    Cursor.Current = Cursors.WaitCursor;
                    // Abrimos el archivo excel con ClosedXML
                    using (XLWorkbook wb = new XLWorkbook(rutaDestino))
                    {
                        var ws = wb.Worksheet("Datos");
                        // Se llena los datos en la hoja "Datos" usando DataTable de this.productoTableAdapter.Fill(this.negocio.Producto);
                        DataTable dt = this.productoTableAdapter.GetData();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                // Encuentra la columna correspondiente en la hoja de Excel basándose en el nombre de la columna en el DataTable
                                var cell = ws.Row(1).CellsUsed().FirstOrDefault(c => c.Value.ToString() == dt.Columns[j].ColumnName);
                                if (cell != null)
                                {
                                    int excelColumn = cell.Address.ColumnNumber;
                                    ws.Cell(i + 2, excelColumn).Value = dt.Rows[i][j].ToString();
                                }
                            }
                        }

                        // La celda ProveedoresExistentes pertenece a la columna 15
                        ws.Cell(1, 15).Value = "ProveedoresExistentes";
                        // La celda CategoriasExistentes pertenece a la columna 16
                        ws.Cell(1, 16).Value = "CategoriasExistentes";
                        // ahora, se llenara las filas de las celdas ProveedoresExistentes y CategoriasExistentes usando los datos de la base de datos
                        // ProveedoresExistentes
                        foreach (Proveedor proveedor in listaProveedores)
                        {
                            ws.Cell(listaProveedores.IndexOf(proveedor) + 2, 15).Value = proveedor.RazonSocial;
                        }

                        // CategoriasExistentes
                        foreach (Categoria categoria in listaCategorias)
                        {
                            ws.Cell(listaCategorias.IndexOf(categoria) + 2, 16).Value = categoria.Nombre;
                        }
                        
                        
                        wb.Save();
                    }
                    MessageBox.Show("Planilla creada con éxito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void btnBuscarRuta_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Excel Workbook|*.xlsx";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    cmbHoja.Items.Clear();
                    dgvImportar.DataSource = null;

                    txtRuta.Text = openFile.FileName;

                    // fileStream nos permitirá leer, escribir, abrir y cerrar archivos
                    FileStream fsSource = new FileStream(txtRuta.Text, FileMode.Open, FileAccess.Read);

                    IExcelDataReader reader = ExcelReaderFactory.CreateReader(fsSource);

                    // Convertimos las hojas en un dataset
                    dtsProductos = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    // Obtenemos las tablas y le añadimos sus nombres al combobox
                    foreach (DataTable tabla in dtsProductos.Tables)
                    {
                        // no cargar la hoja "Datos"
                        if (tabla.TableName != "Datos")
                        {
                            cmbHoja.Items.Add(tabla.TableName);
                        }
                    }
                    cmbHoja.SelectedIndex = 0;
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea salir del módulo de importación de productos?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
