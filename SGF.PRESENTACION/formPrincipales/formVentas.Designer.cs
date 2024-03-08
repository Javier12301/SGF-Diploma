namespace SGF.PRESENTACION.formPrincipales
{
    partial class formVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formVentas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lblNumerodeVenta = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.lblCliente = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblNombreEmpresa = new System.Windows.Forms.Label();
            this.pbLogoEmpresa = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.cmbFactura = new System.Windows.Forms.ToolStripComboBox();
            this.lblTipodeFactura = new System.Windows.Forms.ToolStripLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.icoCandado = new FontAwesome.Sharp.IconPictureBox();
            this.dgvVenta = new System.Windows.Forms.DataGridView();
            this.dgvcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDisponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAumentar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDecrementar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCierreCja = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblImpuesto = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnImprimirUltimoTicket = new System.Windows.Forms.Button();
            this.btnHistorialDeVenta = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoEmpresa)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icoCandado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta)).BeginInit();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.toolStrip2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.lblNumerodeVenta,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.lblCliente,
            this.toolStripSeparator3});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(798, 25);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabel1.Text = "Número: ";
            // 
            // lblNumerodeVenta
            // 
            this.lblNumerodeVenta.ForeColor = System.Drawing.Color.White;
            this.lblNumerodeVenta.Name = "lblNumerodeVenta";
            this.lblNumerodeVenta.Size = new System.Drawing.Size(35, 22);
            this.lblNumerodeVenta.Text = "0001";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(47, 22);
            this.toolStripLabel2.Text = "Cliente:";
            // 
            // lblCliente
            // 
            this.lblCliente.ForeColor = System.Drawing.Color.White;
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(102, 22);
            this.lblCliente.Text = "Consumidor Final";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.pbLogoEmpresa);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 72);
            this.panel1.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.lblNombreEmpresa);
            this.panel3.Location = new System.Drawing.Point(99, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(695, 46);
            this.panel3.TabIndex = 12;
            // 
            // lblNombreEmpresa
            // 
            this.lblNombreEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombreEmpresa.AutoEllipsis = true;
            this.lblNombreEmpresa.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreEmpresa.Location = new System.Drawing.Point(30, 9);
            this.lblNombreEmpresa.Name = "lblNombreEmpresa";
            this.lblNombreEmpresa.Size = new System.Drawing.Size(605, 34);
            this.lblNombreEmpresa.TabIndex = 1;
            this.lblNombreEmpresa.Text = "SISTEMA DE GESTIÓN FARMACÉUTICA";
            this.lblNombreEmpresa.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbLogoEmpresa
            // 
            this.pbLogoEmpresa.Image = ((System.Drawing.Image)(resources.GetObject("pbLogoEmpresa.Image")));
            this.pbLogoEmpresa.Location = new System.Drawing.Point(5, 3);
            this.pbLogoEmpresa.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.pbLogoEmpresa.Name = "pbLogoEmpresa";
            this.pbLogoEmpresa.Size = new System.Drawing.Size(89, 66);
            this.pbLogoEmpresa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogoEmpresa.TabIndex = 11;
            this.pbLogoEmpresa.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(141)))), ((int)(((byte)(196)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.cmbFactura,
            this.lblTipodeFactura});
            this.toolStrip1.Location = new System.Drawing.Point(0, 97);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(798, 25);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel4.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(179, 22);
            this.toolStripLabel4.Text = "VENTA DE PRODUCTOS";
            // 
            // cmbFactura
            // 
            this.cmbFactura.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbFactura.AutoSize = false;
            this.cmbFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFactura.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFactura.Margin = new System.Windows.Forms.Padding(1, 1, 4, 1);
            this.cmbFactura.Name = "cmbFactura";
            this.cmbFactura.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbFactura.Size = new System.Drawing.Size(121, 23);
            // 
            // lblTipodeFactura
            // 
            this.lblTipodeFactura.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTipodeFactura.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipodeFactura.ForeColor = System.Drawing.Color.White;
            this.lblTipodeFactura.Name = "lblTipodeFactura";
            this.lblTipodeFactura.Size = new System.Drawing.Size(100, 22);
            this.lblTipodeFactura.Text = "Tipo de Factura:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cmbMoneda);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.iconButton1);
            this.panel6.Controls.Add(this.textBox1);
            this.panel6.Controls.Add(this.icoCandado);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 122);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(798, 32);
            this.panel6.TabIndex = 24;
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.Location = new System.Drawing.Point(661, 6);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(133, 21);
            this.cmbMoneda.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(588, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 30;
            this.label1.Text = "Moneda";
            // 
            // iconButton1
            // 
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 24;
            this.iconButton1.Location = new System.Drawing.Point(274, 3);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(29, 26);
            this.iconButton1.TabIndex = 29;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(209)))));
            this.textBox1.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(39, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(231, 26);
            this.textBox1.TabIndex = 28;
            // 
            // icoCandado
            // 
            this.icoCandado.BackColor = System.Drawing.Color.White;
            this.icoCandado.ForeColor = System.Drawing.Color.Black;
            this.icoCandado.IconChar = FontAwesome.Sharp.IconChar.Barcode;
            this.icoCandado.IconColor = System.Drawing.Color.Black;
            this.icoCandado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoCandado.IconSize = 29;
            this.icoCandado.Location = new System.Drawing.Point(4, 2);
            this.icoCandado.Name = "icoCandado";
            this.icoCandado.Size = new System.Drawing.Size(29, 29);
            this.icoCandado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.icoCandado.TabIndex = 27;
            this.icoCandado.TabStop = false;
            // 
            // dgvVenta
            // 
            this.dgvVenta.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvVenta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVenta.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvVenta.ColumnHeadersHeight = 27;
            this.dgvVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcID,
            this.dgvcProducto,
            this.dgvcCantidad,
            this.dgvcPrecio,
            this.dgvcDescuento,
            this.dgvcTotal,
            this.dgvcDisponible,
            this.btnAumentar,
            this.btnDecrementar,
            this.btnEliminar});
            this.dgvVenta.GridColor = System.Drawing.Color.White;
            this.dgvVenta.Location = new System.Drawing.Point(0, 160);
            this.dgvVenta.Name = "dgvVenta";
            this.dgvVenta.ReadOnly = true;
            this.dgvVenta.RowHeadersVisible = false;
            this.dgvVenta.Size = new System.Drawing.Size(798, 127);
            this.dgvVenta.TabIndex = 25;
            // 
            // dgvcID
            // 
            this.dgvcID.HeaderText = "ID";
            this.dgvcID.Name = "dgvcID";
            this.dgvcID.ReadOnly = true;
            this.dgvcID.Visible = false;
            // 
            // dgvcProducto
            // 
            this.dgvcProducto.FillWeight = 180F;
            this.dgvcProducto.HeaderText = "Producto";
            this.dgvcProducto.Name = "dgvcProducto";
            this.dgvcProducto.ReadOnly = true;
            // 
            // dgvcCantidad
            // 
            this.dgvcCantidad.FillWeight = 78.08739F;
            this.dgvcCantidad.HeaderText = "Cantidad";
            this.dgvcCantidad.Name = "dgvcCantidad";
            this.dgvcCantidad.ReadOnly = true;
            // 
            // dgvcPrecio
            // 
            this.dgvcPrecio.FillWeight = 51.2655F;
            this.dgvcPrecio.HeaderText = "Precio";
            this.dgvcPrecio.Name = "dgvcPrecio";
            this.dgvcPrecio.ReadOnly = true;
            // 
            // dgvcDescuento
            // 
            this.dgvcDescuento.FillWeight = 78.08739F;
            this.dgvcDescuento.HeaderText = "Descuento";
            this.dgvcDescuento.Name = "dgvcDescuento";
            this.dgvcDescuento.ReadOnly = true;
            // 
            // dgvcTotal
            // 
            this.dgvcTotal.FillWeight = 51.2655F;
            this.dgvcTotal.HeaderText = "Importe";
            this.dgvcTotal.Name = "dgvcTotal";
            this.dgvcTotal.ReadOnly = true;
            // 
            // dgvcDisponible
            // 
            this.dgvcDisponible.FillWeight = 78.08739F;
            this.dgvcDisponible.HeaderText = "Disponible";
            this.dgvcDisponible.Name = "dgvcDisponible";
            this.dgvcDisponible.ReadOnly = true;
            // 
            // btnAumentar
            // 
            this.btnAumentar.HeaderText = "";
            this.btnAumentar.Name = "btnAumentar";
            this.btnAumentar.ReadOnly = true;
            // 
            // btnDecrementar
            // 
            this.btnDecrementar.HeaderText = "";
            this.btnDecrementar.Name = "btnDecrementar";
            this.btnDecrementar.ReadOnly = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.FillWeight = 50F;
            this.btnEliminar.HeaderText = "";
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(141)))), ((int)(((byte)(202)))));
            this.panel2.Controls.Add(this.flowLayoutPanel2);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 293);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 71);
            this.panel2.TabIndex = 26;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(233)))));
            this.flowLayoutPanel2.Controls.Add(this.btnCierreCja);
            this.flowLayoutPanel2.Controls.Add(this.button1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(291, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(230, 64);
            this.flowLayoutPanel2.TabIndex = 24;
            // 
            // btnCierreCja
            // 
            this.btnCierreCja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(223)))), ((int)(((byte)(241)))));
            this.btnCierreCja.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCierreCja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCierreCja.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCierreCja.ForeColor = System.Drawing.Color.Black;
            this.btnCierreCja.Image = ((System.Drawing.Image)(resources.GetObject("btnCierreCja.Image")));
            this.btnCierreCja.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCierreCja.Location = new System.Drawing.Point(3, 3);
            this.btnCierreCja.Name = "btnCierreCja";
            this.btnCierreCja.Size = new System.Drawing.Size(113, 59);
            this.btnCierreCja.TabIndex = 7;
            this.btnCierreCja.Text = "Cierre de caja";
            this.btnCierreCja.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCierreCja.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(223)))), ((int)(((byte)(241)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(122, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 59);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cobrar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(233)))));
            this.panel5.Controls.Add(this.lblImpuesto);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.lblSubTotal);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label2);
            this.panel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(127)))), ((int)(((byte)(176)))));
            this.panel5.Location = new System.Drawing.Point(524, 2);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(270, 64);
            this.panel5.TabIndex = 25;
            // 
            // lblImpuesto
            // 
            this.lblImpuesto.AutoEllipsis = true;
            this.lblImpuesto.BackColor = System.Drawing.Color.White;
            this.lblImpuesto.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImpuesto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(110)))), ((int)(((byte)(142)))));
            this.lblImpuesto.Location = new System.Drawing.Point(67, 33);
            this.lblImpuesto.Name = "lblImpuesto";
            this.lblImpuesto.Size = new System.Drawing.Size(68, 27);
            this.lblImpuesto.TabIndex = 19;
            this.lblImpuesto.Text = "2.800,20";
            this.lblImpuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Impuesto:";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoEllipsis = true;
            this.lblSubTotal.BackColor = System.Drawing.Color.White;
            this.lblSubTotal.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(110)))), ((int)(((byte)(142)))));
            this.lblSubTotal.Location = new System.Drawing.Point(67, 3);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(68, 27);
            this.lblSubTotal.TabIndex = 17;
            this.lblSubTotal.Text = "2.800,20";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Subtotal:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(110)))), ((int)(((byte)(142)))));
            this.label2.Location = new System.Drawing.Point(141, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 57);
            this.label2.TabIndex = 15;
            this.label2.Text = "5";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(233)))));
            this.panel4.Controls.Add(this.btnImprimirUltimoTicket);
            this.panel4.Controls.Add(this.btnHistorialDeVenta);
            this.panel4.Controls.Add(this.btnClientes);
            this.panel4.Location = new System.Drawing.Point(4, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(275, 64);
            this.panel4.TabIndex = 18;
            // 
            // btnImprimirUltimoTicket
            // 
            this.btnImprimirUltimoTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(223)))), ((int)(((byte)(241)))));
            this.btnImprimirUltimoTicket.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnImprimirUltimoTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirUltimoTicket.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirUltimoTicket.ForeColor = System.Drawing.Color.Black;
            this.btnImprimirUltimoTicket.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirUltimoTicket.Image")));
            this.btnImprimirUltimoTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirUltimoTicket.Location = new System.Drawing.Point(8, 33);
            this.btnImprimirUltimoTicket.Name = "btnImprimirUltimoTicket";
            this.btnImprimirUltimoTicket.Size = new System.Drawing.Size(167, 27);
            this.btnImprimirUltimoTicket.TabIndex = 10;
            this.btnImprimirUltimoTicket.Text = "Reimprimir última venta";
            this.btnImprimirUltimoTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimirUltimoTicket.UseVisualStyleBackColor = false;
            // 
            // btnHistorialDeVenta
            // 
            this.btnHistorialDeVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(223)))), ((int)(((byte)(241)))));
            this.btnHistorialDeVenta.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnHistorialDeVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorialDeVenta.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnHistorialDeVenta.ForeColor = System.Drawing.Color.Black;
            this.btnHistorialDeVenta.Image = ((System.Drawing.Image)(resources.GetObject("btnHistorialDeVenta.Image")));
            this.btnHistorialDeVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorialDeVenta.Location = new System.Drawing.Point(8, 3);
            this.btnHistorialDeVenta.Name = "btnHistorialDeVenta";
            this.btnHistorialDeVenta.Size = new System.Drawing.Size(167, 27);
            this.btnHistorialDeVenta.TabIndex = 9;
            this.btnHistorialDeVenta.Text = "Historial de Venta";
            this.btnHistorialDeVenta.UseVisualStyleBackColor = false;
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(223)))), ((int)(((byte)(241)))));
            this.btnClientes.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.Black;
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClientes.Location = new System.Drawing.Point(182, 2);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(84, 59);
            this.btnClientes.TabIndex = 8;
            this.btnClientes.Text = "CLIENTES";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // formVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 364);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvVenta);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formVentas";
            this.Text = "formVentas";
            this.Load += new System.EventHandler(this.formVentas_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoEmpresa)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icoCandado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta)).EndInit();
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel lblNumerodeVenta;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel lblCliente;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblNombreEmpresa;
        private System.Windows.Forms.PictureBox pbLogoEmpresa;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox cmbFactura;
        private System.Windows.Forms.ToolStripLabel lblTipodeFactura;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.TextBox textBox1;
        private FontAwesome.Sharp.IconPictureBox icoCandado;
        private System.Windows.Forms.DataGridView dgvVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDisponible;
        private System.Windows.Forms.DataGridViewButtonColumn btnAumentar;
        private System.Windows.Forms.DataGridViewButtonColumn btnDecrementar;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnCierreCja;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblImpuesto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnImprimirUltimoTicket;
        private System.Windows.Forms.Button btnHistorialDeVenta;
        private System.Windows.Forms.Button btnClientes;
    }
}