namespace ClinicaFrba.Abm_Afiliado
{
    partial class AbmAfiliado
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
            this.label_seleccionar_op = new System.Windows.Forms.Label();
            this.seleccionAlta = new System.Windows.Forms.RadioButton();
            this.selecBaja = new System.Windows.Forms.RadioButton();
            this.selecModif = new System.Windows.Forms.RadioButton();
            this.botonSeguir = new System.Windows.Forms.Button();
            this.botonAtras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_seleccionar_op
            // 
            this.label_seleccionar_op.AutoSize = true;
            this.label_seleccionar_op.Location = new System.Drawing.Point(13, 13);
            this.label_seleccionar_op.Name = "label_seleccionar_op";
            this.label_seleccionar_op.Size = new System.Drawing.Size(131, 13);
            this.label_seleccionar_op.TabIndex = 0;
            this.label_seleccionar_op.Text = "Seleccione una operación";
            // 
            // seleccionAlta
            // 
            this.seleccionAlta.AutoSize = true;
            this.seleccionAlta.Location = new System.Drawing.Point(16, 40);
            this.seleccionAlta.Name = "seleccionAlta";
            this.seleccionAlta.Size = new System.Drawing.Size(43, 17);
            this.seleccionAlta.TabIndex = 1;
            this.seleccionAlta.TabStop = true;
            this.seleccionAlta.Text = "Alta";
            this.seleccionAlta.UseVisualStyleBackColor = true;
            this.seleccionAlta.CheckedChanged += new System.EventHandler(this.seleccionAlta_CheckedChanged);
            // 
            // selecBaja
            // 
            this.selecBaja.AutoSize = true;
            this.selecBaja.Location = new System.Drawing.Point(16, 64);
            this.selecBaja.Name = "selecBaja";
            this.selecBaja.Size = new System.Drawing.Size(46, 17);
            this.selecBaja.TabIndex = 2;
            this.selecBaja.TabStop = true;
            this.selecBaja.Text = "Baja";
            this.selecBaja.UseVisualStyleBackColor = true;
            this.selecBaja.CheckedChanged += new System.EventHandler(this.selecBaja_CheckedChanged);
            // 
            // selecModif
            // 
            this.selecModif.AutoSize = true;
            this.selecModif.Location = new System.Drawing.Point(16, 87);
            this.selecModif.Name = "selecModif";
            this.selecModif.Size = new System.Drawing.Size(85, 17);
            this.selecModif.TabIndex = 3;
            this.selecModif.TabStop = true;
            this.selecModif.Text = "Modificación";
            this.selecModif.UseVisualStyleBackColor = true;
            this.selecModif.CheckedChanged += new System.EventHandler(this.selecModif_CheckedChanged);
            // 
            // botonSeguir
            // 
            this.botonSeguir.Location = new System.Drawing.Point(116, 136);
            this.botonSeguir.Name = "botonSeguir";
            this.botonSeguir.Size = new System.Drawing.Size(75, 23);
            this.botonSeguir.TabIndex = 4;
            this.botonSeguir.Text = "Siguiente...";
            this.botonSeguir.UseVisualStyleBackColor = true;
            this.botonSeguir.Click += new System.EventHandler(this.botonSeguir_Click);
            // 
            // botonAtras
            // 
            this.botonAtras.Location = new System.Drawing.Point(16, 136);
            this.botonAtras.Name = "botonAtras";
            this.botonAtras.Size = new System.Drawing.Size(70, 23);
            this.botonAtras.TabIndex = 5;
            this.botonAtras.Text = "<- Atrás";
            this.botonAtras.UseVisualStyleBackColor = true;
            this.botonAtras.Click += new System.EventHandler(this.botonAtras_Click);
            // 
            // AbmAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(202, 167);
            this.Controls.Add(this.botonAtras);
            this.Controls.Add(this.botonSeguir);
            this.Controls.Add(this.selecModif);
            this.Controls.Add(this.selecBaja);
            this.Controls.Add(this.seleccionAlta);
            this.Controls.Add(this.label_seleccionar_op);
            this.Name = "AbmAfiliado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM Afiliado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_seleccionar_op;
        private System.Windows.Forms.RadioButton seleccionAlta;
        private System.Windows.Forms.RadioButton selecBaja;
        private System.Windows.Forms.RadioButton selecModif;
        private System.Windows.Forms.Button botonSeguir;
        private System.Windows.Forms.Button botonAtras;
    }
}