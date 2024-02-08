namespace SGF.PRESENTACION.formModales
{
    partial class mdMoneda
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlRazon = new System.Windows.Forms.Panel();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNombreMoneda = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.pnlNroDocumento = new System.Windows.Forms.Panel();
            this.txtSimboloMoneda = new System.Windows.Forms.TextBox();
            this.lblSimbolo = new System.Windows.Forms.Label();
            this.pnlDireccion = new System.Windows.Forms.Panel();
            this.lblPosicion = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rbDespues = new System.Windows.Forms.RadioButton();
            this.rbAntes = new System.Windows.Forms.RadioButton();
            this.lblMuestraMoneda = new System.Windows.Forms.Label();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.gControlCerrar = new Guna.UI.WinForms.GunaControlBox();
            this.lblNombreForm = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlRazon.SuspendLayout();
            this.pnlNroDocumento.SuspendLayout();
            this.pnlDireccion.SuspendLayout();
            this.panel7.SuspendLayout();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.pnlControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 293);
            this.panel1.TabIndex = 3;
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
            this.btnCancelar.Location = new System.Drawing.Point(3, 256);
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
            this.btnGuardar.Location = new System.Drawing.Point(109, 256);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(104, 31);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.pnlRazon);
            this.flowLayoutPanel1.Controls.Add(this.pnlNroDocumento);
            this.flowLayoutPanel1.Controls.Add(this.pnlDireccion);
            this.flowLayoutPanel1.Controls.Add(this.lblMuestraMoneda);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 38);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(209, 214);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // pnlRazon
            // 
            this.pnlRazon.Controls.Add(this.txtID);
            this.pnlRazon.Controls.Add(this.txtNombreMoneda);
            this.pnlRazon.Controls.Add(this.lblNombre);
            this.pnlRazon.Location = new System.Drawing.Point(3, 3);
            this.pnlRazon.Name = "pnlRazon";
            this.pnlRazon.Size = new System.Drawing.Size(198, 54);
            this.pnlRazon.TabIndex = 1;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(171, 3);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(23, 21);
            this.txtID.TabIndex = 0;
            this.txtID.Visible = false;
            // 
            // txtNombreMoneda
            // 
            this.txtNombreMoneda.Location = new System.Drawing.Point(8, 26);
            this.txtNombreMoneda.Name = "txtNombreMoneda";
            this.txtNombreMoneda.Size = new System.Drawing.Size(186, 22);
            this.txtNombreMoneda.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(5, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(57, 14);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre *";
            // 
            // pnlNroDocumento
            // 
            this.pnlNroDocumento.Controls.Add(this.txtSimboloMoneda);
            this.pnlNroDocumento.Controls.Add(this.lblSimbolo);
            this.pnlNroDocumento.Location = new System.Drawing.Point(3, 63);
            this.pnlNroDocumento.Name = "pnlNroDocumento";
            this.pnlNroDocumento.Size = new System.Drawing.Size(198, 54);
            this.pnlNroDocumento.TabIndex = 5;
            // 
            // txtSimboloMoneda
            // 
            this.txtSimboloMoneda.Location = new System.Drawing.Point(8, 26);
            this.txtSimboloMoneda.Name = "txtSimboloMoneda";
            this.txtSimboloMoneda.Size = new System.Drawing.Size(186, 22);
            this.txtSimboloMoneda.TabIndex = 6;
            // 
            // lblSimbolo
            // 
            this.lblSimbolo.AutoSize = true;
            this.lblSimbolo.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSimbolo.Location = new System.Drawing.Point(5, 9);
            this.lblSimbolo.Name = "lblSimbolo";
            this.lblSimbolo.Size = new System.Drawing.Size(59, 14);
            this.lblSimbolo.TabIndex = 0;
            this.lblSimbolo.Text = "Simbolo *";
            // 
            // pnlDireccion
            // 
            this.pnlDireccion.Controls.Add(this.lblPosicion);
            this.pnlDireccion.Controls.Add(this.panel7);
            this.pnlDireccion.Location = new System.Drawing.Point(3, 123);
            this.pnlDireccion.Name = "pnlDireccion";
            this.pnlDireccion.Size = new System.Drawing.Size(198, 54);
            this.pnlDireccion.TabIndex = 7;
            // 
            // lblPosicion
            // 
            this.lblPosicion.AutoSize = true;
            this.lblPosicion.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosicion.Location = new System.Drawing.Point(5, 9);
            this.lblPosicion.Name = "lblPosicion";
            this.lblPosicion.Size = new System.Drawing.Size(54, 14);
            this.lblPosicion.TabIndex = 0;
            this.lblPosicion.Text = "Posición";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.rbDespues);
            this.panel7.Controls.Add(this.rbAntes);
            this.panel7.Location = new System.Drawing.Point(8, 26);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(186, 23);
            this.panel7.TabIndex = 10;
            // 
            // rbDespues
            // 
            this.rbDespues.AutoSize = true;
            this.rbDespues.Checked = true;
            this.rbDespues.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDespues.Location = new System.Drawing.Point(93, 2);
            this.rbDespues.Name = "rbDespues";
            this.rbDespues.Size = new System.Drawing.Size(69, 19);
            this.rbDespues.TabIndex = 5;
            this.rbDespues.TabStop = true;
            this.rbDespues.Text = "Después";
            this.rbDespues.UseVisualStyleBackColor = true;
            this.rbDespues.CheckedChanged += new System.EventHandler(this.radioButtos_CheckedChanged);
            // 
            // rbAntes
            // 
            this.rbAntes.AutoSize = true;
            this.rbAntes.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAntes.Location = new System.Drawing.Point(27, 2);
            this.rbAntes.Name = "rbAntes";
            this.rbAntes.Size = new System.Drawing.Size(55, 19);
            this.rbAntes.TabIndex = 4;
            this.rbAntes.Text = "Antes";
            this.rbAntes.UseVisualStyleBackColor = true;
            this.rbAntes.CheckedChanged += new System.EventHandler(this.radioButtos_CheckedChanged);
            // 
            // lblMuestraMoneda
            // 
            this.lblMuestraMoneda.AutoEllipsis = true;
            this.lblMuestraMoneda.BackColor = System.Drawing.Color.Linen;
            this.lblMuestraMoneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMuestraMoneda.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMuestraMoneda.Location = new System.Drawing.Point(3, 180);
            this.lblMuestraMoneda.Name = "lblMuestraMoneda";
            this.lblMuestraMoneda.Size = new System.Drawing.Size(198, 25);
            this.lblMuestraMoneda.TabIndex = 11;
            this.lblMuestraMoneda.Text = "$ 520";
            this.lblMuestraMoneda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.pnlControl.Controls.Add(this.gControlCerrar);
            this.pnlControl.Controls.Add(this.lblNombreForm);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControl.Location = new System.Drawing.Point(0, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(217, 32);
            this.pnlControl.TabIndex = 3;
            this.pnlControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlControl_MouseDown);
            this.pnlControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlControl_MouseMove);
            // 
            // gControlCerrar
            // 
            this.gControlCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gControlCerrar.AnimationHoverSpeed = 0.07F;
            this.gControlCerrar.AnimationSpeed = 0.03F;
            this.gControlCerrar.IconColor = System.Drawing.Color.White;
            this.gControlCerrar.IconSize = 15F;
            this.gControlCerrar.Location = new System.Drawing.Point(172, 0);
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
            this.lblNombreForm.Size = new System.Drawing.Size(117, 17);
            this.lblNombreForm.TabIndex = 3;
            this.lblNombreForm.Tag = "";
            this.lblNombreForm.Text = "Registrar moneda";
            this.lblNombreForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlControl_MouseDown);
            this.lblNombreForm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlControl_MouseMove);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 300;
            this.errorProvider.ContainerControl = this;
            // 
            // mdMoneda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 293);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mdMoneda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mdMoneda";
            this.Load += new System.EventHandler(this.mdMoneda_Load);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlRazon.ResumeLayout(false);
            this.pnlRazon.PerformLayout();
            this.pnlNroDocumento.ResumeLayout(false);
            this.pnlNroDocumento.PerformLayout();
            this.pnlDireccion.ResumeLayout(false);
            this.pnlDireccion.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlRazon;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNombreMoneda;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Panel pnlNroDocumento;
        private System.Windows.Forms.TextBox txtSimboloMoneda;
        private System.Windows.Forms.Label lblSimbolo;
        private System.Windows.Forms.Panel pnlDireccion;
        private System.Windows.Forms.Label lblPosicion;
        private System.Windows.Forms.Panel pnlControl;
        private Guna.UI.WinForms.GunaControlBox gControlCerrar;
        private System.Windows.Forms.Label lblNombreForm;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.RadioButton rbDespues;
        private System.Windows.Forms.RadioButton rbAntes;
        private System.Windows.Forms.Label lblMuestraMoneda;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}