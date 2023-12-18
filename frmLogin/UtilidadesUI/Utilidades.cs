using FontAwesome.Sharp;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmLogin.UtilidadesUI
{
    public class Utilidades
    {
        private static Utilidades _instancia = null;
        private Utilidades()
        {
        }
        public static Utilidades ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Utilidades();
                }
                return _instancia;
            }
        }

        // Función modular, se necesitará fontawesome y un textbox guna
        public void MostrarContraseña(GunaLineTextBox textbox, IconButton btnOjo)
        {
            textbox.PasswordChar = (char)0;
            btnOjo.IconFont = IconFont.Solid;
        }

        public void OcultarContraseña(GunaLineTextBox textbox, IconButton btnOjo)
        {
            textbox.PasswordChar = '*';
            btnOjo.IconFont = IconFont.Regular;
        }

    }
}
