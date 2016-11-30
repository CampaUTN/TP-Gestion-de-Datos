namespace ClinicaFrba.Registro_Resultado
{
    partial class RegistroResultado
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
            this.listadoConsultas = new System.Windows.Forms.DataGridView();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.checkBoxFueConcretada = new System.Windows.Forms.CheckBox();
            this.textBoxSintomas = new System.Windows.Forms.TextBox();
            this.textBoxDiagnostico = new System.Windows.Forms.RichTextBox();
            this.labelSelecConsulta = new System.Windows.Forms.Label();
            this.labelDiagnostico = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.botonLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listadoConsultas)).BeginInit();
            this.SuspendLayout();
            // 
            // listadoConsultas
            // 
            this.listadoConsultas.AllowUserToAddRows = false;
            this.listadoConsultas.AllowUserToDeleteRows = false;
            this.listadoConsultas.AllowUserToResizeColumns = false;
            this.listadoConsultas.AllowUserToResizeRows = false;
            this.listadoConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listadoConsultas.EnableHeadersVisualStyles = false;
            this.listadoConsultas.Location = new System.Drawing.Point(24, 25);
            this.listadoConsultas.MultiSelect = false;
            this.listadoConsultas.Name = "listadoConsultas";
            this.listadoConsultas.ReadOnly = true;
            this.listadoConsultas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listadoConsultas.Size = new System.Drawing.Size(393, 319);
            this.listadoConsultas.TabIndex = 0;
            this.listadoConsultas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listadoConsultas_CellClick);
            this.listadoConsultas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listadoConsultas_CellContentClick);
            // 
            // botonAceptar
            // 
            this.botonAceptar.Enabled = false;
            this.botonAceptar.Location = new System.Drawing.Point(342, 586);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(75, 23);
            this.botonAceptar.TabIndex = 1;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCancelar.Location = new System.Drawing.Point(24, 586);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 2;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // checkBoxFueConcretada
            // 
            this.checkBoxFueConcretada.AutoSize = true;
            this.checkBoxFueConcretada.Enabled = false;
            this.checkBoxFueConcretada.Location = new System.Drawing.Point(310, 350);
            this.checkBoxFueConcretada.Name = "checkBoxFueConcretada";
            this.checkBoxFueConcretada.Size = new System.Drawing.Size(107, 17);
            this.checkBoxFueConcretada.TabIndex = 3;
            this.checkBoxFueConcretada.Text = "Fue concretada?";
            this.checkBoxFueConcretada.UseVisualStyleBackColor = true;
            // 
            // textBoxSintomas
            // 
            this.textBoxSintomas.Enabled = false;
            this.textBoxSintomas.Location = new System.Drawing.Point(24, 371);
            this.textBoxSintomas.MaxLength = 256;
            this.textBoxSintomas.Name = "textBoxSintomas";
            this.textBoxSintomas.Size = new System.Drawing.Size(393, 20);
            this.textBoxSintomas.TabIndex = 4;
            // 
            // textBoxDiagnostico
            // 
            this.textBoxDiagnostico.Enabled = false;
            this.textBoxDiagnostico.Location = new System.Drawing.Point(24, 422);
            this.textBoxDiagnostico.MaxLength = 512;
            this.textBoxDiagnostico.Name = "textBoxDiagnostico";
            this.textBoxDiagnostico.Size = new System.Drawing.Size(393, 158);
            this.textBoxDiagnostico.TabIndex = 5;
            this.textBoxDiagnostico.Text = "";
            this.textBoxDiagnostico.TextChanged += new System.EventHandler(this.textBoxDiagnostico_TextChanged);
            // 
            // labelSelecConsulta
            // 
            this.labelSelecConsulta.AutoSize = true;
            this.labelSelecConsulta.Location = new System.Drawing.Point(21, 9);
            this.labelSelecConsulta.Name = "labelSelecConsulta";
            this.labelSelecConsulta.Size = new System.Drawing.Size(124, 13);
            this.labelSelecConsulta.TabIndex = 6;
            this.labelSelecConsulta.Text = "Seleccione una consulta";
            // 
            // labelDiagnostico
            // 
            this.labelDiagnostico.AutoSize = true;
            this.labelDiagnostico.Location = new System.Drawing.Point(24, 403);
            this.labelDiagnostico.Name = "labelDiagnostico";
            this.labelDiagnostico.Size = new System.Drawing.Size(125, 13);
            this.labelDiagnostico.TabIndex = 7;
            this.labelDiagnostico.Text = "Diagnostico del Paciente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ingrese los sintomas";
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(244, 586);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.botonLimpiar.TabIndex = 10;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // RegistroResultado
            // 
            this.AcceptButton = this.botonAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.botonCancelar;
            this.ClientSize = new System.Drawing.Size(439, 621);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelDiagnostico);
            this.Controls.Add(this.labelSelecConsulta);
            this.Controls.Add(this.textBoxDiagnostico);
            this.Controls.Add(this.textBoxSintomas);
            this.Controls.Add(this.checkBoxFueConcretada);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.listadoConsultas);
            this.MinimizeBox = false;
            this.Name = "RegistroResultado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro resultado de atención médica";
            this.Load += new System.EventHandler(this.RegistroResultado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listadoConsultas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView listadoConsultas;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.CheckBox checkBoxFueConcretada;
        private System.Windows.Forms.TextBox textBoxSintomas;
        private System.Windows.Forms.RichTextBox textBoxDiagnostico;
        private System.Windows.Forms.Label labelSelecConsulta;
        private System.Windows.Forms.Label labelDiagnostico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonLimpiar;
    }
}