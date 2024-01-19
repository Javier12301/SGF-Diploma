namespace SGF.PRESENTACION.formPrincipales
{
    partial class formMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFechayHora = new Guna.UI.WinForms.GunaTextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pnlPadre = new System.Windows.Forms.Panel();
            this.tHorayFecha = new System.Windows.Forms.Timer(this.components);
            this.tsSuperior = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnVentas = new System.Windows.Forms.ToolStripButton();
            this.btnProductos = new System.Windows.Forms.ToolStripButton();
            this.btnProveedor = new System.Windows.Forms.ToolStripButton();
            this.btnInventario = new System.Windows.Forms.ToolStripButton();
            this.btnRegistro = new System.Windows.Forms.ToolStripButton();
            this.btnReportes = new System.Windows.Forms.ToolStripButton();
            this.btnAjustes = new System.Windows.Forms.ToolStripButton();
            this.btnLogOut = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.lblUsuario = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.lblGrupo = new System.Windows.Forms.ToolStripLabel();
            this.panel1.SuspendLayout();
            this.tsSuperior.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.txtFechayHora);
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 539);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1256, 39);
            this.panel1.TabIndex = 15;
            // 
            // txtFechayHora
            // 
            this.txtFechayHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFechayHora.BackColor = System.Drawing.Color.Transparent;
            this.txtFechayHora.BaseColor = System.Drawing.Color.White;
            this.txtFechayHora.BorderColor = System.Drawing.Color.Silver;
            this.txtFechayHora.BorderSize = 0;
            this.txtFechayHora.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFechayHora.Enabled = false;
            this.txtFechayHora.FocusedBaseColor = System.Drawing.Color.White;
            this.txtFechayHora.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtFechayHora.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtFechayHora.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtFechayHora.ForeColor = System.Drawing.Color.DimGray;
            this.txtFechayHora.Location = new System.Drawing.Point(1001, 2);
            this.txtFechayHora.Margin = new System.Windows.Forms.Padding(4);
            this.txtFechayHora.Name = "txtFechayHora";
            this.txtFechayHora.PasswordChar = '\0';
            this.txtFechayHora.Radius = 5;
            this.txtFechayHora.Size = new System.Drawing.Size(217, 32);
            this.txtFechayHora.TabIndex = 13;
            this.txtFechayHora.Text = "0";
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.DimGray;
            this.lblFecha.Location = new System.Drawing.Point(11, 10);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(189, 15);
            this.lblFecha.TabIndex = 12;
            this.lblFecha.Text = "© 2023 (v2.0) - Javier Ramírez.";
            // 
            // pnlPadre
            // 
            this.pnlPadre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPadre.BackColor = System.Drawing.Color.White;
            this.pnlPadre.Location = new System.Drawing.Point(7, 83);
            this.pnlPadre.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPadre.Name = "pnlPadre";
            this.pnlPadre.Size = new System.Drawing.Size(1244, 455);
            this.pnlPadre.TabIndex = 16;
            // 
            // tHorayFecha
            // 
            this.tHorayFecha.Enabled = true;
            this.tHorayFecha.Interval = 1000;
            this.tHorayFecha.Tick += new System.EventHandler(this.tHorayFecha_Tick);
            // 
            // tsSuperior
            // 
            this.tsSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.tsSuperior.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsSuperior.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSuperior.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsSuperior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnVentas,
            this.btnProductos,
            this.btnProveedor,
            this.btnInventario,
            this.btnRegistro,
            this.btnReportes,
            this.btnAjustes,
            this.btnLogOut});
            this.tsSuperior.Location = new System.Drawing.Point(0, 0);
            this.tsSuperior.Name = "tsSuperior";
            this.tsSuperior.Size = new System.Drawing.Size(1256, 54);
            this.tsSuperior.TabIndex = 106;
            this.tsSuperior.Text = "toolStrip2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // btnVentas
            // 
            this.btnVentas.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.Color.Black;
            this.btnVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnVentas.Image")));
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnVentas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(54, 51);
            this.btnVentas.Tag = "formVentas";
            this.btnVentas.Text = "Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.Black;
            this.btnProductos.Image = ((System.Drawing.Image)(resources.GetObject("btnProductos.Image")));
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProductos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnProductos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(75, 51);
            this.btnProductos.Tag = "formProductos";
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnProveedor
            // 
            this.btnProveedor.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedor.ForeColor = System.Drawing.Color.Black;
            this.btnProveedor.Image = ((System.Drawing.Image)(resources.GetObject("btnProveedor.Image")));
            this.btnProveedor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProveedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnProveedor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProveedor.Name = "btnProveedor";
            this.btnProveedor.Size = new System.Drawing.Size(88, 51);
            this.btnProveedor.Tag = "formProveedores";
            this.btnProveedor.Text = "Proveedores";
            this.btnProveedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProveedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProveedor.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.ForeColor = System.Drawing.Color.Black;
            this.btnInventario.Image = ((System.Drawing.Image)(resources.GetObject("btnInventario.Image")));
            this.btnInventario.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnInventario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnInventario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(75, 51);
            this.btnInventario.Tag = "formInventario";
            this.btnInventario.Text = "Inventario";
            this.btnInventario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInventario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnRegistro
            // 
            this.btnRegistro.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.ForeColor = System.Drawing.Color.Black;
            this.btnRegistro.Image = ((System.Drawing.Image)(resources.GetObject("btnRegistro.Image")));
            this.btnRegistro.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRegistro.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRegistro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Size = new System.Drawing.Size(70, 51);
            this.btnRegistro.Tag = "formRegistros";
            this.btnRegistro.Text = "Registros";
            this.btnRegistro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegistro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnReportes
            // 
            this.btnReportes.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.Black;
            this.btnReportes.Image = ((System.Drawing.Image)(resources.GetObject("btnReportes.Image")));
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReportes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(67, 51);
            this.btnReportes.Tag = "formReportes";
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnAjustes
            // 
            this.btnAjustes.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjustes.ForeColor = System.Drawing.Color.Black;
            this.btnAjustes.Image = ((System.Drawing.Image)(resources.GetObject("btnAjustes.Image")));
            this.btnAjustes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAjustes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAjustes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAjustes.Name = "btnAjustes";
            this.btnAjustes.Size = new System.Drawing.Size(57, 51);
            this.btnAjustes.Tag = "formAjustes";
            this.btnAjustes.Text = "Ajustes";
            this.btnAjustes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAjustes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAjustes.Click += new System.EventHandler(this.btnAjustes_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.Black;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLogOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLogOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(94, 51);
            this.btnLogOut.Text = "Cerrar Sesión";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStrip1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.lblUsuario,
            this.toolStripSeparator2,
            this.toolStripLabel5,
            this.lblGrupo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 54);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1256, 25);
            this.toolStrip1.TabIndex = 107;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(51, 22);
            this.toolStripLabel2.Text = "Usuario:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUsuario.Size = new System.Drawing.Size(100, 22);
            this.lblUsuario.Text = "ADMINISTRADOR";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(43, 22);
            this.toolStripLabel5.Text = "Grupo:";
            // 
            // lblGrupo
            // 
            this.lblGrupo.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrupo.ForeColor = System.Drawing.Color.Black;
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblGrupo.Size = new System.Drawing.Size(100, 22);
            this.lblGrupo.Text = "ADMINISTRADOR";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 578);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tsSuperior);
            this.Controls.Add(this.pnlPadre);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(1272, 617);
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestión Farmacéutico";
            this.Load += new System.EventHandler(this.formMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tsSuperior.ResumeLayout(false);
            this.tsSuperior.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaTextBox txtFechayHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel pnlPadre;
        private System.Windows.Forms.Timer tHorayFecha;
        private System.Windows.Forms.ToolStrip tsSuperior;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel lblUsuario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripLabel lblGrupo;
        private System.Windows.Forms.ToolStripButton btnVentas;
        private System.Windows.Forms.ToolStripButton btnProductos;
        private System.Windows.Forms.ToolStripButton btnProveedor;
        private System.Windows.Forms.ToolStripButton btnInventario;
        private System.Windows.Forms.ToolStripButton btnRegistro;
        private System.Windows.Forms.ToolStripButton btnReportes;
        private System.Windows.Forms.ToolStripButton btnAjustes;
        private System.Windows.Forms.ToolStripButton btnLogOut;
    }
}