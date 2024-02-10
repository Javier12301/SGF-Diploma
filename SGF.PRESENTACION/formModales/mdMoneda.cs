using SGF.MODELO.Negocio;
using SGF.NEGOCIO.Negocio;
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
    public partial class mdMoneda : Form
    {
        // Controladoras
        private NegocioBLL lNegocio = NegocioBLL.ObtenerInstancia;
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;

        public Moneda monedaAmodificar { get; set; }
        public int cantidadAntes { get; set; }
        public int cantidadDespues { get; set; }

        public mdMoneda(Moneda moneda)
        {
            InitializeComponent();
            monedaAmodificar = moneda;
        }

        private void mdMoneda_Load(object sender, EventArgs e)
        {
            try
            {
                if (monedaAmodificar != null)
                {
                    rbAntes.Checked = true;
                    txtID.Text = monedaAmodificar.MonedaID.ToString();
                    txtNombreMoneda.Text = monedaAmodificar.Nombre;
                    txtSimboloMoneda.Text = monedaAmodificar.Simbolo;
                    if (monedaAmodificar.Posicion == "Antes")
                        rbAntes.Checked = true;
                    else
                        rbDespues.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Manejo de resopnsabilidades
        private bool ValidarCampos()
        {
            bool camposValidos = true;

            camposValidos &= uiUtilidades.VerificarTextbox(txtNombreMoneda, errorProvider, lblNombre);
            camposValidos &= uiUtilidades.VerificarTextbox(txtSimboloMoneda, errorProvider, lblSimbolo);
            return camposValidos;
        }

        private Moneda CrearMonedaModificada()
        {
            return new Moneda
            {
                MonedaID = Convert.ToInt32(txtID.Text),
                Nombre = txtNombreMoneda.Text,
                Simbolo = txtSimboloMoneda.Text,
                Posicion = rbAntes.Checked ? "Antes" : "Después"
            };
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Moneda moneda = CrearMonedaModificada();
                if (monedaAmodificar.Nombre != moneda.Nombre)
                {
                    bool monedaExiste = lNegocio.ExisteMoneda(moneda.Nombre);
                    if (monedaExiste)
                    {
                        errorProvider.SetError(lblNombre, "Ya existe una moneda con este nombre");
                        MessageBox.Show("El nombre de la moneda ingresada ya existe. Por favor, ingrese un nombre diferente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                cantidadAntes = lNegocio.ConteoMonedas();
                bool resultado = lNegocio.ModificarMoneda(moneda);
                if (resultado)
                {
                    cantidadDespues = lNegocio.ConteoMonedas();
                    RegistroBLL.RegistrarMovimiento("Modificación", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), 1, cantidadAntes, cantidadDespues, "Monedas", $"Se modificó con éxito la moneda: {moneda.Nombre}");
                    MessageBox.Show("Se modificó con éxito la moneda.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo modificar la moneda. Por favor, vuelva a intentarlo y si el problema persiste, pónganse en contacto con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea cancelar la operación?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        // Manejo de interfaz
        // evento de radiobutton checkchanged
        private void radioButtos_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            string simboloMoneda = string.IsNullOrEmpty(txtSimboloMoneda.Text) ? "$" : txtSimboloMoneda.Text;
            if (rb.Name == rbDespues.Name)
            {
                // mostrar ejemplo de posición
                lblMuestraMoneda.Text = "543.21 " + simboloMoneda;
            }
            else
            {
                lblMuestraMoneda.Text = simboloMoneda + " 543.21";
            }
        }

        private Point mousePosicion;
        private void pnlControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int deltaX = e.X - mousePosicion.X;
                int deltaY = e.Y - mousePosicion.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }

        private void pnlControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousePosicion = e.Location;
            }
        }
    }
}
