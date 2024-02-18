using SGF.MODELO.Seguridad;
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

namespace SGF.PRESENTACION.formPrincipales.formHijos
{
    public partial class formAuditoria : Form
    {
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        List<Auditoria> listaAuditoria;
        private Permiso permisoDeUsuario;

        public formAuditoria()
        {
            InitializeComponent();
            listaAuditoria = new List<Auditoria>();
        }

        private void formAuditoria_Load(object sender, EventArgs e)
        {
            uiUtilidades.cargarPermisos(this.GetType().Name, flpContenedorBotones);
            cargarLista();
            cargarFiltros();
            cargarPermisos();
        }

        private void cargarPermisos()
        {
            permisoDeUsuario = new Permiso();
            uiUtilidades.cargarPermisos(this.GetType().Name, flpContenedorBotones, permisoDeUsuario);
        }

        // Manejo de filtros
        private void cargarLista()
        {
            if(txtBuscar.Text != string.Empty || cmbFiltroBuscar.SelectedIndex > 0 || cmbFiltroMovimiento.SelectedIndex > 0 || cmbFiltroUsuario.SelectedIndex > 0 )
            {
                filtrarLista();
            }
            else
            {
                this.auditoriaTableAdapter.Fill(this.farmaciaDatosDataSet.Auditoria);
            }
        }

        private void filtrarLista()
        {
            if(cmbFiltroBuscar.SelectedIndex == 0 && cmbFiltroMovimiento.SelectedIndex == 0 && cmbFiltroUsuario.SelectedIndex == 0 && string.IsNullOrEmpty(txtBuscar.Text))
            {
                this.auditoriaTableAdapter.Fill(this.farmaciaDatosDataSet.Auditoria);
            }
            else
            {
                this.auditoriaTableAdapter.Filtrar(farmaciaDatosDataSet.Auditoria, cmbFiltroUsuario.Text, cmbFiltroMovimiento.Text, cmbFiltroBuscar.Text, txtBuscar.Text, dtpInicio.Value, dtpFin.Value);
            }
        }

        // Cargar lista Auditoria
        private List<Auditoria> ObtenerListaAuditoria()
        {
            listaAuditoria = AuditoriaBLL.ObtenerListaAuditoria();
            return listaAuditoria;
        }

        private void cargarFiltros()
        {
            ObtenerListaAuditoria();
            // Filtro de buscar por
            cmbFiltroBuscar.Items.Add("Todo");
            cmbFiltroBuscar.Items.Add("Nombre Usuario");
            cmbFiltroBuscar.Items.Add("Movimiento");
            cmbFiltroBuscar.Items.Add("Descripcion");
            cmbFiltroBuscar.SelectedIndex = 0;

            // Filtro de fecha
            dtpInicio.Value = DateTime.Now.AddYears(-2);
            dtpFin.Value = DateTime.Now.AddYears(1);

            // Filtro de movimiento
            cmbFiltroMovimiento.Items.Add("Todos");
            foreach(var lista in listaAuditoria)
            {
                // Comprobar que no exista el movimiento en el combobox
                if(!cmbFiltroMovimiento.Items.Contains(lista.Movimiento))
                {
                    cmbFiltroMovimiento.Items.Add(lista.Movimiento);
                }
            }
            cmbFiltroMovimiento.SelectedIndex = 0;

            // Filtro de Nombre Usuario
            cmbFiltroUsuario.Items.Add("Todos");
            foreach(var lista in listaAuditoria)
            {
                // Comprobar que no exista el movimiento en el combobox
                if(!cmbFiltroUsuario.Items.Contains(lista.NombreUsuario))
                {
                    cmbFiltroUsuario.Items.Add(lista.NombreUsuario);
                }
            }
            cmbFiltroUsuario.SelectedIndex = 0;
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarLista();
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            this.auditoriaTableAdapter.Filtrar(farmaciaDatosDataSet.Auditoria, cmbFiltroUsuario.Text, cmbFiltroMovimiento.Text, cmbFiltroBuscar.Text, txtBuscar.Text, dtpInicio.Value, dtpFin.Value);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void dtpFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                this.auditoriaTableAdapter.Filtrar(farmaciaDatosDataSet.Auditoria, cmbFiltroUsuario.Text, cmbFiltroMovimiento.Text, cmbFiltroBuscar.Text, txtBuscar.Text, dtpInicio.Value, dtpFin.Value);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (permisoDeUsuario.Exportar)
                {
                    uiUtilidades.ExportarDataGridViewAExcel(dgvAuditoria, "Lista Auditoria", "Informe de Auditoria");
                    AuditoriaBLL.RegistrarMovimiento("Exportar", SesionBLL.ObtenerInstancia.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), "Se exporto con éxito la lista de auditoria.");
                }
                else
                {
                    MessageBox.Show("No tiene permisos para exportar la lista de auditoria.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AuditoriaBLL.RegistrarMovimiento("Exportar", SesionBLL.ObtenerInstancia.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), "Ocurrió un error al exportar la lista de usuarios.");
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
