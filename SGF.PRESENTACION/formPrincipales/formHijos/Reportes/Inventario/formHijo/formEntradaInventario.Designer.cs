namespace SGF.PRESENTACION.formPrincipales.formHijos.Reportes.Inventario.formHijo
{
    partial class formEntradaInventario
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formEntradaInventario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartProductosMasComprados = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.productoReporteMasCompradosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportes = new SGF.PRESENTACION.Reportes();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.productoReporteMayorStockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.txtTopMayorStock = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvProducosConMayorCantidad = new System.Windows.Forms.DataGridView();
            this.productoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCantidadMinima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpContenedorBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEntradaMasiva = new System.Windows.Forms.Button();
            this.btnSalidaMasiva = new System.Windows.Forms.Button();
            this.reportesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.producto_Reporte_MayorStockTableAdapter = new SGF.PRESENTACION.ReportesTableAdapters.Producto_Reporte_MayorStockTableAdapter();
            this.producto_Reporte_MasCompradosTableAdapter = new SGF.PRESENTACION.ReportesTableAdapters.Producto_Reporte_MasCompradosTableAdapter();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductosMasComprados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoReporteMasCompradosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportes)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productoReporteMayorStockBindingSource)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducosConMayorCantidad)).BeginInit();
            this.flpContenedorBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.flpContenedorBotones);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 281);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.86381F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.13619F));
            this.tableLayoutPanel1.Controls.Add(this.chartProductosMasComprados, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(562, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 274F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 274F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(514, 274);
            this.tableLayoutPanel1.TabIndex = 125;
            // 
            // chartProductosMasComprados
            // 
            chartArea1.Name = "ChartArea1";
            this.chartProductosMasComprados.ChartAreas.Add(chartArea1);
            this.chartProductosMasComprados.DataSource = this.productoReporteMasCompradosBindingSource;
            this.chartProductosMasComprados.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            legend1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chartProductosMasComprados.Legends.Add(legend1);
            this.chartProductosMasComprados.Location = new System.Drawing.Point(3, 3);
            this.chartProductosMasComprados.Name = "chartProductosMasComprados";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.CustomProperties = "DrawingStyle=Wedge, PointWidth=0.5, PixelPointWidth=6";
            series1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.White;
            series1.Name = "Productos";
            series1.XValueMember = "Nombre";
            series1.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series1.YValueMembers = "CantidadComprada";
            series1.YValuesPerPoint = 4;
            this.chartProductosMasComprados.Series.Add(series1);
            this.chartProductosMasComprados.Size = new System.Drawing.Size(508, 268);
            this.chartProductosMasComprados.TabIndex = 128;
            this.chartProductosMasComprados.Text = "chart1";
            this.chartProductosMasComprados.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            title1.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title1.BorderColor = System.Drawing.Color.White;
            title1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Top 5 productos más comprados";
            this.chartProductosMasComprados.Titles.Add(title1);
            // 
            // productoReporteMasCompradosBindingSource
            // 
            this.productoReporteMasCompradosBindingSource.DataMember = "Producto_Reporte_MasComprados";
            this.productoReporteMasCompradosBindingSource.DataSource = this.reportes;
            // 
            // reportes
            // 
            this.reportes.DataSetName = "Reportes";
            this.reportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.bindingNavigator1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.dgvProducosConMayorCantidad);
            this.panel3.Location = new System.Drawing.Point(5, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(554, 223);
            this.panel3.TabIndex = 124;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.productoReporteMayorStockBindingSource;
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
            this.btnImprimir,
            this.txtTopMayorStock,
            this.toolStripLabel2});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 198);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(554, 25);
            this.bindingNavigator1.TabIndex = 125;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // productoReporteMayorStockBindingSource
            // 
            this.productoReporteMayorStockBindingSource.DataMember = "Producto_Reporte_MayorStock";
            this.productoReporteMayorStockBindingSource.DataSource = this.reportes;
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
            // btnImprimir
            // 
            this.btnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(23, 22);
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtTopMayorStock
            // 
            this.txtTopMayorStock.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtTopMayorStock.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTopMayorStock.Name = "txtTopMayorStock";
            this.txtTopMayorStock.Size = new System.Drawing.Size(100, 25);
            this.txtTopMayorStock.Leave += new System.EventHandler(this.txtTopMayorStock_Leave);
            this.txtTopMayorStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnKey_Press);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(33, 22);
            this.toolStripLabel2.Text = "Filas:";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(583, 39);
            this.panel4.TabIndex = 124;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 19);
            this.label2.TabIndex = 125;
            this.label2.Text = "Productos con más stock";
            // 
            // dgvProducosConMayorCantidad
            // 
            this.dgvProducosConMayorCantidad.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProducosConMayorCantidad.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducosConMayorCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducosConMayorCantidad.AutoGenerateColumns = false;
            this.dgvProducosConMayorCantidad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducosConMayorCantidad.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducosConMayorCantidad.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProducosConMayorCantidad.ColumnHeadersHeight = 40;
            this.dgvProducosConMayorCantidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProducosConMayorCantidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productoIDDataGridViewTextBoxColumn,
            this.dgvcCodigo,
            this.dgvcLote,
            this.dgvcCategoria,
            this.dgvcProveedor,
            this.dgvcNombre,
            this.dgvcCantidadMinima,
            this.dgvcCantidad});
            this.dgvProducosConMayorCantidad.DataSource = this.productoReporteMayorStockBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducosConMayorCantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProducosConMayorCantidad.GridColor = System.Drawing.Color.White;
            this.dgvProducosConMayorCantidad.Location = new System.Drawing.Point(3, 48);
            this.dgvProducosConMayorCantidad.Name = "dgvProducosConMayorCantidad";
            this.dgvProducosConMayorCantidad.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Roboto", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducosConMayorCantidad.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProducosConMayorCantidad.RowHeadersVisible = false;
            this.dgvProducosConMayorCantidad.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducosConMayorCantidad.Size = new System.Drawing.Size(548, 147);
            this.dgvProducosConMayorCantidad.TabIndex = 123;
            // 
            // productoIDDataGridViewTextBoxColumn
            // 
            this.productoIDDataGridViewTextBoxColumn.DataPropertyName = "ProductoID";
            this.productoIDDataGridViewTextBoxColumn.HeaderText = "ProductoID";
            this.productoIDDataGridViewTextBoxColumn.Name = "productoIDDataGridViewTextBoxColumn";
            this.productoIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.productoIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // dgvcCodigo
            // 
            this.dgvcCodigo.DataPropertyName = "Codigo";
            this.dgvcCodigo.HeaderText = "Código";
            this.dgvcCodigo.Name = "dgvcCodigo";
            this.dgvcCodigo.ReadOnly = true;
            // 
            // dgvcLote
            // 
            this.dgvcLote.DataPropertyName = "Lote";
            this.dgvcLote.HeaderText = "Lote";
            this.dgvcLote.Name = "dgvcLote";
            this.dgvcLote.ReadOnly = true;
            // 
            // dgvcCategoria
            // 
            this.dgvcCategoria.DataPropertyName = "Categoria";
            this.dgvcCategoria.HeaderText = "Categoria";
            this.dgvcCategoria.Name = "dgvcCategoria";
            this.dgvcCategoria.ReadOnly = true;
            // 
            // dgvcProveedor
            // 
            this.dgvcProveedor.DataPropertyName = "Proveedor";
            this.dgvcProveedor.HeaderText = "Proveedor";
            this.dgvcProveedor.Name = "dgvcProveedor";
            this.dgvcProveedor.ReadOnly = true;
            // 
            // dgvcNombre
            // 
            this.dgvcNombre.DataPropertyName = "Nombre";
            this.dgvcNombre.HeaderText = "Nombre";
            this.dgvcNombre.Name = "dgvcNombre";
            this.dgvcNombre.ReadOnly = true;
            // 
            // dgvcCantidadMinima
            // 
            this.dgvcCantidadMinima.DataPropertyName = "CantidadMinima";
            this.dgvcCantidadMinima.HeaderText = "Cantidad mínima";
            this.dgvcCantidadMinima.Name = "dgvcCantidadMinima";
            this.dgvcCantidadMinima.ReadOnly = true;
            // 
            // dgvcCantidad
            // 
            this.dgvcCantidad.DataPropertyName = "Cantidad";
            this.dgvcCantidad.HeaderText = "Stock";
            this.dgvcCantidad.Name = "dgvcCantidad";
            this.dgvcCantidad.ReadOnly = true;
            // 
            // flpContenedorBotones
            // 
            this.flpContenedorBotones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flpContenedorBotones.BackColor = System.Drawing.Color.LightGray;
            this.flpContenedorBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpContenedorBotones.Controls.Add(this.btnEntradaMasiva);
            this.flpContenedorBotones.Controls.Add(this.btnSalidaMasiva);
            this.flpContenedorBotones.Location = new System.Drawing.Point(5, 229);
            this.flpContenedorBotones.Margin = new System.Windows.Forms.Padding(4);
            this.flpContenedorBotones.Name = "flpContenedorBotones";
            this.flpContenedorBotones.Size = new System.Drawing.Size(384, 48);
            this.flpContenedorBotones.TabIndex = 118;
            // 
            // btnEntradaMasiva
            // 
            this.btnEntradaMasiva.BackColor = System.Drawing.Color.White;
            this.btnEntradaMasiva.Enabled = false;
            this.btnEntradaMasiva.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEntradaMasiva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntradaMasiva.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntradaMasiva.ForeColor = System.Drawing.Color.Black;
            this.btnEntradaMasiva.Image = ((System.Drawing.Image)(resources.GetObject("btnEntradaMasiva.Image")));
            this.btnEntradaMasiva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntradaMasiva.Location = new System.Drawing.Point(3, 3);
            this.btnEntradaMasiva.Name = "btnEntradaMasiva";
            this.btnEntradaMasiva.Size = new System.Drawing.Size(182, 38);
            this.btnEntradaMasiva.TabIndex = 120;
            this.btnEntradaMasiva.Tag = "Entrada";
            this.btnEntradaMasiva.Text = "Entrada a Inventario";
            this.btnEntradaMasiva.UseVisualStyleBackColor = false;
            this.btnEntradaMasiva.Click += new System.EventHandler(this.btnEntradaMasiva_Click);
            // 
            // btnSalidaMasiva
            // 
            this.btnSalidaMasiva.BackColor = System.Drawing.Color.White;
            this.btnSalidaMasiva.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSalidaMasiva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalidaMasiva.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalidaMasiva.ForeColor = System.Drawing.Color.Black;
            this.btnSalidaMasiva.Image = ((System.Drawing.Image)(resources.GetObject("btnSalidaMasiva.Image")));
            this.btnSalidaMasiva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalidaMasiva.Location = new System.Drawing.Point(191, 3);
            this.btnSalidaMasiva.Name = "btnSalidaMasiva";
            this.btnSalidaMasiva.Size = new System.Drawing.Size(187, 38);
            this.btnSalidaMasiva.TabIndex = 122;
            this.btnSalidaMasiva.Tag = "Salida";
            this.btnSalidaMasiva.Text = "Salida de Inventario";
            this.btnSalidaMasiva.UseVisualStyleBackColor = false;
            this.btnSalidaMasiva.Click += new System.EventHandler(this.btnSalidaMasiva_Click);
            // 
            // producto_Reporte_MayorStockTableAdapter
            // 
            this.producto_Reporte_MayorStockTableAdapter.ClearBeforeFill = true;
            // 
            // producto_Reporte_MasCompradosTableAdapter
            // 
            this.producto_Reporte_MasCompradosTableAdapter.ClearBeforeFill = true;
            // 
            // formEntradaInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 281);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formEntradaInventario";
            this.Text = "formEntradaInventario";
            this.Load += new System.EventHandler(this.formEntradaInventario_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartProductosMasComprados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoReporteMasCompradosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportes)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productoReporteMayorStockBindingSource)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducosConMayorCantidad)).EndInit();
            this.flpContenedorBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reportesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpContenedorBotones;
        private System.Windows.Forms.Button btnEntradaMasiva;
        private System.Windows.Forms.BindingSource reportesBindingSource;
        private System.Windows.Forms.Button btnSalidaMasiva;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvProducosConMayorCantidad;
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
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripTextBox txtTopMayorStock;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private PRESENTACION.Reportes reportes;
        private System.Windows.Forms.BindingSource productoReporteMayorStockBindingSource;
        private ReportesTableAdapters.Producto_Reporte_MayorStockTableAdapter producto_Reporte_MayorStockTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProductosMasComprados;
        private System.Windows.Forms.BindingSource productoReporteMasCompradosBindingSource;
        private ReportesTableAdapters.Producto_Reporte_MasCompradosTableAdapter producto_Reporte_MasCompradosTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn productoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCantidadMinima;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCantidad;
    }
}