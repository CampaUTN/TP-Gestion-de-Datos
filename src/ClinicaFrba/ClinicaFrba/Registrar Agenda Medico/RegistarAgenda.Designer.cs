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
            this.botonListar = new System.Windows.Forms.Button();
            this.grillaProfesionales = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.grillaEspecialidades = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grillaProfesionales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaEspecialidades)).BeginInit();
            this.SuspendLayout();
            // 
            // selectorFecha
            // 
            this.selectorFecha.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.selectorFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectorFecha.CustomFormat = "\"MM dd yyyy hh mm ss\"";
            this.selectorFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.selectorFecha.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.selectorFecha.Location = new System.Drawing.Point(12, 398);
            this.selectorFecha.Margin = new System.Windows.Forms.Padding(5);
            this.selectorFecha.MaxDate = new System.DateTime(3000, 10, 26, 0, 0, 0, 0);
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
            this.botonCancelar.Location = new System.Drawing.Point(517, 395);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 21;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // AceptarButton
            // 
            this.AceptarButton.Location = new System.Drawing.Point(598, 395);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 22;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // botonListar
            // 
            this.botonListar.Location = new System.Drawing.Point(585, 32);
            this.botonListar.Name = "botonListar";
            this.botonListar.Size = new System.Drawing.Size(88, 47);
            this.botonListar.TabIndex = 24;
            this.botonListar.Text = "Listar Profesionales";
            this.botonListar.UseVisualStyleBackColor = true;
            this.botonListar.Click += new System.EventHandler(this.botonListar_Click);
            // 
            // grillaProfesionales
            // 
            this.grillaProfesionales.AllowUserToAddRows = false;
            this.grillaProfesionales.AllowUserToDeleteRows = false;
            this.grillaProfesionales.AllowUserToResizeColumns = false;
            this.grillaProfesionales.AllowUserToResizeRows = false;
            this.grillaProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaProfesionales.Location = new System.Drawing.Point(12, 32);
            this.grillaProfesionales.Name = "grillaProfesionales";
            this.grillaProfesionales.ShowEditingIcon = false;
            this.grillaProfesionales.Size = new System.Drawing.Size(557, 131);
            this.grillaProfesionales.TabIndex = 25;
            this.grillaProfesionales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaProfesionales_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Seleccion de profesional\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // grillaEspecialidades
            // 
            this.grillaEspecialidades.AllowUserToAddRows = false;
            this.grillaEspecialidades.AllowUserToDeleteRows = false;
            this.grillaEspecialidades.AllowUserToResizeColumns = false;
            this.grillaEspecialidades.AllowUserToResizeRows = false;
            this.grillaEspecialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaEspecialidades.Location = new System.Drawing.Point(12, 211);
            this.grillaEspecialidades.Name = "grillaEspecialidades";
            this.grillaEspecialidades.ShowEditingIcon = false;
            this.grillaEspecialidades.Size = new System.Drawing.Size(557, 131);
            this.grillaEspecialidades.TabIndex = 27;
            this.grillaEspecialidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaEspecialidades_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(12, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Seleccion de especialidad";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(585, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 47);
            this.button1.TabIndex = 29;
            this.button1.Text = "Listar Especialidades";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegistarAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 430);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grillaEspecialidades);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grillaProfesionales);
            this.Controls.Add(this.botonListar);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.selectorFecha);
            this.Name = "RegistarAgenda";
            this.Text = "Alta Agenda Profesional";
            this.Load += new System.EventHandler(this.RegistarAgenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaProfesionales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaEspecialidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.DateTimePicker selectorFecha;
        protected System.Windows.Forms.Button botonCancelar;
        protected System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.Button botonListar;
        private System.Windows.Forms.DataGridView grillaProfesionales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grillaEspecialidades;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}