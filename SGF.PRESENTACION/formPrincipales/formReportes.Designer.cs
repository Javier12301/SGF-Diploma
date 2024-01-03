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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExistencias = new System.Windows.Forms.Button();
            this.btnEntradas = new System.Windows.Forms.Button();
            this.btnSalidas = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExportarP = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctLineSeparator)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlReportesPadre);
            this.panel1.Controls.Add(this.pctLineSeparator);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.btnExistencias);
            this.flowLayoutPanel1.Controls.Add(this.btnEntradas);
            this.flowLayoutPanel1.Controls.Add(this.btnSalidas);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.btnExportarP);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 6);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(857, 81);
            this.flowLayoutPanel1.TabIndex = 106;
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
            this.btnExistencias.Location = new System.Drawing.Point(3, 3);
            this.btnExistencias.Name = "btnExistencias";
            this.btnExistencias.Size = new System.Drawing.Size(118, 73);
            this.btnExistencias.TabIndex = 18;
            this.btnExistencias.Text = "Existencias";
            this.btnExistencias.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExistencias.UseVisualStyleBackColor = false;
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
            this.btnEntradas.Location = new System.Drawing.Point(127, 3);
            this.btnEntradas.Name = "btnEntradas";
            this.btnEntradas.Size = new System.Drawing.Size(118, 73);
            this.btnEntradas.TabIndex = 15;
            this.btnEntradas.Text = "Entrada a Inventario";
            this.btnEntradas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEntradas.UseVisualStyleBackColor = false;
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
            this.btnSalidas.Text = "Salida de Inventario";
            this.btnSalidas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalidas.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(499, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 73);
            this.button1.TabIndex = 19;
            this.button1.Text = "Imprimir";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
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
            this.btnExportarP.Location = new System.Drawing.Point(623, 3);
            this.btnExportarP.Name = "btnExportarP";
            this.btnExportarP.Size = new System.Drawing.Size(118, 73);
            this.btnExportarP.TabIndex = 17;
            this.btnExportarP.Text = "Exportar";
            this.btnExportarP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportarP.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(375, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 73);
            this.button2.TabIndex = 20;
            this.button2.Text = "Historico";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = false;
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
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctLineSeparator)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnExistencias;
        private System.Windows.Forms.Button btnEntradas;
        private System.Windows.Forms.Button btnSalidas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnExportarP;
        private System.Windows.Forms.PictureBox pctLineSeparator;
        private System.Windows.Forms.Panel pnlReportesPadre;
        private System.Windows.Forms.Button button2;
    }
}