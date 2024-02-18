namespace SGF.PRESENTACION.formModales
{
    partial class mdDetalleCompraEntrada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdDetalleCompraEntrada));
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pbCancelado = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtFolio = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTipoComprobante = new System.Windows.Forms.Label();
            this.dgvDetallesCompras = new System.Windows.Forms.DataGridView();
            this.dgvcCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCantidadComprada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcPrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalleCompraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.negocio = new SGF.PRESENTACION.Negocio();
            this.flpContenedorBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.detalle_CompraTableAdapter = new SGF.PRESENTACION.NegocioTableAdapters.Detalle_CompraTableAdapter();
            this.printDatagrid = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleCompraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.negocio)).BeginInit();
            this.flpContenedorBotones.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel5);
            this.panel1.Controls.Add(this.pbCancelado);
            this.panel1.Controls.Add(this.flowLayoutPanel3);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.dgvDetallesCompras);
            this.panel1.Controls.Add(this.flpContenedorBotones);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 403);
            this.panel1.TabIndex = 0;
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
            this.flowLayoutPanel5.Location = new System.Drawing.Point(531, 334);
            this.flowLayoutPanel5.MaximumSize = new System.Drawing.Size(591, 26);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(187, 26);
            this.flowLayoutPanel5.TabIndex = 248;
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.Black;
            this.txtTotal.Location = new System.Drawing.Point(105, 0);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 0, 0, 1);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Padding = new System.Windows.Forms.Padding(2);
            this.txtTotal.Size = new System.Drawing.Size(80, 25);
            this.txtTotal.TabIndex = 245;
            this.txtTotal.Text = "$3500.52";
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
            this.label8.Size = new System.Drawing.Size(96, 22);
            this.label8.TabIndex = 247;
            this.label8.Text = "Precio total:";
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
            this.flowLayoutPanel3.Size = new System.Drawing.Size(361, 18);
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
            this.label10.Size = new System.Drawing.Size(110, 15);
            this.label10.TabIndex = 243;
            this.label10.Text = "Fecha de compra:";
            // 
            // txtFecha
            // 
            this.txtFecha.AutoEllipsis = true;
            this.txtFecha.AutoSize = true;
            this.txtFecha.Font = new System.Drawing.Font("Roboto", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(254, 1);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(0);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(105, 15);
            this.txtFecha.TabIndex = 244;
            this.txtFecha.Text = "Distribuidora ABC";
            this.txtFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this.txtFolio);
            this.flowLayoutPanel2.Controls.Add(this.label5);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(651, 72);
            this.flowLayoutPanel2.MaximumSize = new System.Drawing.Size(591, 26);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(67, 19);
            this.flowLayoutPanel2.TabIndex = 241;
            // 
            // txtFolio
            // 
            this.txtFolio.AutoEllipsis = true;
            this.txtFolio.AutoSize = true;
            this.txtFolio.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolio.Location = new System.Drawing.Point(44, 1);
            this.txtFolio.Margin = new System.Windows.Forms.Padding(0);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(21, 16);
            this.txtFolio.TabIndex = 242;
            this.txtFolio.Text = "55";
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtProveedor);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.txtDocumento);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.txtTipoComprobante);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 73);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(591, 26);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(444, 17);
            this.flowLayoutPanel1.TabIndex = 240;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 14);
            this.label1.TabIndex = 236;
            this.label1.Text = "Proveedor:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtProveedor
            // 
            this.txtProveedor.AutoEllipsis = true;
            this.txtProveedor.AutoSize = true;
            this.txtProveedor.Font = new System.Drawing.Font("Roboto", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProveedor.Location = new System.Drawing.Point(71, 1);
            this.txtProveedor.Margin = new System.Windows.Forms.Padding(0);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(101, 14);
            this.txtProveedor.TabIndex = 241;
            this.txtProveedor.Text = "Distribuidora ABC";
            this.txtProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(175, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 14);
            this.label7.TabIndex = 238;
            this.label7.Text = "Documento:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.AutoEllipsis = true;
            this.txtDocumento.AutoSize = true;
            this.txtDocumento.Font = new System.Drawing.Font("Roboto", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))));
            this.txtDocumento.Location = new System.Drawing.Point(250, 1);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(0);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(63, 14);
            this.txtDocumento.TabIndex = 242;
            this.txtDocumento.Text = "22448403";
            this.txtDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(316, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 14);
            this.label6.TabIndex = 241;
            this.label6.Text = "Comprobante:";
            // 
            // txtTipoComprobante
            // 
            this.txtTipoComprobante.AutoEllipsis = true;
            this.txtTipoComprobante.AutoSize = true;
            this.txtTipoComprobante.Font = new System.Drawing.Font("Roboto", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))));
            this.txtTipoComprobante.Location = new System.Drawing.Point(402, 1);
            this.txtTipoComprobante.Margin = new System.Windows.Forms.Padding(0);
            this.txtTipoComprobante.Name = "txtTipoComprobante";
            this.txtTipoComprobante.Size = new System.Drawing.Size(40, 14);
            this.txtTipoComprobante.TabIndex = 242;
            this.txtTipoComprobante.Text = "Boleta";
            this.txtTipoComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDetallesCompras
            // 
            this.dgvDetallesCompras.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetallesCompras.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetallesCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetallesCompras.AutoGenerateColumns = false;
            this.dgvDetallesCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetallesCompras.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetallesCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetallesCompras.ColumnHeadersHeight = 40;
            this.dgvDetallesCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetallesCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcCodigo,
            this.dgvcProducto,
            this.dgvcCantidadComprada,
            this.dgvcPrecioCompra,
            this.dgvcSubTotal});
            this.dgvDetallesCompras.DataSource = this.detalleCompraBindingSource;
            this.dgvDetallesCompras.GridColor = System.Drawing.Color.White;
            this.dgvDetallesCompras.Location = new System.Drawing.Point(3, 97);
            this.dgvDetallesCompras.Name = "dgvDetallesCompras";
            this.dgvDetallesCompras.ReadOnly = true;
            this.dgvDetallesCompras.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetallesCompras.Size = new System.Drawing.Size(717, 232);
            this.dgvDetallesCompras.TabIndex = 209;
            this.dgvDetallesCompras.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDetallesCompras_RowPostPaint);
            // 
            // dgvcCodigo
            // 
            this.dgvcCodigo.DataPropertyName = "CodigoBarras";
            this.dgvcCodigo.HeaderText = "Código";
            this.dgvcCodigo.Name = "dgvcCodigo";
            this.dgvcCodigo.ReadOnly = true;
            // 
            // dgvcProducto
            // 
            this.dgvcProducto.DataPropertyName = "Nombre de Producto";
            this.dgvcProducto.HeaderText = "Producto";
            this.dgvcProducto.Name = "dgvcProducto";
            this.dgvcProducto.ReadOnly = true;
            // 
            // dgvcCantidadComprada
            // 
            this.dgvcCantidadComprada.DataPropertyName = "Cantidad Comprada";
            this.dgvcCantidadComprada.HeaderText = "Cantidad comprada";
            this.dgvcCantidadComprada.Name = "dgvcCantidadComprada";
            this.dgvcCantidadComprada.ReadOnly = true;
            // 
            // dgvcPrecioCompra
            // 
            this.dgvcPrecioCompra.DataPropertyName = "Precio de Compra";
            this.dgvcPrecioCompra.HeaderText = "Precio de compra";
            this.dgvcPrecioCompra.Name = "dgvcPrecioCompra";
            this.dgvcPrecioCompra.ReadOnly = true;
            // 
            // dgvcSubTotal
            // 
            this.dgvcSubTotal.DataPropertyName = "Sub Total";
            this.dgvcSubTotal.HeaderText = "Sub total";
            this.dgvcSubTotal.Name = "dgvcSubTotal";
            this.dgvcSubTotal.ReadOnly = true;
            // 
            // detalleCompraBindingSource
            // 
            this.detalleCompraBindingSource.DataMember = "Detalle_Compra";
            this.detalleCompraBindingSource.DataSource = this.negocio;
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
            // detalle_CompraTableAdapter
            // 
            this.detalle_CompraTableAdapter.ClearBeforeFill = true;
            // 
            // printDatagrid
            // 
            this.printDatagrid.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDatagrid_PrintPage);
            // 
            // mdDetalleCompraEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(723, 403);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(617, 442);
            this.Name = "mdDetalleCompraEntrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalles de compra";
            this.Load += new System.EventHandler(this.mdDetalleCompraEntrada_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleCompraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.negocio)).EndInit();
            this.flpContenedorBotones.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpContenedorBotones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvDetallesCompras;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource detalleCompraBindingSource;
        private Negocio negocio;
        private NegocioTableAdapters.Detalle_CompraTableAdapter detalle_CompraTableAdapter;
        private System.Drawing.Printing.PrintDocument printDatagrid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label txtProveedor;
        private System.Windows.Forms.Label txtDocumento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtTipoComprobante;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label txtFolio;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label txtUsuario;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label txtFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCantidadComprada;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcPrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSubTotal;
        private System.Windows.Forms.Label pbCancelado;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label label8;
    }
}