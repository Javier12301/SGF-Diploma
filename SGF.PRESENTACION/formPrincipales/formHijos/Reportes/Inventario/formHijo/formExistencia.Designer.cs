namespace SGF.PRESENTACION.formPrincipales.formHijos.Reportes.Inventario.formHijo
{
    partial class formExistencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formExistencia));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpContenedorBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmbFiltroTipoProducto = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbFiltroExistencias = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFiltroProveedor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFiltroCategoria = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPrecioDeInventario = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCostodeInventario = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExistencia = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.dgvcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcPrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcPrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.negocio = new SGF.PRESENTACION.Negocio();
            this.productoTableAdapter = new SGF.PRESENTACION.NegocioTableAdapters.ProductoTableAdapter();
            this.panel1.SuspendLayout();
            this.flpContenedorBotones.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.negocio)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flpContenedorBotones);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgvProductos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 281);
            this.panel1.TabIndex = 0;
            // 
            // flpContenedorBotones
            // 
            this.flpContenedorBotones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flpContenedorBotones.BackColor = System.Drawing.Color.LightGray;
            this.flpContenedorBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpContenedorBotones.Controls.Add(this.btnImprimir);
            this.flpContenedorBotones.Controls.Add(this.btnExportar);
            this.flpContenedorBotones.Location = new System.Drawing.Point(5, 229);
            this.flpContenedorBotones.Margin = new System.Windows.Forms.Padding(4);
            this.flpContenedorBotones.Name = "flpContenedorBotones";
            this.flpContenedorBotones.Size = new System.Drawing.Size(243, 48);
            this.flpContenedorBotones.TabIndex = 118;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImprimir.BackColor = System.Drawing.Color.White;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.Black;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(3, 3);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(110, 40);
            this.btnImprimir.TabIndex = 11;
            this.btnImprimir.Tag = "Imprimir";
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportar.BackColor = System.Drawing.Color.White;
            this.btnExportar.Enabled = false;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.Black;
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(119, 3);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(110, 40);
            this.btnExportar.TabIndex = 12;
            this.btnExportar.Tag = "Exportar";
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.cmbFiltroTipoProducto);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.cmbFiltroExistencias);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.cmbFiltroProveedor);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.cmbFiltroCategoria);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(5, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1071, 38);
            this.panel4.TabIndex = 117;
            // 
            // cmbFiltroTipoProducto
            // 
            this.cmbFiltroTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroTipoProducto.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltroTipoProducto.FormattingEnabled = true;
            this.cmbFiltroTipoProducto.Location = new System.Drawing.Point(848, 7);
            this.cmbFiltroTipoProducto.Name = "cmbFiltroTipoProducto";
            this.cmbFiltroTipoProducto.Size = new System.Drawing.Size(166, 23);
            this.cmbFiltroTipoProducto.TabIndex = 10;
            this.cmbFiltroTipoProducto.SelectedIndexChanged += new System.EventHandler(this.combobox_SelecteIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(743, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Tipo producto:";
            // 
            // cmbFiltroExistencias
            // 
            this.cmbFiltroExistencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroExistencias.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltroExistencias.FormattingEnabled = true;
            this.cmbFiltroExistencias.Location = new System.Drawing.Point(578, 7);
            this.cmbFiltroExistencias.Name = "cmbFiltroExistencias";
            this.cmbFiltroExistencias.Size = new System.Drawing.Size(159, 23);
            this.cmbFiltroExistencias.TabIndex = 8;
            this.cmbFiltroExistencias.SelectedIndexChanged += new System.EventHandler(this.combobox_SelecteIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(493, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Existencias:";
            // 
            // cmbFiltroProveedor
            // 
            this.cmbFiltroProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroProveedor.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltroProveedor.FormattingEnabled = true;
            this.cmbFiltroProveedor.Location = new System.Drawing.Point(328, 7);
            this.cmbFiltroProveedor.Name = "cmbFiltroProveedor";
            this.cmbFiltroProveedor.Size = new System.Drawing.Size(159, 23);
            this.cmbFiltroProveedor.TabIndex = 6;
            this.cmbFiltroProveedor.SelectedIndexChanged += new System.EventHandler(this.combobox_SelecteIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(248, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Proveedor:";
            // 
            // cmbFiltroCategoria
            // 
            this.cmbFiltroCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroCategoria.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltroCategoria.FormattingEnabled = true;
            this.cmbFiltroCategoria.Location = new System.Drawing.Point(83, 7);
            this.cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            this.cmbFiltroCategoria.Size = new System.Drawing.Size(159, 23);
            this.cmbFiltroCategoria.TabIndex = 4;
            this.cmbFiltroCategoria.SelectedIndexChanged += new System.EventHandler(this.combobox_SelecteIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Categoría:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtPrecioDeInventario);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtCostodeInventario);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtExistencia);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(706, 229);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(370, 48);
            this.panel2.TabIndex = 116;
            // 
            // txtPrecioDeInventario
            // 
            this.txtPrecioDeInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(255)))), ((int)(((byte)(208)))));
            this.txtPrecioDeInventario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtPrecioDeInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtPrecioDeInventario.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioDeInventario.Location = new System.Drawing.Point(258, 18);
            this.txtPrecioDeInventario.Name = "txtPrecioDeInventario";
            this.txtPrecioDeInventario.Size = new System.Drawing.Size(101, 23);
            this.txtPrecioDeInventario.TabIndex = 5;
            this.txtPrecioDeInventario.Text = "800";
            this.txtPrecioDeInventario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(252, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = "Precio de inventario";
            // 
            // txtCostodeInventario
            // 
            this.txtCostodeInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(255)))), ((int)(((byte)(208)))));
            this.txtCostodeInventario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtCostodeInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtCostodeInventario.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostodeInventario.Location = new System.Drawing.Point(133, 18);
            this.txtCostodeInventario.Name = "txtCostodeInventario";
            this.txtCostodeInventario.Size = new System.Drawing.Size(101, 23);
            this.txtCostodeInventario.TabIndex = 3;
            this.txtCostodeInventario.Text = "800";
            this.txtCostodeInventario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(126, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Costo de inventario";
            // 
            // txtExistencia
            // 
            this.txtExistencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(255)))), ((int)(((byte)(208)))));
            this.txtExistencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtExistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtExistencia.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExistencia.Location = new System.Drawing.Point(8, 18);
            this.txtExistencia.Name = "txtExistencia";
            this.txtExistencia.Size = new System.Drawing.Size(101, 23);
            this.txtExistencia.TabIndex = 1;
            this.txtExistencia.Text = "800";
            this.txtExistencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Existencias";
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
            this.dgvcLote,
            this.dgvcNombreProducto,
            this.dgvcStock,
            this.dgvcPrecioCompra,
            this.dgvcPrecioVenta});
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
            this.dgvProductos.Location = new System.Drawing.Point(4, 44);
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
            this.dgvProductos.Size = new System.Drawing.Size(1072, 183);
            this.dgvProductos.TabIndex = 114;
            // 
            // dgvcID
            // 
            this.dgvcID.DataPropertyName = "ProductoID";
            this.dgvcID.HeaderText = "ID";
            this.dgvcID.Name = "dgvcID";
            this.dgvcID.ReadOnly = true;
            this.dgvcID.Visible = false;
            // 
            // dgvcCodigo
            // 
            this.dgvcCodigo.DataPropertyName = "CodigoBarras";
            this.dgvcCodigo.HeaderText = "Código";
            this.dgvcCodigo.Name = "dgvcCodigo";
            this.dgvcCodigo.ReadOnly = true;
            // 
            // dgvcLote
            // 
            this.dgvcLote.DataPropertyName = "NumeroLote";
            this.dgvcLote.HeaderText = "Lote";
            this.dgvcLote.Name = "dgvcLote";
            this.dgvcLote.ReadOnly = true;
            // 
            // dgvcNombreProducto
            // 
            this.dgvcNombreProducto.DataPropertyName = "Nombre";
            this.dgvcNombreProducto.HeaderText = "Nombre";
            this.dgvcNombreProducto.Name = "dgvcNombreProducto";
            this.dgvcNombreProducto.ReadOnly = true;
            // 
            // dgvcStock
            // 
            this.dgvcStock.DataPropertyName = "Stock";
            this.dgvcStock.HeaderText = "Existencia";
            this.dgvcStock.Name = "dgvcStock";
            this.dgvcStock.ReadOnly = true;
            // 
            // dgvcPrecioCompra
            // 
            this.dgvcPrecioCompra.DataPropertyName = "PrecioCompra";
            this.dgvcPrecioCompra.HeaderText = "Precio compra";
            this.dgvcPrecioCompra.Name = "dgvcPrecioCompra";
            this.dgvcPrecioCompra.ReadOnly = true;
            // 
            // dgvcPrecioVenta
            // 
            this.dgvcPrecioVenta.DataPropertyName = "PrecioVenta";
            this.dgvcPrecioVenta.HeaderText = "Precio venta";
            this.dgvcPrecioVenta.Name = "dgvcPrecioVenta";
            this.dgvcPrecioVenta.ReadOnly = true;
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
            // productoTableAdapter
            // 
            this.productoTableAdapter.ClearBeforeFill = true;
            // 
            // formExistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1081, 281);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formExistencia";
            this.Text = "formExistencia";
            this.Load += new System.EventHandler(this.formExistencia_Load);
            this.panel1.ResumeLayout(false);
            this.flpContenedorBotones.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.negocio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label txtPrecioDeInventario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtCostodeInventario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtExistencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Panel panel4;
        private Negocio negocio;
        private System.Windows.Forms.BindingSource productoBindingSource;
        private NegocioTableAdapters.ProductoTableAdapter productoTableAdapter;
        private System.Windows.Forms.ComboBox cmbFiltroExistencias;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbFiltroProveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFiltroCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFiltroTipoProducto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flpContenedorBotones;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcPrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcPrecioVenta;
    }
}