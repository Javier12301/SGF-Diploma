using ClosedXML.Excel;
using FontAwesome.Sharp;
using Guna.UI.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using SGF.MODELO.Negocio;
using SGF.MODELO.Seguridad;
using SGF.NEGOCIO.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SGF.PRESENTACION.UtilidadesComunes
{
    public class UtilidadesUI
    {
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private static UtilidadesUI _instancia = null;
        private UtilidadesUI()
        {
        }
        public static UtilidadesUI ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new UtilidadesUI();
                }
                return _instancia;
            }
        }

        public void HtmlToPdf(string htmlContent, string outputPath, NegocioModelo NegocioDatos)
        {
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                using (Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25))
                {
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));
                    System.Drawing.Image logo;
                    if (NegocioDatos.Logo != null)
                    {
                        string logoFileName = "logo.png";
                        string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SGF.PRESENTACION", "Recursos", "Logo negocio");
                        string path = Path.Combine(directoryPath, logoFileName);
                        // si el directorio no existe, poner el logo por defecto para evitar errores
                        if (!File.Exists(path))
                        {
                            logo = Properties.Resources.logoDefault;
                        }
                        else
                        {
                            logo = System.Drawing.Image.FromFile(path);
                        }
                    }
                    else
                    {
                        logo = Properties.Resources.logoDefault;
                    }
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(logo, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(80, 60);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                    pdfDoc.Add(img);

                    using (StringReader sr = new StringReader(htmlContent))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                }
            }
        }



        // Manejo de módulo de negocio
        // Convertir imagen a byte[]
        public byte[] ImageToByteArray(System.Drawing.Image imageIN)
        {
            if (imageIN != null)
            {
                byte[] byteArray = null;
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        imageIN.Save(ms, imageIN.RawFormat);
                        byteArray = ms.ToArray();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return byteArray;
            }
            else
            {
                return null;
            }
        }

        public System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn != null)
            {
                System.Drawing.Image returnImage;
                using (MemoryStream ms = new MemoryStream(byteArrayIn))
                {
                    returnImage = System.Drawing.Image.FromStream(ms);
                }
                return returnImage;
            }
            else
            {
                return null;
            }
        }

        public System.Drawing.Image LogoPorDefecto()
        {
            return Properties.Resources.logoDefault;
        }

        public System.Drawing.Icon ByteArrayToIcon(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                // Crea una imagen a partir del array de bytes
                var img = System.Drawing.Image.FromStream(ms);

                // Ajusta la System.Drawing.Imagen para que tenga un tamaño adecuado para un icono
                var bmp = new Bitmap(img, new Size(32, 32));

                // Convierte la imagen ajustada en un icono
                return System.Drawing.Icon.FromHandle(bmp.GetHicon());
            }
        }

        // Transformar imagen a icono
        public System.Drawing.Icon ImageToIcon(System.Drawing.Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image", "La imagen no puede ser nula.");
            }

            using (Bitmap bitmap = new Bitmap(image))
            {
                IntPtr Hicon = bitmap.GetHicon();
                return System.Drawing.Icon.FromHandle(Hicon);
            }
        }
        // FIN Manejo de módulo de negocio

        public void cargarPermisos(string nombreFormulario, FlowLayoutPanel flpContenedorBotones, Permiso permisoDeUsuario = null)
        {
            List<Modulo> modulosPermitidos = lSesion.UsuarioEnSesion().Usuario.ObtenerModulosPermitidos();

            Modulo modulosActivos = modulosPermitidos.FirstOrDefault(m => m.Descripcion == nombreFormulario);

            List<Accion> accionesPermitidas = null;
            if (modulosActivos != null)
            {
                accionesPermitidas = modulosActivos.ListaAcciones;
            }

            // Buscar el módulo correspondiente al formulario actual
            Modulo moduloActual = modulosPermitidos.FirstOrDefault(m => m.Descripcion == nombreFormulario);

            // Si se encuentra el módulo, cargar las opciones
            if (moduloActual != null)
            {
                foreach (Control control in flpContenedorBotones.Controls)
                {
                    if (control is Button && control.Tag != null)
                    {
                        // Obtener el nombre de la acción desde el Tag del botón
                        string nombreAccionBoton = control.Tag.ToString();

                        // Verificar si el nombre de la acción está en la lista de acciones del módulo
                        bool tienePermiso = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == nombreAccionBoton);

                        // Activar o desactivar el botón según los permisos
                        control.Enabled = tienePermiso;
                        control.Visible = tienePermiso;
                    }
                }
                if (permisoDeUsuario != null)
                {
                    permisoDeUsuario.Alta = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Alta");
                    permisoDeUsuario.Modificar = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Modificar");
                    permisoDeUsuario.Baja = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Baja");
                    permisoDeUsuario.Importar = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Importar");
                    permisoDeUsuario.Exportar = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Exportar");
                    permisoDeUsuario.Imprimir = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Imprimir");
                    permisoDeUsuario.Grafico = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Gráfico");
                    permisoDeUsuario.Cancelar = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Cancelar");
                    permisoDeUsuario.EntradaMasiva = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Entrada");
                    permisoDeUsuario.SalidaMasiva = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Salida");
                    permisoDeUsuario.GenerarRegistro = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Generar registro");
                }
            }
        }

        public void ExportarDataGridViewAExcel(DataGridView dgv, string nombreArchivo, string nombreHoja)
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

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(row.Cells.Cast<DataGridViewCell>().Select(c => c.Value).ToArray());
                    }
                }

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

        // Función modular, se necesitará fontawesome y un textbox guna
        public void MostrarContraseñaG(GunaLineTextBox textbox, IconButton btnOjo)
        {
            textbox.PasswordChar = (char)0;
            btnOjo.IconFont = IconFont.Solid;
        }

        public void OcultarContraseñaG(GunaLineTextBox textbox, IconButton btnOjo)
        {
            textbox.PasswordChar = '*';
            btnOjo.IconFont = IconFont.Regular;
        }

        public void MostrarContraseña(TextBox textbox, IconButton btnOjo)
        {
            textbox.PasswordChar = (char)0;
            btnOjo.IconFont = IconFont.Solid;
        }

        public void OcultarContraseña(TextBox textbox, IconButton btnOjo)
        {
            textbox.PasswordChar = '*';
            btnOjo.IconFont = IconFont.Regular;
        }



        public bool errorTextboxG(GunaLineTextBox textbox, bool error)
        {
            if (error)
            {
                textbox.LineColor = ColorTranslator.FromHtml("#FF4136");
                return true;
            }
            else
            {
                textbox.LineColor = ColorTranslator.FromHtml("#5AA8E1");
                return false;
            }
        }

        // Limpiar varios campos de texto
        public void LimpiarTextbox(params TextBoxBase[] textboxes)
        {
            foreach (TextBoxBase txbox in textboxes)
            {
                txbox.Text = "";
            }
        }

        // Setear a index 0 a varios combobox
        public void LimpiarCombobox(params ComboBox[] comboboxes)
        {
            foreach (ComboBox combobox in comboboxes)
            {
                combobox.SelectedIndex = 0;
            }
        }

        public void Combobox_ShortcutSiguienteIndex(ComboBox combobox, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (combobox.SelectedIndex == combobox.Items.Count - 1)
                {
                    combobox.SelectedIndex = 0;
                }
                else
                {
                    combobox.SelectedIndex++;
                }
            }
        }

        // Verificar número de telefono
        // ingresar caracteres numericos y permitir guiones
        public void TextboxTelefono(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public bool VerificarTextbox(TextBoxBase textbox, ErrorProvider mensajeError, Label lbl)
        {
            if (!string.IsNullOrEmpty(textbox.Text))
            {
                // No está vacío
                mensajeError.SetError(lbl, "");
                return true;
            }
            else
            {
                // Está vacío
                mensajeError.SetError(lbl, "Este campo no puede estar vacío.");
                return false;
            }
        }

        // Estos tipos de textbox poseen lineas inferiores, lo que indica visualmente al usuario donde ocurrio un error
        public bool VerificarTextboxG(GunaLineTextBox textbox)
        {
            if (!string.IsNullOrEmpty(textbox.Text))
            {
                errorTextboxG(textbox, false);
                return true;
            }
            else
            {
                errorTextboxG(textbox, true);
                return false;
            }
        }


        // Verificar mail correcto
        public bool VerificarMail(TextBoxBase textbox, ErrorProvider mensajeError, Label lbl)
        {
            if (textbox.Text.Contains("@"))
            {
                mensajeError.SetError(lbl, "");
                return true;
            }
            else
            {
                mensajeError.SetError(lbl, "El mail ingresado no es válido.");
                return false;
            }
        }

        public bool VerificarMailG(GunaLineTextBox textbox)
        {
            if (textbox.Text.Contains("@"))
            {
                textbox.LineColor = ColorTranslator.FromHtml("#5AA8E1");
                return true;
            }
            else
            {
                textbox.LineColor = ColorTranslator.FromHtml("#FF4136");
                return false;
            }
        }

        // verificar combobox que no esté en selectindex 0
        public bool VerificarCombobox(ComboBox combobox, ErrorProvider mensajeError, Label lbl)
        {
            if (combobox.SelectedIndex != 0)
            {
                mensajeError.SetError(lbl, "");
                return true;
            }
            else
            {
                mensajeError.SetError(lbl, "Debe seleccionar una opción.");
                return false;
            }
        }

        // Verificar fecha vencimiento utilizando el dia de hoy
        public bool VerificarFechaVencimiento(DateTimePicker fechaVencimiento, ErrorProvider mensajeError, Label lbl)
        {
            if (fechaVencimiento.Value.Date >= DateTime.Now.Date)
            {
                // Fecha valida
                mensajeError.SetError(lbl, "");
                return true;
            }
            else
            {
                // Vencido
                mensajeError.SetError(lbl, "El producto ingresado se encuentra vencido, por favor, verifique la fecha de vencimiento antes de cargar el producto.");
                return false;
            }
        }

        public bool VerificarTextboxPrecio(TextBoxBase textbox, ErrorProvider mensajeError)
        {
            if (!string.IsNullOrEmpty(textbox.Text))
            {
                // No está vacío
                mensajeError.SetError(textbox, "");
                return true;
            }
            else
            {
                // Está vacío
                mensajeError.SetError(textbox, "Este campo no puede estar vacío.");
                return false;
            }
        }

        public bool VerificarFormatoMoneda(TextBoxBase textbox, ErrorProvider mensajeError)
        {
            if (decimal.TryParse(textbox.Text, out decimal valor))
            {
                if (valor == 0.00m)  // Verifica si el valor es igual a 0.00
                {
                    mensajeError.SetError(textbox, "El valor ingresado debe ser mayor a 0.");
                    return false;
                }
                else
                {
                    mensajeError.SetError(textbox, "");
                    return true;
                }
            }
            else
            {
                mensajeError.SetError(textbox, "El valor ingresado no cumple con el formato moneda, si desea agregar centavos, utilice el formato 0.00");
                return false;
            }
        }


        // Verificar precio y costo ingresado, el costo no debe ser mayor al precio
        public bool VerificarPrecioyCosto(TextBoxBase costo, TextBoxBase precio, ErrorProvider mensajeError)
        {
            decimal costoDecimal = decimal.Parse(costo.Text);
            decimal precioDecimal = decimal.Parse(precio.Text);

            if (precioDecimal >= costoDecimal)
            {
                mensajeError.SetError(precio, "");
                return true;
            }
            else
            {
                mensajeError.SetError(precio, "El precio debe ser mayor a costo ( Precio >= Costo )");
                return false;
            }
        }

        public string FormatearMoneda(decimal numeroMoneda, NegocioModelo NegocioDatos)
        {
            string moneda = string.Empty;
            if (NegocioDatos.Moneda.Posicion == "Antes")
            {
                moneda = NegocioDatos.Moneda.Simbolo + " " + numeroMoneda.ToString("N2");
            }
            else
            {
                moneda = numeroMoneda.ToString("N2") + " " + NegocioDatos.Moneda.Simbolo;
            }
            return moneda;
        }

        // Manejo de Textbox con Formato Moneda
        public void TextboxMoneda_KeyPress(TextBox textbox, KeyPressEventArgs e, ErrorProvider error)
        {
            error.SetError(textbox, "");
            // Formato regional de Argentina
            if (e.KeyChar == '.')
            {
                e.Handled = true;
                SendKeys.Send(",");
            }

            // Solo puede haber una coma en el textbox
            if (e.KeyChar == ',')
            {
                if (textbox.Text.Contains(","))
                {
                    error.SetError(textbox, "Solo puede haber una coma en el campo.");
                    e.Handled = true;
                }
            }

            // Solo permite números y control keys (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '.' || e.KeyChar == ','))
            {
                error.SetError(textbox, "Solo se permiten números en este campo.");
                e.Handled = true;
            }
        }


        public void TextboxMoneda_Leave(TextBox textbox, EventArgs e)
        {
            // Formato regional de Argentina
            // 1.000,00
            if (string.IsNullOrEmpty(textbox.Text))
                textbox.Text = "0.00";
            textbox.Text = string.Format(CultureInfo.GetCultureInfo("es-AR"), "{0:N2}", Convert.ToDecimal(textbox.Text));

        }

        // Solo numeros
        public void SoloNumero(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        // Solo mayusculas y numeros sin espacios con keypresseventargs
        public void SoloMayusculasYNumeros(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

    }
}
