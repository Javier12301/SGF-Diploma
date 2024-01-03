namespace SGF.PRESENTACION.frmModales.Seguridad
{
    partial class frmNuevaContraseña
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
            this.pnlControl = new System.Windows.Forms.Panel();
            this.gControlCerrar = new Guna.UI.WinForms.GunaControlBox();
            this.lblNombreForm = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOjoConfirmar = new FontAwesome.Sharp.IconButton();
            this.btnOjoNueva = new FontAwesome.Sharp.IconButton();
            this.txtConfirmarContraseña = new System.Windows.Forms.TextBox();
            this.lblConfirmarContraseña = new System.Windows.Forms.Label();
            this.txtNuevaContraseña = new System.Windows.Forms.TextBox();
            this.lblNuevaContraseña = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlControl.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
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
            this.pnlControl.Size = new System.Drawing.Size(350, 38);
            this.pnlControl.TabIndex = 3;
            // 
            // gControlCerrar
            // 
            this.gControlCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gControlCerrar.AnimationHoverSpeed = 0.07F;
            this.gControlCerrar.AnimationSpeed = 0.03F;
            this.gControlCerrar.IconColor = System.Drawing.Color.White;
            this.gControlCerrar.IconSize = 15F;
            this.gControlCerrar.Location = new System.Drawing.Point(298, 0);
            this.gControlCerrar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gControlCerrar.Name = "gControlCerrar";
            this.gControlCerrar.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.gControlCerrar.OnHoverIconColor = System.Drawing.Color.White;
            this.gControlCerrar.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gControlCerrar.Size = new System.Drawing.Size(52, 38);
            this.gControlCerrar.TabIndex = 0;
            // 
            // lblNombreForm
            // 
            this.lblNombreForm.AutoSize = true;
            this.lblNombreForm.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.lblNombreForm.ForeColor = System.Drawing.Color.White;
            this.lblNombreForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNombreForm.Location = new System.Drawing.Point(5, 12);
            this.lblNombreForm.Name = "lblNombreForm";
            this.lblNombreForm.Size = new System.Drawing.Size(122, 15);
            this.lblNombreForm.TabIndex = 0;
            this.lblNombreForm.Text = "Cambiar Contraseña";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnOjoConfirmar);
            this.panel1.Controls.Add(this.btnOjoNueva);
            this.panel1.Controls.Add(this.txtConfirmarContraseña);
            this.panel1.Controls.Add(this.lblConfirmarContraseña);
            this.panel1.Controls.Add(this.txtNuevaContraseña);
            this.panel1.Controls.Add(this.lblNuevaContraseña);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 133);
            this.panel1.TabIndex = 1;
            // 
            // btnOjoConfirmar
            // 
            this.btnOjoConfirmar.FlatAppearance.BorderSize = 0;
            this.btnOjoConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnOjoConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnOjoConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOjoConfirmar.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnOjoConfirmar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.btnOjoConfirmar.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnOjoConfirmar.IconSize = 29;
            this.btnOjoConfirmar.Location = new System.Drawing.Point(309, 92);
            this.btnOjoConfirmar.Name = "btnOjoConfirmar";
            this.btnOjoConfirmar.Size = new System.Drawing.Size(29, 27);
            this.btnOjoConfirmar.TabIndex = 4;
            this.btnOjoConfirmar.UseVisualStyleBackColor = true;
            this.btnOjoConfirmar.Click += new System.EventHandler(this.btnOjo_Click);
            this.btnOjoConfirmar.MouseEnter += new System.EventHandler(this.btnOjo_Enter);
            this.btnOjoConfirmar.MouseLeave += new System.EventHandler(this.btnOjo_MouseLeave);
            // 
            // btnOjoNueva
            // 
            this.btnOjoNueva.FlatAppearance.BorderSize = 0;
            this.btnOjoNueva.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnOjoNueva.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnOjoNueva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOjoNueva.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnOjoNueva.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.btnOjoNueva.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnOjoNueva.IconSize = 29;
            this.btnOjoNueva.Location = new System.Drawing.Point(309, 32);
            this.btnOjoNueva.Name = "btnOjoNueva";
            this.btnOjoNueva.Size = new System.Drawing.Size(29, 27);
            this.btnOjoNueva.TabIndex = 2;
            this.btnOjoNueva.UseVisualStyleBackColor = true;
            this.btnOjoNueva.Click += new System.EventHandler(this.btnOjo_Click);
            this.btnOjoNueva.MouseEnter += new System.EventHandler(this.btnOjo_Enter);
            this.btnOjoNueva.MouseLeave += new System.EventHandler(this.btnOjo_MouseLeave);
            // 
            // txtConfirmarContraseña
            // 
            this.txtConfirmarContraseña.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmarContraseña.Font = new System.Drawing.Font("Roboto", 12F);
            this.txtConfirmarContraseña.Location = new System.Drawing.Point(21, 92);
            this.txtConfirmarContraseña.Name = "txtConfirmarContraseña";
            this.txtConfirmarContraseña.Size = new System.Drawing.Size(282, 27);
            this.txtConfirmarContraseña.TabIndex = 3;
            this.txtConfirmarContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCredenciales_KeyPress);
            // 
            // lblConfirmarContraseña
            // 
            this.lblConfirmarContraseña.AutoSize = true;
            this.lblConfirmarContraseña.Font = new System.Drawing.Font("Roboto", 11.25F);
            this.lblConfirmarContraseña.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblConfirmarContraseña.Location = new System.Drawing.Point(8, 71);
            this.lblConfirmarContraseña.Name = "lblConfirmarContraseña";
            this.lblConfirmarContraseña.Size = new System.Drawing.Size(155, 18);
            this.lblConfirmarContraseña.TabIndex = 0;
            this.lblConfirmarContraseña.Text = "Confirmar Contraseña";
            // 
            // txtNuevaContraseña
            // 
            this.txtNuevaContraseña.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNuevaContraseña.Font = new System.Drawing.Font("Roboto", 12F);
            this.txtNuevaContraseña.Location = new System.Drawing.Point(21, 32);
            this.txtNuevaContraseña.Name = "txtNuevaContraseña";
            this.txtNuevaContraseña.Size = new System.Drawing.Size(282, 27);
            this.txtNuevaContraseña.TabIndex = 1;
            this.txtNuevaContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCredenciales_KeyPress);
            // 
            // lblNuevaContraseña
            // 
            this.lblNuevaContraseña.AutoSize = true;
            this.lblNuevaContraseña.Font = new System.Drawing.Font("Roboto", 11.25F);
            this.lblNuevaContraseña.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNuevaContraseña.Location = new System.Drawing.Point(8, 11);
            this.lblNuevaContraseña.Name = "lblNuevaContraseña";
            this.lblNuevaContraseña.Size = new System.Drawing.Size(131, 18);
            this.lblNuevaContraseña.TabIndex = 0;
            this.lblNuevaContraseña.Text = "Nueva Contraseña";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(11)))), ((int)(((byte)(53)))));
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(137)))), ((int)(((byte)(180)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelar.Location = new System.Drawing.Point(250, 177);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 31);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(125)))), ((int)(((byte)(166)))));
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(137)))), ((int)(((byte)(180)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConfirmar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnConfirmar.Location = new System.Drawing.Point(149, 177);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(95, 31);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 300;
            this.errorProvider.ContainerControl = this;
            // 
            // frmNuevaContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 215);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNuevaContraseña";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevaContraseña";
            this.Load += new System.EventHandler(this.frmNuevaContraseña_Load);
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControl;
        private Guna.UI.WinForms.GunaControlBox gControlCerrar;
        private System.Windows.Forms.Label lblNombreForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtConfirmarContraseña;
        private System.Windows.Forms.Label lblConfirmarContraseña;
        private System.Windows.Forms.TextBox txtNuevaContraseña;
        private System.Windows.Forms.Label lblNuevaContraseña;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private FontAwesome.Sharp.IconButton btnOjoConfirmar;
        private FontAwesome.Sharp.IconButton btnOjoNueva;
    }
}