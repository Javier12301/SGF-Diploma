namespace SGF.PRESENTACION.frmModales.Seguridad
{
    partial class frmVerificarMail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblInformacion = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.txt5 = new System.Windows.Forms.TextBox();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.pnlControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.pnlControl.Size = new System.Drawing.Size(659, 38);
            this.pnlControl.TabIndex = 4;
            // 
            // gControlCerrar
            // 
            this.gControlCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gControlCerrar.AnimationHoverSpeed = 0.07F;
            this.gControlCerrar.AnimationSpeed = 0.03F;
            this.gControlCerrar.IconColor = System.Drawing.Color.White;
            this.gControlCerrar.IconSize = 15F;
            this.gControlCerrar.Location = new System.Drawing.Point(607, 0);
            this.gControlCerrar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gControlCerrar.Name = "gControlCerrar";
            this.gControlCerrar.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.gControlCerrar.OnHoverIconColor = System.Drawing.Color.White;
            this.gControlCerrar.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gControlCerrar.Size = new System.Drawing.Size(52, 38);
            this.gControlCerrar.TabIndex = 2;
            // 
            // lblNombreForm
            // 
            this.lblNombreForm.AutoSize = true;
            this.lblNombreForm.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.lblNombreForm.ForeColor = System.Drawing.Color.White;
            this.lblNombreForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNombreForm.Location = new System.Drawing.Point(5, 12);
            this.lblNombreForm.Name = "lblNombreForm";
            this.lblNombreForm.Size = new System.Drawing.Size(97, 15);
            this.lblNombreForm.TabIndex = 0;
            this.lblNombreForm.Text = "Verificar Cuenta";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblUsuario);
            this.panel1.Controls.Add(this.lblInformacion);
            this.panel1.Controls.Add(this.lblMail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 96);
            this.panel1.TabIndex = 7;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblUsuario.Location = new System.Drawing.Point(12, 69);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(67, 19);
            this.lblUsuario.TabIndex = 7;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblInformacion
            // 
            this.lblInformacion.AutoSize = true;
            this.lblInformacion.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacion.ForeColor = System.Drawing.Color.Black;
            this.lblInformacion.Location = new System.Drawing.Point(6, 3);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(226, 23);
            this.lblInformacion.TabIndex = 6;
            this.lblInformacion.Text = "Información de tu cuenta";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMail.ForeColor = System.Drawing.Color.Black;
            this.lblMail.Location = new System.Drawing.Point(12, 34);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(140, 19);
            this.lblMail.TabIndex = 6;
            this.lblMail.Text = "Correo electronico:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.txt3);
            this.panel2.Controls.Add(this.txt5);
            this.panel2.Controls.Add(this.txt1);
            this.panel2.Controls.Add(this.txt2);
            this.panel2.Controls.Add(this.txt4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 133);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(659, 74);
            this.panel2.TabIndex = 8;
            // 
            // txt3
            // 
            this.txt3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.txt3.Font = new System.Drawing.Font("Consolas", 40F);
            this.txt3.Location = new System.Drawing.Point(263, 1);
            this.txt3.MaxLength = 1;
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(124, 70);
            this.txt3.TabIndex = 2;
            this.txt3.Text = "1";
            this.txt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt5
            // 
            this.txt5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.txt5.Font = new System.Drawing.Font("Consolas", 40F);
            this.txt5.Location = new System.Drawing.Point(527, 1);
            this.txt5.MaxLength = 1;
            this.txt5.Name = "txt5";
            this.txt5.Size = new System.Drawing.Size(124, 70);
            this.txt5.TabIndex = 4;
            this.txt5.Text = "1";
            this.txt5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt1
            // 
            this.txt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.txt1.Font = new System.Drawing.Font("Consolas", 40F);
            this.txt1.Location = new System.Drawing.Point(3, 1);
            this.txt1.MaxLength = 1;
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(124, 70);
            this.txt1.TabIndex = 0;
            this.txt1.Text = "1";
            this.txt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt2
            // 
            this.txt2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.txt2.Font = new System.Drawing.Font("Consolas", 40F);
            this.txt2.Location = new System.Drawing.Point(133, 1);
            this.txt2.MaxLength = 1;
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(124, 70);
            this.txt2.TabIndex = 1;
            this.txt2.Text = "1";
            this.txt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt4
            // 
            this.txt4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.txt4.Font = new System.Drawing.Font("Consolas", 40F);
            this.txt4.Location = new System.Drawing.Point(393, 1);
            this.txt4.MaxLength = 1;
            this.txt4.Name = "txt4";
            this.txt4.Size = new System.Drawing.Size(124, 70);
            this.txt4.TabIndex = 3;
            this.txt4.Text = "1";
            this.txt4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmVerificarMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 207);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVerificarMail";
            this.Text = "frmVerificarMail";
            this.Load += new System.EventHandler(this.frmVerificarMail_Load);
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControl;
        private Guna.UI.WinForms.GunaControlBox gControlCerrar;
        private System.Windows.Forms.Label lblNombreForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblInformacion;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.TextBox txt5;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txt4;
    }
}