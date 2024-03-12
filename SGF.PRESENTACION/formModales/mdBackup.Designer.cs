namespace SGF.PRESENTACION.formModales
{
    partial class mdBackup
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.gControlCerrar = new Guna.UI.WinForms.GunaControlBox();
            this.lblNombreForm = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.btnRestaurar = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnRestaurar);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.txtRuta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.pnlControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 240);
            this.panel1.TabIndex = 2;
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
            this.btnLimpiar.Location = new System.Drawing.Point(271, 524);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(139, 38);
            this.btnLimpiar.TabIndex = 28;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
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
            this.btnCancelar.Location = new System.Drawing.Point(131, 524);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(139, 38);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
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
            this.btnGuardar.Location = new System.Drawing.Point(413, 524);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(137, 38);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.pnlControl.Controls.Add(this.gControlCerrar);
            this.pnlControl.Controls.Add(this.lblNombreForm);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControl.Location = new System.Drawing.Point(0, 0);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(4);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(800, 39);
            this.pnlControl.TabIndex = 3;
            // 
            // gControlCerrar
            // 
            this.gControlCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gControlCerrar.AnimationHoverSpeed = 0.07F;
            this.gControlCerrar.AnimationSpeed = 0.03F;
            this.gControlCerrar.IconColor = System.Drawing.Color.White;
            this.gControlCerrar.IconSize = 15F;
            this.gControlCerrar.Location = new System.Drawing.Point(740, 0);
            this.gControlCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.gControlCerrar.Name = "gControlCerrar";
            this.gControlCerrar.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.gControlCerrar.OnHoverIconColor = System.Drawing.Color.White;
            this.gControlCerrar.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gControlCerrar.Size = new System.Drawing.Size(60, 39);
            this.gControlCerrar.TabIndex = 4;
            // 
            // lblNombreForm
            // 
            this.lblNombreForm.AutoSize = true;
            this.lblNombreForm.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreForm.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNombreForm.Location = new System.Drawing.Point(9, 10);
            this.lblNombreForm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreForm.Name = "lblNombreForm";
            this.lblNombreForm.Size = new System.Drawing.Size(209, 23);
            this.lblNombreForm.TabIndex = 3;
            this.lblNombreForm.Tag = "";
            this.lblNombreForm.Text = "Backup de base de datos";
            // 
            // iconButton1
            // 
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(38, 81);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(207, 60);
            this.iconButton1.TabIndex = 30;
            this.iconButton1.Text = "Generar backup";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 18);
            this.label1.TabIndex = 31;
            this.label1.Text = "Ruta:";
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(83, 179);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(435, 26);
            this.txtRuta.TabIndex = 32;
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
            this.btnBuscar.Location = new System.Drawing.Point(525, 179);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(39, 28);
            this.btnBuscar.TabIndex = 97;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnRestaurar.IconColor = System.Drawing.Color.Black;
            this.btnRestaurar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRestaurar.Location = new System.Drawing.Point(571, 177);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(176, 32);
            this.btnRestaurar.TabIndex = 98;
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // mdBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 240);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mdBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mdBackup";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel pnlControl;
        private Guna.UI.WinForms.GunaControlBox gControlCerrar;
        private System.Windows.Forms.Label lblNombreForm;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnRestaurar;
    }
}