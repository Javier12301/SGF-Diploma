namespace SGF.PRESENTACION.formPrincipales
{
    partial class formPerfiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPerfiles));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlPerfilesPadre = new System.Windows.Forms.Panel();
            this.pctLineSeparator = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnGrupos = new System.Windows.Forms.Button();
            this.btnInformes = new System.Windows.Forms.Button();
            this.btnMisDatos = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctLineSeparator)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlPerfilesPadre);
            this.panel1.Controls.Add(this.pctLineSeparator);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 448);
            this.panel1.TabIndex = 4;
            // 
            // pnlPerfilesPadre
            // 
            this.pnlPerfilesPadre.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPerfilesPadre.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPerfilesPadre.Location = new System.Drawing.Point(0, 88);
            this.pnlPerfilesPadre.Name = "pnlPerfilesPadre";
            this.pnlPerfilesPadre.Size = new System.Drawing.Size(1081, 360);
            this.pnlPerfilesPadre.TabIndex = 210;
            // 
            // pctLineSeparator
            // 
            this.pctLineSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pctLineSeparator.Location = new System.Drawing.Point(2, 80);
            this.pctLineSeparator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.pctLineSeparator.Name = "pctLineSeparator";
            this.pctLineSeparator.Size = new System.Drawing.Size(1081, 2);
            this.pctLineSeparator.TabIndex = 209;
            this.pctLineSeparator.TabStop = false;
            this.pctLineSeparator.Tag = "txtUser";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.btnUsuarios);
            this.flowLayoutPanel1.Controls.Add(this.btnGrupos);
            this.flowLayoutPanel1.Controls.Add(this.btnInformes);
            this.flowLayoutPanel1.Controls.Add(this.btnMisDatos);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 6);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(857, 70);
            this.flowLayoutPanel1.TabIndex = 106;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.White;
            this.btnUsuarios.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.Black;
            this.btnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Image")));
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUsuarios.Location = new System.Drawing.Point(3, 3);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(118, 62);
            this.btnUsuarios.TabIndex = 18;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUsuarios.UseVisualStyleBackColor = false;
            // 
            // btnGrupos
            // 
            this.btnGrupos.BackColor = System.Drawing.Color.White;
            this.btnGrupos.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGrupos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrupos.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrupos.ForeColor = System.Drawing.Color.Black;
            this.btnGrupos.Image = ((System.Drawing.Image)(resources.GetObject("btnGrupos.Image")));
            this.btnGrupos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGrupos.Location = new System.Drawing.Point(127, 3);
            this.btnGrupos.Name = "btnGrupos";
            this.btnGrupos.Size = new System.Drawing.Size(118, 62);
            this.btnGrupos.TabIndex = 15;
            this.btnGrupos.Text = "Grupos";
            this.btnGrupos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrupos.UseVisualStyleBackColor = false;
            // 
            // btnInformes
            // 
            this.btnInformes.BackColor = System.Drawing.Color.White;
            this.btnInformes.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnInformes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformes.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInformes.ForeColor = System.Drawing.Color.Black;
            this.btnInformes.Image = ((System.Drawing.Image)(resources.GetObject("btnInformes.Image")));
            this.btnInformes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnInformes.Location = new System.Drawing.Point(251, 3);
            this.btnInformes.Name = "btnInformes";
            this.btnInformes.Size = new System.Drawing.Size(118, 62);
            this.btnInformes.TabIndex = 16;
            this.btnInformes.Text = "Auditoria";
            this.btnInformes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInformes.UseVisualStyleBackColor = false;
            // 
            // btnMisDatos
            // 
            this.btnMisDatos.BackColor = System.Drawing.Color.White;
            this.btnMisDatos.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnMisDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMisDatos.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMisDatos.ForeColor = System.Drawing.Color.Black;
            this.btnMisDatos.Image = ((System.Drawing.Image)(resources.GetObject("btnMisDatos.Image")));
            this.btnMisDatos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMisDatos.Location = new System.Drawing.Point(375, 3);
            this.btnMisDatos.Name = "btnMisDatos";
            this.btnMisDatos.Size = new System.Drawing.Size(118, 62);
            this.btnMisDatos.TabIndex = 19;
            this.btnMisDatos.Text = "Mis datos";
            this.btnMisDatos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMisDatos.UseVisualStyleBackColor = false;
            // 
            // formPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 448);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formPerfiles";
            this.Text = "formPerfiles";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctLineSeparator)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlPerfilesPadre;
        private System.Windows.Forms.PictureBox pctLineSeparator;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnGrupos;
        private System.Windows.Forms.Button btnInformes;
        private System.Windows.Forms.Button btnMisDatos;
    }
}