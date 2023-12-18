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

namespace SGF.PRESENTACION.frmModales.Seguridad
{
    public partial class frmVerificarMail : Form
    {
        UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        private string codigoAzar { get; set; }
        private bool codigoValido { get; set; }
        public frmVerificarMail(string codigoAzar)
        {
            InitializeComponent();
            this.codigoAzar = codigoAzar;
            codigoValido = false;
        }

        private void frmVerificarMail_Load(object sender, EventArgs e)
        {
            txt1.Select();
        }

        private void txtN_Changed(object sender, EventArgs e)
        {
            verificarCodigo();
        }

        private void txtN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                verificarCodigo();
            }
            siguienteTxtN(sender, e);
        }


        private void verificarCodigo()
        {
            string codigo = txt1.Text + txt2.Text + txt3.Text + txt4.Text + txt5.Text;
            if (codigo == codigoAzar)
            {
                codigoValido = true;
                this.Close();
            }
        }

        // Manejo de interfaz

        // Cuando se presiona una tecla en los textbox, se tabulará
        private void siguienteTxtN(object sender, KeyPressEventArgs e)
        {
            TextBox txtN = (TextBox)sender;
            switch (txtN.TabIndex)
            {
                case 0:
                    if (char.IsNumber(e.KeyChar))
                    {
                        SendKeys.Send("{TAB}");
                    }
                    break;
                case 1:
                    if (char.IsNumber(e.KeyChar))
                    {
                        SendKeys.Send("{TAB}");
                    }
                    if (e.KeyChar == (char)Keys.Back)
                    {
                        SendKeys.Send("+{TAB}");
                    }
                    break;
                case 2:
                    if (char.IsNumber(e.KeyChar))
                    {
                        SendKeys.Send("{TAB}");
                    }
                    if (e.KeyChar == (char)Keys.Back)
                    {
                        SendKeys.Send("+{TAB}");
                    }
                    break;
                case 3:
                    if (char.IsNumber(e.KeyChar))
                    {
                        SendKeys.Send("{TAB}");
                    }
                    if (e.KeyChar == (char)Keys.Back)
                    {
                        SendKeys.Send("+{TAB}");
                    }
                    break;
                case 4:
                    if (e.KeyChar == (char)Keys.Back)
                    {
                        SendKeys.Send("+{TAB}");
                    }
                    break;
            }
        }
    }
}
