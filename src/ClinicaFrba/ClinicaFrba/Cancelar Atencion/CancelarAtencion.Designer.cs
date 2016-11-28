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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.selecPlan = new System.Windows.Forms.ComboBox();
            this.botonSalir = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grillaProfesionales)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 49;
            this.label2.Text = "Turnos";
            this.label2.Click += new System.EventHandler(this.label2_Click);
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
            this.grillaProfesionales.Size = new System.Drawing.Size(627, 149);
            this.grillaProfesionales.TabIndex = 45;
            this.grillaProfesionales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaProfesionales_CellContentClick);
            // 
            // botonListar
            // 
            this.botonListar.Location = new System.Drawing.Point(645, 32);
            this.botonListar.Name = "botonListar";
            this.botonListar.Size = new System.Drawing.Size(88, 71);
            this.botonListar.TabIndex = 44;
            this.botonListar.Text = "Listar ateciones medicas";
            this.botonListar.UseVisualStyleBackColor = true;
            this.botonListar.Click += new System.EventHandler(this.botonListar_Click);
            // 
            // botonAtras
            // 
            this.botonAtras.Location = new System.Drawing.Point(12, 446);
            this.botonAtras.Name = "botonAtras";
            this.botonAtras.Size = new System.Drawing.Size(70, 23);
            this.botonAtras.TabIndex = 50;
            this.botonAtras.Text = "<- Atrás";
            this.botonAtras.UseVisualStyleBackColor = true;
            this.botonAtras.Click += new System.EventHandler(this.botonAtras_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(298, 225);
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
            this.label1.Location = new System.Drawing.Point(12, 112);
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
            this.desde.Location = new System.Drawing.Point(143, 112);
            this.desde.Margin = new System.Windows.Forms.Padding(5);
            this.desde.MaxDate = new System.DateTime(3000, 10, 26, 0, 0, 0, 0);
            this.desde.Name = "desde";
            this.desde.RightToLeftLayout = true;
            this.desde.Size = new System.Drawing.Size(95, 20);
            this.desde.TabIndex = 54;
            this.desde.ValueChanged += new System.EventHandler(this.desde_ValueChanged);
            // 
            // from
            // 
            this.from.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.from.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.from.CustomFormat = "";
            this.from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.from.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.from.Location = new System.Drawing.Point(239, 144);
            this.from.Margin = new System.Windows.Forms.Padding(5);
            this.from.MaxDate = new System.DateTime(3000, 10, 26, 0, 0, 0, 0);
            this.from.Name = "from";
            this.from.RightToLeftLayout = true;
            this.from.Size = new System.Drawing.Size(95, 20);
            this.from.TabIndex = 55;
            this.from.ValueChanged += new System.EventHandler(this.from_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(12, 144);
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
            this.to.Location = new System.Drawing.Point(405, 144);
            this.to.Margin = new System.Windows.Forms.Padding(5);
            this.to.MaxDate = new System.DateTime(3000, 10, 26, 0, 0, 0, 0);
            this.to.Name = "to";
            this.to.RightToLeftLayout = true;
            this.to.Size = new System.Drawing.Size(95, 20);
            this.to.TabIndex = 57;
            this.to.ValueChanged += new System.EventHandler(this.to_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label4.Location = new System.Drawing.Point(172, 144);
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
            this.label5.Location = new System.Drawing.Point(342, 144);
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
            this.selecDia.Location = new System.Drawing.Point(18, 58);
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
            this.selecPeriodo.Location = new System.Drawing.Point(18, 86);
            this.selecPeriodo.Name = "selecPeriodo";
            this.selecPeriodo.Size = new System.Drawing.Size(61, 17);
            this.selecPeriodo.TabIndex = 61;
            this.selecPeriodo.Text = "Periodo";
            this.selecPeriodo.UseVisualStyleBackColor = true;
            this.selecPeriodo.CheckedChanged += new System.EventHandler(this.selecPeriodo_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 187);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(686, 20);
            this.textBox1.TabIndex = 62;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label6.Location = new System.Drawing.Point(11, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 63;
            this.label6.Text = "Motivo:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label7.Location = new System.Drawing.Point(11, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 20);
            this.label7.TabIndex = 64;
            this.label7.Text = "Tipo:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // selecPlan
            // 
            this.selecPlan.FormattingEnabled = true;
            this.selecPlan.Items.AddRange(new object[] {
            "Viaje",
            "Enfermedad",
            "Asuntos familiares",
            "Otra causa"});
            this.selecPlan.Location = new System.Drawing.Point(63, 217);
            this.selecPlan.Name = "selecPlan";
            this.selecPlan.Size = new System.Drawing.Size(124, 21);
            this.selecPlan.TabIndex = 65;
            this.selecPlan.Text = "Seleccione tipo";
            this.selecPlan.SelectedIndexChanged += new System.EventHandler(this.selecPlan_SelectedIndexChanged);
            // 
            // botonSalir
            // 
            this.botonSalir.Location = new System.Drawing.Point(710, 263);
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.Size = new System.Drawing.Size(75, 23);
            this.botonSalir.TabIndex = 66;
            this.botonSalir.Text = "Salir";
            this.botonSalir.UseVisualStyleBackColor = true;
            this.botonSalir.Click += new System.EventHandler(this.botonSalir_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label8.Location = new System.Drawing.Point(14, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(177, 20);
            this.label8.TabIndex = 67;
            this.label8.Text = "Cancelar dia o periodo";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // CancelarAtencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 295);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.botonSalir);
            this.Controls.Add(this.selecPlan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
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
        private TextBox textBox1;
        private Label label6;
        private Label label7;
        protected ComboBox selecPlan;
        private Button botonSalir;
        private Label label8;
    }
}