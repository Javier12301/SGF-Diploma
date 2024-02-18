namespace SGF.PRESENTACION.formPrincipales
{
    partial class formReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formReportes));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlReportesPadre = new System.Windows.Forms.Panel();
            this.pctLineSeparator = new System.Windows.Forms.PictureBox();
            this.flpContenedorBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExistencias = new System.Windows.Forms.Button();
            this.btnEntradas = new System.Windows.Forms.Button();
            this.btnSalidas = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctLineSeparator)).BeginInit();
            this.flpContenedorBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlReportesPadre);
            this.panel1.Controls.Add(this.pctLineSeparator);
            this.panel1.Controls.Add(this.flpContenedorBotones);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 448);
            this.panel1.TabIndex = 2;
            // 
            // pnlReportesPadre
            // 
            this.pnlReportesPadre.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlReportesPadre.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlReportesPadre.Location = new System.Drawing.Point(0, 101);
            this.pnlReportesPadre.Name = "pnlReportesPadre";
            this.pnlReportesPadre.Size = new System.Drawing.Size(1081, 347);
            this.pnlReportesPadre.TabIndex = 210;
            // 
            // pctLineSeparator
            // 
            this.pctLineSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pctLineSeparator.Location = new System.Drawing.Point(4, 93);
            this.pctLineSeparator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.pctLineSeparator.Name = "pctLineSeparator";
            this.pctLineSeparator.Size = new System.Drawing.Size(1081, 2);
            this.pctLineSeparator.TabIndex = 209;
            this.pctLineSeparator.TabStop = false;
            this.pctLineSeparator.Tag = "txtUser";
            // 
            // flpContenedorBotones
            // 
            this.flpContenedorBotones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpContenedorBotones.BackColor = System.Drawing.Color.LightGray;
            this.flpContenedorBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpContenedorBotones.Controls.Add(this.btnEntradas);
            this.flpContenedorBotones.Controls.Add(this.btnExistencias);
            this.flpContenedorBotones.Controls.Add(this.btnSalidas);
            this.flpContenedorBotones.Location = new System.Drawing.Point(0, 6);
            this.flpContenedorBotones.Margin = new System.Windows.Forms.Padding(4);
            this.flpContenedorBotones.Name = "flpContenedorBotones";
            this.flpContenedorBotones.Size = new System.Drawing.Size(857, 81);
            this.flpContenedorBotones.TabIndex = 106;
            // 
            // btnExistencias
            // 
            this.btnExistencias.BackColor = System.Drawing.Color.White;
            this.btnExistencias.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnExistencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExistencias.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExistencias.ForeColor = System.Drawing.Color.Black;
            this.btnExistencias.Image = ((System.Drawing.Image)(resources.GetObject("btnExistencias.Image")));
            this.btnExistencias.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExistencias.Location = new System.Drawing.Point(127, 3);
            this.btnExistencias.Name = "btnExistencias";
            this.btnExistencias.Size = new System.Drawing.Size(118, 73);
            this.btnExistencias.TabIndex = 18;
            this.btnExistencias.Tag = "Ventas";
            this.btnExistencias.Text = "Ventas";
            this.btnExistencias.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExistencias.UseVisualStyleBackColor = false;
            this.btnExistencias.Click += new System.EventHandler(this.btnExistencias_Click);
            // 
            // btnEntradas
            // 
            this.btnEntradas.BackColor = System.Drawing.Color.White;
            this.btnEntradas.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEntradas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntradas.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntradas.ForeColor = System.Drawing.Color.Black;
            this.btnEntradas.Image = ((System.Drawing.Image)(resources.GetObject("btnEntradas.Image")));
            this.btnEntradas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEntradas.Location = new System.Drawing.Point(3, 3);
            this.btnEntradas.Name = "btnEntradas";
            this.btnEntradas.Size = new System.Drawing.Size(118, 73);
            this.btnEntradas.TabIndex = 15;
            this.btnEntradas.Tag = "Inventario";
            this.btnEntradas.Text = "Inventario";
            this.btnEntradas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEntradas.UseVisualStyleBackColor = false;
            this.btnEntradas.Click += new System.EventHandler(this.btnEntradas_Click);
            // 
            // btnSalidas
            // 
            this.btnSalidas.BackColor = System.Drawing.Color.White;
            this.btnSalidas.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSalidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalidas.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalidas.ForeColor = System.Drawing.Color.Black;
            this.btnSalidas.Image = ((System.Drawing.Image)(resources.GetObject("btnSalidas.Image")));
            this.btnSalidas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalidas.Location = new System.Drawing.Point(251, 3);
            this.btnSalidas.Name = "btnSalidas";
            this.btnSalidas.Size = new System.Drawing.Size(118, 73);
            this.btnSalidas.TabIndex = 16;
            this.btnSalidas.Tag = "Clientes";
            this.btnSalidas.Text = "Clientes";
            this.btnSalidas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalidas.UseVisualStyleBackColor = false;
            this.btnSalidas.Click += new System.EventHandler(this.btnSalidas_Click);
            // 
            // formReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 448);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formReportes";
            this.Text = "formReportes";
            this.Load += new System.EventHandler(this.formReportes_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctLineSeparator)).EndInit();
            this.flpContenedorBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpContenedorBotones;
        private System.Windows.Forms.Button btnExistencias;
        private System.Windows.Forms.Button btnEntradas;
        private System.Windows.Forms.Button btnSalidas;
        private System.Windows.Forms.PictureBox pctLineSeparator;
        private System.Windows.Forms.Panel pnlReportesPadre;
    }
}