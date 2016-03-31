namespace CCM_Cine
{
    partial class Form_Horarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Horarios));
            this.lblFechaAño = new System.Windows.Forms.Label();
            this.txtFechaAño = new System.Windows.Forms.TextBox();
            this.lblFechaMes = new System.Windows.Forms.Label();
            this.txtFechaMes = new System.Windows.Forms.TextBox();
            this.lblFechaDia = new System.Windows.Forms.Label();
            this.txtFechaDia = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblSala = new System.Windows.Forms.Label();
            this.lblPelicula = new System.Windows.Forms.Label();
            this.lblMinutoInicio = new System.Windows.Forms.Label();
            this.txtMinutoInicio = new System.Windows.Forms.TextBox();
            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.txtHoraInicio = new System.Windows.Forms.TextBox();
            this.lblInicio = new System.Windows.Forms.Label();
            this.cmbSala = new System.Windows.Forms.ComboBox();
            this.cmbPeliculas = new System.Windows.Forms.ComboBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtCodigoBuscar = new System.Windows.Forms.TextBox();
            this.lblCodigoBuscar = new System.Windows.Forms.Label();
            this.lblMinutoFinal = new System.Windows.Forms.Label();
            this.txtMinutoFinal = new System.Windows.Forms.TextBox();
            this.lblHoraFinal = new System.Windows.Forms.Label();
            this.txtHoraFinal = new System.Windows.Forms.TextBox();
            this.lblFinal = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFechaAño
            // 
            this.lblFechaAño.AutoSize = true;
            this.lblFechaAño.Location = new System.Drawing.Point(225, 117);
            this.lblFechaAño.Name = "lblFechaAño";
            this.lblFechaAño.Size = new System.Drawing.Size(21, 13);
            this.lblFechaAño.TabIndex = 36;
            this.lblFechaAño.Text = "AA";
            // 
            // txtFechaAño
            // 
            this.txtFechaAño.Location = new System.Drawing.Point(183, 114);
            this.txtFechaAño.Name = "txtFechaAño";
            this.txtFechaAño.Size = new System.Drawing.Size(36, 20);
            this.txtFechaAño.TabIndex = 35;
            // 
            // lblFechaMes
            // 
            this.lblFechaMes.AutoSize = true;
            this.lblFechaMes.Location = new System.Drawing.Point(152, 117);
            this.lblFechaMes.Name = "lblFechaMes";
            this.lblFechaMes.Size = new System.Drawing.Size(25, 13);
            this.lblFechaMes.TabIndex = 34;
            this.lblFechaMes.Text = "MM";
            // 
            // txtFechaMes
            // 
            this.txtFechaMes.Location = new System.Drawing.Point(131, 114);
            this.txtFechaMes.Name = "txtFechaMes";
            this.txtFechaMes.Size = new System.Drawing.Size(23, 20);
            this.txtFechaMes.TabIndex = 33;
            // 
            // lblFechaDia
            // 
            this.lblFechaDia.AutoSize = true;
            this.lblFechaDia.Location = new System.Drawing.Point(105, 117);
            this.lblFechaDia.Name = "lblFechaDia";
            this.lblFechaDia.Size = new System.Drawing.Size(23, 13);
            this.lblFechaDia.TabIndex = 32;
            this.lblFechaDia.Text = "DD";
            // 
            // txtFechaDia
            // 
            this.txtFechaDia.Location = new System.Drawing.Point(84, 114);
            this.txtFechaDia.Name = "txtFechaDia";
            this.txtFechaDia.Size = new System.Drawing.Size(23, 20);
            this.txtFechaDia.TabIndex = 31;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(10, 117);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 30;
            this.lblFecha.Text = "Fecha";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(12, 9);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 37;
            this.lblCodigo.Text = "Codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(84, 6);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(121, 20);
            this.txtCodigo.TabIndex = 38;
            // 
            // lblSala
            // 
            this.lblSala.AutoSize = true;
            this.lblSala.Location = new System.Drawing.Point(12, 35);
            this.lblSala.Name = "lblSala";
            this.lblSala.Size = new System.Drawing.Size(28, 13);
            this.lblSala.TabIndex = 39;
            this.lblSala.Text = "Sala";
            // 
            // lblPelicula
            // 
            this.lblPelicula.AutoSize = true;
            this.lblPelicula.Location = new System.Drawing.Point(12, 61);
            this.lblPelicula.Name = "lblPelicula";
            this.lblPelicula.Size = new System.Drawing.Size(44, 13);
            this.lblPelicula.TabIndex = 41;
            this.lblPelicula.Text = "Pelicula";
            // 
            // lblMinutoInicio
            // 
            this.lblMinutoInicio.AutoSize = true;
            this.lblMinutoInicio.Location = new System.Drawing.Point(152, 141);
            this.lblMinutoInicio.Name = "lblMinutoInicio";
            this.lblMinutoInicio.Size = new System.Drawing.Size(25, 13);
            this.lblMinutoInicio.TabIndex = 47;
            this.lblMinutoInicio.Text = "MM";
            // 
            // txtMinutoInicio
            // 
            this.txtMinutoInicio.Location = new System.Drawing.Point(131, 138);
            this.txtMinutoInicio.Name = "txtMinutoInicio";
            this.txtMinutoInicio.Size = new System.Drawing.Size(23, 20);
            this.txtMinutoInicio.TabIndex = 46;
            // 
            // lblHoraInicio
            // 
            this.lblHoraInicio.AutoSize = true;
            this.lblHoraInicio.Location = new System.Drawing.Point(105, 141);
            this.lblHoraInicio.Name = "lblHoraInicio";
            this.lblHoraInicio.Size = new System.Drawing.Size(23, 13);
            this.lblHoraInicio.TabIndex = 45;
            this.lblHoraInicio.Text = "HH";
            // 
            // txtHoraInicio
            // 
            this.txtHoraInicio.Location = new System.Drawing.Point(84, 138);
            this.txtHoraInicio.Name = "txtHoraInicio";
            this.txtHoraInicio.Size = new System.Drawing.Size(23, 20);
            this.txtHoraInicio.TabIndex = 44;
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(10, 141);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(58, 13);
            this.lblInicio.TabIndex = 43;
            this.lblInicio.Text = "Hora Inicio";
            // 
            // cmbSala
            // 
            this.cmbSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSala.FormattingEnabled = true;
            this.cmbSala.Location = new System.Drawing.Point(84, 32);
            this.cmbSala.Name = "cmbSala";
            this.cmbSala.Size = new System.Drawing.Size(121, 21);
            this.cmbSala.TabIndex = 48;
            // 
            // cmbPeliculas
            // 
            this.cmbPeliculas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeliculas.FormattingEnabled = true;
            this.cmbPeliculas.Location = new System.Drawing.Point(84, 58);
            this.cmbPeliculas.Name = "cmbPeliculas";
            this.cmbPeliculas.Size = new System.Drawing.Size(121, 21);
            this.cmbPeliculas.TabIndex = 49;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(96, 196);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(63, 23);
            this.btnBorrar.TabIndex = 54;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(32, 196);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 53;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(144, 196);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 52;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(183, 196);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(59, 23);
            this.btnCancelar.TabIndex = 51;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(15, 196);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(63, 23);
            this.btnGuardar.TabIndex = 50;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtCodigoBuscar
            // 
            this.txtCodigoBuscar.Location = new System.Drawing.Point(84, 19);
            this.txtCodigoBuscar.Name = "txtCodigoBuscar";
            this.txtCodigoBuscar.Size = new System.Drawing.Size(121, 20);
            this.txtCodigoBuscar.TabIndex = 58;
            // 
            // lblCodigoBuscar
            // 
            this.lblCodigoBuscar.AutoSize = true;
            this.lblCodigoBuscar.Location = new System.Drawing.Point(12, 22);
            this.lblCodigoBuscar.Name = "lblCodigoBuscar";
            this.lblCodigoBuscar.Size = new System.Drawing.Size(40, 13);
            this.lblCodigoBuscar.TabIndex = 57;
            this.lblCodigoBuscar.Text = "Codigo";
            // 
            // lblMinutoFinal
            // 
            this.lblMinutoFinal.AutoSize = true;
            this.lblMinutoFinal.Location = new System.Drawing.Point(152, 165);
            this.lblMinutoFinal.Name = "lblMinutoFinal";
            this.lblMinutoFinal.Size = new System.Drawing.Size(25, 13);
            this.lblMinutoFinal.TabIndex = 63;
            this.lblMinutoFinal.Text = "MM";
            // 
            // txtMinutoFinal
            // 
            this.txtMinutoFinal.Location = new System.Drawing.Point(131, 162);
            this.txtMinutoFinal.Name = "txtMinutoFinal";
            this.txtMinutoFinal.Size = new System.Drawing.Size(23, 20);
            this.txtMinutoFinal.TabIndex = 62;
            // 
            // lblHoraFinal
            // 
            this.lblHoraFinal.AutoSize = true;
            this.lblHoraFinal.Location = new System.Drawing.Point(105, 165);
            this.lblHoraFinal.Name = "lblHoraFinal";
            this.lblHoraFinal.Size = new System.Drawing.Size(23, 13);
            this.lblHoraFinal.TabIndex = 61;
            this.lblHoraFinal.Text = "HH";
            // 
            // txtHoraFinal
            // 
            this.txtHoraFinal.Location = new System.Drawing.Point(84, 162);
            this.txtHoraFinal.Name = "txtHoraFinal";
            this.txtHoraFinal.Size = new System.Drawing.Size(23, 20);
            this.txtHoraFinal.TabIndex = 60;
            // 
            // lblFinal
            // 
            this.lblFinal.AutoSize = true;
            this.lblFinal.Location = new System.Drawing.Point(10, 165);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(55, 13);
            this.lblFinal.TabIndex = 59;
            this.lblFinal.Text = "Hora Final";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(84, 84);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(121, 20);
            this.txtPrecio.TabIndex = 65;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(12, 87);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(37, 13);
            this.lblPrecio.TabIndex = 64;
            this.lblPrecio.Text = "Precio";
            // 
            // Form_Horarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 234);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblMinutoFinal);
            this.Controls.Add(this.txtMinutoFinal);
            this.Controls.Add(this.lblHoraFinal);
            this.Controls.Add(this.txtHoraFinal);
            this.Controls.Add(this.lblFinal);
            this.Controls.Add(this.txtCodigoBuscar);
            this.Controls.Add(this.lblCodigoBuscar);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbPeliculas);
            this.Controls.Add(this.cmbSala);
            this.Controls.Add(this.lblMinutoInicio);
            this.Controls.Add(this.txtMinutoInicio);
            this.Controls.Add(this.lblHoraInicio);
            this.Controls.Add(this.txtHoraInicio);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.lblPelicula);
            this.Controls.Add(this.lblSala);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblFechaAño);
            this.Controls.Add(this.txtFechaAño);
            this.Controls.Add(this.lblFechaMes);
            this.Controls.Add(this.txtFechaMes);
            this.Controls.Add(this.lblFechaDia);
            this.Controls.Add(this.txtFechaDia);
            this.Controls.Add(this.lblFecha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Horarios";
            this.Text = "Horarios";
            this.Load += new System.EventHandler(this.Form_Horarios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFechaAño;
        private System.Windows.Forms.TextBox txtFechaAño;
        private System.Windows.Forms.Label lblFechaMes;
        private System.Windows.Forms.TextBox txtFechaMes;
        private System.Windows.Forms.Label lblFechaDia;
        private System.Windows.Forms.TextBox txtFechaDia;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblSala;
        private System.Windows.Forms.Label lblPelicula;
        private System.Windows.Forms.Label lblMinutoInicio;
        private System.Windows.Forms.TextBox txtMinutoInicio;
        private System.Windows.Forms.Label lblHoraInicio;
        private System.Windows.Forms.TextBox txtHoraInicio;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.ComboBox cmbSala;
        private System.Windows.Forms.ComboBox cmbPeliculas;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtCodigoBuscar;
        private System.Windows.Forms.Label lblCodigoBuscar;
        private System.Windows.Forms.Label lblMinutoFinal;
        private System.Windows.Forms.TextBox txtMinutoFinal;
        private System.Windows.Forms.Label lblHoraFinal;
        private System.Windows.Forms.TextBox txtHoraFinal;
        private System.Windows.Forms.Label lblFinal;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblPrecio;
    }
}