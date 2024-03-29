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

namespace SGF.PRESENTACION.formModales
{
    public partial class mdAjustes : Form
    {
        public string OpcionSeleccionada { get; set; }
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        public mdAjustes()
        {
            InitializeComponent();
            OpcionSeleccionada = string.Empty;
        }

        private void mdAjustes_Load(object sender, EventArgs e)
        {
            uiUtilidades.cargarPermisos("formAjustes", flpContenedorBotones);
        }

        private void btnPerfiles_Click(object sender, EventArgs e)
        {
            OpcionSeleccionada = "Perfiles";
            this.Close();
        }


        private void btnNegocio_Click(object sender, EventArgs e)
        {
            OpcionSeleccionada = "Negocio";
            this.Close();
        }

        private void btnBaseDatos_Click(object sender, EventArgs e)
        {
            using(var modal = new mdBackup())
            {
                modal.ShowDialog();
                this.Close();
            }
        }


        private void btnOtrasConfiguraciones_Click(object sender, EventArgs e)
        {
            OpcionSeleccionada = "Configuraciones";
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Interfaz
        private Point mousePosicion;
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousePosicion = e.Location;
            }
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int deltaX = e.X - mousePosicion.X;
                int deltaY = e.Y - mousePosicion.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }

       
    }
}
