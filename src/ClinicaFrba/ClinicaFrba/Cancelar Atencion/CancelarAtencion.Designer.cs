namespace ClinicaFrba.Cancelar_Atencion
{
    partial class CancelarAtencion
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
            this.label2 = new System.Windows.Forms.Label();
            this.grillaProfesionales = new System.Windows.Forms.DataGridView();
            this.botonListar = new System.Windows.Forms.Button();
            this.botonAtras = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.desde = new System.Windows.Forms.DateTimePicker();
            this.from = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.to = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.selecDia = new System.Windows.Forms.RadioButton();
            this.selecPeriodo = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.grillaProfesionales)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 20);
            this.label2.TabIndex = 49;
            this.label2.Text = "Seleccion de atencion";
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
            this.grillaProfesionales.Size = new System.Drawing.Size(588, 203);
            this.grillaProfesionales.TabIndex = 45;
            this.grillaProfesionales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaProfesionales_CellContentClick);
            // 
            // botonListar
            // 
            this.botonListar.Location = new System.Drawing.Point(614, 32);
            this.botonListar.Name = "botonListar";
            this.botonListar.Size = new System.Drawing.Size(88, 71);
            this.botonListar.TabIndex = 44;
            this.botonListar.Text = "Listar ateciones medicas";
            this.botonListar.UseVisualStyleBackColor = true;
            this.botonListar.Click += new System.EventHandler(this.botonListar_Click);
            // 
            // botonAtras
            // 
            this.botonAtras.Location = new System.Drawing.Point(12, 368);
            this.botonAtras.Name = "botonAtras";
            this.botonAtras.Size = new System.Drawing.Size(70, 23);
            this.botonAtras.TabIndex = 50;
            this.botonAtras.Text = "<- Atrás";
            this.botonAtras.UseVisualStyleBackColor = true;
            this.botonAtras.Click += new System.EventHandler(this.botonAtras_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(226, 304);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(224, 47);
            this.button2.TabIndex = 51;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(83, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "Dia a cancelar:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // desde
            // 
            this.desde.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.desde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.desde.CustomFormat = "";
            this.desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.desde.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.desde.Location = new System.Drawing.Point(214, 247);
            this.desde.Margin = new System.Windows.Forms.Padding(5);
            this.desde.MaxDate = new System.DateTime(3000, 10, 26, 0, 0, 0, 0);
            this.desde.MinDate = new System.DateTime(2010, 10, 26, 0, 0, 0, 0);
            this.desde.Name = "desde";
            this.desde.RightToLeftLayout = true;
            this.desde.Size = new System.Drawing.Size(95, 20);
            this.desde.TabIndex = 54;
            this.desde.Value = new System.DateTime(2016, 10, 26, 0, 0, 0, 0);
            this.desde.ValueChanged += new System.EventHandler(this.desde_ValueChanged);
            // 
            // from
            // 
            this.from.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.from.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.from.CustomFormat = "";
            this.from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.from.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.from.Location = new System.Drawing.Point(310, 274);
            this.from.Margin = new System.Windows.Forms.Padding(5);
            this.from.MaxDate = new System.DateTime(3000, 10, 26, 0, 0, 0, 0);
            this.from.MinDate = new System.DateTime(2010, 10, 26, 0, 0, 0, 0);
            this.from.Name = "from";
            this.from.RightToLeftLayout = true;
            this.from.Size = new System.Drawing.Size(95, 20);
            this.from.TabIndex = 55;
            this.from.Value = new System.DateTime(2016, 10, 26, 0, 0, 0, 0);
            this.from.ValueChanged += new System.EventHandler(this.from_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(83, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 20);
            this.label3.TabIndex = 56;
            this.label3.Text = "Periodo a cancelar:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // to
            // 
            this.to.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.to.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.to.CustomFormat = "";
            this.to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.to.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.to.Location = new System.Drawing.Point(485, 274);
            this.to.Margin = new System.Windows.Forms.Padding(5);
            this.to.MaxDate = new System.DateTime(3000, 10, 26, 0, 0, 0, 0);
            this.to.MinDate = new System.DateTime(2010, 10, 26, 0, 0, 0, 0);
            this.to.Name = "to";
            this.to.RightToLeftLayout = true;
            this.to.Size = new System.Drawing.Size(95, 20);
            this.to.TabIndex = 57;
            this.to.Value = new System.DateTime(2016, 10, 26, 0, 0, 0, 0);
            this.to.ValueChanged += new System.EventHandler(this.to_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label4.Location = new System.Drawing.Point(243, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 58;
            this.label4.Text = "desde:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label5.Location = new System.Drawing.Point(422, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 59;
            this.label5.Text = "hasta:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // selecDia
            // 
            this.selecDia.AutoSize = true;
            this.selecDia.Checked = true;
            this.selecDia.Location = new System.Drawing.Point(16, 250);
            this.selecDia.Name = "selecDia";
            this.selecDia.Size = new System.Drawing.Size(41, 17);
            this.selecDia.TabIndex = 60;
            this.selecDia.TabStop = true;
            this.selecDia.Text = "Dia";
            this.selecDia.UseVisualStyleBackColor = true;
            this.selecDia.CheckedChanged += new System.EventHandler(this.selecDia_CheckedChanged);
            // 
            // selecPeriodo
            // 
            this.selecPeriodo.AutoSize = true;
            this.selecPeriodo.Location = new System.Drawing.Point(16, 278);
            this.selecPeriodo.Name = "selecPeriodo";
            this.selecPeriodo.Size = new System.Drawing.Size(61, 17);
            this.selecPeriodo.TabIndex = 61;
            this.selecPeriodo.Text = "Periodo";
            this.selecPeriodo.UseVisualStyleBackColor = true;
            this.selecPeriodo.CheckedChanged += new System.EventHandler(this.selecPeriodo_CheckedChanged);
            // 
            // CancelarAtencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 403);
            this.Controls.Add(this.selecPeriodo);
            this.Controls.Add(this.selecDia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.to);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.from);
            this.Controls.Add(this.desde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.botonAtras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grillaProfesionales);
            this.Controls.Add(this.botonListar);
            this.Name = "CancelarAtencion";
            this.Text = "Cancelacion Atencion";
            this.Load += new System.EventHandler(this.CancelarAtencion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaProfesionales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grillaProfesionales;
        private System.Windows.Forms.Button botonListar;
        private System.Windows.Forms.Button botonAtras;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.DateTimePicker desde;
        protected System.Windows.Forms.DateTimePicker from;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.DateTimePicker to;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton selecDia;
        private System.Windows.Forms.RadioButton selecPeriodo;
    }
}