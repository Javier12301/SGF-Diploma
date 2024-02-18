namespace SGF.PRESENTACION.formPrincipales
{
    partial class formRegistros
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formRegistros));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tsMostrar = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsdMostrar = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsMenuRegistro = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiID = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFechayHora = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNombreUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMovimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiModulo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDescripcion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuCantidades = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCantidadAntes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCantidadDespues = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCantidad = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvRegistros = new System.Windows.Forms.DataGridView();
            this.dgvcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcFechayHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNombreUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCantidadAntes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCantidadDespues = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.negocio = new SGF.PRESENTACION.Negocio();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.flpFecha = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cmbFiltroBuscar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flpContenedorBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
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
            this.cmbFiltroMovimiento = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbFiltroUsuario = new System.Windows.Forms.ToolStripComboBox();
            this.registroTableAdapter = new SGF.PRESENTACION.NegocioTableAdapters.RegistroTableAdapter();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tsMostrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.negocio)).BeginInit();
            this.panel4.SuspendLayout();
            this.flpFecha.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flpContenedorBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.flpContenedorBotones);
            this.panel1.Controls.Add(this.bindingNavigator1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 448);
            this.panel1.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.tsMostrar);
            this.panel5.Controls.Add(this.dgvRegistros);
            this.panel5.Location = new System.Drawing.Point(5, 149);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1073, 247);
            this.panel5.TabIndex = 111;
            // 
            // tsMostrar
            // 
            this.tsMostrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(141)))), ((int)(((byte)(196)))));
            this.tsMostrar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMostrar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.tsdMostrar});
            this.tsMostrar.Location = new System.Drawing.Point(0, 0);
            this.tsMostrar.Name = "tsMostrar";
            this.tsMostrar.Size = new System.Drawing.Size(1073, 25);
            this.tsMostrar.TabIndex = 111;
            this.tsMostrar.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsdMostrar
            // 
            this.tsdMostrar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuRegistro,
            this.tsMenuCantidades});
            this.tsdMostrar.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.tsdMostrar.ForeColor = System.Drawing.Color.White;
            this.tsdMostrar.Image = global::SGF.PRESENTACION.Properties.Resources.checkList_Blanco;
            this.tsdMostrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdMostrar.Name = "tsdMostrar";
            this.tsdMostrar.Size = new System.Drawing.Size(151, 22);
            this.tsdMostrar.Text = "Mostrar Columnas";
            // 
            // tsMenuRegistro
            // 
            this.tsMenuRegistro.Checked = true;
            this.tsMenuRegistro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsMenuRegistro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiID,
            this.tsmiFechayHora,
            this.tsmiNombreUsuario,
            this.tsmiMovimiento,
            this.tsmiModulo,
            this.tsmiDescripcion});
            this.tsMenuRegistro.Name = "tsMenuRegistro";
            this.tsMenuRegistro.Size = new System.Drawing.Size(145, 22);
            this.tsMenuRegistro.Text = "Registro";
            this.tsMenuRegistro.CheckedChanged += new System.EventHandler(this.tsmiMenu_CheckChanged);
            this.tsMenuRegistro.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiID
            // 
            this.tsmiID.Checked = true;
            this.tsmiID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiID.Name = "tsmiID";
            this.tsmiID.Size = new System.Drawing.Size(153, 22);
            this.tsmiID.Text = "ID";
            this.tsmiID.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiID.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiFechayHora
            // 
            this.tsmiFechayHora.Checked = true;
            this.tsmiFechayHora.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiFechayHora.Name = "tsmiFechayHora";
            this.tsmiFechayHora.Size = new System.Drawing.Size(153, 22);
            this.tsmiFechayHora.Text = "Fecha y hora";
            this.tsmiFechayHora.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiFechayHora.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiNombreUsuario
            // 
            this.tsmiNombreUsuario.Checked = true;
            this.tsmiNombreUsuario.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiNombreUsuario.Name = "tsmiNombreUsuario";
            this.tsmiNombreUsuario.Size = new System.Drawing.Size(153, 22);
            this.tsmiNombreUsuario.Text = "Usuario";
            this.tsmiNombreUsuario.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiNombreUsuario.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiMovimiento
            // 
            this.tsmiMovimiento.Checked = true;
            this.tsmiMovimiento.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiMovimiento.Name = "tsmiMovimiento";
            this.tsmiMovimiento.Size = new System.Drawing.Size(153, 22);
            this.tsmiMovimiento.Text = "Movimiento";
            this.tsmiMovimiento.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiMovimiento.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiModulo
            // 
            this.tsmiModulo.Checked = true;
            this.tsmiModulo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiModulo.Name = "tsmiModulo";
            this.tsmiModulo.Size = new System.Drawing.Size(153, 22);
            this.tsmiModulo.Text = "Módulo";
            this.tsmiModulo.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiModulo.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiDescripcion
            // 
            this.tsmiDescripcion.Checked = true;
            this.tsmiDescripcion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiDescripcion.Name = "tsmiDescripcion";
            this.tsmiDescripcion.Size = new System.Drawing.Size(153, 22);
            this.tsmiDescripcion.Text = "Descripción";
            this.tsmiDescripcion.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiDescripcion.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsMenuCantidades
            // 
            this.tsMenuCantidades.Checked = true;
            this.tsMenuCantidades.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsMenuCantidades.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCantidadAntes,
            this.tsmiCantidadDespues,
            this.tsmiCantidad});
            this.tsMenuCantidades.Name = "tsMenuCantidades";
            this.tsMenuCantidades.Size = new System.Drawing.Size(145, 22);
            this.tsMenuCantidades.Text = "Cantidades";
            this.tsMenuCantidades.CheckedChanged += new System.EventHandler(this.tsmiMenu_CheckChanged);
            this.tsMenuCantidades.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiCantidadAntes
            // 
            this.tsmiCantidadAntes.Checked = true;
            this.tsmiCantidadAntes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiCantidadAntes.Name = "tsmiCantidadAntes";
            this.tsmiCantidadAntes.Size = new System.Drawing.Size(198, 22);
            this.tsmiCantidadAntes.Text = "Cantidad antes";
            this.tsmiCantidadAntes.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiCantidadAntes.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiCantidadDespues
            // 
            this.tsmiCantidadDespues.Checked = true;
            this.tsmiCantidadDespues.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiCantidadDespues.Name = "tsmiCantidadDespues";
            this.tsmiCantidadDespues.Size = new System.Drawing.Size(198, 22);
            this.tsmiCantidadDespues.Text = "Cantidades después";
            this.tsmiCantidadDespues.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiCantidadDespues.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // tsmiCantidad
            // 
            this.tsmiCantidad.Checked = true;
            this.tsmiCantidad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiCantidad.Name = "tsmiCantidad";
            this.tsmiCantidad.Size = new System.Drawing.Size(198, 22);
            this.tsmiCantidad.Text = "Cantidad";
            this.tsmiCantidad.CheckedChanged += new System.EventHandler(this.tsmi_CheckedChanged);
            this.tsmiCantidad.Click += new System.EventHandler(this.tsmiButtons_Click);
            // 
            // dgvRegistros
            // 
            this.dgvRegistros.AllowUserToAddRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRegistros.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegistros.AutoGenerateColumns = false;
            this.dgvRegistros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegistros.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegistros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvRegistros.ColumnHeadersHeight = 40;
            this.dgvRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRegistros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcID,
            this.dgvcFechayHora,
            this.dgvcMovimiento,
            this.dgvcNombreUsuario,
            this.dgvcCantidad,
            this.dgvcCantidadAntes,
            this.dgvcCantidadDespues,
            this.dgvcModulo,
            this.dgvcDescripcion});
            this.dgvRegistros.DataSource = this.registroBindingSource;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Roboto", 9F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRegistros.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvRegistros.GridColor = System.Drawing.Color.White;
            this.dgvRegistros.Location = new System.Drawing.Point(0, 28);
            this.dgvRegistros.Name = "dgvRegistros";
            this.dgvRegistros.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Roboto", 9F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegistros.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvRegistros.RowHeadersVisible = false;
            this.dgvRegistros.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRegistros.Size = new System.Drawing.Size(1073, 216);
            this.dgvRegistros.TabIndex = 110;
            // 
            // dgvcID
            // 
            this.dgvcID.DataPropertyName = "RegistrosID";
            this.dgvcID.FillWeight = 40F;
            this.dgvcID.HeaderText = "ID";
            this.dgvcID.Name = "dgvcID";
            this.dgvcID.ReadOnly = true;
            // 
            // dgvcFechayHora
            // 
            this.dgvcFechayHora.DataPropertyName = "FechayHora";
            this.dgvcFechayHora.HeaderText = "Fecha y hora";
            this.dgvcFechayHora.Name = "dgvcFechayHora";
            this.dgvcFechayHora.ReadOnly = true;
            // 
            // dgvcMovimiento
            // 
            this.dgvcMovimiento.DataPropertyName = "Movimiento";
            this.dgvcMovimiento.HeaderText = "Movimiento";
            this.dgvcMovimiento.Name = "dgvcMovimiento";
            this.dgvcMovimiento.ReadOnly = true;
            // 
            // dgvcNombreUsuario
            // 
            this.dgvcNombreUsuario.DataPropertyName = "NombreUsuario";
            this.dgvcNombreUsuario.HeaderText = "Usuario";
            this.dgvcNombreUsuario.Name = "dgvcNombreUsuario";
            this.dgvcNombreUsuario.ReadOnly = true;
            // 
            // dgvcCantidad
            // 
            this.dgvcCantidad.DataPropertyName = "Cantidad";
            this.dgvcCantidad.HeaderText = "Cantidad";
            this.dgvcCantidad.Name = "dgvcCantidad";
            this.dgvcCantidad.ReadOnly = true;
            // 
            // dgvcCantidadAntes
            // 
            this.dgvcCantidadAntes.DataPropertyName = "CantidadAntes";
            this.dgvcCantidadAntes.HeaderText = "Cantidad antes";
            this.dgvcCantidadAntes.Name = "dgvcCantidadAntes";
            this.dgvcCantidadAntes.ReadOnly = true;
            // 
            // dgvcCantidadDespues
            // 
            this.dgvcCantidadDespues.DataPropertyName = "CantidadDespues";
            this.dgvcCantidadDespues.HeaderText = "Cantidad despues";
            this.dgvcCantidadDespues.Name = "dgvcCantidadDespues";
            this.dgvcCantidadDespues.ReadOnly = true;
            // 
            // dgvcModulo
            // 
            this.dgvcModulo.DataPropertyName = "Modulo";
            this.dgvcModulo.HeaderText = "Módulo";
            this.dgvcModulo.Name = "dgvcModulo";
            this.dgvcModulo.ReadOnly = true;
            // 
            // dgvcDescripcion
            // 
            this.dgvcDescripcion.DataPropertyName = "Descripcion";
            this.dgvcDescripcion.HeaderText = "Descripción";
            this.dgvcDescripcion.Name = "dgvcDescripcion";
            this.dgvcDescripcion.ReadOnly = true;
            // 
            // registroBindingSource
            // 
            this.registroBindingSource.DataMember = "Registro";
            this.registroBindingSource.DataSource = this.negocio;
            // 
            // negocio
            // 
            this.negocio.DataSetName = "Negocio";
            this.negocio.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.chkFecha);
            this.panel4.Controls.Add(this.flpFecha);
            this.panel4.Controls.Add(this.btnBuscar);
            this.panel4.Controls.Add(this.txtBuscar);
            this.panel4.Controls.Add(this.cmbFiltroBuscar);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(5, 92);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1073, 54);
            this.panel4.TabIndex = 107;
            // 
            // chkFecha
            // 
            this.chkFecha.AutoSize = true;
            this.chkFecha.Checked = true;
            this.chkFecha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFecha.Location = new System.Drawing.Point(595, 19);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(56, 17);
            this.chkFecha.TabIndex = 98;
            this.chkFecha.Text = "Fecha";
            this.chkFecha.UseVisualStyleBackColor = true;
            this.chkFecha.CheckedChanged += new System.EventHandler(this.chkFecha_CheckedChanged);
            // 
            // flpFecha
            // 
            this.flpFecha.Controls.Add(this.panel2);
            this.flpFecha.Controls.Add(this.panel3);
            this.flpFecha.Location = new System.Drawing.Point(185, 5);
            this.flpFecha.Name = "flpFecha";
            this.flpFecha.Size = new System.Drawing.Size(404, 43);
            this.flpFecha.TabIndex = 97;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtpInicio);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 35);
            this.panel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha Inicio:";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpInicio.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(90, 7);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(103, 23);
            this.dtpInicio.TabIndex = 5;
            this.dtpInicio.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.dtpFin);
            this.panel3.Location = new System.Drawing.Point(209, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(189, 35);
            this.panel3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fecha Fin:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFin
            // 
            this.dtpFin.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(78, 7);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(103, 23);
            this.dtpFin.TabIndex = 7;
            this.dtpFin.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
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
            this.cmbFiltroBuscar.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroBuscar_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(639, 17);
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
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista de registros";
            // 
            // flpContenedorBotones
            // 
            this.flpContenedorBotones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpContenedorBotones.BackColor = System.Drawing.Color.LightGray;
            this.flpContenedorBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpContenedorBotones.Controls.Add(this.btnExportar);
            this.flpContenedorBotones.Controls.Add(this.btnEliminar);
            this.flpContenedorBotones.Location = new System.Drawing.Point(0, 4);
            this.flpContenedorBotones.Margin = new System.Windows.Forms.Padding(4);
            this.flpContenedorBotones.Name = "flpContenedorBotones";
            this.flpContenedorBotones.Size = new System.Drawing.Size(692, 81);
            this.flpContenedorBotones.TabIndex = 106;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.White;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.Black;
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExportar.Location = new System.Drawing.Point(4, 4);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(112, 73);
            this.btnExportar.TabIndex = 12;
            this.btnExportar.Tag = "Exportar";
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminar.Location = new System.Drawing.Point(124, 4);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(112, 73);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Tag = "Baja";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.AutoSize = false;
            this.bindingNavigator1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bindingNavigator1.BindingSource = this.registroBindingSource;
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
            this.cmbFiltroMovimiento,
            this.toolStripLabel2,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.cmbFiltroUsuario});
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
            this.bnpNumeroItem.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            // cmbFiltroMovimiento
            // 
            this.cmbFiltroMovimiento.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbFiltroMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroMovimiento.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.cmbFiltroMovimiento.Name = "cmbFiltroMovimiento";
            this.cmbFiltroMovimiento.Size = new System.Drawing.Size(160, 49);
            this.cmbFiltroMovimiento.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroBuscar_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(71, 46);
            this.toolStripLabel2.Text = "Movimiento";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 49);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(52, 46);
            this.toolStripLabel1.Text = "Usuario:";
            // 
            // cmbFiltroUsuario
            // 
            this.cmbFiltroUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroUsuario.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.cmbFiltroUsuario.Name = "cmbFiltroUsuario";
            this.cmbFiltroUsuario.Size = new System.Drawing.Size(160, 49);
            this.cmbFiltroUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroBuscar_SelectedIndexChanged);
            // 
            // registroTableAdapter
            // 
            this.registroTableAdapter.ClearBeforeFill = true;
            // 
            // formRegistros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 448);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formRegistros";
            this.Text = "formRegistros";
            this.Load += new System.EventHandler(this.formRegistros_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tsMostrar.ResumeLayout(false);
            this.tsMostrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.negocio)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flpFecha.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flpContenedorBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStrip tsMostrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton tsdMostrar;
        private System.Windows.Forms.ToolStripMenuItem tsMenuRegistro;
        private System.Windows.Forms.ToolStripMenuItem tsmiID;
        private System.Windows.Forms.ToolStripMenuItem tsmiNombreUsuario;
        private System.Windows.Forms.ToolStripMenuItem tsmiMovimiento;
        private System.Windows.Forms.ToolStripMenuItem tsmiModulo;
        private System.Windows.Forms.ToolStripMenuItem tsmiDescripcion;
        private System.Windows.Forms.DataGridView dgvRegistros;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cmbFiltroBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpContenedorBotones;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnExportar;
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
        private System.Windows.Forms.ToolStripComboBox cmbFiltroMovimiento;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cmbFiltroUsuario;
        private System.Windows.Forms.ToolStripMenuItem tsMenuCantidades;
        private System.Windows.Forms.ToolStripMenuItem tsmiCantidadAntes;
        private System.Windows.Forms.ToolStripMenuItem tsmiCantidadDespues;
        private System.Windows.Forms.ToolStripMenuItem tsmiCantidad;
        private Negocio negocio;
        private System.Windows.Forms.BindingSource registroBindingSource;
        private NegocioTableAdapters.RegistroTableAdapter registroTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcFechayHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNombreUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCantidadAntes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCantidadDespues;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcModulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDescripcion;
        private System.Windows.Forms.ToolStripMenuItem tsmiFechayHora;
        private System.Windows.Forms.FlowLayoutPanel flpFecha;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.CheckBox chkFecha;
    }
}