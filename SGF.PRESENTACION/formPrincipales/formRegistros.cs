﻿using SGF.MODELO.Seguridad;
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

namespace SGF.PRESENTACION.formPrincipales
{
    public partial class formRegistros : Form
    {
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        public formRegistros()
        {
            InitializeComponent();
        }

        private void formRegistros_Load(object sender, EventArgs e)
        {
            uiUtilidades.cargarPermisos(this.GetType().Name, flpContenedorBotones);
        }

    }
}
