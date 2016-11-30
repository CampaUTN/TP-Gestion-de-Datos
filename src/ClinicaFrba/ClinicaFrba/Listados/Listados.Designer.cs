namespace ClinicaFrba.Listados
{
    partial class Listados
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
            this.dateTimePickerAnio = new System.Windows.Forms.DateTimePicker();
            this.buttonConsultar = new System.Windows.Forms.Button();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewListado2 = new System.Windows.Forms.DataGridView();
            this.comboBoxListado2Filtro = new System.Windows.Forms.ComboBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.dataGridViewListado5 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.dataGridViewListado4 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewListado3 = new System.Windows.Forms.DataGridView();
            this.comboBoxListado3Filtro = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxListado1Filtro = new System.Windows.Forms.ComboBox();
            this.dataGridViewListado1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.dateTimePickerMesDesde = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerMesHasta = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxSemestre = new System.Windows.Forms.ComboBox();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListado2)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListado5)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListado4)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListado3)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListado1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePickerAnio
            // 
            this.dateTimePickerAnio.Location = new System.Drawing.Point(59, 18);
            this.dateTimePickerAnio.Name = "dateTimePickerAnio";
            this.dateTimePickerAnio.Size = new System.Drawing.Size(94, 20);
            this.dateTimePickerAnio.TabIndex = 1;
            this.dateTimePickerAnio.Value = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            // 
            // buttonConsultar
            // 
            this.buttonConsultar.Location = new System.Drawing.Point(353, 46);
            this.buttonConsultar.Name = "buttonConsultar";
            this.buttonConsultar.Size = new System.Drawing.Size(75, 23);
            this.buttonConsultar.TabIndex = 3;
            this.buttonConsultar.Text = "Actualizar";
            this.buttonConsultar.UseVisualStyleBackColor = true;
            this.buttonConsultar.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonVolver
            // 
            this.buttonVolver.Location = new System.Drawing.Point(12, 484);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(75, 23);
            this.buttonVolver.TabIndex = 5;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Año:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.dataGridViewListado2);
            this.tabPage2.Controls.Add(this.comboBoxListado2Filtro);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(420, 371);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Listado 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(10, 8);
            this.textBox2.Margin = new System.Windows.Forms.Padding(5);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(402, 37);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "Top 5 de los profesionales más consultados por Plan, detallando también bajo\r\nque" +
    " Especialidad.\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Plan:";
            // 
            // dataGridViewListado2
            // 
            this.dataGridViewListado2.AllowUserToAddRows = false;
            this.dataGridViewListado2.AllowUserToDeleteRows = false;
            this.dataGridViewListado2.AllowUserToResizeColumns = false;
            this.dataGridViewListado2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewListado2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListado2.Location = new System.Drawing.Point(6, 106);
            this.dataGridViewListado2.Name = "dataGridViewListado2";
            this.dataGridViewListado2.Size = new System.Drawing.Size(406, 259);
            this.dataGridViewListado2.TabIndex = 6;
            // 
            // comboBoxListado2Filtro
            // 
            this.comboBoxListado2Filtro.FormattingEnabled = true;
            this.comboBoxListado2Filtro.Location = new System.Drawing.Point(45, 66);
            this.comboBoxListado2Filtro.Name = "comboBoxListado2Filtro";
            this.comboBoxListado2Filtro.Size = new System.Drawing.Size(172, 21);
            this.comboBoxListado2Filtro.TabIndex = 7;
            this.comboBoxListado2Filtro.SelectedIndexChanged += new System.EventHandler(this.comboBoxListado2Filtro_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.textBox5);
            this.tabPage5.Controls.Add(this.dataGridViewListado5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(420, 371);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Listado 5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(10, 8);
            this.textBox5.Margin = new System.Windows.Forms.Padding(5);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(402, 37);
            this.textBox5.TabIndex = 7;
            this.textBox5.Text = "Top 5 de las especialidades de médicos con más bonos de consultas\r\nutilizados.";
            // 
            // dataGridViewListado5
            // 
            this.dataGridViewListado5.AllowUserToAddRows = false;
            this.dataGridViewListado5.AllowUserToDeleteRows = false;
            this.dataGridViewListado5.AllowUserToResizeColumns = false;
            this.dataGridViewListado5.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewListado5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListado5.Location = new System.Drawing.Point(6, 106);
            this.dataGridViewListado5.Name = "dataGridViewListado5";
            this.dataGridViewListado5.Size = new System.Drawing.Size(406, 259);
            this.dataGridViewListado5.TabIndex = 6;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.textBox4);
            this.tabPage4.Controls.Add(this.dataGridViewListado4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(420, 371);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Listado 4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(10, 8);
            this.textBox4.Margin = new System.Windows.Forms.Padding(5);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(402, 37);
            this.textBox4.TabIndex = 7;
            this.textBox4.Text = "Top 5 de los afiliados con mayor cantidad de bonos comprados, detallando si\r\npert" +
    "enece a un grupo familiar.";
            // 
            // dataGridViewListado4
            // 
            this.dataGridViewListado4.AllowUserToAddRows = false;
            this.dataGridViewListado4.AllowUserToDeleteRows = false;
            this.dataGridViewListado4.AllowUserToResizeColumns = false;
            this.dataGridViewListado4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewListado4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListado4.Location = new System.Drawing.Point(6, 106);
            this.dataGridViewListado4.Name = "dataGridViewListado4";
            this.dataGridViewListado4.Size = new System.Drawing.Size(406, 259);
            this.dataGridViewListado4.TabIndex = 6;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBox3);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.dataGridViewListado3);
            this.tabPage3.Controls.Add(this.comboBoxListado3Filtro);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(420, 371);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Listado 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(10, 8);
            this.textBox3.Margin = new System.Windows.Forms.Padding(5);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(402, 37);
            this.textBox3.TabIndex = 13;
            this.textBox3.Text = "Top 5 de los profesionales con menos horas trabajadas filtrando por Especialidad." +
    "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Especialidad:";
            // 
            // dataGridViewListado3
            // 
            this.dataGridViewListado3.AllowUserToAddRows = false;
            this.dataGridViewListado3.AllowUserToDeleteRows = false;
            this.dataGridViewListado3.AllowUserToResizeColumns = false;
            this.dataGridViewListado3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewListado3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListado3.Location = new System.Drawing.Point(6, 106);
            this.dataGridViewListado3.Name = "dataGridViewListado3";
            this.dataGridViewListado3.Size = new System.Drawing.Size(406, 259);
            this.dataGridViewListado3.TabIndex = 10;
            // 
            // comboBoxListado3Filtro
            // 
            this.comboBoxListado3Filtro.FormattingEnabled = true;
            this.comboBoxListado3Filtro.Location = new System.Drawing.Point(83, 66);
            this.comboBoxListado3Filtro.Name = "comboBoxListado3Filtro";
            this.comboBoxListado3Filtro.Size = new System.Drawing.Size(172, 21);
            this.comboBoxListado3Filtro.TabIndex = 11;
            this.comboBoxListado3Filtro.SelectedIndexChanged += new System.EventHandler(this.comboBoxListado3Filtro_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.comboBoxListado1Filtro);
            this.tabPage1.Controls.Add(this.dataGridViewListado1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(420, 371);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(10, 8);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(402, 37);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Top 5 de las especialidades que más se registraron cancelaciones, tanto de afilia" +
    "dos como de profesionales.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tipo de usuario:";
            // 
            // comboBoxListado1Filtro
            // 
            this.comboBoxListado1Filtro.FormattingEnabled = true;
            this.comboBoxListado1Filtro.Items.AddRange(new object[] {
            "Afiliados",
            "Profesionales",
            "Ambos"});
            this.comboBoxListado1Filtro.Location = new System.Drawing.Point(96, 66);
            this.comboBoxListado1Filtro.Name = "comboBoxListado1Filtro";
            this.comboBoxListado1Filtro.Size = new System.Drawing.Size(172, 21);
            this.comboBoxListado1Filtro.TabIndex = 3;
            this.comboBoxListado1Filtro.SelectedIndexChanged += new System.EventHandler(this.comboBoxListado1Filtro_SelectedIndexChanged);
            // 
            // dataGridViewListado1
            // 
            this.dataGridViewListado1.AllowUserToAddRows = false;
            this.dataGridViewListado1.AllowUserToDeleteRows = false;
            this.dataGridViewListado1.AllowUserToResizeColumns = false;
            this.dataGridViewListado1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewListado1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListado1.Location = new System.Drawing.Point(6, 106);
            this.dataGridViewListado1.Name = "dataGridViewListado1";
            this.dataGridViewListado1.Size = new System.Drawing.Size(406, 259);
            this.dataGridViewListado1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 81);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(428, 397);
            this.tabControl1.TabIndex = 4;
            // 
            // dateTimePickerMesDesde
            // 
            this.dateTimePickerMesDesde.Location = new System.Drawing.Point(59, 51);
            this.dateTimePickerMesDesde.Name = "dateTimePickerMesDesde";
            this.dateTimePickerMesDesde.Size = new System.Drawing.Size(94, 20);
            this.dateTimePickerMesDesde.TabIndex = 7;
            this.dateTimePickerMesDesde.ValueChanged += new System.EventHandler(this.dateTimePickerMesDesde_ValueChanged);
            // 
            // dateTimePickerMesHasta
            // 
            this.dateTimePickerMesHasta.Location = new System.Drawing.Point(203, 51);
            this.dateTimePickerMesHasta.Name = "dateTimePickerMesHasta";
            this.dateTimePickerMesHasta.Size = new System.Drawing.Size(94, 20);
            this.dateTimePickerMesHasta.TabIndex = 8;
            this.dateTimePickerMesHasta.ValueChanged += new System.EventHandler(this.dateTimePickerMesHasta_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Desde:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(160, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Hasta:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(159, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Semestre:";
            // 
            // comboBoxSemestre
            // 
            this.comboBoxSemestre.FormattingEnabled = true;
            this.comboBoxSemestre.Items.AddRange(new object[] {
            "1º",
            "2º"});
            this.comboBoxSemestre.Location = new System.Drawing.Point(220, 17);
            this.comboBoxSemestre.Name = "comboBoxSemestre";
            this.comboBoxSemestre.Size = new System.Drawing.Size(35, 21);
            this.comboBoxSemestre.TabIndex = 12;
            this.comboBoxSemestre.SelectedIndexChanged += new System.EventHandler(this.comboBoxSemestre_SelectedIndexChanged);
            // 
            // Listados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 513);
            this.Controls.Add(this.comboBoxSemestre);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerMesHasta);
            this.Controls.Add(this.dateTimePickerMesDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonConsultar);
            this.Controls.Add(this.dateTimePickerAnio);
            this.Name = "Listados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Estadístico";
            this.Load += new System.EventHandler(this.Listados_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListado2)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListado5)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListado4)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListado3)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListado1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerAnio;
        private System.Windows.Forms.Button buttonConsultar;
        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewListado2;
        private System.Windows.Forms.ComboBox comboBoxListado2Filtro;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewListado3;
        private System.Windows.Forms.ComboBox comboBoxListado3Filtro;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxListado1Filtro;
        private System.Windows.Forms.DataGridView dataGridViewListado1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.DataGridView dataGridViewListado5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.DataGridView dataGridViewListado4;
        private System.Windows.Forms.DateTimePicker dateTimePickerMesDesde;
        private System.Windows.Forms.DateTimePicker dateTimePickerMesHasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxSemestre;
    }
}