﻿namespace SGF.PRESENTACION.formPrincipales
{
    partial class formProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProveedores));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.dgvcNombreCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cmbFiltroBuscar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNuevoP = new System.Windows.Forms.Button();
            this.btnModificarP = new System.Windows.Forms.Button();
            this.btnEliminarP = new System.Windows.Forms.Button();
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
            this.cmbFiltroEstado = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvProductos);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.bindingNavigator1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 448);
            this.panel1.TabIndex = 1;
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
            this.dgvcNombreCategoria});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProductos.GridColor = System.Drawing.Color.White;
            this.dgvProductos.Location = new System.Drawing.Point(5, 152);
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
            this.dgvProductos.Size = new System.Drawing.Size(1059, 244);
            this.dgvProductos.TabIndex = 109;
            // 
            // dgvcNombreCategoria
            // 
            this.dgvcNombreCategoria.DataPropertyName = "NombreCategoria";
            this.dgvcNombreCategoria.HeaderText = "Categoría";
            this.dgvcNombreCategoria.Name = "dgvcNombreCategoria";
            this.dgvcNombreCategoria.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(870, 4);
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
            this.label2.Location = new System.Drawing.Point(61, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Estado";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnBuscar);
            this.panel4.Controls.Add(this.btnLimpiar);
            this.panel4.Controls.Add(this.txtBuscar);
            this.panel4.Controls.Add(this.cmbFiltroBuscar);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(5, 92);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1059, 54);
            this.panel4.TabIndex = 107;
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
            this.btnBuscar.Location = new System.Drawing.Point(991, 14);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(29, 23);
            this.btnBuscar.TabIndex = 96;
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiar.IconColor = System.Drawing.Color.Black;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.IconSize = 18;
            this.btnLimpiar.Location = new System.Drawing.Point(1025, 14);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(28, 23);
            this.btnLimpiar.TabIndex = 97;
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.txtBuscar.Location = new System.Drawing.Point(797, 14);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(188, 23);
            this.txtBuscar.TabIndex = 3;
            // 
            // cmbFiltroBuscar
            // 
            this.cmbFiltroBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFiltroBuscar.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltroBuscar.FormattingEnabled = true;
            this.cmbFiltroBuscar.Location = new System.Drawing.Point(678, 14);
            this.cmbFiltroBuscar.Name = "cmbFiltroBuscar";
            this.cmbFiltroBuscar.Size = new System.Drawing.Size(113, 23);
            this.cmbFiltroBuscar.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(596, 17);
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
            this.label1.Size = new System.Drawing.Size(212, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista de Proveedores";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.btnNuevoP);
            this.flowLayoutPanel1.Controls.Add(this.btnModificarP);
            this.flowLayoutPanel1.Controls.Add(this.btnEliminarP);
            this.flowLayoutPanel1.Controls.Add(this.btnImportarP);
            this.flowLayoutPanel1.Controls.Add(this.btnExportarP);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 4);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(857, 81);
            this.flowLayoutPanel1.TabIndex = 106;
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
            this.btnNuevoP.Text = "Nuevo";
            this.btnNuevoP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevoP.UseVisualStyleBackColor = false;
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
            this.btnModificarP.Text = "Modificar";
            this.btnModificarP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnModificarP.UseVisualStyleBackColor = false;
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
            this.btnEliminarP.Text = "Eliminar";
            this.btnEliminarP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminarP.UseVisualStyleBackColor = false;
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
            this.btnImportarP.Location = new System.Drawing.Point(364, 4);
            this.btnImportarP.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportarP.Name = "btnImportarP";
            this.btnImportarP.Size = new System.Drawing.Size(112, 73);
            this.btnImportarP.TabIndex = 11;
            this.btnImportarP.Text = "Importar";
            this.btnImportarP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportarP.UseVisualStyleBackColor = false;
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
            this.btnExportarP.Location = new System.Drawing.Point(484, 4);
            this.btnExportarP.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportarP.Name = "btnExportarP";
            this.btnExportarP.Size = new System.Drawing.Size(112, 73);
            this.btnExportarP.TabIndex = 12;
            this.btnExportarP.Text = "Exportar";
            this.btnExportarP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportarP.UseVisualStyleBackColor = false;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.AutoSize = false;
            this.bindingNavigator1.BackColor = System.Drawing.Color.WhiteSmoke;
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
            this.cmbFiltroEstado,
            this.toolStripLabel2,
            this.toolStripSeparator3});
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
            // cmbFiltroEstado
            // 
            this.cmbFiltroEstado.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(160, 49);
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
            // formProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 448);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formProveedores";
            this.Text = "formProveedores";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNombreCategoria;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cmbFiltroBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnNuevoP;
        private System.Windows.Forms.Button btnModificarP;
        private System.Windows.Forms.Button btnEliminarP;
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
        private System.Windows.Forms.ToolStripComboBox cmbFiltroEstado;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}