using SGF.NEGOCIO.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.formModales
{
    public partial class mdBackup : Form
    {
        public mdBackup()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea realizar un backup de la base de datos?", "Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(respuesta == DialogResult.Yes)
            {
                MessageBox.Show(BackupBLL.GenerarBackup());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = "C:\\Program Files\\Microsoft SQL Server\\MSSQL16.MSSQLSERVER\\MSSQL\\Backup";
            openFile.Filter = "Archivos de backup (*.bak)|*.bak";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = openFile.FileName;
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            if(txtRuta.Text != "")
            {
                MessageBox.Show(BackupBLL.RestaurarBackup(txtRuta.Text));
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo de backup");
            }
        }
    }
}
