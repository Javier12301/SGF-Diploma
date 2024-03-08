using SGF.MODELO.Seguridad;
using SGF.NEGOCIO.Seguridad;
using SGF.PRESENTACION.formModales.Seguridad.formHijosAuditoria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGF.PRESENTACION.formModales.Seguridad
{
    public partial class mdDetalleAuditoria : Form
    {
        private Permiso permisoAuditoria { get; set; }
        private int AuditoriaID { get; set; }
        private Form formularioActivo;


        public mdDetalleAuditoria(Permiso permisoUsuario, int auditoriaID = 0)
        {
            permisoAuditoria = permisoUsuario;
            AuditoriaID = auditoriaID;
            InitializeComponent();
        }

        // Auditoria permitirá visualizar detalles de productos y clientes
        private void mdDetalleAuditoria_Load(object sender, EventArgs e)
        {
            try
            {
                if (permisoAuditoria.Detalles)
                {
                    if(AuditoriaID > 0)
                    {
                        Auditoria oAuditoria = AuditoriaBLL.ObtenerAuditoriaID(AuditoriaID);
                        // Obtener detalles, si el detalle es un "-" se mostrará un mensaje que no está disponible el detalle para este modulo
                        if(oAuditoria.Detalles == "-")
                        {
                            MessageBox.Show("No está disponible los detalles para este módulo", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        cargarDatosAuditoria(oAuditoria);
                        abrirFormularioHijo(new formDetalleProductos(oAuditoria));
                        
                    }
                    else
                    {
                        MessageBox.Show("No se ha seleccionado una de las auditorías de la lista", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("No tiene permisos para ver los detalles de la auditoría", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cargarDatosAuditoria(Auditoria auditoria)
        {
            if(auditoria != null)
            {
                lblUsuario.Text = auditoria.NombreUsuario;
                lblModulo.Text = auditoria.Modulo;
                lblMovimiento.Text = auditoria.Movimiento;
                lblFecha.Text = auditoria.FechayHora.ToString("dd/MM/yy");
            }
            else
            {
                throw new Exception("Ocurrió un error al cargar los datos de la auditoría, por favor contacte al administrador para solucionar este error.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Código de formularios padre e hijo
        private void abrirFormularioHijo(Form formularioHijo)
        {
            // Resaltamos el botón activado
            Cursor.Current = Cursors.WaitCursor;

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
            pnlDetallesPadre.Controls.Add(formularioHijo);
            pnlDetallesPadre.Tag = formularioHijo;
            // Ponemos al frente el formulario hijo
            formularioHijo.BringToFront();

            // Abrimos el formulario
            formularioHijo.Show();
            Cursor.Current = Cursors.Default;
        }

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
