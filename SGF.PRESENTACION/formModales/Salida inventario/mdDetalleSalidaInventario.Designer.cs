namespace SGF.PRESENTACION.formModales.Salida_inventario
{
    partial class mdDetalleSalidaInventario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdDetalleSalidaInventario));
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cmbFiltroBuscar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtFolio = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pbCancelado = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.Label();
            this.dgvDetallesSalidas = new System.Windows.Forms.DataGridView();
            this.dgvcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCodigoBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalleSalidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.negocio = new SGF.PRESENTACION.Negocio();
            this.flpContenedorBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.detalle_SalidaTableAdapter = new SGF.PRESENTACION.NegocioTableAdapters.Detalle_SalidaTableAdapter();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesSalidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleSalidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.negocio)).BeginInit();
            this.flpContenedorBotones.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.flowLayoutPanel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pbCancelado);
            this.panel1.Controls.Add(this.flowLayoutPanel3);
            this.panel1.Controls.Add(this.dgvDetallesSalidas);
            this.panel1.Controls.Add(this.flpContenedorBotones);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 403);
            this.panel1.TabIndex = 1;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel5.AutoSize = true;
            this.flowLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel5.Controls.Add(this.txtTotal);
            this.flowLayoutPanel5.Controls.Add(this.label8);
            this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(552, 334);
            this.flowLayoutPanel5.MaximumSize = new System.Drawing.Size(591, 26);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(166, 26);
            this.flowLayoutPanel5.TabIndex = 249;
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.Black;
            this.txtTotal.Location = new System.Drawing.Point(123, 0);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 0, 0, 1);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Padding = new System.Windows.Forms.Padding(2);
            this.txtTotal.Size = new System.Drawing.Size(41, 25);
            this.txtTotal.TabIndex = 245;
            this.txtTotal.Text = "200";
            this.txtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label8.Size = new System.Drawing.Size(114, 22);
            this.label8.TabIndex = 247;
            this.label8.Text = "Cantidad total:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Controls.Add(this.txtBuscar);
            this.panel2.Controls.Add(this.cmbFiltroBuscar);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.flowLayoutPanel2);
            this.panel2.Location = new System.Drawing.Point(3, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 28);
            this.panel2.TabIndex = 246;
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
            this.btnBuscar.Location = new System.Drawing.Point(692, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(23, 22);
            this.btnBuscar.TabIndex = 249;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(502, 5);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(188, 20);
            this.txtBuscar.TabIndex = 248;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // cmbFiltroBuscar
            // 
            this.cmbFiltroBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFiltroBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltroBuscar.FormattingEnabled = true;
            this.cmbFiltroBuscar.Location = new System.Drawing.Point(410, 4);
            this.cmbFiltroBuscar.Name = "cmbFiltroBuscar";
            this.cmbFiltroBuscar.Size = new System.Drawing.Size(89, 21);
            this.cmbFiltroBuscar.TabIndex = 247;
            this.cmbFiltroBuscar.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroBuscar_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(332, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 246;
            this.label3.Text = "Buscar por:";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this.txtFolio);
            this.flowLayoutPanel2.Controls.Add(this.label5);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel2.MaximumSize = new System.Drawing.Size(591, 26);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(60, 19);
            this.flowLayoutPanel2.TabIndex = 245;
            // 
            // txtFolio
            // 
            this.txtFolio.AutoEllipsis = true;
            this.txtFolio.AutoSize = true;
            this.txtFolio.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolio.Location = new System.Drawing.Point(44, 1);
            this.txtFolio.Margin = new System.Windows.Forms.Padding(0);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(14, 16);
            this.txtFolio.TabIndex = 242;
            this.txtFolio.Text = "2";
            this.txtFolio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(3, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 227;
            this.label5.Text = "Folio:";
            // 
            // pbCancelado
            // 
            this.pbCancelado.BackColor = System.Drawing.Color.Transparent;
            this.pbCancelado.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbCancelado.ForeColor = System.Drawing.Color.Red;
            this.pbCancelado.Location = new System.Drawing.Point(476, 252);
            this.pbCancelado.Name = "pbCancelado";
            this.pbCancelado.Size = new System.Drawing.Size(237, 63);
            this.pbCancelado.TabIndex = 244;
            this.pbCancelado.Text = "CANCELADO";
            this.pbCancelado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel3.Controls.Add(this.label4);
            this.flowLayoutPanel3.Controls.Add(this.txtUsuario);
            this.flowLayoutPanel3.Controls.Add(this.label10);
            this.flowLayoutPanel3.Controls.Add(this.txtFecha);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 338);
            this.flowLayoutPanel3.MaximumSize = new System.Drawing.Size(591, 26);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(351, 18);
            this.flowLayoutPanel3.TabIndex = 242;
            this.flowLayoutPanel3.WrapContents = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 213;
            this.label4.Text = "Realizado por:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.AutoEllipsis = true;
            this.txtUsuario.AutoSize = true;
            this.txtUsuario.Font = new System.Drawing.Font("Roboto", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(95, 1);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(0);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(43, 15);
            this.txtUsuario.TabIndex = 243;
            this.txtUsuario.Text = "Admin";
            this.txtUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(141, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 15);
            this.label10.TabIndex = 243;
            this.label10.Text = "Fecha de salida:";
            // 
            // txtFecha
            // 
            this.txtFecha.AutoEllipsis = true;
            this.txtFecha.AutoSize = true;
            this.txtFecha.Font = new System.Drawing.Font("Roboto", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(244, 1);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(0);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(105, 15);
            this.txtFecha.TabIndex = 244;
            this.txtFecha.Text = "Distribuidora ABC";
            this.txtFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDetallesSalidas
            // 
            this.dgvDetallesSalidas.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetallesSalidas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetallesSalidas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetallesSalidas.AutoGenerateColumns = false;
            this.dgvDetallesSalidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetallesSalidas.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetallesSalidas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetallesSalidas.ColumnHeadersHeight = 40;
            this.dgvDetallesSalidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetallesSalidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcID,
            this.dgvcCodigoBarras,
            this.dgvcNombreProducto,
            this.dgvcProveedor,
            this.dgvcCategoria,
            this.dgvcCantidad});
            this.dgvDetallesSalidas.DataSource = this.detalleSalidaBindingSource;
            this.dgvDetallesSalidas.GridColor = System.Drawing.Color.White;
            this.dgvDetallesSalidas.Location = new System.Drawing.Point(3, 106);
            this.dgvDetallesSalidas.Name = "dgvDetallesSalidas";
            this.dgvDetallesSalidas.ReadOnly = true;
            this.dgvDetallesSalidas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetallesSalidas.Size = new System.Drawing.Size(717, 223);
            this.dgvDetallesSalidas.TabIndex = 209;
            this.dgvDetallesSalidas.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDetallesSalidas_RowPostPaint);
            // 
            // dgvcID
            // 
            this.dgvcID.DataPropertyName = "DetalleSalidaID";
            this.dgvcID.HeaderText = "DetalleSalidaID";
            this.dgvcID.Name = "dgvcID";
            this.dgvcID.ReadOnly = true;
            this.dgvcID.Visible = false;
            // 
            // dgvcCodigoBarras
            // 
            this.dgvcCodigoBarras.DataPropertyName = "CodigoBarras";
            this.dgvcCodigoBarras.HeaderText = "Código";
            this.dgvcCodigoBarras.Name = "dgvcCodigoBarras";
            this.dgvcCodigoBarras.ReadOnly = true;
            // 
            // dgvcNombreProducto
            // 
            this.dgvcNombreProducto.DataPropertyName = "NombreProducto";
            this.dgvcNombreProducto.HeaderText = "Producto";
            this.dgvcNombreProducto.Name = "dgvcNombreProducto";
            this.dgvcNombreProducto.ReadOnly = true;
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
            // dgvcCantidad
            // 
            this.dgvcCantidad.DataPropertyName = "Cantidad";
            this.dgvcCantidad.HeaderText = "Cantidad";
            this.dgvcCantidad.Name = "dgvcCantidad";
            this.dgvcCantidad.ReadOnly = true;
            // 
            // detalleSalidaBindingSource
            // 
            this.detalleSalidaBindingSource.DataMember = "Detalle_Salida";
            this.detalleSalidaBindingSource.DataSource = this.negocio;
            // 
            // negocio
            // 
            this.negocio.DataSetName = "Negocio";
            this.negocio.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // flpContenedorBotones
            // 
            this.flpContenedorBotones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpContenedorBotones.BackColor = System.Drawing.Color.LightGray;
            this.flpContenedorBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpContenedorBotones.Controls.Add(this.btnImprimir);
            this.flpContenedorBotones.Controls.Add(this.btnCancelar);
            this.flpContenedorBotones.Location = new System.Drawing.Point(3, 3);
            this.flpContenedorBotones.Name = "flpContenedorBotones";
            this.flpContenedorBotones.Size = new System.Drawing.Size(717, 66);
            this.flpContenedorBotones.TabIndex = 208;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.White;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.Black;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.Location = new System.Drawing.Point(3, 3);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(84, 59);
            this.btnImprimir.TabIndex = 10;
            this.btnImprimir.Tag = "Imprimir";
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(93, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 59);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Tag = "Cancelar";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.btnSalir);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 364);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(723, 39);
            this.panel3.TabIndex = 104;
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
            this.btnSalir.Location = new System.Drawing.Point(616, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(104, 31);
            this.btnSalir.TabIndex = 28;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // detalle_SalidaTableAdapter
            // 
            this.detalle_SalidaTableAdapter.ClearBeforeFill = true;
            // 
            // mdDetalleSalidaInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 403);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(617, 442);
            this.Name = "mdDetalleSalidaInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de salida de inventario";
            this.Load += new System.EventHandler(this.mdDetalleSalidaInventario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesSalidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleSalidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.negocio)).EndInit();
            this.flpContenedorBotones.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtUsuario;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label txtFecha;
        private System.Windows.Forms.DataGridView dgvDetallesSalidas;
        private System.Windows.Forms.FlowLayoutPanel flpContenedorBotones;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label pbCancelado;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label txtFolio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cmbFiltroBuscar;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.BindingSource detalleSalidaBindingSource;
        private Negocio negocio;
        private NegocioTableAdapters.Detalle_SalidaTableAdapter detalle_SalidaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCodigoBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCantidad;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label label8;
    }
}