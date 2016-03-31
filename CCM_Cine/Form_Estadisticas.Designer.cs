namespace CCM_Cine
{
    partial class Form_Estadisticas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Estadisticas));
            this.lblPelicula = new System.Windows.Forms.Label();
            this.txtPelicula = new System.Windows.Forms.TextBox();
            this.txtSala = new System.Windows.Forms.TextBox();
            this.lblSala = new System.Windows.Forms.Label();
            this.txtPersona = new System.Windows.Forms.TextBox();
            this.lblPersona = new System.Windows.Forms.Label();
            this.btn = new System.Windows.Forms.Button();
            this.lblVeces = new System.Windows.Forms.Label();
            this.txtVeces3 = new System.Windows.Forms.TextBox();
            this.txtVeces2 = new System.Windows.Forms.TextBox();
            this.txtVeces1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblPelicula
            // 
            this.lblPelicula.AutoSize = true;
            this.lblPelicula.Location = new System.Drawing.Point(12, 43);
            this.lblPelicula.Name = "lblPelicula";
            this.lblPelicula.Size = new System.Drawing.Size(91, 13);
            this.lblPelicula.TabIndex = 0;
            this.lblPelicula.Text = "Pelicula mas vista";
            // 
            // txtPelicula
            // 
            this.txtPelicula.Location = new System.Drawing.Point(134, 40);
            this.txtPelicula.Name = "txtPelicula";
            this.txtPelicula.ReadOnly = true;
            this.txtPelicula.Size = new System.Drawing.Size(128, 20);
            this.txtPelicula.TabIndex = 1;
            // 
            // txtSala
            // 
            this.txtSala.Location = new System.Drawing.Point(134, 74);
            this.txtSala.Name = "txtSala";
            this.txtSala.ReadOnly = true;
            this.txtSala.Size = new System.Drawing.Size(128, 20);
            this.txtSala.TabIndex = 3;
            // 
            // lblSala
            // 
            this.lblSala.AutoSize = true;
            this.lblSala.Location = new System.Drawing.Point(12, 77);
            this.lblSala.Name = "lblSala";
            this.lblSala.Size = new System.Drawing.Size(89, 13);
            this.lblSala.TabIndex = 2;
            this.lblSala.Text = "Sala mas visitada";
            // 
            // txtPersona
            // 
            this.txtPersona.Location = new System.Drawing.Point(134, 112);
            this.txtPersona.Name = "txtPersona";
            this.txtPersona.ReadOnly = true;
            this.txtPersona.Size = new System.Drawing.Size(128, 20);
            this.txtPersona.TabIndex = 5;
            // 
            // lblPersona
            // 
            this.lblPersona.AutoSize = true;
            this.lblPersona.Location = new System.Drawing.Point(12, 115);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(116, 13);
            this.lblPersona.TabIndex = 4;
            this.lblPersona.Text = "Persona que visita mas";
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(127, 153);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(75, 23);
            this.btn.TabIndex = 6;
            this.btn.Text = "Cerrar";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // lblVeces
            // 
            this.lblVeces.AutoSize = true;
            this.lblVeces.Location = new System.Drawing.Point(276, 13);
            this.lblVeces.Name = "lblVeces";
            this.lblVeces.Size = new System.Drawing.Size(37, 13);
            this.lblVeces.TabIndex = 7;
            this.lblVeces.Text = "Veces";
            // 
            // txtVeces3
            // 
            this.txtVeces3.Location = new System.Drawing.Point(272, 112);
            this.txtVeces3.Name = "txtVeces3";
            this.txtVeces3.ReadOnly = true;
            this.txtVeces3.Size = new System.Drawing.Size(46, 20);
            this.txtVeces3.TabIndex = 10;
            // 
            // txtVeces2
            // 
            this.txtVeces2.Location = new System.Drawing.Point(272, 74);
            this.txtVeces2.Name = "txtVeces2";
            this.txtVeces2.ReadOnly = true;
            this.txtVeces2.Size = new System.Drawing.Size(46, 20);
            this.txtVeces2.TabIndex = 9;
            // 
            // txtVeces1
            // 
            this.txtVeces1.Location = new System.Drawing.Point(272, 40);
            this.txtVeces1.Name = "txtVeces1";
            this.txtVeces1.ReadOnly = true;
            this.txtVeces1.Size = new System.Drawing.Size(46, 20);
            this.txtVeces1.TabIndex = 8;
            // 
            // Form_Estadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 188);
            this.Controls.Add(this.txtVeces3);
            this.Controls.Add(this.txtVeces2);
            this.Controls.Add(this.txtVeces1);
            this.Controls.Add(this.lblVeces);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.txtPersona);
            this.Controls.Add(this.lblPersona);
            this.Controls.Add(this.txtSala);
            this.Controls.Add(this.lblSala);
            this.Controls.Add(this.txtPelicula);
            this.Controls.Add(this.lblPelicula);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Estadisticas";
            this.Text = "Estadisticas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPelicula;
        private System.Windows.Forms.TextBox txtPelicula;
        private System.Windows.Forms.TextBox txtSala;
        private System.Windows.Forms.Label lblSala;
        private System.Windows.Forms.TextBox txtPersona;
        private System.Windows.Forms.Label lblPersona;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Label lblVeces;
        private System.Windows.Forms.TextBox txtVeces3;
        private System.Windows.Forms.TextBox txtVeces2;
        private System.Windows.Forms.TextBox txtVeces1;
    }
}