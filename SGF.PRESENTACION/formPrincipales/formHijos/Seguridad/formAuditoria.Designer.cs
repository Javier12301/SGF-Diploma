﻿namespace SGF.PRESENTACION.formPrincipales.formHijos
{
    partial class formAuditoria
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAuditoria));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlpContainer = new System.Windows.Forms.TableLayoutPanel();
            this.chartResumenMovimientos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvAuditoria = new System.Windows.Forms.DataGridView();
            this.dgvcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcFechayHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNombreUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auditoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.farmaciaDatosDataSet = new SGF.PRESENTACION.FarmaciaDatosDataSet();
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
            this.cmbFiltroModulo = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbFiltroUsuario = new System.Windows.Forms.ToolStripComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
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
            this.btnDetalles = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnGrafico = new System.Windows.Forms.Button();
            this.reportes = new SGF.PRESENTACION.Reportes();
            this.auditoriaTableAdapter = new SGF.PRESENTACION.FarmaciaDatosDataSetTableAdapters.AuditoriaTableAdapter();
            this.panel1.SuspendLayout();
            this.tlpContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartResumenMovimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.auditoriaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.farmaciaDatosDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flpContenedorBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tlpContainer);
            this.panel1.Controls.Add(this.bindingNavigator1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.flpContenedorBotones);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 360);
            this.panel1.TabIndex = 1;
            // 
            // tlpContainer
            // 
            this.tlpContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpContainer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpContainer.ColumnCount = 2;
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.35947F));
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.64052F));
            this.tlpContainer.Controls.Add(this.chartResumenMovimientos, 0, 0);
            this.tlpContainer.Controls.Add(this.dgvAuditoria, 0, 0);
            this.tlpContainer.Location = new System.Drawing.Point(6, 139);
            this.tlpContainer.Name = "tlpContainer";
            this.tlpContainer.RowCount = 1;
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContainer.Size = new System.Drawing.Size(1071, 169);
            this.tlpContainer.TabIndex = 14;
            this.tlpContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpContainer_Paint);
            // 
            // chartResumenMovimientos
            // 
            chartArea1.Name = "ChartArea1";
            this.chartResumenMovimientos.ChartAreas.Add(chartArea1);
            this.chartResumenMovimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            legend1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chartResumenMovimientos.Legends.Add(legend1);
            this.chartResumenMovimientos.Location = new System.Drawing.Point(703, 4);
            this.chartResumenMovimientos.Name = "chartResumenMovimientos";
            this.chartResumenMovimientos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.CustomProperties = "DrawingStyle=Wedge, PointWidth=0.5, PixelPointWidth=6";
            series1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.White;
            series1.Name = "Movimientos";
            series1.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series1.YValuesPerPoint = 4;
            this.chartResumenMovimientos.Series.Add(series1);
            this.chartResumenMovimientos.Size = new System.Drawing.Size(364, 161);
            this.chartResumenMovimientos.TabIndex = 129;
            this.chartResumenMovimientos.Text = "chart1";
            this.chartResumenMovimientos.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            title1.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title1.BorderColor = System.Drawing.Color.White;
            title1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Resumen de movimientos del año";
            this.chartResumenMovimientos.Titles.Add(title1);
            // 
            // dgvAuditoria
            // 
            this.dgvAuditoria.AllowUserToAddRows = false;
            this.dgvAuditoria.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAuditoria.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAuditoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAuditoria.AutoGenerateColumns = false;
            this.dgvAuditoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAuditoria.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuditoria.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAuditoria.ColumnHeadersHeight = 40;
            this.dgvAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAuditoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcID,
            this.dgvcFechayHora,
            this.Modulo,
            this.dgvcMovimiento,
            this.dgvcNombreUsuario,
            this.dgvcDescripcion});
            this.dgvAuditoria.DataSource = this.auditoriaBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAuditoria.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAuditoria.GridColor = System.Drawing.Color.White;
            this.dgvAuditoria.Location = new System.Drawing.Point(4, 4);
            this.dgvAuditoria.Name = "dgvAuditoria";
            this.dgvAuditoria.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Roboto", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuditoria.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAuditoria.RowHeadersVisible = false;
            this.dgvAuditoria.RowHeadersWidth = 51;
            this.dgvAuditoria.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAuditoria.Size = new System.Drawing.Size(692, 161);
            this.dgvAuditoria.TabIndex = 13;
            this.dgvAuditoria.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAuditoria_CellDoubleClick);
            this.dgvAuditoria.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAuditoria_CellEnter);
            // 
            // dgvcID
            // 
            this.dgvcID.DataPropertyName = "AuditoriaID";
            this.dgvcID.HeaderText = "ID";
            this.dgvcID.MinimumWidth = 6;
            this.dgvcID.Name = "dgvcID";
            this.dgvcID.ReadOnly = true;
            this.dgvcID.Visible = false;
            // 
            // dgvcFechayHora
            // 
            this.dgvcFechayHora.DataPropertyName = "FechayHora";
            this.dgvcFechayHora.HeaderText = "Fecha y Hora";
            this.dgvcFechayHora.MinimumWidth = 6;
            this.dgvcFechayHora.Name = "dgvcFechayHora";
            this.dgvcFechayHora.ReadOnly = true;
            // 
            // Modulo
            // 
            this.Modulo.DataPropertyName = "Modulo";
            this.Modulo.HeaderText = "Modulo";
            this.Modulo.Name = "Modulo";
            this.Modulo.ReadOnly = true;
            // 
            // dgvcMovimiento
            // 
            this.dgvcMovimiento.DataPropertyName = "Movimiento";
            this.dgvcMovimiento.HeaderText = "Movimiento";
            this.dgvcMovimiento.MinimumWidth = 6;
            this.dgvcMovimiento.Name = "dgvcMovimiento";
            this.dgvcMovimiento.ReadOnly = true;
            // 
            // dgvcNombreUsuario
            // 
            this.dgvcNombreUsuario.DataPropertyName = "NombreUsuario";
            this.dgvcNombreUsuario.HeaderText = "Usuario";
            this.dgvcNombreUsuario.MinimumWidth = 6;
            this.dgvcNombreUsuario.Name = "dgvcNombreUsuario";
            this.dgvcNombreUsuario.ReadOnly = true;
            // 
            // dgvcDescripcion
            // 
            this.dgvcDescripcion.DataPropertyName = "Descripcion";
            this.dgvcDescripcion.HeaderText = "Descripcion";
            this.dgvcDescripcion.MinimumWidth = 6;
            this.dgvcDescripcion.Name = "dgvcDescripcion";
            this.dgvcDescripcion.ReadOnly = true;
            // 
            // auditoriaBindingSource
            // 
            this.auditoriaBindingSource.DataMember = "Auditoria";
            this.auditoriaBindingSource.DataSource = this.farmaciaDatosDataSet;
            // 
            // farmaciaDatosDataSet
            // 
            this.farmaciaDatosDataSet.DataSetName = "FarmaciaDatosDataSet";
            this.farmaciaDatosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.AutoSize = false;
            this.bindingNavigator1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bindingNavigator1.BindingSource = this.auditoriaBindingSource;
            this.bindingNavigator1.CountItem = this.bnpCantidadDeItems;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold);
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.cmbFiltroModulo,
            this.toolStripLabel3,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.cmbFiltroUsuario});
            this.bindingNavigator1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 311);
            this.bindingNavigator1.MoveFirstItem = this.bnpPrimerItem;
            this.bindingNavigator1.MoveLastItem = this.bnpUltimoItem;
            this.bindingNavigator1.MoveNextItem = this.bnpSiguienteItem;
            this.bindingNavigator1.MovePreviousItem = this.bnpItemAnterior;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bnpNumeroItem;
            this.bindingNavigator1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bindingNavigator1.Size = new System.Drawing.Size(1081, 49);
            this.bindingNavigator1.TabIndex = 13;
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
            this.bnpUltimoItem.Size = new System.Drawing.Size(24, 46);
            this.bnpUltimoItem.Text = "Mover último";
            // 
            // bnpSiguienteItem
            // 
            this.bnpSiguienteItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnpSiguienteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnpSiguienteItem.Image = ((System.Drawing.Image)(resources.GetObject("bnpSiguienteItem.Image")));
            this.bnpSiguienteItem.Name = "bnpSiguienteItem";
            this.bnpSiguienteItem.RightToLeftAutoMirrorImage = true;
            this.bnpSiguienteItem.Size = new System.Drawing.Size(24, 46);
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
            this.bnpItemAnterior.Size = new System.Drawing.Size(24, 46);
            this.bnpItemAnterior.Text = "Mover anterior";
            // 
            // bnpPrimerItem
            // 
            this.bnpPrimerItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnpPrimerItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnpPrimerItem.Image = ((System.Drawing.Image)(resources.GetObject("bnpPrimerItem.Image")));
            this.bnpPrimerItem.Name = "bnpPrimerItem";
            this.bnpPrimerItem.RightToLeftAutoMirrorImage = true;
            this.bnpPrimerItem.Size = new System.Drawing.Size(24, 46);
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
            this.cmbFiltroMovimiento.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(74, 46);
            this.toolStripLabel2.Text = "Movimiento:";
            // 
            // cmbFiltroModulo
            // 
            this.cmbFiltroModulo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbFiltroModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroModulo.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.cmbFiltroModulo.Name = "cmbFiltroModulo";
            this.cmbFiltroModulo.Size = new System.Drawing.Size(160, 49);
            this.cmbFiltroModulo.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel3.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(48, 46);
            this.toolStripLabel3.Text = "Módulo";
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
            this.cmbFiltroUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.flowLayoutPanel1);
            this.panel4.Controls.Add(this.btnBuscar);
            this.panel4.Controls.Add(this.txtBuscar);
            this.panel4.Controls.Add(this.cmbFiltroBuscar);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(6, 79);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1071, 54);
            this.panel4.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(112, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(404, 43);
            this.flowLayoutPanel1.TabIndex = 3;
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
            this.dtpInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFin_KeyPress);
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
            this.dtpFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFin_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar.IconColor = System.Drawing.Color.Black;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 16;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(1034, 17);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnBuscar.Size = new System.Drawing.Size(28, 23);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.txtBuscar.Location = new System.Drawing.Point(840, 17);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(188, 23);
            this.txtBuscar.TabIndex = 10;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // cmbFiltroBuscar
            // 
            this.cmbFiltroBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFiltroBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroBuscar.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltroBuscar.FormattingEnabled = true;
            this.cmbFiltroBuscar.Location = new System.Drawing.Point(721, 17);
            this.cmbFiltroBuscar.Name = "cmbFiltroBuscar";
            this.cmbFiltroBuscar.Size = new System.Drawing.Size(113, 23);
            this.cmbFiltroBuscar.TabIndex = 9;
            this.cmbFiltroBuscar.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(639, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Buscar por:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Auditoria";
            // 
            // flpContenedorBotones
            // 
            this.flpContenedorBotones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpContenedorBotones.BackColor = System.Drawing.Color.LightGray;
            this.flpContenedorBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpContenedorBotones.Controls.Add(this.btnDetalles);
            this.flpContenedorBotones.Controls.Add(this.btnExportar);
            this.flpContenedorBotones.Controls.Add(this.btnGrafico);
            this.flpContenedorBotones.Location = new System.Drawing.Point(4, 4);
            this.flpContenedorBotones.Margin = new System.Windows.Forms.Padding(4);
            this.flpContenedorBotones.Name = "flpContenedorBotones";
            this.flpContenedorBotones.Size = new System.Drawing.Size(833, 68);
            this.flpContenedorBotones.TabIndex = 0;
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
            this.btnDetalles.Location = new System.Drawing.Point(3, 3);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(112, 57);
            this.btnDetalles.TabIndex = 11;
            this.btnDetalles.Tag = "Detalles";
            this.btnDetalles.Text = "Detalles";
            this.btnDetalles.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetalles.UseVisualStyleBackColor = false;
            this.btnDetalles.Visible = false;
            this.btnDetalles.Click += new System.EventHandler(this.btnDetalles_Click);
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
            this.btnExportar.Location = new System.Drawing.Point(122, 4);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(112, 57);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Tag = "Exportar";
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnGrafico
            // 
            this.btnGrafico.BackColor = System.Drawing.Color.White;
            this.btnGrafico.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGrafico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrafico.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrafico.ForeColor = System.Drawing.Color.Black;
            this.btnGrafico.Image = ((System.Drawing.Image)(resources.GetObject("btnGrafico.Image")));
            this.btnGrafico.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGrafico.Location = new System.Drawing.Point(242, 4);
            this.btnGrafico.Margin = new System.Windows.Forms.Padding(4);
            this.btnGrafico.Name = "btnGrafico";
            this.btnGrafico.Size = new System.Drawing.Size(112, 57);
            this.btnGrafico.TabIndex = 2;
            this.btnGrafico.Tag = "Gráfico";
            this.btnGrafico.Text = "Gráfico";
            this.btnGrafico.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrafico.UseVisualStyleBackColor = false;
            this.btnGrafico.Click += new System.EventHandler(this.btnGrafico_Click);
            // 
            // reportes
            // 
            this.reportes.DataSetName = "Reportes";
            this.reportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // auditoriaTableAdapter
            // 
            this.auditoriaTableAdapter.ClearBeforeFill = true;
            // 
            // formAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 360);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formAuditoria";
            this.Text = "formAuditoria";
            this.Load += new System.EventHandler(this.formAuditoria_Load);
            this.panel1.ResumeLayout(false);
            this.tlpContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartResumenMovimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.auditoriaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.farmaciaDatosDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flpContenedorBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cmbFiltroBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpContenedorBotones;
        private System.Windows.Forms.Button btnExportar;
        private FarmaciaDatosDataSet farmaciaDatosDataSet;
        private System.Windows.Forms.BindingSource auditoriaBindingSource;
        private FarmaciaDatosDataSetTableAdapters.AuditoriaTableAdapter auditoriaTableAdapter;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.TableLayoutPanel tlpContainer;
        private System.Windows.Forms.DataGridView dgvAuditoria;
        private System.Windows.Forms.Button btnGrafico;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResumenMovimientos;
        private PRESENTACION.Reportes reportes;
        private System.Windows.Forms.Button btnDetalles;
        private System.Windows.Forms.ToolStripComboBox cmbFiltroModulo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcFechayHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNombreUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDescripcion;
    }
}