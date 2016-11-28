using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using ClinicaFrba.Abm_Afiliado;
using System.Configuration;


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
            this.botonListar = new System.Windows.Forms.Button();
            this.grillaProfesionales = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.inicio = new System.Windows.Forms.DateTimePicker();
            this.fin = new System.Windows.Forms.DateTimePicker();
            this.dia = new System.Windows.Forms.ComboBox();
            this.hasta = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.botonSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grillaProfesionales)).BeginInit();
            this.SuspendLayout();
            // 
            // desde
            // 
            this.desde.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.desde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.desde.CustomFormat = "";
            this.desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.desde.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.desde.Location = new System.Drawing.Point(129, 252);
            this.desde.Margin = new System.Windows.Forms.Padding(5);
            this.desde.MaxDate = new System.DateTime(3000, 10, 26, 0, 0, 0, 0);
            this.desde.MinDate = System.DateTime.ParseExact(ConfigurationManager.AppSettings["fecha"].ToString().Substring(0, "yyyy-MM-dd".Length), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            this.desde.Name = "desde";
            this.desde.RightToLeftLayout = true;
            this.desde.Size = new System.Drawing.Size(95, 20);
            this.desde.TabIndex = 14;
            this.desde.Value = System.DateTime.ParseExact(ConfigurationManager.AppSettings["fecha"].ToString().Substring(0, "yyyy-MM-dd".Length), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            this.desde.ValueChanged += new System.EventHandler(this.selectorFecha_ValueChanged);
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(0, 0);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 42;
            // 
            // botonListar
            // 
            this.botonListar.Location = new System.Drawing.Point(585, 52);
            this.botonListar.Name = "botonListar";
            this.botonListar.Size = new System.Drawing.Size(88, 71);
            this.botonListar.TabIndex = 24;
            this.botonListar.Text = "Listar Profesionales con especialidades";
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
            this.grillaProfesionales.Location = new System.Drawing.Point(15, 42);
            this.grillaProfesionales.Name = "grillaProfesionales";
            this.grillaProfesionales.ShowEditingIcon = false;
            this.grillaProfesionales.Size = new System.Drawing.Size(557, 131);
            this.grillaProfesionales.TabIndex = 25;
            this.grillaProfesionales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaProfesionales_CellContentClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 41;
            // 
            // inicio
            // 
            this.inicio.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.inicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.inicio.CustomFormat = "HH:mm";
            this.inicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inicio.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.inicio.Location = new System.Drawing.Point(249, 216);
            this.inicio.Margin = new System.Windows.Forms.Padding(5);
            this.inicio.MaxDate = new System.DateTime(3000, 10, 26, 0, 0, 0, 0);
            this.inicio.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.inicio.Name = "inicio";
            this.inicio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.inicio.RightToLeftLayout = true;
            this.inicio.ShowUpDown = true;
            this.inicio.Size = new System.Drawing.Size(65, 20);
            this.inicio.TabIndex = 30;
            this.inicio.Value = new System.DateTime(2016, 11, 1, 10, 0, 0, 0);
            this.inicio.ValueChanged += new System.EventHandler(this.inicio_ValueChanged);
            // 
            // fin
            // 
            this.fin.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.fin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fin.CustomFormat = "HH:mm";
            this.fin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fin.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.fin.Location = new System.Drawing.Point(391, 218);
            this.fin.Margin = new System.Windows.Forms.Padding(5);
            this.fin.MaxDate = new System.DateTime(3000, 10, 26, 0, 0, 0, 0);
            this.fin.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.fin.Name = "fin";
            this.fin.RightToLeftLayout = true;
            this.fin.ShowUpDown = true;
            this.fin.Size = new System.Drawing.Size(65, 20);
            this.fin.TabIndex = 32;
            this.fin.Value = new System.DateTime(2016, 11, 1, 20, 0, 0, 0);
            this.fin.ValueChanged += new System.EventHandler(this.fin_ValueChanged);
            // 
            // dia
            // 
            this.dia.AutoCompleteCustomSource.AddRange(new string[] {
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes",
            "Sabado"});
            this.dia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.dia.Cursor = System.Windows.Forms.Cursors.Default;
            this.dia.FormattingEnabled = true;
            this.dia.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes",
            "Sabado"});
            this.dia.Location = new System.Drawing.Point(54, 218);
            this.dia.Name = "dia";
            this.dia.Size = new System.Drawing.Size(106, 21);
            this.dia.TabIndex = 33;
            this.dia.SelectedIndexChanged += new System.EventHandler(this.dia_SelectedIndexChanged);
            // 
            // hasta
            // 
            this.hasta.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.hasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.hasta.CustomFormat = "";
            this.hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.hasta.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.hasta.Location = new System.Drawing.Point(129, 282);
            this.hasta.Margin = new System.Windows.Forms.Padding(5);
            this.hasta.MaxDate = new System.DateTime(3000, 10, 26, 0, 0, 0, 0);
            this.hasta.MinDate = System.DateTime.ParseExact(ConfigurationManager.AppSettings["fecha"].ToString().Substring(0, "yyyy-MM-dd".Length), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            this.hasta.Name = "hasta";
            this.hasta.RightToLeftLayout = true;
            this.hasta.Size = new System.Drawing.Size(95, 20);
            this.hasta.TabIndex = 35;
            this.hasta.Value = System.DateTime.ParseExact(ConfigurationManager.AppSettings["fecha"].ToString().Substring(0, "yyyy-MM-dd".Length), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            this.hasta.ValueChanged += new System.EventHandler(this.hasta_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label5.Location = new System.Drawing.Point(11, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "Valido desde:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label6.Location = new System.Drawing.Point(183, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 37;
            this.label6.Text = "Desde";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label7.Location = new System.Drawing.Point(329, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.TabIndex = 38;
            this.label7.Text = "Hasta";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(232, 322);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(224, 47);
            this.button2.TabIndex = 39;
            this.button2.Text = "Agregar Horario";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "Seleccion de profesional y especialidad";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(11, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 44;
            this.label3.Text = "Dia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label4.Location = new System.Drawing.Point(12, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 46;
            this.label4.Text = "Valido hasta:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // botonSalir
            // 
            this.botonSalir.Location = new System.Drawing.Point(598, 386);
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.Size = new System.Drawing.Size(75, 23);
            this.botonSalir.TabIndex = 47;
            this.botonSalir.Text = "Salir";
            this.botonSalir.UseVisualStyleBackColor = true;
            this.botonSalir.Click += new System.EventHandler(this.botonSalir_Click);
            // 
            // RegistarAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 421);
            this.Controls.Add(this.botonSalir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.hasta);
            this.Controls.Add(this.dia);
            this.Controls.Add(this.fin);
            this.Controls.Add(this.inicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grillaProfesionales);
            this.Controls.Add(this.botonListar);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.desde);
            this.Name = "RegistarAgenda";
            this.Text = "Alta Agenda Profesional";
            this.Load += new System.EventHandler(this.RegistarAgenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaProfesionales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.DateTimePicker desde;
        protected System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Button botonListar;
        private System.Windows.Forms.DataGridView grillaProfesionales;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.DateTimePicker inicio;
        protected System.Windows.Forms.DateTimePicker fin;
        protected System.Windows.Forms.ComboBox dia;
        protected System.Windows.Forms.DateTimePicker hasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Button botonSalir;
    }
}