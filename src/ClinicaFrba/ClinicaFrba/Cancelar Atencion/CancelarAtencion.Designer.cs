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
            this.botonCancelar = new System.Windows.Forms.Button();
            this.botonAtras = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.desde = new System.Windows.Forms.DateTimePicker();
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
            this.grillaProfesionales.Size = new System.Drawing.Size(588, 189);
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
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(21, 119);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 48;
            // 
            // botonAtras
            // 
            this.botonAtras.Location = new System.Drawing.Point(12, 368);
            this.botonAtras.Name = "botonAtras";
            this.botonAtras.Size = new System.Drawing.Size(70, 23);
            this.botonAtras.TabIndex = 50;
            this.botonAtras.Text = "<- Atrás";
            this.botonAtras.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(224, 308);
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
            this.label1.Location = new System.Drawing.Point(17, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "Dia a cancelar:";
            // 
            // desde
            // 
            this.desde.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.desde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.desde.CustomFormat = "";
            this.desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.desde.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.desde.Location = new System.Drawing.Point(148, 243);
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
            // CancelarAtencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 403);
            this.Controls.Add(this.desde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.botonAtras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grillaProfesionales);
            this.Controls.Add(this.botonListar);
            this.Controls.Add(this.botonCancelar);
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
        protected System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Button botonAtras;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.DateTimePicker desde;
    }
}