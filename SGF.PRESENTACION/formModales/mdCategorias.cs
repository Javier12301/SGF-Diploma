using SGF.MODELO;
using SGF.MODELO.Seguridad;
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
    public partial class mdCategorias : Form
    {
        UtilidadesUI uiUtilidades = UtilidadesUI.ObtenerInstancia;
        CategoriaBLL lCategoria = CategoriaBLL.ObtenerInstancia;
        SesionBLL lSesion = SesionBLL.ObtenerInstancia;

        private bool permisoAgregar { get; set; }
        private bool permisoModificar { get; set; }
        private bool permisoEliminar { get; set; }

        private int cantidadAntes { get; set; }
        private int cantidadDespues { get; set; }

        private Categoria oCategoriaPorModificar { get; set; }
        private bool modificandoCategoria { get; set; }
        public mdCategorias()
        {
            InitializeComponent();
            modificandoCategoria = false;
        }

        private void mdCategorias_Load(object sender, EventArgs e)
        {
            cargarEstado();
            cargarPermiso();
            cargarLista();
            cargarFiltro();
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!modificandoCategoria)
                {
                    altaCategoria();
                }
                else
                {
                    modificarCategoria();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Manejo de responsabilidades
        private bool ValidarCampos()
        {
            bool camposValidos = true;

            camposValidos &= uiUtilidades.VerificarTextbox(txtNombre, errorProvider, lblNombre);
            camposValidos &= uiUtilidades.VerificarCombobox(cmbEstado, errorProvider, lblEstado);

            return camposValidos;
        }

        private Categoria CrearCategoria()
        {
            return new Categoria
            {
                Nombre = txtNombre.Text,
                // Si la descripción no se ingresa nada poner un -
                Descripcion = txtDescripcion.Text == string.Empty ? "-" : txtDescripcion.Text,
                Estado = cmbEstado.SelectedItem.ToString() == "Activo" ? true : false
            };
        }

        private Categoria CrearCategoriaModificada()
        {
            return new Categoria
            {
                CategoriaID = Convert.ToInt32(txtID.Text),
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text == string.Empty ? "-" : txtDescripcion.Text,
                Estado = cmbEstado.SelectedItem.ToString() == "Activo" ? true : false
            };
        }

        // Alta
        private void altaCategoria()
        {
            if (ValidarCampos())
            {
                Categoria categoria = CrearCategoria();
                bool categoriaExiste = lCategoria.ExisteCategoria(categoria.Nombre);
                if (categoriaExiste)
                {
                    errorProvider.SetError(lblNombre, "Ya existe una categoría con ese nombre.");
                    MessageBox.Show("La categoría ingresada ya existe. Por favor, ingrese una categoría diferente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cantidadAntes = lCategoria.ConteoCategorias();
                bool resultado = lCategoria.AltaCategoria(categoria);

                if (resultado)
                {
                    cantidadDespues = lCategoria.ConteoCategorias();
                    MessageBox.Show("La categoría fue dada de alta con éxito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RegistroBLL.RegistrarMovimiento("Alta", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), 1, cantidadAntes, cantidadDespues, "Categorías", $"Se dio de alta con éxito la categoría: {categoria.Nombre}");

                    DialogResult respuesta = MessageBox.Show("¿Desea seguir agregando categorías?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.No)
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        cargarLista();
                        alternarModoEdicion();
                    }
                }
                else
                {
                    MessageBox.Show("Error al dar de alta la categoría. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Modificar
        private void modificarCategoria()
        {
            if (ValidarCampos())
            {
                Categoria categoria = CrearCategoriaModificada();

                bool categoriaExiste = false;
                if (oCategoriaPorModificar.Nombre != categoria.Nombre)
                {
                    categoriaExiste = lCategoria.ExisteCategoria(categoria.Nombre);
                    if (categoriaExiste)
                    {
                        errorProvider.SetError(lblNombre, "Ya existe una categoría con ese nombre.");
                        MessageBox.Show("La categoría ingresada ya existe. Por favor, ingrese una categoría diferente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                cantidadAntes = lCategoria.ConteoCategorias();
                bool resultado = lCategoria.ModificarCategoria(categoria);

                if (resultado)
                {
                    cantidadDespues = lCategoria.ConteoCategorias();
                    if (lCategoria.CategoriaTieneProductos(categoria.CategoriaID))
                    {
                        if (categoria.Estado == true)
                        {
                            DialogResult respuesta = MessageBox.Show("La categoría tiene productos asignados. ¿Desea activar todos los productos de la categoría?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (respuesta == DialogResult.Yes)
                            {
                                int cantidadProductosEnCategoria = lCategoria.ConteoProductosEnCategoria(categoria.CategoriaID);
                                int cantidadProductosHabilitados = lCategoria.HabilitarProductos(categoria.CategoriaID);
                                RegistroBLL.RegistrarMovimiento("Modificación", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), cantidadProductosHabilitados, cantidadProductosEnCategoria, cantidadProductosEnCategoria, "Categorías", $"Se habilitaron {cantidadProductosHabilitados} productos de la categoría: {categoria.Nombre}");
                            }
                        }
                        else
                        {
                            DialogResult respuesta = MessageBox.Show("La categoría tiene productos asignados. ¿Desea desactivar todos los productos de la categoría?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (respuesta == DialogResult.Yes)
                            {
                                int cantidadProductosEnCategoria = lCategoria.ConteoProductosEnCategoria(categoria.CategoriaID);
                                int cantidadProductosDeshabilitados = lCategoria.DeshabilitarProductos(categoria.CategoriaID);
                                RegistroBLL.RegistrarMovimiento("Modificación", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), cantidadProductosDeshabilitados, cantidadProductosEnCategoria, cantidadProductosEnCategoria, "Categorías" ,$"Se deshabilitaron {cantidadProductosDeshabilitados} productos de la categoría: {categoria.Nombre}");
                            }
                        }
                    }
                    RegistroBLL.RegistrarMovimiento("Modificación", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), 1, cantidadAntes, cantidadDespues, "Categorías", $"Se modifico con éxito la categoría: {categoria.Nombre}");
                    MessageBox.Show("La categoría fue modificada con éxito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult respuestaUsuario = MessageBox.Show("¿Desea seguir modificando categorías?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuestaUsuario == DialogResult.No)
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        modificandoCategoria = false;
                        alternarModoEdicion();
                        cargarLista();
                    }
                }
                else
                {
                    MessageBox.Show("Error al modificar la categoría. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Baja
        private void bajaCategoria(int categoriaID, string nombre)
        {
            try
            {
                string nombreCategoria = nombre;
                string operacion = string.Empty;
                DialogResult respuesta;
                Operacion categoriaAEliminar;
                // Comprobar si la categoría tiene productos asignados
                if (lCategoria.CategoriaTieneProductos(categoriaID))
                {
                    respuesta = MessageBox.Show("La categoría seleccionada tiene productos asignados, ¿desea asignar a los productos como sin categoría?", "Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (DialogResult.Yes == respuesta)
                    {
                        operacion = "AsignarProductosSinCategoria";
                    }
                    else if (DialogResult.No == respuesta)
                    {
                        respuesta = MessageBox.Show("¿Desea eliminar la categoría y los productos asignados a esta?", "Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (DialogResult.Yes == respuesta)
                        {
                            operacion = "EliminarCategoriaYProductos";
                        }
                        else
                        {
                            MessageBox.Show("Operación cancelada.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Operación cancelada.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
                else
                {
                    operacion = "EliminarCategoria";
                }

                categoriaAEliminar = new Operacion
                {
                    ID = categoriaID,
                    Nombre = nombreCategoria,
                    NombreOperacion = operacion
                };

                bool resultado = lCategoria.BajaCategoria(categoriaAEliminar);
                if (resultado)
                {
                    RegistroBLL.RegistrarMovimiento("Baja", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), 1, cantidadAntes, cantidadDespues, "Categorías" ,$"Se dio de baja con éxito la categoría: {nombreCategoria}");
                    MessageBox.Show("La categoría fue eliminada con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarLista();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la categoría. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void cargarPermiso()
        {
            string nombreFormulario = "formCategorias";
            List<Modulo> modulosPermitidos = lSesion.UsuarioEnSesion().Usuario.ObtenerModulosPermitidos();

            // Buscar modulo correspondiente del formulario actual
            Modulo moduloActual = modulosPermitidos.FirstOrDefault(m => m.Descripcion == nombreFormulario);

            // Si el modulo se encuentra cargar permisos
            if (moduloActual != null)
            {
                permisoAgregar = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Alta");
                permisoModificar = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Modificar");
                permisoEliminar = moduloActual.ListaAcciones.Any(accion => accion.Descripcion == "Baja");

                if (permisoAgregar)
                {
                    HabilitarCampos();
                }
                else
                {
                    DeshabilitarCampos();
                }

                dgvcModificar.Visible = permisoModificar;
                dgvcEliminar.Visible = permisoEliminar;
            }
            else
            {
                MessageBox.Show("No tiene permisos para acceder a este módulo. Por favor, póngase en contacto con el administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void HabilitarCampos()
        {
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
            cmbEstado.Enabled = true;
            btnGuardar.Enabled = true;
        }

        private void DeshabilitarCampos()
        {
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            cmbEstado.Enabled = false;
            btnGuardar.Enabled = false;
        }

        // Manejo de filtros
        private void cargarLista()
        {
            if (txtBusqueda.Text != string.Empty || cmbFiltroEstado.SelectedIndex > 0)
            {
                filtrarLista();
            }
            else
            {
                this.categoriaTableAdapter.Fill(this.negocio.Categoria);
            }
        }

        private void filtrarLista()
        {
            if (string.IsNullOrEmpty(txtBusqueda.Text) && cmbFiltroEstado.SelectedIndex == 0)
            {
                this.categoriaTableAdapter.Fill(this.negocio.Categoria);
            }
            else
            {
                this.categoriaTableAdapter.Filtrar(this.negocio.Categoria, cmbFiltroEstado.Text, txtBusqueda.Text);
            }
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            filtrarLista();
        }

        private void cargarEstado()
        {
            cmbEstado.Items.Add("Selecccione el estado...");
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
            cmbEstado.SelectedIndex = 0;
        }

        private void cargarFiltro()
        {
            cmbFiltroEstado.Items.Add("Todos");
            cmbFiltroEstado.Items.Add("Activo");
            cmbFiltroEstado.Items.Add("Inactivo");
            cmbFiltroEstado.SelectedIndex = 0;
        }


        // Manejo de Interfaz

        private void alternarModoEdicion(Categoria oCategoria = null)
        {
            if (oCategoria != null && modificandoCategoria && permisoModificar)
            {
                HabilitarCampos();
                oCategoriaPorModificar = oCategoria;
                txtID.Text = oCategoria.CategoriaID.ToString();
                txtNombre.Text = oCategoria.Nombre;
                txtDescripcion.Text = oCategoria.Descripcion;
                cmbEstado.SelectedIndex = oCategoria.Estado == true ? 1 : 2;
                // Boton modificar
                btnGuardar.BackColor = Color.DarkOrange;
                btnGuardar.Text = "Modificar";
            }
            else if (!permisoModificar)
            {
                MessageBox.Show("No tiene permisos para realizar esta acción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                oCategoriaPorModificar = null;
                // limpiar campos
                uiUtilidades.LimpiarTextbox(txtID, txtNombre, txtDescripcion);
                uiUtilidades.LimpiarCombobox(cmbEstado);
                // cambair el color del botón
                btnGuardar.BackColor = Color.FromArgb(38, 125, 166);
                btnGuardar.Text = "Guardar";
                if (permisoAgregar)
                {
                    HabilitarCampos();
                }
                else
                {
                    DeshabilitarCampos();
                }
            }
        }

        private void dgvCategorias_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }

                // Nombre de la columna
                string nombreColumna = dgvCategorias.Columns[e.ColumnIndex].Name;

                // Botón modificar
                if (nombreColumna == "dgvcModificar" && permisoModificar)
                {
                    // Se crearan los botones, pero su estado de enabled será verificado utilizando los permisos del usuario
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    // Propiedades de la imagen
                    var w = Properties.Resources.modificar_boton_15.Width;
                    var h = Properties.Resources.modificar_boton_15.Height;
                    var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                    // Dibujar imagen
                    e.Graphics.DrawImage(Properties.Resources.modificar_boton_15, new Rectangle(x, y, w, h));
                    e.Handled = true;
                }

                // Botón eliminar
                if (nombreColumna == "dgvcEliminar" && permisoEliminar)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    // Propiedades de la imagen
                    var w = Properties.Resources.eliminar_boton_15.Width;
                    var h = Properties.Resources.eliminar_boton_15.Height;
                    var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                    // Dibujar imagen
                    e.Graphics.DrawImage(Properties.Resources.eliminar_boton_15, new Rectangle(x, y, w, h));
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + " Contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCategorias.Columns[e.ColumnIndex].Name == "dgvcModificar" && permisoModificar)
                {
                    // Modificar categoría seleccionada
                    int indice = e.RowIndex;
                    if (indice >= 0)
                    {
                        // Obtener id de la categoría
                        int categoriaID = Convert.ToInt32(dgvCategorias.Rows[indice].Cells["dgvcID"].Value);
                        // Pasar datos de la categoría al formulario
                        Categoria oCategoria = lCategoria.ObtenerCategoriaPorID(categoriaID);
                        modificandoCategoria = true;
                        alternarModoEdicion(oCategoria);
                    }
                }
                else if (!permisoModificar)
                {
                    MessageBox.Show("Error: No tiene permisos para realizar esta acción.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (dgvCategorias.Columns[e.ColumnIndex].Name == "dgvcEliminar" && permisoEliminar)
                {
                    int indice = e.RowIndex;
                    if (indice >= 0)
                    {
                        string nombreCategoria = dgvCategorias.Rows[indice].Cells["dgvcNombre"].Value.ToString();
                        int categoriaID = Convert.ToInt32(dgvCategorias.Rows[indice].Cells["dgvcID"].Value);
                        DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar la categoría " + nombreCategoria + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.Yes)
                        {
                            bajaCategoria(categoriaID, nombreCategoria);
                            cargarLista();
                        }
                    }
                }
                else if (!permisoEliminar)
                {
                    MessageBox.Show("Error: No tiene permisos para realizar esta acción.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + " Contacte con el administrador del sistema.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cmbEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            // al presionar enter 
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (cmbEstado.SelectedIndex == cmbEstado.Items.Count - 1)
                {
                    cmbEstado.SelectedIndex = 0;
                }
                else
                {
                    cmbEstado.SelectedIndex++;
                }
            }
        }

        // SOLUCIONAR ERROR CADENA DE ENTRADA
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!modificandoCategoria)
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro que desea salir?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == resultado)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                DialogResult resultado = MessageBox.Show("¿Desea cancelar la modificación de la categoría?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == resultado)
                {
                    modificandoCategoria = false;
                    alternarModoEdicion();
                    MessageBox.Show("Operación cancelada.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }



}
