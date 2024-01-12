using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.formPrincipales.formHijos
{
    public partial class formAuditoria : Form
    {
        public formAuditoria()
        {
            InitializeComponent();
        }

        private void formAuditoria_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'farmaciaDatosDataSet.Auditoria' Puede moverla o quitarla según sea necesario.
            this.auditoriaTableAdapter.Fill(this.farmaciaDatosDataSet.Auditoria);

        }
    }
}
