namespace SGF.PRESENTACION.formModales
{
    partial class mdProductos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlContainerRadioButtons = new System.Windows.Forms.Panel();
            this.rbMedicamento = new System.Windows.Forms.RadioButton();
            this.rbProductoGeneral = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCodigo = new System.Windows.Forms.Panel();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.pnlNombreProducto = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.pnlLote = new System.Windows.Forms.Panel();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.lblLote = new System.Windows.Forms.Label();
            this.pnlPropiedades = new System.Windows.Forms.Panel();
            this.chkVencimiento = new System.Windows.Forms.CheckBox();
            this.chkBajoReceta = new System.Windows.Forms.CheckBox();
            this.chkRefrigeado = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlVencimiento = new System.Windows.Forms.Panel();
            this.dtaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.lblVencimiento = new System.Windows.Forms.Label();
            this.pnlCategoria = new System.Windows.Forms.Panel();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.pnlProveedor = new System.Windows.Forms.Panel();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.pnlPrecioCosto = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.pnlStock = new System.Windows.Forms.Panel();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlCantidadMinima = new System.Windows.Forms.Panel();
            this.txtCantidadMinima = new System.Windows.Forms.TextBox();
            this.lblCantidadMinima = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.gControlCerrar = new Guna.UI.WinForms.GunaControlBox();
            this.lblNombreForm = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.pnlContainerRadioButtons.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlCodigo.SuspendLayout();
            this.pnlNombreProducto.SuspendLayout();
            this.pnlLote.SuspendLayout();
            this.pnlPropiedades.SuspendLayout();
            this.pnlVencimiento.SuspendLayout();
            this.pnlCategoria.SuspendLayout();
            this.pnlProveedor.SuspendLayout();
            this.pnlPrecioCosto.SuspendLayout();
            this.pnlStock.SuspendLayout();
            this.pnlCantidadMinima.SuspendLayout();
            this.panel10.SuspendLayout();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pnlContainerRadioButtons);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.pnlControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 462);
            this.panel1.TabIndex = 1;
            // 
            // pnlContainerRadioButtons
            // 
            this.pnlContainerRadioButtons.Controls.Add(this.rbMedicamento);
            this.pnlContainerRadioButtons.Controls.Add(this.rbProductoGeneral);
            this.pnlContainerRadioButtons.Controls.Add(this.label1);
            this.pnlContainerRadioButtons.Location = new System.Drawing.Point(3, 41);
            this.pnlContainerRadioButtons.Name = "pnlContainerRadioButtons";
            this.pnlContainerRadioButtons.Size = new System.Drawing.Size(405, 28);
            this.pnlContainerRadioButtons.TabIndex = 31;
            // 
            // rbMedicamento
            // 
            this.rbMedicamento.AutoSize = true;
            this.rbMedicamento.Location = new System.Drawing.Point(173, 6);
            this.rbMedicamento.Name = "rbMedicamento";
            this.rbMedicamento.Size = new System.Drawing.Size(99, 18);
            this.rbMedicamento.TabIndex = 32;
            this.rbMedicamento.Text = "Medicamento";
            this.rbMedicamento.UseVisualStyleBackColor = true;
            this.rbMedicamento.CheckedChanged += new System.EventHandler(this.rbMedicamento_CheckedChanged);
            // 
            // rbProductoGeneral
            // 
            this.rbProductoGeneral.AutoSize = true;
            this.rbProductoGeneral.Location = new System.Drawing.Point(48, 6);
            this.rbProductoGeneral.Name = "rbProductoGeneral";
            this.rbProductoGeneral.Size = new System.Drawing.Size(118, 18);
            this.rbProductoGeneral.TabIndex = 31;
            this.rbProductoGeneral.Text = "Producto general";
            this.rbProductoGeneral.UseVisualStyleBackColor = true;
            this.rbProductoGeneral.CheckedChanged += new System.EventHandler(this.rbProductoGeneral_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 30;
            this.label1.Text = "Tipo:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Green;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(163)))), ((int)(((byte)(80)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLimpiar.Location = new System.Drawing.Point(199, 426);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(104, 31);
            this.btnLimpiar.TabIndex = 28;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(11)))), ((int)(((byte)(53)))));
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(137)))), ((int)(((byte)(180)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(93, 426);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 31);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(125)))), ((int)(((byte)(166)))));
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(137)))), ((int)(((byte)(180)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(305, 426);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(103, 31);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.pnlCodigo);
            this.flowLayoutPanel1.Controls.Add(this.pnlNombreProducto);
            this.flowLayoutPanel1.Controls.Add(this.pnlLote);
            this.flowLayoutPanel1.Controls.Add(this.pnlPropiedades);
            this.flowLayoutPanel1.Controls.Add(this.pnlVencimiento);
            this.flowLayoutPanel1.Controls.Add(this.pnlCategoria);
            this.flowLayoutPanel1.Controls.Add(this.pnlProveedor);
            this.flowLayoutPanel1.Controls.Add(this.pnlPrecioCosto);
            this.flowLayoutPanel1.Controls.Add(this.pnlStock);
            this.flowLayoutPanel1.Controls.Add(this.pnlCantidadMinima);
            this.flowLayoutPanel1.Controls.Add(this.panel10);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 75);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(413, 345);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // pnlCodigo
            // 
            this.pnlCodigo.Controls.Add(this.txtID);
            this.pnlCodigo.Controls.Add(this.txtCodigo);
            this.pnlCodigo.Controls.Add(this.lblCodigo);
            this.pnlCodigo.Location = new System.Drawing.Point(3, 3);
            this.pnlCodigo.Name = "pnlCodigo";
            this.pnlCodigo.Size = new System.Drawing.Size(195, 54);
            this.pnlCodigo.TabIndex = 5;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(163, 3);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(23, 21);
            this.txtID.TabIndex = 0;
            this.txtID.Visible = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(8, 26);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(178, 22);
            this.txtCodigo.TabIndex = 6;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(5, 9);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(107, 14);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código de Barras *";
            // 
            // pnlNombreProducto
            // 
            this.pnlNombreProducto.Controls.Add(this.txtNombre);
            this.pnlNombreProducto.Controls.Add(this.lblNombre);
            this.pnlNombreProducto.Location = new System.Drawing.Point(204, 3);
            this.pnlNombreProducto.Name = "pnlNombreProducto";
            this.pnlNombreProducto.Size = new System.Drawing.Size(195, 54);
            this.pnlNombreProducto.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(8, 26);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(178, 22);
            this.txtNombre.TabIndex = 8;
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(5, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(161, 11);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre de Producto*";
            // 
            // pnlLote
            // 
            this.pnlLote.Controls.Add(this.txtLote);
            this.pnlLote.Controls.Add(this.lblLote);
            this.pnlLote.Location = new System.Drawing.Point(3, 63);
            this.pnlLote.Name = "pnlLote";
            this.pnlLote.Size = new System.Drawing.Size(195, 54);
            this.pnlLote.TabIndex = 9;
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(8, 26);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(178, 22);
            this.txtLote.TabIndex = 10;
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLote.Location = new System.Drawing.Point(5, 9);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(39, 14);
            this.lblLote.TabIndex = 0;
            this.lblLote.Text = "Lote *";
            // 
            // pnlPropiedades
            // 
            this.pnlPropiedades.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlPropiedades.Controls.Add(this.chkVencimiento);
            this.pnlPropiedades.Controls.Add(this.chkBajoReceta);
            this.pnlPropiedades.Controls.Add(this.chkRefrigeado);
            this.pnlPropiedades.Controls.Add(this.label11);
            this.pnlPropiedades.Location = new System.Drawing.Point(204, 63);
            this.pnlPropiedades.Name = "pnlPropiedades";
            this.pnlPropiedades.Size = new System.Drawing.Size(195, 60);
            this.pnlPropiedades.TabIndex = 12;
            // 
            // chkVencimiento
            // 
            this.chkVencimiento.AutoSize = true;
            this.chkVencimiento.Checked = true;
            this.chkVencimiento.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVencimiento.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVencimiento.Location = new System.Drawing.Point(102, 22);
            this.chkVencimiento.Name = "chkVencimiento";
            this.chkVencimiento.Size = new System.Drawing.Size(88, 17);
            this.chkVencimiento.TabIndex = 15;
            this.chkVencimiento.Text = "Vencimiento";
            this.chkVencimiento.UseVisualStyleBackColor = true;
            this.chkVencimiento.CheckedChanged += new System.EventHandler(this.chkVencimiento_CheckedChanged);
            // 
            // chkBajoReceta
            // 
            this.chkBajoReceta.AutoSize = true;
            this.chkBajoReceta.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBajoReceta.Location = new System.Drawing.Point(14, 39);
            this.chkBajoReceta.Name = "chkBajoReceta";
            this.chkBajoReceta.Size = new System.Drawing.Size(86, 17);
            this.chkBajoReceta.TabIndex = 14;
            this.chkBajoReceta.Text = "Bajo Receta";
            this.chkBajoReceta.UseVisualStyleBackColor = true;
            // 
            // chkRefrigeado
            // 
            this.chkRefrigeado.AutoSize = true;
            this.chkRefrigeado.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRefrigeado.Location = new System.Drawing.Point(14, 22);
            this.chkRefrigeado.Name = "chkRefrigeado";
            this.chkRefrigeado.Size = new System.Drawing.Size(87, 17);
            this.chkRefrigeado.TabIndex = 13;
            this.chkRefrigeado.Text = "Refrigerado";
            this.chkRefrigeado.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(5, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "Propiedades";
            // 
            // pnlVencimiento
            // 
            this.pnlVencimiento.Controls.Add(this.dtaVencimiento);
            this.pnlVencimiento.Controls.Add(this.lblVencimiento);
            this.pnlVencimiento.Location = new System.Drawing.Point(3, 129);
            this.pnlVencimiento.Name = "pnlVencimiento";
            this.pnlVencimiento.Size = new System.Drawing.Size(195, 54);
            this.pnlVencimiento.TabIndex = 11;
            // 
            // dtaVencimiento
            // 
            this.dtaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtaVencimiento.Location = new System.Drawing.Point(8, 26);
            this.dtaVencimiento.Name = "dtaVencimiento";
            this.dtaVencimiento.Size = new System.Drawing.Size(178, 22);
            this.dtaVencimiento.TabIndex = 12;
            // 
            // lblVencimiento
            // 
            this.lblVencimiento.AutoSize = true;
            this.lblVencimiento.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVencimiento.Location = new System.Drawing.Point(5, 9);
            this.lblVencimiento.Name = "lblVencimiento";
            this.lblVencimiento.Size = new System.Drawing.Size(133, 14);
            this.lblVencimiento.TabIndex = 0;
            this.lblVencimiento.Text = "Fecha de Vencimiento *";
            // 
            // pnlCategoria
            // 
            this.pnlCategoria.Controls.Add(this.cmbCategoria);
            this.pnlCategoria.Controls.Add(this.lblCategoria);
            this.pnlCategoria.Location = new System.Drawing.Point(204, 129);
            this.pnlCategoria.Name = "pnlCategoria";
            this.pnlCategoria.Size = new System.Drawing.Size(195, 54);
            this.pnlCategoria.TabIndex = 15;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(8, 26);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(178, 22);
            this.cmbCategoria.TabIndex = 16;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(5, 9);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(130, 14);
            this.lblCategoria.TabIndex = 0;
            this.lblCategoria.Text = "Seleccionar Categoría *";
            // 
            // pnlProveedor
            // 
            this.pnlProveedor.Controls.Add(this.cmbProveedor);
            this.pnlProveedor.Controls.Add(this.lblProveedor);
            this.pnlProveedor.Location = new System.Drawing.Point(3, 189);
            this.pnlProveedor.Name = "pnlProveedor";
            this.pnlProveedor.Size = new System.Drawing.Size(195, 54);
            this.pnlProveedor.TabIndex = 17;
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(8, 26);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(178, 22);
            this.cmbProveedor.TabIndex = 18;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(5, 9);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(134, 14);
            this.lblProveedor.TabIndex = 0;
            this.lblProveedor.Text = "Seleccionar Proveedor *";
            // 
            // pnlPrecioCosto
            // 
            this.pnlPrecioCosto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlPrecioCosto.Controls.Add(this.label7);
            this.pnlPrecioCosto.Controls.Add(this.txtCosto);
            this.pnlPrecioCosto.Controls.Add(this.label8);
            this.pnlPrecioCosto.Controls.Add(this.txtPrecio);
            this.pnlPrecioCosto.Location = new System.Drawing.Point(204, 189);
            this.pnlPrecioCosto.Name = "pnlPrecioCosto";
            this.pnlPrecioCosto.Size = new System.Drawing.Size(195, 54);
            this.pnlPrecioCosto.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(7, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "Costo:";
            // 
            // txtCosto
            // 
            this.txtCosto.BackColor = System.Drawing.SystemColors.Window;
            this.txtCosto.Font = new System.Drawing.Font("Roboto", 9F);
            this.txtCosto.Location = new System.Drawing.Point(59, 4);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(107, 22);
            this.txtCosto.TabIndex = 19;
            this.txtCosto.Text = "0";
            this.txtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextboxMoneda_KeyPress);
            this.txtCosto.Leave += new System.EventHandler(this.TextboxMoneda_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(7, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "Precio:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrecio.Font = new System.Drawing.Font("Roboto", 9F);
            this.txtPrecio.Location = new System.Drawing.Point(59, 29);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(107, 22);
            this.txtPrecio.TabIndex = 20;
            this.txtPrecio.Text = "0";
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextboxMoneda_KeyPress);
            this.txtPrecio.Leave += new System.EventHandler(this.TextboxMoneda_Leave);
            // 
            // pnlStock
            // 
            this.pnlStock.Controls.Add(this.txtStock);
            this.pnlStock.Controls.Add(this.label9);
            this.pnlStock.Location = new System.Drawing.Point(3, 249);
            this.pnlStock.Name = "pnlStock";
            this.pnlStock.Size = new System.Drawing.Size(195, 54);
            this.pnlStock.TabIndex = 21;
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtStock.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.Location = new System.Drawing.Point(8, 26);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Size = new System.Drawing.Size(178, 23);
            this.txtStock.TabIndex = 22;
            this.txtStock.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "Stock";
            // 
            // pnlCantidadMinima
            // 
            this.pnlCantidadMinima.Controls.Add(this.txtCantidadMinima);
            this.pnlCantidadMinima.Controls.Add(this.lblCantidadMinima);
            this.pnlCantidadMinima.Location = new System.Drawing.Point(204, 249);
            this.pnlCantidadMinima.Name = "pnlCantidadMinima";
            this.pnlCantidadMinima.Size = new System.Drawing.Size(195, 54);
            this.pnlCantidadMinima.TabIndex = 23;
            // 
            // txtCantidadMinima
            // 
            this.txtCantidadMinima.Location = new System.Drawing.Point(8, 26);
            this.txtCantidadMinima.Name = "txtCantidadMinima";
            this.txtCantidadMinima.Size = new System.Drawing.Size(178, 22);
            this.txtCantidadMinima.TabIndex = 24;
            this.txtCantidadMinima.Text = "0";
            // 
            // lblCantidadMinima
            // 
            this.lblCantidadMinima.AutoSize = true;
            this.lblCantidadMinima.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadMinima.Location = new System.Drawing.Point(5, 9);
            this.lblCantidadMinima.Name = "lblCantidadMinima";
            this.lblCantidadMinima.Size = new System.Drawing.Size(98, 14);
            this.lblCantidadMinima.TabIndex = 0;
            this.lblCantidadMinima.Text = "Cantidad Mínima";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.LightGray;
            this.panel10.Controls.Add(this.chkEstado);
            this.panel10.Location = new System.Drawing.Point(3, 309);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(405, 31);
            this.panel10.TabIndex = 25;
            // 
            // chkEstado
            // 
            this.chkEstado.BackColor = System.Drawing.Color.White;
            this.chkEstado.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.chkEstado.Location = new System.Drawing.Point(336, 3);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.chkEstado.Size = new System.Drawing.Size(64, 25);
            this.chkEstado.TabIndex = 26;
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = false;
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.pnlControl.Controls.Add(this.gControlCerrar);
            this.pnlControl.Controls.Add(this.lblNombreForm);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControl.Location = new System.Drawing.Point(0, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(419, 32);
            this.pnlControl.TabIndex = 3;
            this.pnlControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            this.pnlControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseMove);
            // 
            // gControlCerrar
            // 
            this.gControlCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gControlCerrar.AnimationHoverSpeed = 0.07F;
            this.gControlCerrar.AnimationSpeed = 0.03F;
            this.gControlCerrar.IconColor = System.Drawing.Color.White;
            this.gControlCerrar.IconSize = 15F;
            this.gControlCerrar.Location = new System.Drawing.Point(374, 0);
            this.gControlCerrar.Name = "gControlCerrar";
            this.gControlCerrar.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.gControlCerrar.OnHoverIconColor = System.Drawing.Color.White;
            this.gControlCerrar.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gControlCerrar.Size = new System.Drawing.Size(45, 32);
            this.gControlCerrar.TabIndex = 4;
            // 
            // lblNombreForm
            // 
            this.lblNombreForm.AutoSize = true;
            this.lblNombreForm.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreForm.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNombreForm.Location = new System.Drawing.Point(7, 8);
            this.lblNombreForm.Name = "lblNombreForm";
            this.lblNombreForm.Size = new System.Drawing.Size(123, 17);
            this.lblNombreForm.TabIndex = 3;
            this.lblNombreForm.Tag = "";
            this.lblNombreForm.Text = "Registrar Producto";
            this.lblNombreForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            this.lblNombreForm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseMove);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 300;
            this.errorProvider.ContainerControl = this;
            // 
            // mdProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 462);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mdProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mdProductos";
            this.Load += new System.EventHandler(this.mdProductos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlContainerRadioButtons.ResumeLayout(false);
            this.pnlContainerRadioButtons.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlCodigo.ResumeLayout(false);
            this.pnlCodigo.PerformLayout();
            this.pnlNombreProducto.ResumeLayout(false);
            this.pnlNombreProducto.PerformLayout();
            this.pnlLote.ResumeLayout(false);
            this.pnlLote.PerformLayout();
            this.pnlPropiedades.ResumeLayout(false);
            this.pnlPropiedades.PerformLayout();
            this.pnlVencimiento.ResumeLayout(false);
            this.pnlVencimiento.PerformLayout();
            this.pnlCategoria.ResumeLayout(false);
            this.pnlCategoria.PerformLayout();
            this.pnlProveedor.ResumeLayout(false);
            this.pnlProveedor.PerformLayout();
            this.pnlPrecioCosto.ResumeLayout(false);
            this.pnlPrecioCosto.PerformLayout();
            this.pnlStock.ResumeLayout(false);
            this.pnlStock.PerformLayout();
            this.pnlCantidadMinima.ResumeLayout(false);
            this.pnlCantidadMinima.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlCodigo;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Panel pnlNombreProducto;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Panel pnlLote;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.Panel pnlVencimiento;
        private System.Windows.Forms.DateTimePicker dtaVencimiento;
        private System.Windows.Forms.Label lblVencimiento;
        private System.Windows.Forms.Panel pnlPropiedades;
        private System.Windows.Forms.CheckBox chkBajoReceta;
        private System.Windows.Forms.CheckBox chkRefrigeado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Panel pnlProveedor;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Panel pnlPrecioCosto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Panel pnlStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Panel pnlControl;
        private Guna.UI.WinForms.GunaControlBox gControlCerrar;
        private System.Windows.Forms.Label lblNombreForm;
        private System.Windows.Forms.CheckBox chkVencimiento;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel pnlContainerRadioButtons;
        private System.Windows.Forms.RadioButton rbMedicamento;
        private System.Windows.Forms.RadioButton rbProductoGeneral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCantidadMinima;
        private System.Windows.Forms.TextBox txtCantidadMinima;
        private System.Windows.Forms.Label lblCantidadMinima;
    }
}