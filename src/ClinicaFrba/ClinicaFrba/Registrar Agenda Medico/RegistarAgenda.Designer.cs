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
            this.desde = new System.Windows.Forms.DateTimePicker();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.botonListar = new System.Windows.Forms.Button();
            this.grillaProfesionales = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.grillaEspecialidades = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.inicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.fin = new System.Windows.Forms.DateTimePicker();
            this.dia = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.hasta = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grillaProfesionales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaEspecialidades)).BeginInit();
            this.SuspendLayout();
            // 
            // desde
            // 
            this.desde.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.desde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.desde.CustomFormat = "";
            this.desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.desde.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.desde.Location = new System.Drawing.Point(130, 389);
            this.desde.Margin = new System.Windows.Forms.Padding(5);
            this.desde.MaxDate = new System.DateTime(3000, 10, 26, 0, 0, 0, 0);
            this.desde.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.desde.Name = "desde";
            this.desde.RightToLeftLayout = true;
            this.desde.Size = new System.Drawing.Size(95, 20);
            this.desde.TabIndex = 14;
            this.desde.Value = new System.DateTime(2016, 10, 26, 0, 0, 0, 0);
            this.desde.ValueChanged += new System.EventHandler(this.selectorFecha_ValueChanged);
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(506, 469);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 21;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // AceptarButton
            // 
            this.AceptarButton.Location = new System.Drawing.Point(598, 469);
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
            this.grillaEspecialidades.Size = new System.Drawing.Size(557, 125);
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
            // inicio
            // 
            this.inicio.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.inicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.inicio.CustomFormat = "";
            this.inicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.inicio.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.inicio.Location = new System.Drawing.Point(233, 355);
            this.inicio.Margin = new System.Windows.Forms.Padding(5);
            this.inicio.MaxDate = new System.DateTime(3000, 10, 26, 0, 0, 0, 0);
            this.inicio.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.inicio.Name = "inicio";
            this.inicio.RightToLeftLayout = true;
            this.inicio.ShowUpDown = true;
            this.inicio.Size = new System.Drawing.Size(65, 20);
            this.inicio.TabIndex = 30;
            this.inicio.Value = new System.DateTime(2016, 11, 1, 10, 0, 0, 0);
            this.inicio.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(9, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Dia";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // fin
            // 
            this.fin.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.fin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fin.CustomFormat = "";
            this.fin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.fin.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.fin.Location = new System.Drawing.Point(392, 355);
            this.fin.Margin = new System.Windows.Forms.Padding(5);
            this.fin.MaxDate = new System.DateTime(3000, 10, 26, 0, 0, 0, 0);
            this.fin.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.fin.Name = "fin";
            this.fin.RightToLeftLayout = true;
            this.fin.ShowUpDown = true;
            this.fin.Size = new System.Drawing.Size(65, 20);
            this.fin.TabIndex = 32;
            this.fin.Value = new System.DateTime(2016, 11, 1, 20, 0, 0, 0);
            // 
            // dia
            // 
            this.dia.FormattingEnabled = true;
            this.dia.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes",
            "Sabado"});
            this.dia.Location = new System.Drawing.Point(50, 355);
            this.dia.Name = "dia";
            this.dia.Size = new System.Drawing.Size(106, 21);
            this.dia.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label4.Location = new System.Drawing.Point(12, 419);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Valido hasta:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // hasta
            // 
            this.hasta.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.hasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.hasta.CustomFormat = "";
            this.hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.hasta.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.hasta.Location = new System.Drawing.Point(130, 419);
            this.hasta.Margin = new System.Windows.Forms.Padding(5);
            this.hasta.MaxDate = new System.DateTime(3000, 10, 26, 0, 0, 0, 0);
            this.hasta.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.hasta.Name = "hasta";
            this.hasta.RightToLeftLayout = true;
            this.hasta.Size = new System.Drawing.Size(95, 20);
            this.hasta.TabIndex = 35;
            this.hasta.Value = new System.DateTime(2017, 5, 20, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label5.Location = new System.Drawing.Point(12, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "Valido desde:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label6.Location = new System.Drawing.Point(167, 355);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 37;
            this.label6.Text = "Desde";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label7.Location = new System.Drawing.Point(330, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.TabIndex = 38;
            this.label7.Text = "Hasta";
            // 
            // RegistarAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 504);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.hasta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dia);
            this.Controls.Add(this.fin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inicio);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grillaEspecialidades);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grillaProfesionales);
            this.Controls.Add(this.botonListar);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.desde);
            this.Name = "RegistarAgenda";
            this.Text = "Alta Agenda Profesional";
            this.Load += new System.EventHandler(this.RegistarAgenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaProfesionales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaEspecialidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.DateTimePicker desde;
        protected System.Windows.Forms.Button botonCancelar;
        protected System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.Button botonListar;
        private System.Windows.Forms.DataGridView grillaProfesionales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grillaEspecialidades;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        protected System.Windows.Forms.DateTimePicker inicio;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.DateTimePicker fin;
        protected System.Windows.Forms.ComboBox dia;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.DateTimePicker hasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}