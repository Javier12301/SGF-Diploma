﻿using SGF.PRESENTACION.formModales.Seguridad.formHijosPerfiles;
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
    public partial class formPerfiles : Form
    {
        private Form formularioActivo;
        private Button botonActivo;
        public formPerfiles()
        {
            InitializeComponent();
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

        // Abrir Formularios dentro del panel padre
        private void abrirFormularioHijo(Form formularioHijo, Button btnSender)
        {
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
            pnlPerfilesPadre.Controls.Add(formularioHijo);
            pnlPerfilesPadre.Tag = formularioHijo;
            // Ponemos al frente el formulario hijo
            formularioHijo.BringToFront();

            // Abrimos el formulario
            formularioHijo.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new formUsuarios(), btnUsuarios);

        }

        private void btnGrupos_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new formGrupos(), btnGrupos);
        }
    }
}
