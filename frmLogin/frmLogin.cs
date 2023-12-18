using SGF.MODELO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SGF.NEGOCIO;


namespace frmLogin
{
    public partial class frmLogin : Form
    {
        N_Usuario cUsuario = N_Usuario.ObtenerInstancia;
        
        Usuario oUsuario;
        private bool contraseñaVisible { get; set; }
        public frmLogin()
        {
            InitializeComponent();
            contraseñaVisible = false;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsuarioG.Select();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        // Utilidades de interfaz
        private void alternarVisibilidadContraseña()
        {
            if (contraseñaVisible)
            {
                contraseñaVisible = false;
            }
            else
            {
                contraseñaVisible = true;
            }
        }

        private void mostrarContraseña()
        {
            txtContraseñaG.PasswordChar = '\0';
        }

    }
}
