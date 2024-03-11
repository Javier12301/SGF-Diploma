namespace SGF.PRESENTACION.formPrincipales.formHijos.Reportes.Inventario
{
    partial class formReporteInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formReporteInventario));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlPadreReporteInventario = new System.Windows.Forms.Panel();
            this.flpContenedorBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExistencias = new System.Windows.Forms.Button();
            this.btnEntradas = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flpContenedorBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlPadreReporteInventario);
            this.panel1.Controls.Add(this.flpContenedorBotones);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 360);
            this.panel1.TabIndex = 1;
            // 
            // pnlPadreReporteInventario
            // 
            this.pnlPadreReporteInventario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPadreReporteInventario.Location = new System.Drawing.Point(0, 70);
            this.pnlPadreReporteInventario.Name = "pnlPadreReporteInventario";
            this.pnlPadreReporteInventario.Size = new System.Drawing.Size(1081, 290);
            this.pnlPadreReporteInventario.TabIndex = 108;
            // 
            // flpContenedorBotones
            // 
            this.flpContenedorBotones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpContenedorBotones.BackColor = System.Drawing.Color.LightGray;
            this.flpContenedorBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpContenedorBotones.Controls.Add(this.btnExistencias);
            this.flpContenedorBotones.Controls.Add(this.btnEntradas);
            this.flpContenedorBotones.Location = new System.Drawing.Point(4, 4);
            this.flpContenedorBotones.Margin = new System.Windows.Forms.Padding(4);
            this.flpContenedorBotones.Name = "flpContenedorBotones";
            this.flpContenedorBotones.Size = new System.Drawing.Size(857, 62);
            this.flpContenedorBotones.TabIndex = 107;
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
            this.btnExistencias.Location = new System.Drawing.Point(4, 4);
            this.btnExistencias.Margin = new System.Windows.Forms.Padding(4);
            this.btnExistencias.Name = "btnExistencias";
            this.btnExistencias.Size = new System.Drawing.Size(118, 54);
            this.btnExistencias.TabIndex = 9;
            this.btnExistencias.Tag = "Existencias de inventario";
            this.btnExistencias.Text = "Existencias";
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
            this.btnEntradas.Location = new System.Drawing.Point(130, 4);
            this.btnEntradas.Margin = new System.Windows.Forms.Padding(4);
            this.btnEntradas.Name = "btnEntradas";
            this.btnEntradas.Size = new System.Drawing.Size(145, 54);
            this.btnEntradas.TabIndex = 10;
            this.btnEntradas.Tag = "Resumen de inventario";
            this.btnEntradas.Text = "Resumen de inventario";
            this.btnEntradas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEntradas.UseVisualStyleBackColor = false;
            this.btnEntradas.Click += new System.EventHandler(this.btnModificarP_Click);
            // 
            // formReporteInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 360);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formReporteInventario";
            this.Text = "formReporteInventario";
            this.Load += new System.EventHandler(this.formReporteInventario_Load);
            this.panel1.ResumeLayout(false);
            this.flpContenedorBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpContenedorBotones;
        private System.Windows.Forms.Button btnExistencias;
        private System.Windows.Forms.Button btnEntradas;
        private System.Windows.Forms.Panel pnlPadreReporteInventario;
    }
}