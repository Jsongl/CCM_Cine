namespace CCM_Cine
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.MenuPrin = new System.Windows.Forms.MenuStrip();
            this.peliculasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peliculasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.horariosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarEstadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCartelera = new System.Windows.Forms.Button();
            this.btnVenta = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.MenuPrin.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPrin
            // 
            this.MenuPrin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.peliculasToolStripMenuItem,
            this.listadosToolStripMenuItem,
            this.estadisticasToolStripMenuItem});
            this.MenuPrin.Location = new System.Drawing.Point(0, 0);
            this.MenuPrin.Name = "MenuPrin";
            this.MenuPrin.Size = new System.Drawing.Size(796, 24);
            this.MenuPrin.TabIndex = 1;
            this.MenuPrin.Text = "menuStrip1";
            // 
            // peliculasToolStripMenuItem
            // 
            this.peliculasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.salasToolStripMenuItem,
            this.horariosToolStripMenuItem,
            this.usuariosToolStripMenuItem});
            this.peliculasToolStripMenuItem.Name = "peliculasToolStripMenuItem";
            this.peliculasToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.peliculasToolStripMenuItem.Text = "Mantenimiento";
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.agregarToolStripMenuItem.Text = "Peliculas";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // salasToolStripMenuItem
            // 
            this.salasToolStripMenuItem.Name = "salasToolStripMenuItem";
            this.salasToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.salasToolStripMenuItem.Text = "Salas";
            this.salasToolStripMenuItem.Click += new System.EventHandler(this.salasToolStripMenuItem_Click);
            // 
            // horariosToolStripMenuItem
            // 
            this.horariosToolStripMenuItem.Name = "horariosToolStripMenuItem";
            this.horariosToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.horariosToolStripMenuItem.Text = "Horarios";
            this.horariosToolStripMenuItem.Click += new System.EventHandler(this.horariosToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // listadosToolStripMenuItem
            // 
            this.listadosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.peliculasToolStripMenuItem1,
            this.salasToolStripMenuItem1,
            this.horariosToolStripMenuItem1,
            this.usuariosToolStripMenuItem1});
            this.listadosToolStripMenuItem.Name = "listadosToolStripMenuItem";
            this.listadosToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.listadosToolStripMenuItem.Text = "Listados";
            // 
            // peliculasToolStripMenuItem1
            // 
            this.peliculasToolStripMenuItem1.Name = "peliculasToolStripMenuItem1";
            this.peliculasToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.peliculasToolStripMenuItem1.Text = "Peliculas";
            this.peliculasToolStripMenuItem1.Click += new System.EventHandler(this.peliculasToolStripMenuItem1_Click);
            // 
            // salasToolStripMenuItem1
            // 
            this.salasToolStripMenuItem1.Name = "salasToolStripMenuItem1";
            this.salasToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.salasToolStripMenuItem1.Text = "Salas";
            this.salasToolStripMenuItem1.Click += new System.EventHandler(this.salasToolStripMenuItem1_Click);
            // 
            // horariosToolStripMenuItem1
            // 
            this.horariosToolStripMenuItem1.Name = "horariosToolStripMenuItem1";
            this.horariosToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.horariosToolStripMenuItem1.Text = "Horarios";
            this.horariosToolStripMenuItem1.Click += new System.EventHandler(this.horariosToolStripMenuItem1_Click);
            // 
            // usuariosToolStripMenuItem1
            // 
            this.usuariosToolStripMenuItem1.Name = "usuariosToolStripMenuItem1";
            this.usuariosToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.usuariosToolStripMenuItem1.Text = "Usuarios";
            this.usuariosToolStripMenuItem1.Click += new System.EventHandler(this.usuariosToolStripMenuItem1_Click);
            // 
            // estadisticasToolStripMenuItem
            // 
            this.estadisticasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarEstadisticasToolStripMenuItem});
            this.estadisticasToolStripMenuItem.Name = "estadisticasToolStripMenuItem";
            this.estadisticasToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.estadisticasToolStripMenuItem.Text = "Estadisticas";
            // 
            // mostrarEstadisticasToolStripMenuItem
            // 
            this.mostrarEstadisticasToolStripMenuItem.Name = "mostrarEstadisticasToolStripMenuItem";
            this.mostrarEstadisticasToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.mostrarEstadisticasToolStripMenuItem.Text = "Mostrar Estadisticas";
            this.mostrarEstadisticasToolStripMenuItem.Click += new System.EventHandler(this.mostrarEstadisticasToolStripMenuItem_Click);
            // 
            // btnCartelera
            // 
            this.btnCartelera.Location = new System.Drawing.Point(0, 389);
            this.btnCartelera.Name = "btnCartelera";
            this.btnCartelera.Size = new System.Drawing.Size(106, 57);
            this.btnCartelera.TabIndex = 5;
            this.btnCartelera.Text = "Mostrar Cartelera";
            this.btnCartelera.UseVisualStyleBackColor = true;
            this.btnCartelera.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // btnVenta
            // 
            this.btnVenta.Location = new System.Drawing.Point(224, 389);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(106, 57);
            this.btnVenta.TabIndex = 7;
            this.btnVenta.Text = "Venta Boletos";
            this.btnVenta.UseVisualStyleBackColor = true;
            this.btnVenta.Click += new System.EventHandler(this.btnVenta_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(112, 389);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(106, 57);
            this.btnImprimir.TabIndex = 9;
            this.btnImprimir.Text = "Imprimir Boletos";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 448);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnVenta);
            this.Controls.Add(this.btnCartelera);
            this.Controls.Add(this.MenuPrin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuPrin;
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.MenuPrin.ResumeLayout(false);
            this.MenuPrin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuPrin;
        private System.Windows.Forms.ToolStripMenuItem peliculasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horariosToolStripMenuItem;
        private System.Windows.Forms.Button btnCartelera;
        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ToolStripMenuItem listadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peliculasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem horariosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem estadisticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarEstadisticasToolStripMenuItem;
    }
}