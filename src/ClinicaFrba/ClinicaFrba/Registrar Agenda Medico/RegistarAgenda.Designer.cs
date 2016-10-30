namespace ClinicaFrba.Registrar_Agenda_Medico
{
    partial class RegistarAgenda
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
            this.selectorFecha = new System.Windows.Forms.DateTimePicker();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectorFecha
            // 
            this.selectorFecha.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.selectorFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectorFecha.Checked = false;
            this.selectorFecha.CustomFormat = "";
            this.selectorFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.selectorFecha.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.selectorFecha.Location = new System.Drawing.Point(140, 94);
            this.selectorFecha.Margin = new System.Windows.Forms.Padding(5);
            this.selectorFecha.MaxDate = new System.DateTime(2016, 10, 26, 0, 0, 0, 0);
            this.selectorFecha.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.selectorFecha.Name = "selectorFecha";
            this.selectorFecha.RightToLeftLayout = true;
            this.selectorFecha.Size = new System.Drawing.Size(130, 20);
            this.selectorFecha.TabIndex = 14;
            this.selectorFecha.Value = new System.DateTime(2016, 10, 26, 0, 0, 0, 0);
            this.selectorFecha.ValueChanged += new System.EventHandler(this.selectorFecha_ValueChanged);
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(12, 227);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 21;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // AceptarButton
            // 
            this.AceptarButton.Location = new System.Drawing.Point(197, 227);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 22;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // RegistarAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.selectorFecha);
            this.Name = "RegistarAgenda";
            this.Text = "Alta Agenda Profesional";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.DateTimePicker selectorFecha;
        protected System.Windows.Forms.Button botonCancelar;
        protected System.Windows.Forms.Button AceptarButton;
    }
}