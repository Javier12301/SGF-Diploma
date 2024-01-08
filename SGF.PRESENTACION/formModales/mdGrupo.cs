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
using System.Windows.Forms.VisualStyles;

namespace SGF.PRESENTACION.formModales
{
    public partial class mdGrupo : Form
    {
        private List<Modulo> listaModulos { get; set; }
        private List<Permiso> listaPermisos { get; set; }
        private UtilidadesUI lUtiliades = UtilidadesUI.ObtenerInstancia;
        private GrupoBLL lGrupo = GrupoBLL.ObtenerInstancia;
        private ModuloBLL lModulo = ModuloBLL.ObtenerInstancia;
        public mdGrupo()
        {
            InitializeComponent();
            listaPermisos = new List<Permiso>();
        }

        private void mdGrupo_Load(object sender, EventArgs e)
        {
            cargarModulos();
            // seleccionar tab page 0
            tcMain.SelectedIndex = 1;
        }

        private void chkPermisos_Changed(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                string nombreModulo = checkBox.Tag.ToString();
                string nombreAccion = checkBox.Text;
                bool estado = checkBox.Checked;

                // Actualizar el estado en el diccionario
                if (checkboxStates.ContainsKey(nombreModulo) && checkboxStates[nombreModulo].ContainsKey(nombreAccion))
                {
                    checkboxStates[nombreModulo][nombreAccion] = estado;
                }
            }
        }

