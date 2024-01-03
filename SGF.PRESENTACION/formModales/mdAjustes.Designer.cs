namespace SGF.PRESENTACION.formModales
{
    partial class mdAjustes
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
            this.pnlControl = new System.Windows.Forms.Panel();
            this.gControlCerrar = new Guna.UI.WinForms.GunaControlBox();
            this.lblNombreForm = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPerfiles = new FontAwesome.Sharp.IconButton();
            this.btnNegocio = new FontAwesome.Sharp.IconButton();
            this.btnBaseDatos = new FontAwesome.Sharp.IconButton();
            this.btnOtrasConfiguraciones = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlControl.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.pnlControl.Controls.Add(this.gControlCerrar);
            this.pnlControl.Controls.Add(this.lblNombreForm);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControl.Location = new System.Drawing.Point(0, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(372, 32);
            this.pnlControl.TabIndex = 1;
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
            this.gControlCerrar.Location = new System.Drawing.Point(327, 0);
            this.gControlCerrar.Name = "gControlCerrar";
            this.gControlCerrar.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.gControlCerrar.OnHoverIconColor = System.Drawing.Color.White;
            this.gControlCerrar.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gControlCerrar.Size = new System.Drawing.Size(45, 32);
            this.gControlCerrar.TabIndex = 0;
            // 
            // lblNombreForm
            // 
            this.lblNombreForm.AutoEllipsis = true;
            this.lblNombreForm.AutoSize = true;
            this.lblNombreForm.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreForm.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNombreForm.Location = new System.Drawing.Point(7, 8);
            this.lblNombreForm.Name = "lblNombreForm";
            this.lblNombreForm.Size = new System.Drawing.Size(53, 17);
            this.lblNombreForm.TabIndex = 0;
            this.lblNombreForm.Tag = "";
            this.lblNombreForm.Text = "Ajustes";
            this.lblNombreForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            this.lblNombreForm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseMove);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnPerfiles);
            this.flowLayoutPanel2.Controls.Add(this.btnNegocio);
            this.flowLayoutPanel2.Controls.Add(this.btnBaseDatos);
            this.flowLayoutPanel2.Controls.Add(this.btnOtrasConfiguraciones);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 38);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(372, 176);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // btnPerfiles
            // 
            this.btnPerfiles.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerfiles.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.btnPerfiles.IconColor = System.Drawing.Color.Black;
            this.btnPerfiles.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPerfiles.IconSize = 45;
            this.btnPerfiles.Location = new System.Drawing.Point(3, 3);
            this.btnPerfiles.Name = "btnPerfiles";
            this.btnPerfiles.Size = new System.Drawing.Size(180, 82);
            this.btnPerfiles.TabIndex = 0;
            this.btnPerfiles.Text = "Perfiles";
            this.btnPerfiles.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPerfiles.UseVisualStyleBackColor = true;
            this.btnPerfiles.Click += new System.EventHandler(this.btnPerfiles_Click);
            // 
            // btnNegocio
            // 
            this.btnNegocio.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNegocio.IconChar = FontAwesome.Sharp.IconChar.Shop;
            this.btnNegocio.IconColor = System.Drawing.Color.Black;
            this.btnNegocio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNegocio.IconSize = 45;
            this.btnNegocio.Location = new System.Drawing.Point(189, 3);
            this.btnNegocio.Name = "btnNegocio";
            this.btnNegocio.Size = new System.Drawing.Size(180, 82);
            this.btnNegocio.TabIndex = 1;
            this.btnNegocio.Text = "Datos de negocio";
            this.btnNegocio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNegocio.UseVisualStyleBackColor = true;
            this.btnNegocio.Click += new System.EventHandler(this.btnNegocio_Click);
            // 
            // btnBaseDatos
            // 
            this.btnBaseDatos.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaseDatos.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.btnBaseDatos.IconColor = System.Drawing.Color.Black;
            this.btnBaseDatos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBaseDatos.IconSize = 45;
            this.btnBaseDatos.Location = new System.Drawing.Point(3, 91);
            this.btnBaseDatos.Name = "btnBaseDatos";
            this.btnBaseDatos.Size = new System.Drawing.Size(180, 82);
            this.btnBaseDatos.TabIndex = 2;
            this.btnBaseDatos.Text = "Gestionar base de datos";
            this.btnBaseDatos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBaseDatos.UseVisualStyleBackColor = true;
            this.btnBaseDatos.Click += new System.EventHandler(this.btnBaseDatos_Click);
            // 
            // btnOtrasConfiguraciones
            // 
            this.btnOtrasConfiguraciones.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtrasConfiguraciones.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.btnOtrasConfiguraciones.IconColor = System.Drawing.Color.Black;
            this.btnOtrasConfiguraciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnOtrasConfiguraciones.IconSize = 45;
            this.btnOtrasConfiguraciones.Location = new System.Drawing.Point(189, 91);
            this.btnOtrasConfiguraciones.Name = "btnOtrasConfiguraciones";
            this.btnOtrasConfiguraciones.Size = new System.Drawing.Size(180, 82);
            this.btnOtrasConfiguraciones.TabIndex = 3;
            this.btnOtrasConfiguraciones.Text = "Otras configuraciones";
            this.btnOtrasConfiguraciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOtrasConfiguraciones.UseVisualStyleBackColor = true;
            this.btnOtrasConfiguraciones.Click += new System.EventHandler(this.btnOtrasConfiguraciones_Click);
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
            this.btnCancelar.Location = new System.Drawing.Point(265, 220);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 33);
            this.btnCancelar.TabIndex = 92;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // mdAjustes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 257);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.pnlControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mdAjustes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "formAjustes";
            this.Text = "mdAjustes";
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControl;
        private Guna.UI.WinForms.GunaControlBox gControlCerrar;
        private System.Windows.Forms.Label lblNombreForm;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private FontAwesome.Sharp.IconButton btnPerfiles;
        private FontAwesome.Sharp.IconButton btnNegocio;
        private FontAwesome.Sharp.IconButton btnBaseDatos;
        private FontAwesome.Sharp.IconButton btnOtrasConfiguraciones;
        private System.Windows.Forms.Button btnCancelar;
    }
}