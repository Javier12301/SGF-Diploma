namespace SGF.PRESENTACION.formPrincipales
{
    partial class formProductos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProductos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsdMostrar = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsMenuProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiID = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCodigo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNombre = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStock = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTipoProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrecioVenta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrecioCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEstado = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuMedicamento = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLote = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVencimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefrigerado = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReceta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProveedor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNombreCategoria = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.dgvcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTipoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcPrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcPrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcRefrigerado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvcReceta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvcEstado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.productoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.negocio = new SGF.PRESENTACION.Negocio();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flpVencimiento = new System.Windows.Forms.FlowLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.chkVencimiento = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cmbFiltroBuscar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flpContenedorBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNuevoP = new System.Windows.Forms.Button();
            this.btnModificarP = new System.Windows.Forms.Button();
            this.btnEliminarP = new System.Windows.Forms.Button();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnImportarP = new System.Windows.Forms.Button();
            this.btnExportarP = new System.Windows.Forms.Button();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnpCantidadDeItems = new System.Windows.Forms.ToolStripLabel();
            this.bnpUltimoItem = new System.Windows.Forms.ToolStripButton();
            this.bnpSiguienteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bnpNumeroItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bnpItemAnterior = new System.Windows.Forms.ToolStripButton();
            this.bnpPrimerItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbFiltroCategoria = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbFiltroEstado = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.cmbFiltroTipoProducto = new System.Windows.Forms.ToolStripComboBox();
            this.productoTableAdapter = new SGF.PRESENTACION.NegocioTableAdapters.ProductoTableAdapter();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.negocio)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flpVencimiento.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.flpContenedorBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.flpContenedorBotones);
            this.panel1.Controls.Add(this.bindingNavigator1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 448);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.toolStrip1);
            this.panel5.Controls.Add(this.dgvProductos);
            this.panel5.Location = new System.Drawing.Point(5, 149);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1073, 247);
            this.panel5.TabIndex = 110;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(141)))), ((int)(((byte)(196)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.tsdMostrar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1073, 25);
            this.toolStrip1.TabIndex = 111;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsdMostrar
            // 
            this.tsdMostrar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuProducto,
            this.tsMenuMedicamento,
            this.tsmiProveedor,
            this.tsmiNombreCategoria});
            this.tsdMostrar.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.tsdMostrar.ForeColor = System.Drawing.Color.White;
            this.tsdMostrar.Image = global::SGF.PRESENTACION.Properties.Resources.checkList_Blanco;
            this.tsdMostrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdMostrar.Name = "tsdMostrar";
            this.tsdMostrar.Size = new System.Drawing.Size(151, 22);
            this.tsdMostrar.Text = "Mostrar Columnas";
            this.tsdMostrar.DropDownClosed += new System.EventHandler(this.tsdMostrar_DropDownClosed);
            this.tsdMostrar.DropDownOpened += new System.EventHandler(this.tsdMostrar_DropDownOpened);
            // 
            // tsMenuProducto
            // 
            this.tsMenuProducto.Checked = true;
            this.tsMenuProducto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsMenuProducto.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiID,
            this.tsmiCodigo,
            this.tsmiNombre,
            this.tsmiStock,
            this.tsmiTipoProducto,
            this.tsmiPrecioVenta,
            this.tsmiPrecioCompra,
            this.tsmiEstado});
            this.tsMenuProducto.Name = "tsMenuProducto";
            this.tsMenuProducto.Size = new System.Drawing.Size(162, 22);
            this.tsMenuProducto.Text = "Producto";
            this.tsMenuProducto.CheckedChanged += new System.EventHandler(this.tsmiMenu_CheckChanged);
            this.tsMenuProducto.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiID
            // 
            this.tsmiID.Checked = true;
            this.tsmiID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiID.Name = "tsmiID";
            this.tsmiID.Size = new System.Drawing.Size(167, 22);
            this.tsmiID.Text = "ID";
            this.tsmiID.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiID.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiCodigo
            // 
            this.tsmiCodigo.Checked = true;
            this.tsmiCodigo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiCodigo.Name = "tsmiCodigo";
            this.tsmiCodigo.Size = new System.Drawing.Size(167, 22);
            this.tsmiCodigo.Text = "Código";
            this.tsmiCodigo.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiCodigo.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiNombre
            // 
            this.tsmiNombre.Checked = true;
            this.tsmiNombre.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiNombre.Name = "tsmiNombre";
            this.tsmiNombre.Size = new System.Drawing.Size(167, 22);
            this.tsmiNombre.Text = "Nombre";
            this.tsmiNombre.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiNombre.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiStock
            // 
            this.tsmiStock.Checked = true;
            this.tsmiStock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiStock.Name = "tsmiStock";
            this.tsmiStock.Size = new System.Drawing.Size(167, 22);
            this.tsmiStock.Text = "Stock";
            this.tsmiStock.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiStock.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiTipoProducto
            // 
            this.tsmiTipoProducto.Checked = true;
            this.tsmiTipoProducto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiTipoProducto.Name = "tsmiTipoProducto";
            this.tsmiTipoProducto.Size = new System.Drawing.Size(167, 22);
            this.tsmiTipoProducto.Text = "Tipo Producto";
            this.tsmiTipoProducto.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiTipoProducto.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiPrecioVenta
            // 
            this.tsmiPrecioVenta.Checked = true;
            this.tsmiPrecioVenta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiPrecioVenta.Name = "tsmiPrecioVenta";
            this.tsmiPrecioVenta.Size = new System.Drawing.Size(167, 22);
            this.tsmiPrecioVenta.Text = "Precio Venta";
            this.tsmiPrecioVenta.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiPrecioVenta.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiPrecioCompra
            // 
            this.tsmiPrecioCompra.Checked = true;
            this.tsmiPrecioCompra.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiPrecioCompra.Name = "tsmiPrecioCompra";
            this.tsmiPrecioCompra.Size = new System.Drawing.Size(167, 22);
            this.tsmiPrecioCompra.Text = "Precio Compra";
            this.tsmiPrecioCompra.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiPrecioCompra.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiEstado
            // 
            this.tsmiEstado.Checked = true;
            this.tsmiEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiEstado.Name = "tsmiEstado";
            this.tsmiEstado.Size = new System.Drawing.Size(167, 22);
            this.tsmiEstado.Text = "Estado";
            this.tsmiEstado.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsMenuMedicamento
            // 
            this.tsMenuMedicamento.Checked = true;
            this.tsMenuMedicamento.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsMenuMedicamento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLote,
            this.tsmiVencimiento,
            this.tsmiRefrigerado,
            this.tsmiReceta});
            this.tsMenuMedicamento.Name = "tsMenuMedicamento";
            this.tsMenuMedicamento.Size = new System.Drawing.Size(162, 22);
            this.tsMenuMedicamento.Text = "Medicamento";
            this.tsMenuMedicamento.CheckedChanged += new System.EventHandler(this.tsmiMenu_CheckChanged);
            this.tsMenuMedicamento.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiLote
            // 
            this.tsmiLote.Checked = true;
            this.tsmiLote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiLote.Name = "tsmiLote";
            this.tsmiLote.Size = new System.Drawing.Size(155, 22);
            this.tsmiLote.Text = "Lote";
            this.tsmiLote.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiLote.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiVencimiento
            // 
            this.tsmiVencimiento.Checked = true;
            this.tsmiVencimiento.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiVencimiento.Name = "tsmiVencimiento";
            this.tsmiVencimiento.Size = new System.Drawing.Size(155, 22);
            this.tsmiVencimiento.Text = "Vencimiento";
            this.tsmiVencimiento.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiVencimiento.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiRefrigerado
            // 
            this.tsmiRefrigerado.Checked = true;
            this.tsmiRefrigerado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiRefrigerado.Name = "tsmiRefrigerado";
            this.tsmiRefrigerado.Size = new System.Drawing.Size(155, 22);
            this.tsmiRefrigerado.Text = "Refrigerado";
            this.tsmiRefrigerado.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiRefrigerado.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiReceta
            // 
            this.tsmiReceta.Checked = true;
            this.tsmiReceta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiReceta.Name = "tsmiReceta";
            this.tsmiReceta.Size = new System.Drawing.Size(155, 22);
            this.tsmiReceta.Text = "Receta";
            this.tsmiReceta.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiReceta.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiProveedor
            // 
            this.tsmiProveedor.Checked = true;
            this.tsmiProveedor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiProveedor.Name = "tsmiProveedor";
            this.tsmiProveedor.Size = new System.Drawing.Size(162, 22);
            this.tsmiProveedor.Text = "Proveedor";
            this.tsmiProveedor.CheckStateChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiProveedor.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiNombreCategoria
            // 
            this.tsmiNombreCategoria.Checked = true;
            this.tsmiNombreCategoria.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiNombreCategoria.Name = "tsmiNombreCategoria";
            this.tsmiNombreCategoria.Size = new System.Drawing.Size(162, 22);
            this.tsmiNombreCategoria.Text = "Categoría";
            this.tsmiNombreCategoria.CheckStateChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiNombreCategoria.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.AutoGenerateColumns = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductos.ColumnHeadersHeight = 40;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcID,
            this.dgvcCodigo,
            this.dgvcNombre,
            this.dgvcProveedor,
            this.dgvcCategoria,
            this.dgvcStock,
            this.dgvcLote,
            this.dgvcVencimiento,
            this.dgvcTipoProducto,
            this.dgvcPrecioVenta,
            this.dgvcPrecioCompra,
            this.dgvcRefrigerado,
            this.dgvcReceta,
            this.dgvcEstado});
            this.dgvProductos.DataSource = this.productoBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProductos.GridColor = System.Drawing.Color.White;
            this.dgvProductos.Location = new System.Drawing.Point(0, 28);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Roboto", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.Size = new System.Drawing.Size(1073, 216);
            this.dgvProductos.TabIndex = 110;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellEnter);
            this.dgvProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducto_CellDoubleClick);
            this.dgvProductos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellEnter);
            this.dgvProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProductos_KeyDown);
            // 
            // dgvcID
            // 
            this.dgvcID.DataPropertyName = "ProductoID";
            this.dgvcID.HeaderText = "ID";
            this.dgvcID.Name = "dgvcID";
            this.dgvcID.ReadOnly = true;
            // 
            // dgvcCodigo
            // 
            this.dgvcCodigo.DataPropertyName = "CodigoBarras";
            this.dgvcCodigo.HeaderText = "Código";
            this.dgvcCodigo.Name = "dgvcCodigo";
            this.dgvcCodigo.ReadOnly = true;
            // 
            // dgvcNombre
            // 
            this.dgvcNombre.DataPropertyName = "Nombre";
            this.dgvcNombre.HeaderText = "Nombre";
            this.dgvcNombre.Name = "dgvcNombre";
            this.dgvcNombre.ReadOnly = true;
            // 
            // dgvcProveedor
            // 
            this.dgvcProveedor.DataPropertyName = "Proveedor";
            this.dgvcProveedor.HeaderText = "Proveedor";
            this.dgvcProveedor.Name = "dgvcProveedor";
            this.dgvcProveedor.ReadOnly = true;
            // 
            // dgvcCategoria
            // 
            this.dgvcCategoria.DataPropertyName = "Categoria";
            this.dgvcCategoria.HeaderText = "Categoria";
            this.dgvcCategoria.Name = "dgvcCategoria";
            this.dgvcCategoria.ReadOnly = true;
            // 
            // dgvcStock
            // 
            this.dgvcStock.DataPropertyName = "Stock";
            this.dgvcStock.HeaderText = "Stock";
            this.dgvcStock.Name = "dgvcStock";
            this.dgvcStock.ReadOnly = true;
            // 
            // dgvcLote
            // 
            this.dgvcLote.DataPropertyName = "NumeroLote";
            this.dgvcLote.HeaderText = "Lote";
            this.dgvcLote.Name = "dgvcLote";
            this.dgvcLote.ReadOnly = true;
            // 
            // dgvcVencimiento
            // 
            this.dgvcVencimiento.DataPropertyName = "FechaVencimiento";
            this.dgvcVencimiento.HeaderText = "Vencimiento";
            this.dgvcVencimiento.Name = "dgvcVencimiento";
            this.dgvcVencimiento.ReadOnly = true;
            // 
            // dgvcTipoProducto
            // 
            this.dgvcTipoProducto.DataPropertyName = "TipoProducto";
            this.dgvcTipoProducto.HeaderText = "Tipo Producto";
            this.dgvcTipoProducto.Name = "dgvcTipoProducto";
            this.dgvcTipoProducto.ReadOnly = true;
            // 
            // dgvcPrecioVenta
            // 
            this.dgvcPrecioVenta.DataPropertyName = "PrecioVenta";
            this.dgvcPrecioVenta.HeaderText = "Precio venta";
            this.dgvcPrecioVenta.Name = "dgvcPrecioVenta";
            this.dgvcPrecioVenta.ReadOnly = true;
            // 
            // dgvcPrecioCompra
            // 
            this.dgvcPrecioCompra.DataPropertyName = "PrecioCompra";
            this.dgvcPrecioCompra.HeaderText = "Precio compra";
            this.dgvcPrecioCompra.Name = "dgvcPrecioCompra";
            this.dgvcPrecioCompra.ReadOnly = true;
            // 
            // dgvcRefrigerado
            // 
            this.dgvcRefrigerado.DataPropertyName = "Refrigerado";
            this.dgvcRefrigerado.HeaderText = "Refrigerado";
            this.dgvcRefrigerado.Name = "dgvcRefrigerado";
            this.dgvcRefrigerado.ReadOnly = true;
            // 
            // dgvcReceta
            // 
            this.dgvcReceta.DataPropertyName = "BajoReceta";
            this.dgvcReceta.HeaderText = "Receta";
            this.dgvcReceta.Name = "dgvcReceta";
            this.dgvcReceta.ReadOnly = true;
            // 
            // dgvcEstado
            // 
            this.dgvcEstado.DataPropertyName = "Estado";
            this.dgvcEstado.HeaderText = "Estado";
            this.dgvcEstado.Name = "dgvcEstado";
            this.dgvcEstado.ReadOnly = true;
            // 
            // productoBindingSource
            // 
            this.productoBindingSource.DataMember = "Producto";
            this.productoBindingSource.DataSource = this.negocio;
            // 
            // negocio
            // 
            this.negocio.DataSetName = "Negocio";
            this.negocio.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(883, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 81);
            this.panel2.TabIndex = 108;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lblEstado);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(184, 71);
            this.panel3.TabIndex = 7;
            // 
            // lblEstado
            // 
            this.lblEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstado.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(37, 38);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(109, 18);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.Text = "--------";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(68, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Estado";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.flpVencimiento);
            this.panel4.Controls.Add(this.chkVencimiento);
            this.panel4.Controls.Add(this.btnBuscar);
            this.panel4.Controls.Add(this.txtBuscar);
            this.panel4.Controls.Add(this.cmbFiltroBuscar);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(5, 89);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1073, 54);
            this.panel4.TabIndex = 107;
            // 
            // flpVencimiento
            // 
            this.flpVencimiento.Controls.Add(this.panel6);
            this.flpVencimiento.Controls.Add(this.panel7);
            this.flpVencimiento.Location = new System.Drawing.Point(192, 5);
            this.flpVencimiento.Name = "flpVencimiento";
            this.flpVencimiento.Size = new System.Drawing.Size(347, 43);
            this.flpVencimiento.TabIndex = 100;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.dtpInicio);
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(167, 35);
            this.panel6.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Desde";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(55, 7);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(103, 23);
            this.dtpInicio.TabIndex = 5;
            this.dtpInicio.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.dtpFin);
            this.panel7.Location = new System.Drawing.Point(176, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(167, 35);
            this.panel7.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Hasta";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFin
            // 
            this.dtpFin.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(52, 7);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(103, 23);
            this.dtpFin.TabIndex = 7;
            this.dtpFin.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // chkVencimiento
            // 
            this.chkVencimiento.AutoSize = true;
            this.chkVencimiento.Checked = true;
            this.chkVencimiento.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVencimiento.Location = new System.Drawing.Point(545, 19);
            this.chkVencimiento.Name = "chkVencimiento";
            this.chkVencimiento.Size = new System.Drawing.Size(84, 17);
            this.chkVencimiento.TabIndex = 99;
            this.chkVencimiento.Text = "Vencimiento";
            this.chkVencimiento.UseVisualStyleBackColor = true;
            this.chkVencimiento.CheckedChanged += new System.EventHandler(this.chkVencimiento_CheckedChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar.IconColor = System.Drawing.Color.Black;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 16;
            this.btnBuscar.Location = new System.Drawing.Point(1034, 14);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(29, 23);
            this.btnBuscar.TabIndex = 96;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.txtBuscar.Location = new System.Drawing.Point(840, 14);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(188, 23);
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // cmbFiltroBuscar
            // 
            this.cmbFiltroBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFiltroBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroBuscar.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltroBuscar.FormattingEnabled = true;
            this.cmbFiltroBuscar.Location = new System.Drawing.Point(721, 14);
            this.cmbFiltroBuscar.Name = "cmbFiltroBuscar";
            this.cmbFiltroBuscar.Size = new System.Drawing.Size(113, 23);
            this.cmbFiltroBuscar.TabIndex = 2;
            this.cmbFiltroBuscar.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelecteIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(635, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Buscar por:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista de productos";
            // 
            // flpContenedorBotones
            // 
            this.flpContenedorBotones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpContenedorBotones.BackColor = System.Drawing.Color.LightGray;
            this.flpContenedorBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpContenedorBotones.Controls.Add(this.btnNuevoP);
            this.flpContenedorBotones.Controls.Add(this.btnModificarP);
            this.flpContenedorBotones.Controls.Add(this.btnEliminarP);
            this.flpContenedorBotones.Controls.Add(this.btnCategorias);
            this.flpContenedorBotones.Controls.Add(this.btnImportarP);
            this.flpContenedorBotones.Controls.Add(this.btnExportarP);
            this.flpContenedorBotones.Location = new System.Drawing.Point(0, 4);
            this.flpContenedorBotones.Margin = new System.Windows.Forms.Padding(4);
            this.flpContenedorBotones.Name = "flpContenedorBotones";
            this.flpContenedorBotones.Size = new System.Drawing.Size(840, 81);
            this.flpContenedorBotones.TabIndex = 106;
            // 
            // btnNuevoP
            // 
            this.btnNuevoP.BackColor = System.Drawing.Color.White;
            this.btnNuevoP.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnNuevoP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoP.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoP.ForeColor = System.Drawing.Color.Black;
            this.btnNuevoP.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoP.Image")));
            this.btnNuevoP.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevoP.Location = new System.Drawing.Point(4, 4);
            this.btnNuevoP.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevoP.Name = "btnNuevoP";
            this.btnNuevoP.Size = new System.Drawing.Size(112, 73);
            this.btnNuevoP.TabIndex = 9;
            this.btnNuevoP.Tag = "Alta";
            this.btnNuevoP.Text = "Nuevo";
            this.btnNuevoP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevoP.UseVisualStyleBackColor = false;
            this.btnNuevoP.Click += new System.EventHandler(this.btnNuevoP_Click);
            // 
            // btnModificarP
            // 
            this.btnModificarP.BackColor = System.Drawing.Color.White;
            this.btnModificarP.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnModificarP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarP.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarP.ForeColor = System.Drawing.Color.Black;
            this.btnModificarP.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarP.Image")));
            this.btnModificarP.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnModificarP.Location = new System.Drawing.Point(124, 4);
            this.btnModificarP.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificarP.Name = "btnModificarP";
            this.btnModificarP.Size = new System.Drawing.Size(112, 73);
            this.btnModificarP.TabIndex = 10;
            this.btnModificarP.Tag = "Modificar";
            this.btnModificarP.Text = "Modificar";
            this.btnModificarP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnModificarP.UseVisualStyleBackColor = false;
            this.btnModificarP.Click += new System.EventHandler(this.btnModificarP_Click);
            // 
            // btnEliminarP
            // 
            this.btnEliminarP.BackColor = System.Drawing.Color.White;
            this.btnEliminarP.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEliminarP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarP.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarP.ForeColor = System.Drawing.Color.Black;
            this.btnEliminarP.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarP.Image")));
            this.btnEliminarP.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminarP.Location = new System.Drawing.Point(244, 4);
            this.btnEliminarP.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarP.Name = "btnEliminarP";
            this.btnEliminarP.Size = new System.Drawing.Size(112, 73);
            this.btnEliminarP.TabIndex = 13;
            this.btnEliminarP.Tag = "Baja";
            this.btnEliminarP.Text = "Eliminar";
            this.btnEliminarP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminarP.UseVisualStyleBackColor = false;
            this.btnEliminarP.Click += new System.EventHandler(this.btnEliminarP_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.BackColor = System.Drawing.Color.White;
            this.btnCategorias.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorias.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorias.ForeColor = System.Drawing.Color.Black;
            this.btnCategorias.Image = ((System.Drawing.Image)(resources.GetObject("btnCategorias.Image")));
            this.btnCategorias.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCategorias.Location = new System.Drawing.Point(364, 4);
            this.btnCategorias.Margin = new System.Windows.Forms.Padding(4);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(112, 73);
            this.btnCategorias.TabIndex = 14;
            this.btnCategorias.Tag = "formCategorias";
            this.btnCategorias.Text = "Categorías";
            this.btnCategorias.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCategorias.UseVisualStyleBackColor = false;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnImportarP
            // 
            this.btnImportarP.BackColor = System.Drawing.Color.White;
            this.btnImportarP.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnImportarP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportarP.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportarP.ForeColor = System.Drawing.Color.Black;
            this.btnImportarP.Image = ((System.Drawing.Image)(resources.GetObject("btnImportarP.Image")));
            this.btnImportarP.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImportarP.Location = new System.Drawing.Point(484, 4);
            this.btnImportarP.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportarP.Name = "btnImportarP";
            this.btnImportarP.Size = new System.Drawing.Size(112, 73);
            this.btnImportarP.TabIndex = 11;
            this.btnImportarP.Tag = "Importar";
            this.btnImportarP.Text = "Importar";
            this.btnImportarP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportarP.UseVisualStyleBackColor = false;
            this.btnImportarP.Click += new System.EventHandler(this.btnImportarP_Click);
            // 
            // btnExportarP
            // 
            this.btnExportarP.BackColor = System.Drawing.Color.White;
            this.btnExportarP.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnExportarP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarP.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarP.ForeColor = System.Drawing.Color.Black;
            this.btnExportarP.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarP.Image")));
            this.btnExportarP.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExportarP.Location = new System.Drawing.Point(604, 4);
            this.btnExportarP.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportarP.Name = "btnExportarP";
            this.btnExportarP.Size = new System.Drawing.Size(112, 73);
            this.btnExportarP.TabIndex = 12;
            this.btnExportarP.Tag = "Exportar";
            this.btnExportarP.Text = "Exportar";
            this.btnExportarP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportarP.UseVisualStyleBackColor = false;
            this.btnExportarP.Click += new System.EventHandler(this.btnExportarP_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.AutoSize = false;
            this.bindingNavigator1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bindingNavigator1.BindingSource = this.productoBindingSource;
            this.bindingNavigator1.CountItem = this.bnpCantidadDeItems;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnpUltimoItem,
            this.bnpSiguienteItem,
            this.bindingNavigatorSeparator,
            this.bnpCantidadDeItems,
            this.bnpNumeroItem,
            this.bindingNavigatorSeparator1,
            this.bnpItemAnterior,
            this.bnpPrimerItem,
            this.bindingNavigatorSeparator2,
            this.cmbFiltroCategoria,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.cmbFiltroEstado,
            this.toolStripLabel2,
            this.toolStripSeparator3,
            this.toolStripLabel4,
            this.cmbFiltroTipoProducto});
            this.bindingNavigator1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 399);
            this.bindingNavigator1.MoveFirstItem = this.bnpPrimerItem;
            this.bindingNavigator1.MoveLastItem = this.bnpUltimoItem;
            this.bindingNavigator1.MoveNextItem = this.bnpSiguienteItem;
            this.bindingNavigator1.MovePreviousItem = this.bnpItemAnterior;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bnpNumeroItem;
            this.bindingNavigator1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bindingNavigator1.Size = new System.Drawing.Size(1081, 49);
            this.bindingNavigator1.TabIndex = 105;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bnpCantidadDeItems
            // 
            this.bnpCantidadDeItems.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnpCantidadDeItems.Name = "bnpCantidadDeItems";
            this.bnpCantidadDeItems.Size = new System.Drawing.Size(44, 46);
            this.bnpCantidadDeItems.Text = "de {0}";
            this.bnpCantidadDeItems.ToolTipText = "Número total de elementos";
            // 
            // bnpUltimoItem
            // 
            this.bnpUltimoItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnpUltimoItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnpUltimoItem.Image = ((System.Drawing.Image)(resources.GetObject("bnpUltimoItem.Image")));
            this.bnpUltimoItem.Name = "bnpUltimoItem";
            this.bnpUltimoItem.RightToLeftAutoMirrorImage = true;
            this.bnpUltimoItem.Size = new System.Drawing.Size(23, 46);
            this.bnpUltimoItem.Text = "Mover último";
            // 
            // bnpSiguienteItem
            // 
            this.bnpSiguienteItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnpSiguienteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnpSiguienteItem.Image = ((System.Drawing.Image)(resources.GetObject("bnpSiguienteItem.Image")));
            this.bnpSiguienteItem.Name = "bnpSiguienteItem";
            this.bnpSiguienteItem.RightToLeftAutoMirrorImage = true;
            this.bnpSiguienteItem.Size = new System.Drawing.Size(23, 46);
            this.bnpSiguienteItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 49);
            // 
            // bnpNumeroItem
            // 
            this.bnpNumeroItem.AccessibleName = "Posición";
            this.bnpNumeroItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnpNumeroItem.AutoSize = false;
            this.bnpNumeroItem.Name = "bnpNumeroItem";
            this.bnpNumeroItem.Size = new System.Drawing.Size(65, 23);
            this.bnpNumeroItem.Text = "0";
            this.bnpNumeroItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 49);
            // 
            // bnpItemAnterior
            // 
            this.bnpItemAnterior.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnpItemAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnpItemAnterior.Image = ((System.Drawing.Image)(resources.GetObject("bnpItemAnterior.Image")));
            this.bnpItemAnterior.Name = "bnpItemAnterior";
            this.bnpItemAnterior.RightToLeftAutoMirrorImage = true;
            this.bnpItemAnterior.Size = new System.Drawing.Size(23, 46);
            this.bnpItemAnterior.Text = "Mover anterior";
            // 
            // bnpPrimerItem
            // 
            this.bnpPrimerItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnpPrimerItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnpPrimerItem.Image = ((System.Drawing.Image)(resources.GetObject("bnpPrimerItem.Image")));
            this.bnpPrimerItem.Name = "bnpPrimerItem";
            this.bnpPrimerItem.RightToLeftAutoMirrorImage = true;
            this.bnpPrimerItem.Size = new System.Drawing.Size(23, 46);
            this.bnpPrimerItem.Text = "Mover primero";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 49);
            // 
            // cmbFiltroCategoria
            // 
            this.cmbFiltroCategoria.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbFiltroCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroCategoria.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            this.cmbFiltroCategoria.Size = new System.Drawing.Size(160, 49);
            this.cmbFiltroCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelecteIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(71, 46);
            this.toolStripLabel1.Text = "Categoría:";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.BackColor = System.Drawing.Color.Black;
            this.toolStripSeparator2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 49);
            // 
            // cmbFiltroEstado
            // 
            this.cmbFiltroEstado.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(160, 49);
            this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelecteIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(48, 46);
            this.toolStripLabel2.Text = "Estado:";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 49);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(108, 46);
            this.toolStripLabel4.Text = "Tipo de productos:";
            // 
            // cmbFiltroTipoProducto
            // 
            this.cmbFiltroTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroTipoProducto.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.cmbFiltroTipoProducto.Name = "cmbFiltroTipoProducto";
            this.cmbFiltroTipoProducto.Size = new System.Drawing.Size(160, 49);
            this.cmbFiltroTipoProducto.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelecteIndexChanged);
            // 
            // productoTableAdapter
            // 
            this.productoTableAdapter.ClearBeforeFill = true;
            // 
            // formProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 448);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formProductos";
            this.Text = "formMedicamentos";
            this.Load += new System.EventHandler(this.formProductos_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.negocio)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flpVencimiento.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.flpContenedorBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cmbFiltroBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpContenedorBotones;
        private System.Windows.Forms.Button btnNuevoP;
        private System.Windows.Forms.Button btnModificarP;
        private System.Windows.Forms.Button btnEliminarP;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnImportarP;
        private System.Windows.Forms.Button btnExportarP;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bnpCantidadDeItems;
        private System.Windows.Forms.ToolStripButton bnpUltimoItem;
        private System.Windows.Forms.ToolStripButton bnpSiguienteItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bnpNumeroItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bnpItemAnterior;
        private System.Windows.Forms.ToolStripButton bnpPrimerItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripComboBox cmbFiltroCategoria;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox cmbFiltroEstado;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox cmbFiltroTipoProducto;
        private Negocio negocio;
        private System.Windows.Forms.BindingSource productoBindingSource;
        private NegocioTableAdapters.ProductoTableAdapter productoTableAdapter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.ToolStripDropDownButton tsdMostrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsMenuProducto;
        private System.Windows.Forms.ToolStripMenuItem tsMenuMedicamento;
        private System.Windows.Forms.ToolStripMenuItem tsmiProveedor;
        private System.Windows.Forms.ToolStripMenuItem tsmiNombreCategoria;
        private System.Windows.Forms.ToolStripMenuItem tsmiCodigo;
        private System.Windows.Forms.ToolStripMenuItem tsmiID;
        private System.Windows.Forms.ToolStripMenuItem tsmiNombre;
        private System.Windows.Forms.ToolStripMenuItem tsmiStock;
        private System.Windows.Forms.ToolStripMenuItem tsmiTipoProducto;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrecioVenta;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrecioCompra;
        private System.Windows.Forms.ToolStripMenuItem tsmiEstado;
        private System.Windows.Forms.ToolStripMenuItem tsmiLote;
        private System.Windows.Forms.ToolStripMenuItem tsmiVencimiento;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefrigerado;
        private System.Windows.Forms.ToolStripMenuItem tsmiReceta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTipoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcPrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcPrecioCompra;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvcRefrigerado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvcReceta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvcEstado;
        private System.Windows.Forms.CheckBox chkVencimiento;
        private System.Windows.Forms.FlowLayoutPanel flpVencimiento;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFin;
    }
}