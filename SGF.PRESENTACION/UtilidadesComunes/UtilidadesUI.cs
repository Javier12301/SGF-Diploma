using FontAwesome.Sharp;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.UtilidadesComunes
{
    public class UtilidadesUI
    {
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
