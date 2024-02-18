namespace SGF.PRESENTACION.formModales.Salida_inventario
{
    partial class mdSalidaInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdSalidaInventario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.salidaInventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.negocio = new SGF.PRESENTACION.Negocio();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbFiltroEstado = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.dgvSalidas = new System.Windows.Forms.DataGridView();
            this.dgvcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcFechaSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCantidadTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpContenedor = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnDetalles = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.salidaInventarioTableAdapter = new SGF.PRESENTACION.NegocioTableAdapters.SalidaInventarioTableAdapter();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salidaInventarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.negocio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidas)).BeginInit();
            this.flpContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.flpContenedor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 428);
            this.panel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.dtpInicio);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.dtpFin);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(3, 71);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(575, 33);
            this.panel4.TabIndex = 108;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(267, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Desde";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(316, 4);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(103, 23);
            this.dtpInicio.TabIndex = 10;
            this.dtpInicio.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(422, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Hasta";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFin
            // 
            this.dtpFin.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(467, 4);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(103, 23);
            this.dtpFin.TabIndex = 11;
            this.dtpFin.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Salidas realizadas";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.btnSalir);
            this.panel3.Location = new System.Drawing.Point(0, 388);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(581, 40);
            this.panel3.TabIndex = 102;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(11)))), ((int)(((byte)(53)))));
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(137)))), ((int)(((byte)(180)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.Location = new System.Drawing.Point(474, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(104, 31);
            this.btnSalir.TabIndex = 28;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.bindingNavigator1);
            this.panel2.Controls.Add(this.dgvSalidas);
            this.panel2.Location = new System.Drawing.Point(3, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(575, 279);
            this.panel2.TabIndex = 98;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.salidaInventarioBindingSource;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.cmbFiltroEstado,
            this.toolStripLabel1});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 254);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(575, 25);
            this.bindingNavigator1.TabIndex = 112;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // salidaInventarioBindingSource
            // 
            this.salidaInventarioBindingSource.DataMember = "SalidaInventario";
            this.salidaInventarioBindingSource.DataSource = this.negocio;
            // 
            // negocio
            // 
            this.negocio.DataSetName = "Negocio";
            this.negocio.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cmbFiltroEstado
            // 
            this.cmbFiltroEstado.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(115, 25);
            this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroEstado_SelectedIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel1.Text = "Estado:";
            // 
            // dgvSalidas
            // 
            this.dgvSalidas.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSalidas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalidas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalidas.AutoGenerateColumns = false;
            this.dgvSalidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalidas.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalidas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalidas.ColumnHeadersHeight = 40;
            this.dgvSalidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSalidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcID,
            this.dgvcFechaSalida,
            this.dgvcCantidadTotal,
            this.dgvcObservaciones});
            this.dgvSalidas.DataSource = this.salidaInventarioBindingSource;
            this.dgvSalidas.GridColor = System.Drawing.Color.White;
            this.dgvSalidas.Location = new System.Drawing.Point(4, 3);
            this.dgvSalidas.Name = "dgvSalidas";
            this.dgvSalidas.ReadOnly = true;
            this.dgvSalidas.RowHeadersVisible = false;
            this.dgvSalidas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalidas.Size = new System.Drawing.Size(568, 248);
            this.dgvSalidas.TabIndex = 111;
            this.dgvSalidas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalidas_CellDoubleClick);
            // 
            // dgvcID
            // 
            this.dgvcID.DataPropertyName = "SalidaID";
            this.dgvcID.FillWeight = 30F;
            this.dgvcID.HeaderText = "Folio";
            this.dgvcID.Name = "dgvcID";
            this.dgvcID.ReadOnly = true;
            // 
            // dgvcFechaSalida
            // 
            this.dgvcFechaSalida.DataPropertyName = "FechaSalida";
            this.dgvcFechaSalida.FillWeight = 35F;
            this.dgvcFechaSalida.HeaderText = "Fecha de salida";
            this.dgvcFechaSalida.Name = "dgvcFechaSalida";
            this.dgvcFechaSalida.ReadOnly = true;
            // 
            // dgvcCantidadTotal
            // 
            this.dgvcCantidadTotal.DataPropertyName = "CantidadTotalProductos";
            this.dgvcCantidadTotal.FillWeight = 35F;
            this.dgvcCantidadTotal.HeaderText = "Cantidad total";
            this.dgvcCantidadTotal.Name = "dgvcCantidadTotal";
            this.dgvcCantidadTotal.ReadOnly = true;
            // 
            // dgvcObservaciones
            // 
            this.dgvcObservaciones.DataPropertyName = "Observaciones";
            this.dgvcObservaciones.HeaderText = "Observaciones";
            this.dgvcObservaciones.Name = "dgvcObservaciones";
            this.dgvcObservaciones.ReadOnly = true;
            // 
            // flpContenedor
            // 
            this.flpContenedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpContenedor.BackColor = System.Drawing.Color.LightGray;
            this.flpContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpContenedor.Controls.Add(this.btnNuevo);
            this.flpContenedor.Controls.Add(this.btnDetalles);
            this.flpContenedor.Controls.Add(this.btnExportar);
            this.flpContenedor.Location = new System.Drawing.Point(3, 3);
            this.flpContenedor.Name = "flpContenedor";
            this.flpContenedor.Size = new System.Drawing.Size(575, 66);
            this.flpContenedor.TabIndex = 27;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.White;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.Black;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevo.Location = new System.Drawing.Point(3, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(84, 59);
            this.btnNuevo.TabIndex = 9;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Visible = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnDetalles
            // 
            this.btnDetalles.BackColor = System.Drawing.Color.White;
            this.btnDetalles.Enabled = false;
            this.btnDetalles.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnDetalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalles.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalles.ForeColor = System.Drawing.Color.Black;
            this.btnDetalles.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalles.Image")));
            this.btnDetalles.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDetalles.Location = new System.Drawing.Point(93, 3);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(84, 59);
            this.btnDetalles.TabIndex = 10;
            this.btnDetalles.Text = "Detalles";
            this.btnDetalles.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetalles.UseVisualStyleBackColor = false;
            this.btnDetalles.Visible = false;
            this.btnDetalles.Click += new System.EventHandler(this.btnDetalles_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.White;
            this.btnExportar.Enabled = false;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.Black;
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExportar.Location = new System.Drawing.Point(183, 3);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(84, 59);
            this.btnExportar.TabIndex = 11;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Visible = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // salidaInventarioTableAdapter
            // 
            this.salidaInventarioTableAdapter.ClearBeforeFill = true;
            // 
            // mdSalidaInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 428);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(528, 461);
            this.Name = "mdSalidaInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salida de inventario";
            this.Load += new System.EventHandler(this.mdSalidaInventario_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salidaInventarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.negocio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidas)).EndInit();
            this.flpContenedor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripComboBox cmbFiltroEstado;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.DataGridView dgvSalidas;
        private System.Windows.Forms.FlowLayoutPanel flpContenedor;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnDetalles;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcFechaSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCantidadTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcObservaciones;
        private System.Windows.Forms.BindingSource salidaInventarioBindingSource;
        private Negocio negocio;
        private NegocioTableAdapters.SalidaInventarioTableAdapter salidaInventarioTableAdapter;
    }
}