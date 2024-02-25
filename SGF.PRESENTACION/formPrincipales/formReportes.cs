﻿using SGF.MODELO.Seguridad;
using SGF.NEGOCIO.Seguridad;
using SGF.PRESENTACION.formPrincipales.formHijos.Reportes.Inventario;
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
    public partial class formReportes : Form
    {
        private Form formularioActivo;
        private Button botonActivo;


        SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        Permiso permisoDeUsuario;

        public formReportes()
        {
            InitializeComponent();
        }

        private void formReportes_Load(object sender, EventArgs e)
        {
            cargarPermisos();
        }

        private void cargarPermisos()
        {
            permisoDeUsuario = new Permiso();
            uiUtilidades.cargarPermisos(this.GetType().Name, flpContenedorBotones, permisoDeUsuario);
        }

        private void activarBoton(Button btnSender)
        {
            if (btnSender != null)
            {
                if (botonActivo != btnSender)
                {
                    // Desactiva el botón que estaba activo
                    if (botonActivo != null)
                    {
                        desactivarBoton(botonActivo);
                    }

                    // Activamos el botón que fue presionado
                    botonActivo = btnSender;
                    // Color azul predeterminado del sistema
                    botonActivo.BackColor = Color.FromArgb(4, 127, 176);
                    // cambiamos el color del borde
                    // Color blanco para el texto
                    botonActivo.ForeColor = Color.White;
                }
            }
        }

        private void desactivarBoton(Button btnSender)
        {
            // Color blanco predeterminado del sistema
            btnSender.BackColor = Color.FromArgb(242, 248, 255);
            // cambiamos el color del borde a silver
            btnSender.ForeColor = Color.Black;
        }

        private void abrirFormularioHijo(Form formularioHijo, Button btnSender)
        {
            Cursor.Current = Cursors.WaitCursor;
            // Resaltamos el botón activado
            activarBoton(btnSender);

            // Si hay un formulario abierto, lo cerramos
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }
            // Abrimos el formulario hijo
            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            pnlReportesPadre.Controls.Add(formularioHijo);
            pnlReportesPadre.Tag = formularioHijo;
            // Ponemos al frente el formulario hijo
            formularioHijo.BringToFront();

            // Abrimos el formulario
            formularioHijo.Show();
            Cursor.Current = Cursors.Default;
        }


        private void btnEntradas_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new formReporteInventario(), btnInventario);
        }

        private void btnExistencias_Click(object sender, EventArgs e)
        {

        }

        private void btnSalidas_Click(object sender, EventArgs e)
        {

        }
    }
}
