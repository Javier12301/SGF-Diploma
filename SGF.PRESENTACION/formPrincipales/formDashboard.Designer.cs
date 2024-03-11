namespace SGF.PRESENTACION.formPrincipales
{
    partial class formDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            this.lblComprasTotales = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblProveedoresTotales = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.lblCategoriasUsadas = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCategoriasTotales = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.lblMedicamentosVendidos = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMedicamentosTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.lblProductosGeneralVendidos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProductosGeneralTotal = new System.Windows.Forms.Label();
            this.lblProductos = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.dgvProductosPorVencer = new System.Windows.Forms.DataGridView();
            this.productoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoBarrasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroLoteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaVencimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refrigeradoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvcBajoReceta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.productoReporteVencimientoTempranoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportes = new SGF.PRESENTACION.Reportes();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.productoReporteVentasPorMesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgvRankingProductos = new System.Windows.Forms.DataGridView();
            this.codigoBarrasDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroLoteDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDeProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadVendidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoReporteMasVendidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.producto_Reporte_VencimientoTempranoTableAdapter = new SGF.PRESENTACION.ReportesTableAdapters.Producto_Reporte_VencimientoTempranoTableAdapter();
            this.producto_Reporte_MasVendidosTableAdapter = new SGF.PRESENTACION.ReportesTableAdapters.Producto_Reporte_MasVendidosTableAdapter();
            this.producto_Reporte_VentasPorMesTableAdapter = new SGF.PRESENTACION.ReportesTableAdapters.Producto_Reporte_VentasPorMesTableAdapter();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.panel7.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosPorVencer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoReporteVencimientoTempranoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportes)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoReporteVentasPorMesBindingSource)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankingProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoReporteMasVendidosBindingSource)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1077, 42);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(497, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Principal";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel6, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 49);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1067, 102);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.iconPictureBox4);
            this.panel6.Controls.Add(this.lblComprasTotales);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.lblProveedoresTotales);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Font = new System.Drawing.Font("Vivaldi", 8.25F);
            this.panel6.Location = new System.Drawing.Point(798, 2);
            this.panel6.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(259, 90);
            this.panel6.TabIndex = 4;
            // 
            // iconPictureBox4
            // 
            this.iconPictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBox4.BackColor = System.Drawing.Color.White;
            this.iconPictureBox4.ForeColor = System.Drawing.Color.OrangeRed;
            this.iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.Truck;
            this.iconPictureBox4.IconColor = System.Drawing.Color.OrangeRed;
            this.iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox4.IconSize = 26;
            this.iconPictureBox4.Location = new System.Drawing.Point(229, 3);
            this.iconPictureBox4.Name = "iconPictureBox4";
            this.iconPictureBox4.Size = new System.Drawing.Size(26, 26);
            this.iconPictureBox4.TabIndex = 7;
            this.iconPictureBox4.TabStop = false;
            // 
            // lblComprasTotales
            // 
            this.lblComprasTotales.AutoEllipsis = true;
            this.lblComprasTotales.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComprasTotales.ForeColor = System.Drawing.Color.Black;
            this.lblComprasTotales.Location = new System.Drawing.Point(113, 70);
            this.lblComprasTotales.Name = "lblComprasTotales";
            this.lblComprasTotales.Size = new System.Drawing.Size(141, 14);
            this.lblComprasTotales.TabIndex = 3;
            this.lblComprasTotales.Text = "3124214";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(4, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 14);
            this.label9.TabIndex = 2;
            this.label9.Text = "Compras realizadas:";
            // 
            // lblProveedoresTotales
            // 
            this.lblProveedoresTotales.AutoEllipsis = true;
            this.lblProveedoresTotales.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedoresTotales.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblProveedoresTotales.Location = new System.Drawing.Point(4, 37);
            this.lblProveedoresTotales.Name = "lblProveedoresTotales";
            this.lblProveedoresTotales.Size = new System.Drawing.Size(252, 19);
            this.lblProveedoresTotales.TabIndex = 1;
            this.lblProveedoresTotales.Text = "3124214";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.OrangeRed;
            this.label11.Location = new System.Drawing.Point(4, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 19);
            this.label11.TabIndex = 0;
            this.label11.Text = "Proveedores";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.iconPictureBox3);
            this.panel5.Controls.Add(this.lblCategoriasUsadas);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.lblCategoriasTotales);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Font = new System.Drawing.Font("Vivaldi", 8.25F);
            this.panel5.Location = new System.Drawing.Point(532, 2);
            this.panel5.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(256, 90);
            this.panel5.TabIndex = 3;
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBox3.BackColor = System.Drawing.Color.White;
            this.iconPictureBox3.ForeColor = System.Drawing.Color.Green;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.Tag;
            this.iconPictureBox3.IconColor = System.Drawing.Color.Green;
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 26;
            this.iconPictureBox3.Location = new System.Drawing.Point(227, 3);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(26, 26);
            this.iconPictureBox3.TabIndex = 6;
            this.iconPictureBox3.TabStop = false;
            // 
            // lblCategoriasUsadas
            // 
            this.lblCategoriasUsadas.AutoEllipsis = true;
            this.lblCategoriasUsadas.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoriasUsadas.ForeColor = System.Drawing.Color.Black;
            this.lblCategoriasUsadas.Location = new System.Drawing.Point(157, 70);
            this.lblCategoriasUsadas.Name = "lblCategoriasUsadas";
            this.lblCategoriasUsadas.Size = new System.Drawing.Size(94, 14);
            this.lblCategoriasUsadas.TabIndex = 3;
            this.lblCategoriasUsadas.Text = "3124214";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(4, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Productos con categorías:";
            // 
            // lblCategoriasTotales
            // 
            this.lblCategoriasTotales.AutoEllipsis = true;
            this.lblCategoriasTotales.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoriasTotales.ForeColor = System.Drawing.Color.Green;
            this.lblCategoriasTotales.Location = new System.Drawing.Point(4, 37);
            this.lblCategoriasTotales.Name = "lblCategoriasTotales";
            this.lblCategoriasTotales.Size = new System.Drawing.Size(252, 19);
            this.lblCategoriasTotales.TabIndex = 1;
            this.lblCategoriasTotales.Text = "3124214";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Green;
            this.label8.Location = new System.Drawing.Point(4, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Categorías";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.iconPictureBox2);
            this.panel4.Controls.Add(this.lblMedicamentosVendidos);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.lblMedicamentosTotal);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("Vivaldi", 8.25F);
            this.panel4.Location = new System.Drawing.Point(266, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(256, 90);
            this.panel4.TabIndex = 1;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBox2.BackColor = System.Drawing.Color.White;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.SteelBlue;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Pills;
            this.iconPictureBox2.IconColor = System.Drawing.Color.SteelBlue;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 26;
            this.iconPictureBox2.Location = new System.Drawing.Point(227, 3);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(26, 26);
            this.iconPictureBox2.TabIndex = 5;
            this.iconPictureBox2.TabStop = false;
            // 
            // lblMedicamentosVendidos
            // 
            this.lblMedicamentosVendidos.AutoEllipsis = true;
            this.lblMedicamentosVendidos.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicamentosVendidos.ForeColor = System.Drawing.Color.Black;
            this.lblMedicamentosVendidos.Location = new System.Drawing.Point(65, 70);
            this.lblMedicamentosVendidos.Name = "lblMedicamentosVendidos";
            this.lblMedicamentosVendidos.Size = new System.Drawing.Size(185, 14);
            this.lblMedicamentosVendidos.TabIndex = 3;
            this.lblMedicamentosVendidos.Text = "3124214";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(4, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "Vendidos:";
            // 
            // lblMedicamentosTotal
            // 
            this.lblMedicamentosTotal.AutoEllipsis = true;
            this.lblMedicamentosTotal.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicamentosTotal.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMedicamentosTotal.Location = new System.Drawing.Point(4, 37);
            this.lblMedicamentosTotal.Name = "lblMedicamentosTotal";
            this.lblMedicamentosTotal.Size = new System.Drawing.Size(252, 19);
            this.lblMedicamentosTotal.TabIndex = 1;
            this.lblMedicamentosTotal.Text = "3124214";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(4, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Medicamentos";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.iconPictureBox1);
            this.panel3.Controls.Add(this.lblProductosGeneralVendidos);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lblProductosGeneralTotal);
            this.panel3.Controls.Add(this.lblProductos);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Vivaldi", 8.25F);
            this.panel3.Location = new System.Drawing.Point(0, 2);
            this.panel3.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(256, 90);
            this.panel3.TabIndex = 0;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBox1.BackColor = System.Drawing.Color.White;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.DarkOrange;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Box;
            this.iconPictureBox1.IconColor = System.Drawing.Color.DarkOrange;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 26;
            this.iconPictureBox1.Location = new System.Drawing.Point(226, 3);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(26, 26);
            this.iconPictureBox1.TabIndex = 4;
            this.iconPictureBox1.TabStop = false;
            // 
            // lblProductosGeneralVendidos
            // 
            this.lblProductosGeneralVendidos.AutoEllipsis = true;
            this.lblProductosGeneralVendidos.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductosGeneralVendidos.ForeColor = System.Drawing.Color.Black;
            this.lblProductosGeneralVendidos.Location = new System.Drawing.Point(65, 70);
            this.lblProductosGeneralVendidos.Name = "lblProductosGeneralVendidos";
            this.lblProductosGeneralVendidos.Size = new System.Drawing.Size(185, 14);
            this.lblProductosGeneralVendidos.TabIndex = 3;
            this.lblProductosGeneralVendidos.Text = "3124214";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vendidos:";
            // 
            // lblProductosGeneralTotal
            // 
            this.lblProductosGeneralTotal.AutoEllipsis = true;
            this.lblProductosGeneralTotal.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductosGeneralTotal.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblProductosGeneralTotal.Location = new System.Drawing.Point(4, 37);
            this.lblProductosGeneralTotal.Name = "lblProductosGeneralTotal";
            this.lblProductosGeneralTotal.Size = new System.Drawing.Size(252, 19);
            this.lblProductosGeneralTotal.TabIndex = 1;
            this.lblProductosGeneralTotal.Text = "3124214";
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductos.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblProductos.Location = new System.Drawing.Point(4, 4);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(141, 19);
            this.lblProductos.TabIndex = 0;
            this.lblProductos.Text = "Productos general";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.Controls.Add(this.toolStrip1);
            this.panel7.Controls.Add(this.dgvProductosPorVencer);
            this.panel7.Location = new System.Drawing.Point(9, 273);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(5, 2, 5, 0);
            this.panel7.Size = new System.Drawing.Size(765, 154);
            this.panel7.TabIndex = 111;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(141)))), ((int)(((byte)(196)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(5, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(755, 25);
            this.toolStrip1.TabIndex = 111;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(131, 22);
            this.toolStripLabel1.Text = "Productos por vencer";
            // 
            // dgvProductosPorVencer
            // 
            this.dgvProductosPorVencer.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductosPorVencer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductosPorVencer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductosPorVencer.AutoGenerateColumns = false;
            this.dgvProductosPorVencer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductosPorVencer.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductosPorVencer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductosPorVencer.ColumnHeadersHeight = 40;
            this.dgvProductosPorVencer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProductosPorVencer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productoIDDataGridViewTextBoxColumn,
            this.codigoBarrasDataGridViewTextBoxColumn,
            this.numeroLoteDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.Categoria,
            this.Proveedor,
            this.fechaVencimientoDataGridViewTextBoxColumn,
            this.refrigeradoDataGridViewCheckBoxColumn,
            this.dgvcBajoReceta});
            this.dgvProductosPorVencer.DataSource = this.productoReporteVencimientoTempranoBindingSource;
            this.dgvProductosPorVencer.GridColor = System.Drawing.Color.White;
            this.dgvProductosPorVencer.Location = new System.Drawing.Point(5, 30);
            this.dgvProductosPorVencer.Name = "dgvProductosPorVencer";
            this.dgvProductosPorVencer.ReadOnly = true;
            this.dgvProductosPorVencer.RowHeadersVisible = false;
            this.dgvProductosPorVencer.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductosPorVencer.Size = new System.Drawing.Size(757, 120);
            this.dgvProductosPorVencer.TabIndex = 110;
            // 
            // productoIDDataGridViewTextBoxColumn
            // 
            this.productoIDDataGridViewTextBoxColumn.DataPropertyName = "ProductoID";
            this.productoIDDataGridViewTextBoxColumn.HeaderText = "ProductoID";
            this.productoIDDataGridViewTextBoxColumn.Name = "productoIDDataGridViewTextBoxColumn";
            this.productoIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.productoIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // codigoBarrasDataGridViewTextBoxColumn
            // 
            this.codigoBarrasDataGridViewTextBoxColumn.DataPropertyName = "CodigoBarras";
            this.codigoBarrasDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codigoBarrasDataGridViewTextBoxColumn.Name = "codigoBarrasDataGridViewTextBoxColumn";
            this.codigoBarrasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeroLoteDataGridViewTextBoxColumn
            // 
            this.numeroLoteDataGridViewTextBoxColumn.DataPropertyName = "NumeroLote";
            this.numeroLoteDataGridViewTextBoxColumn.HeaderText = "Lote";
            this.numeroLoteDataGridViewTextBoxColumn.Name = "numeroLoteDataGridViewTextBoxColumn";
            this.numeroLoteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Categoria
            // 
            this.Categoria.DataPropertyName = "Categoria";
            this.Categoria.HeaderText = "Categoría";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            // 
            // Proveedor
            // 
            this.Proveedor.DataPropertyName = "Proveedor";
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.ReadOnly = true;
            // 
            // fechaVencimientoDataGridViewTextBoxColumn
            // 
            this.fechaVencimientoDataGridViewTextBoxColumn.DataPropertyName = "FechaVencimiento";
            this.fechaVencimientoDataGridViewTextBoxColumn.HeaderText = "Vencimiento";
            this.fechaVencimientoDataGridViewTextBoxColumn.Name = "fechaVencimientoDataGridViewTextBoxColumn";
            this.fechaVencimientoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // refrigeradoDataGridViewCheckBoxColumn
            // 
            this.refrigeradoDataGridViewCheckBoxColumn.DataPropertyName = "Refrigerado";
            this.refrigeradoDataGridViewCheckBoxColumn.HeaderText = "Refrigerado";
            this.refrigeradoDataGridViewCheckBoxColumn.Name = "refrigeradoDataGridViewCheckBoxColumn";
            this.refrigeradoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // dgvcBajoReceta
            // 
            this.dgvcBajoReceta.DataPropertyName = "BajoReceta";
            this.dgvcBajoReceta.HeaderText = "Receta";
            this.dgvcBajoReceta.Name = "dgvcBajoReceta";
            this.dgvcBajoReceta.ReadOnly = true;
            // 
            // productoReporteVencimientoTempranoBindingSource
            // 
            this.productoReporteVencimientoTempranoBindingSource.DataMember = "Producto_Reporte_VencimientoTemprano";
            this.productoReporteVencimientoTempranoBindingSource.DataSource = this.reportes;
            // 
            // reportes
            // 
            this.reportes.DataSetName = "Reportes";
            this.reportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.cVentas);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(1081, 448);
            this.panel1.TabIndex = 2;
            // 
            // cVentas
            // 
            this.cVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.cVentas.ChartAreas.Add(chartArea1);
            this.cVentas.DataSource = this.productoReporteVentasPorMesBindingSource;
            legend1.Name = "Legend1";
            this.cVentas.Legends.Add(legend1);
            this.cVentas.Location = new System.Drawing.Point(9, 155);
            this.cVentas.Name = "cVentas";
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.MarkerBorderWidth = 5;
            series1.Name = "Ventas";
            series1.XValueMember = "Month";
            series1.YValueMembers = "NumeroDeVentas";
            series1.YValuesPerPoint = 3;
            this.cVentas.Series.Add(series1);
            this.cVentas.Size = new System.Drawing.Size(765, 112);
            this.cVentas.TabIndex = 114;
            this.cVentas.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Resumen de ventas por mes";
            this.cVentas.Titles.Add(title1);
            // 
            // productoReporteVentasPorMesBindingSource
            // 
            this.productoReporteVentasPorMesBindingSource.DataMember = "Producto_Reporte_VentasPorMes";
            this.productoReporteVentasPorMesBindingSource.DataSource = this.reportes;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.Controls.Add(this.dgvRankingProductos);
            this.panel8.Controls.Add(this.toolStrip2);
            this.panel8.Location = new System.Drawing.Point(780, 155);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(296, 271);
            this.panel8.TabIndex = 112;
            // 
            // dgvRankingProductos
            // 
            this.dgvRankingProductos.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRankingProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRankingProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRankingProductos.AutoGenerateColumns = false;
            this.dgvRankingProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRankingProductos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRankingProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRankingProductos.ColumnHeadersHeight = 40;
            this.dgvRankingProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRankingProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoBarrasDataGridViewTextBoxColumn1,
            this.numeroLoteDataGridViewTextBoxColumn1,
            this.nombreDeProductoDataGridViewTextBoxColumn,
            this.tipoProductoDataGridViewTextBoxColumn,
            this.cantidadVendidaDataGridViewTextBoxColumn});
            this.dgvRankingProductos.DataSource = this.productoReporteMasVendidosBindingSource;
            this.dgvRankingProductos.GridColor = System.Drawing.Color.White;
            this.dgvRankingProductos.Location = new System.Drawing.Point(3, 28);
            this.dgvRankingProductos.Name = "dgvRankingProductos";
            this.dgvRankingProductos.ReadOnly = true;
            this.dgvRankingProductos.RowHeadersVisible = false;
            this.dgvRankingProductos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRankingProductos.Size = new System.Drawing.Size(290, 240);
            this.dgvRankingProductos.TabIndex = 113;
            // 
            // codigoBarrasDataGridViewTextBoxColumn1
            // 
            this.codigoBarrasDataGridViewTextBoxColumn1.DataPropertyName = "CodigoBarras";
            this.codigoBarrasDataGridViewTextBoxColumn1.HeaderText = "Código";
            this.codigoBarrasDataGridViewTextBoxColumn1.Name = "codigoBarrasDataGridViewTextBoxColumn1";
            this.codigoBarrasDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // numeroLoteDataGridViewTextBoxColumn1
            // 
            this.numeroLoteDataGridViewTextBoxColumn1.DataPropertyName = "NumeroLote";
            this.numeroLoteDataGridViewTextBoxColumn1.HeaderText = "Lote";
            this.numeroLoteDataGridViewTextBoxColumn1.Name = "numeroLoteDataGridViewTextBoxColumn1";
            this.numeroLoteDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nombreDeProductoDataGridViewTextBoxColumn
            // 
            this.nombreDeProductoDataGridViewTextBoxColumn.DataPropertyName = "Nombre de Producto";
            this.nombreDeProductoDataGridViewTextBoxColumn.HeaderText = "Producto";
            this.nombreDeProductoDataGridViewTextBoxColumn.Name = "nombreDeProductoDataGridViewTextBoxColumn";
            this.nombreDeProductoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoProductoDataGridViewTextBoxColumn
            // 
            this.tipoProductoDataGridViewTextBoxColumn.DataPropertyName = "TipoProducto";
            this.tipoProductoDataGridViewTextBoxColumn.HeaderText = "Tipo producto";
            this.tipoProductoDataGridViewTextBoxColumn.Name = "tipoProductoDataGridViewTextBoxColumn";
            this.tipoProductoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadVendidaDataGridViewTextBoxColumn
            // 
            this.cantidadVendidaDataGridViewTextBoxColumn.DataPropertyName = "Cantidad Vendida";
            this.cantidadVendidaDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadVendidaDataGridViewTextBoxColumn.Name = "cantidadVendidaDataGridViewTextBoxColumn";
            this.cantidadVendidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productoReporteMasVendidosBindingSource
            // 
            this.productoReporteMasVendidosBindingSource.DataMember = "Producto_Reporte_MasVendidos";
            this.productoReporteMasVendidosBindingSource.DataSource = this.reportes;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(141)))), ((int)(((byte)(196)))));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.toolStripLabel2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(296, 25);
            this.toolStrip2.TabIndex = 112;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(149, 22);
            this.toolStripLabel2.Text = "Productos más vendidos";
            // 
            // producto_Reporte_VencimientoTempranoTableAdapter
            // 
            this.producto_Reporte_VencimientoTempranoTableAdapter.ClearBeforeFill = true;
            // 
            // producto_Reporte_MasVendidosTableAdapter
            // 
            this.producto_Reporte_MasVendidosTableAdapter.ClearBeforeFill = true;
            // 
            // producto_Reporte_VentasPorMesTableAdapter
            // 
            this.producto_Reporte_VentasPorMesTableAdapter.ClearBeforeFill = true;
            // 
            // formDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 448);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formDashboard";
            this.Text = "formDashboard";
            this.Load += new System.EventHandler(this.formDashboard_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosPorVencer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoReporteVencimientoTempranoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportes)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoReporteVentasPorMesBindingSource)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankingProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoReporteMasVendidosBindingSource)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel6;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private System.Windows.Forms.Label lblComprasTotales;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblProveedoresTotales;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel5;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private System.Windows.Forms.Label lblCategoriasUsadas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCategoriasTotales;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label lblMedicamentosVendidos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMedicamentosTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label lblProductosGeneralVendidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProductosGeneralTotal;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.DataGridView dgvProductosPorVencer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView dgvRankingProductos;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart cVentas;
        private Reportes reportes;
        private System.Windows.Forms.BindingSource productoReporteVencimientoTempranoBindingSource;
        private ReportesTableAdapters.Producto_Reporte_VencimientoTempranoTableAdapter producto_Reporte_VencimientoTempranoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoBarrasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroLoteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaVencimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn refrigeradoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvcBajoReceta;
        private System.Windows.Forms.BindingSource productoReporteMasVendidosBindingSource;
        private ReportesTableAdapters.Producto_Reporte_MasVendidosTableAdapter producto_Reporte_MasVendidosTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoBarrasDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroLoteDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDeProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadVendidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource productoReporteVentasPorMesBindingSource;
        private ReportesTableAdapters.Producto_Reporte_VentasPorMesTableAdapter producto_Reporte_VentasPorMesTableAdapter;
    }
}