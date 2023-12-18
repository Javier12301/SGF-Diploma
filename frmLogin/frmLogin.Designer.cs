namespace frmLogin
{
    partial class frmLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.btnContraseña = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnOjo = new FontAwesome.Sharp.IconButton();
            this.icoCandado = new FontAwesome.Sharp.IconPictureBox();
            this.txtContraseñaG = new Guna.UI.WinForms.GunaLineTextBox();
            this.icoUsuario = new FontAwesome.Sharp.IconPictureBox();
            this.txtUsuarioG = new Guna.UI.WinForms.GunaLineTextBox();
            this.pbLogoEmpresa = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNombreEmpresa = new System.Windows.Forms.Label();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.gControlCerrar = new Guna.UI.WinForms.GunaControlBox();
            this.lblNombreForm = new System.Windows.Forms.Label();
            this.pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icoCandado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icoUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoEmpresa)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            resources.ApplyResources(this.pnlPrincipal, "pnlPrincipal");
            this.pnlPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlPrincipal.Controls.Add(this.btnContraseña);
            this.pnlPrincipal.Controls.Add(this.btnLogin);
            this.pnlPrincipal.Controls.Add(this.btnOjo);
            this.pnlPrincipal.Controls.Add(this.icoCandado);
            this.pnlPrincipal.Controls.Add(this.txtContraseñaG);
            this.pnlPrincipal.Controls.Add(this.icoUsuario);
            this.pnlPrincipal.Controls.Add(this.txtUsuarioG);
            this.pnlPrincipal.Controls.Add(this.pbLogoEmpresa);
            this.pnlPrincipal.Controls.Add(this.panel1);
            this.pnlPrincipal.Controls.Add(this.pnlControl);
            this.pnlPrincipal.Name = "pnlPrincipal";
            // 
            // btnContraseña
            // 
            resources.ApplyResources(this.btnContraseña, "btnContraseña");
            this.btnContraseña.BackColor = System.Drawing.Color.White;
            this.btnContraseña.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContraseña.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnContraseña.FlatAppearance.BorderSize = 0;
            this.btnContraseña.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnContraseña.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnContraseña.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnContraseña.Name = "btnContraseña";
            this.btnContraseña.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnOjo
            // 
            resources.ApplyResources(this.btnOjo, "btnOjo");
            this.btnOjo.FlatAppearance.BorderSize = 0;
            this.btnOjo.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnOjo.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.btnOjo.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnOjo.IconSize = 29;
            this.btnOjo.Name = "btnOjo";
            this.btnOjo.UseVisualStyleBackColor = true;
            // 
            // icoCandado
            // 
            resources.ApplyResources(this.icoCandado, "icoCandado");
            this.icoCandado.BackColor = System.Drawing.Color.White;
            this.icoCandado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.icoCandado.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.icoCandado.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.icoCandado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoCandado.IconSize = 29;
            this.icoCandado.Name = "icoCandado";
            this.icoCandado.TabStop = false;
            // 
            // txtContraseñaG
            // 
            resources.ApplyResources(this.txtContraseñaG, "txtContraseñaG");
            this.txtContraseñaG.BackColor = System.Drawing.Color.White;
            this.txtContraseñaG.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContraseñaG.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(142)))), ((int)(((byte)(209)))));
            this.txtContraseñaG.LineColor = System.Drawing.Color.Gainsboro;
            this.txtContraseñaG.Name = "txtContraseñaG";
            this.txtContraseñaG.PasswordChar = '\0';
            // 
            // icoUsuario
            // 
            resources.ApplyResources(this.icoUsuario, "icoUsuario");
            this.icoUsuario.BackColor = System.Drawing.Color.White;
            this.icoUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.icoUsuario.IconChar = FontAwesome.Sharp.IconChar.User;
            this.icoUsuario.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.icoUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoUsuario.IconSize = 29;
            this.icoUsuario.Name = "icoUsuario";
            this.icoUsuario.TabStop = false;
            // 
            // txtUsuarioG
            // 
            resources.ApplyResources(this.txtUsuarioG, "txtUsuarioG");
            this.txtUsuarioG.BackColor = System.Drawing.Color.White;
            this.txtUsuarioG.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsuarioG.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(142)))), ((int)(((byte)(209)))));
            this.txtUsuarioG.LineColor = System.Drawing.Color.Gainsboro;
            this.txtUsuarioG.Name = "txtUsuarioG";
            this.txtUsuarioG.PasswordChar = '\0';
            // 
            // pbLogoEmpresa
            // 
            resources.ApplyResources(this.pbLogoEmpresa, "pbLogoEmpresa");
            this.pbLogoEmpresa.Name = "pbLogoEmpresa";
            this.pbLogoEmpresa.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.lblNombreEmpresa);
            this.panel1.Name = "panel1";
            // 
            // lblNombreEmpresa
            // 
            resources.ApplyResources(this.lblNombreEmpresa, "lblNombreEmpresa");
            this.lblNombreEmpresa.AutoEllipsis = true;
            this.lblNombreEmpresa.Name = "lblNombreEmpresa";
            // 
            // pnlControl
            // 
            resources.ApplyResources(this.pnlControl, "pnlControl");
            this.pnlControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.pnlControl.Controls.Add(this.gControlCerrar);
            this.pnlControl.Controls.Add(this.lblNombreForm);
            this.pnlControl.Name = "pnlControl";
            // 
            // gControlCerrar
            // 
            resources.ApplyResources(this.gControlCerrar, "gControlCerrar");
            this.gControlCerrar.AnimationHoverSpeed = 0.07F;
            this.gControlCerrar.AnimationSpeed = 0.03F;
            this.gControlCerrar.IconColor = System.Drawing.Color.White;
            this.gControlCerrar.IconSize = 15F;
            this.gControlCerrar.Name = "gControlCerrar";
            this.gControlCerrar.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.gControlCerrar.OnHoverIconColor = System.Drawing.Color.White;
            this.gControlCerrar.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // lblNombreForm
            // 
            resources.ApplyResources(this.lblNombreForm, "lblNombreForm");
            this.lblNombreForm.ForeColor = System.Drawing.Color.White;
            this.lblNombreForm.Name = "lblNombreForm";
            // 
            // frmLogin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icoCandado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icoUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoEmpresa)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Label lblNombreForm;
        private System.Windows.Forms.PictureBox pbLogoEmpresa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNombreEmpresa;
        private Guna.UI.WinForms.GunaControlBox gControlCerrar;
        private System.Windows.Forms.Button btnContraseña;
        private System.Windows.Forms.Button btnLogin;
        private FontAwesome.Sharp.IconButton btnOjo;
        private FontAwesome.Sharp.IconPictureBox icoCandado;
        private Guna.UI.WinForms.GunaLineTextBox txtContraseñaG;
        private FontAwesome.Sharp.IconPictureBox icoUsuario;
        private Guna.UI.WinForms.GunaLineTextBox txtUsuarioG;
    }
}

