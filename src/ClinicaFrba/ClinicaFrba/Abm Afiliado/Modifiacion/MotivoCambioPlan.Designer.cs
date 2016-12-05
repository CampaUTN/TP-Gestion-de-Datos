namespace ClinicaFrba.Abm_Afiliado.Modifiacion
{
    partial class MotivoCambioPlan
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
            this.motivo = new System.Windows.Forms.RichTextBox();
            this.labelMotivo = new System.Windows.Forms.Label();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.botonAtras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // motivo
            // 
            this.motivo.Location = new System.Drawing.Point(21, 33);
            this.motivo.MaxLength = 255;
            this.motivo.Name = "motivo";
            this.motivo.Size = new System.Drawing.Size(318, 120);
            this.motivo.TabIndex = 0;
            this.motivo.Text = "";
            // 
            // labelMotivo
            // 
            this.labelMotivo.AutoSize = true;
            this.labelMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMotivo.Location = new System.Drawing.Point(21, 13);
            this.labelMotivo.Name = "labelMotivo";
            this.labelMotivo.Size = new System.Drawing.Size(237, 17);
            this.labelMotivo.TabIndex = 1;
            this.labelMotivo.Text = "Indique el motivo del cambio de plan";
            // 
            // botonAceptar
            // 
            this.botonAceptar.Location = new System.Drawing.Point(264, 159);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(75, 23);
            this.botonAceptar.TabIndex = 2;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // botonAtras
            // 
            this.botonAtras.CausesValidation = false;
            this.botonAtras.Location = new System.Drawing.Point(21, 159);
            this.botonAtras.Name = "botonAtras";
            this.botonAtras.Size = new System.Drawing.Size(75, 23);
            this.botonAtras.TabIndex = 3;
            this.botonAtras.Text = "Limpiar";
            this.botonAtras.UseVisualStyleBackColor = true;
            this.botonAtras.Click += new System.EventHandler(this.botonAtras_Click);
            // 
            // MotivoCambioPlan
            // 
            this.AcceptButton = this.botonAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(361, 199);
            this.Controls.Add(this.botonAtras);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.labelMotivo);
            this.Controls.Add(this.motivo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MotivoCambioPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Motivo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox motivo;
        private System.Windows.Forms.Label labelMotivo;
        private System.Windows.Forms.Button botonAceptar;
        public System.Windows.Forms.Button botonAtras;
    }
}