        // ALTA DE GRUPO
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            altaGrupo();
        }

        // Manejo de responsabilidades
        private bool ValidarCampos()
        {
            bool camposValidos = true;
            camposValidos &= lUtiliades.VerificarTextbox(txtNombreGrupo, errorProvider, lblNombreGrupo);
            return camposValidos;
        }

        private Grupo CrearGrupo()
        {
            return new Grupo
            {
                Nombre = txtNombreGrupo.Text,
                Estado = chkEstado.Checked
            };
        }

        private void altaGrupo()
        {
            if (ValidarCampos())
            {
                Grupo grupo = CrearGrupo();
                bool grupoExiste = lGrupo.ExisteGrupo(grupo.Nombre);
                if (grupoExiste)
                {
                    errorProvider.SetError(lblNombreGrupo, "El nombre del grupo ya se encuentra en uso.");
                    MessageBox.Show("El nombre del grupo ya se encuentra en uso.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool resultado = lGrupo.
            }
        }

        // MODIFICAR GRUPO
        private void modificarGrupo()
        {

        }

        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Switch segun el nombre del tab page seleccionado
            switch (tcMain.SelectedTab.Name)
            {
                case "tpVentas":
                    lbAccionesVentas.SelectedIndex = 0;
                    tpVentas_Abierto();
                    break;
                case "tpProductos":
                    lbAccionesProductos.SelectedIndex = 0;
                    tpProductos_Abierto();
                    break;
                case "tpProveedores":
                    lbAccionesProveedor.SelectedIndex = 0;
                    tpProveedores_Abierto();
                    break;
                case "tpInventario":
                    lbAccionesInventario.SelectedIndex = 0;
                    tpInventario_Abierto();
                    break;
                case "tpRegistros":
                    lbAccionesRegistros.SelectedIndex = 0;
                    tpRegistros_Abierto();
                    break;
                case "tpReportes":
                    lbAccionesReportes.SelectedIndex = 0;
                    tpReportes_Abierto();
                    break;
                case "tpAjustes":
                    lbAccionesAjustes.SelectedIndex = 0;
                    tpAjustes_Abierto();
                    break;
                default:
                    break;
            }
        }

        private void lbAccionesVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tcMain.SelectedTab.Name)
            {
                case "tpVentas":
                    tpVentas_Abierto();
                    break;
                case "tpProductos":
                    tpProductos_Abierto();
                    break;
                case "tpProveedores":
                    tpProveedores_Abierto();
                    break;
                case "tpInventario":
                    tpInventario_Abierto();
                    break;
                case "tpRegistros":
                    tpRegistros_Abierto();
                    break;
                case "tpReportes":
                    tpReportes_Abierto();
                    break;
                case "tpAjustes":
                    tpAjustes_Abierto();
                    break;
                default:
                    break;
            }
        }

        // Pestañas de Formularios
        Dictionary<string, Dictionary<string, bool>> checkboxStates = new Dictionary<string, Dictionary<string, bool>>();
        private void ActualizarPermisos(string nombreModulo, FlowLayoutPanel flpPermisos)
        {
            try
            {
                Modulo modulo = listaModulos.FirstOrDefault(m => m.Descripcion == nombreModulo);

                List<Accion> accionesDisponibles = null;
                if (modulo != null)
                {
                    accionesDisponibles = modulo.ListaAcciones;
                }

                if (!checkboxStates.ContainsKey(nombreModulo))
                {
                    checkboxStates[nombreModulo] = new Dictionary<string, bool>();
                }

                foreach (Control control in flpPermisos.Controls)
                {
                    if (control is CheckBox && control.Text != null)
                    {
                        string nombreAccionBoton = control.Text.ToString();
                        bool tienePermiso = accionesDisponibles.Any(accion => accion.Descripcion == nombreAccionBoton);
                        control.Enabled = tienePermiso;
                        control.Visible = tienePermiso;

                        control.Tag = nombreModulo;

                        if (checkboxStates[nombreModulo].ContainsKey(nombreAccionBoton))
                        {
                            CheckBox checkbox = (CheckBox)control;
                            checkbox.Checked = checkboxStates[nombreModulo][nombreAccionBoton];
                        }
                        else
                        {
                            checkboxStates[nombreModulo][nombreAccionBoton] = false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Error al cargar los permisos del módulo {nombreModulo}. Intente nuevamente y si este error persiste contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tpVentas_Abierto()
        {
            try
            {
                if (lbAccionesVentas.SelectedItem.ToString() == "VENTAS")
                {
                    ActualizarPermisos("formVentas", flpPermisos);
                }
                else if (lbAccionesVentas.SelectedItem.ToString() == "CLIENTES")
                {
                    ActualizarPermisos("formClientes", flpPermisos);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los permisos del módulo Ventas, Intente nuevamente y si este error persiste contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tpProductos_Abierto()
        {
            try
            {
                if(lbAccionesProductos.SelectedItem.ToString() == "PRODUCTOS")
                {
                    ActualizarPermisos("formProductos", flpPermisosProductos);
                }else if(lbAccionesProductos.SelectedItem.ToString() == "CATEGORIAS")
                {
                    ActualizarPermisos("formCategorias", flpPermisosProductos);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los permisos del módulo Productos, Intente nuevamente y si este error persiste contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tpProveedores_Abierto()
        {
            if(lbAccionesProveedor.SelectedItem.ToString() == "PROVEEDORES")
            {
                ActualizarPermisos("formProveedores", flpPermisosProveedores);
            }
        }

        private void tpInventario_Abierto()
        {
            if(lbAccionesInventario.SelectedItem.ToString() == "INVENTARIO")
            {
                ActualizarPermisos("formInventario", flpPermisosInventario);
            }
        }

        private void tpRegistros_Abierto()
        {
            if(lbAccionesRegistros.SelectedItem.ToString() == "REGISTROS")
            {
                ActualizarPermisos("formRegistros", flpPermisosRegistros);
            }
        }
        private void tpReportes_Abierto()
        {
            if (lbAccionesReportes.SelectedItem.ToString() == "REPORTES")
            {
                ActualizarPermisos("formReportes", flpPermisosReportes);
            }
            else if (lbAccionesReportes.SelectedItem.ToString() == "REPORTES DE INVENTARIO")
            {
                ActualizarPermisos("formReporteInventario", flpPermisosReportes);
            }
            else if (lbAccionesReportes.SelectedItem.ToString() == "REPORTES DE VENTAS")
            {
                ActualizarPermisos("formReporteVentas", flpPermisosReportes);
            }else if(lbAccionesReportes.SelectedItem.ToString() == "REPORTES DE CLIENTES")
            {
                ActualizarPermisos("formReporteClientes", flpPermisosReportes);
            }
        }

        private void tpAjustes_Abierto()
        {
            lbSubMenuPerfiles.Items.Clear();
            if(lbAccionesAjustes.SelectedItem.ToString() == "AJUSTES")
            {
               ActualizarPermisos("formAjustes", flpPermisosAjustes);
            }else if(lbAccionesAjustes.SelectedItem.ToString() == "PERFILES")
            {
                lbSubMenuPerfiles.Items.Add("USUARIOS");
                lbSubMenuPerfiles.Items.Add("AUDITORIA");
                lbSubMenuPerfiles.Items.Add("GRUPOS");
                lbSubMenuPerfiles.Items.Add("MIS DATOS");
            }          
        }

        private void flpSubMenuPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSubMenuPerfiles.SelectedItem.ToString() == "USUARIOS")
            {
                ActualizarPermisos("formUsuarios", flpPermisosAjustes);
            }
            else if (lbSubMenuPerfiles.SelectedItem.ToString() == "GRUPOS")
            {
                ActualizarPermisos("formGrupos", flpPermisosAjustes);
            }
            else if (lbSubMenuPerfiles.SelectedItem.ToString() == "AUDITORIA")
            {
                ActualizarPermisos("formAuditoria", flpPermisosAjustes);
            }
            else if (lbSubMenuPerfiles.SelectedItem.ToString() == "MIS DATOS")
            {
                ActualizarPermisos("formMisDatos", flpPermisosAjustes);
            }
        }


        // Carga de Datos
        private void cargarModulos()
        {
            listaModulos = lModulo.ObtenerListaModulosDisponibles();
        }


        // Movimiento de ventana
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
