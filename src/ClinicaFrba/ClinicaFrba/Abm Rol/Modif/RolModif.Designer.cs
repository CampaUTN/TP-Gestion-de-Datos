namespace ClinicaFrba.AbmRol
{
    partial class RolModif
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
            this.listFuncionalidades = new System.Windows.Forms.ListBox();
            this.listAsignadas = new System.Windows.Forms.ListBox();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonQuitar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxFuncionalidades = new System.Windows.Forms.GroupBox();
            this.labelNombreValidacion = new System.Windows.Forms.Label();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.checkBoxHabilitado = new System.Windows.Forms.CheckBox();
            this.groupBoxFuncionalidades.SuspendLayout();
            this.SuspendLayout();
            // 
            // listFuncionalidades
            // 
            this.listFuncionalidades.FormattingEnabled = true;
            this.listFuncionalidades.Location = new System.Drawing.Point(222, 58);
            this.listFuncionalidades.Name = "listFuncionalidades";
            this.listFuncionalidades.Size = new System.Drawing.Size(120, 212);
            this.listFuncionalidades.TabIndex = 1;
            this.listFuncionalidades.SelectedIndexChanged += new System.EventHandler(this.listFuncionalidades_SelectedIndexChanged);
            // 
            // listAsignadas
            // 
            this.listAsignadas.FormattingEnabled = true;
            this.listAsignadas.Location = new System.Drawing.Point(6, 58);
            this.listAsignadas.Name = "listAsignadas";
            this.listAsignadas.Size = new System.Drawing.Size(120, 212);
            this.listAsignadas.TabIndex = 2;
            this.listAsignadas.SelectedIndexChanged += new System.EventHandler(this.listAsignadas_SelectedIndexChanged);
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Location = new System.Drawing.Point(138, 137);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(75, 23);
            this.buttonAgregar.TabIndex = 3;
            this.buttonAgregar.Text = "< agregar";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonQuitar
            // 
            this.buttonQuitar.Location = new System.Drawing.Point(138, 166);
            this.buttonQuitar.Name = "buttonQuitar";
            this.buttonQuitar.Size = new System.Drawing.Size(75, 23);
            this.buttonQuitar.TabIndex = 4;
            this.buttonQuitar.Text = "quitar >";
            this.buttonQuitar.UseVisualStyleBackColor = true;
            this.buttonQuitar.Click += new System.EventHandler(this.buttonQuitar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Disponibles:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Asignadas:";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(110, 6);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(132, 20);
            this.textBoxNombre.TabIndex = 8;
            this.textBoxNombre.TextChanged += new System.EventHandler(this.textBoxNombre_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nombre del Rol:";
            // 
            // groupBoxFuncionalidades
            // 
            this.groupBoxFuncionalidades.Controls.Add(this.listAsignadas);
            this.groupBoxFuncionalidades.Controls.Add(this.label3);
            this.groupBoxFuncionalidades.Controls.Add(this.buttonAgregar);
            this.groupBoxFuncionalidades.Controls.Add(this.label1);
            this.groupBoxFuncionalidades.Controls.Add(this.buttonQuitar);
            this.groupBoxFuncionalidades.Controls.Add(this.listFuncionalidades);
            this.groupBoxFuncionalidades.Location = new System.Drawing.Point(12, 62);
            this.groupBoxFuncionalidades.Name = "groupBoxFuncionalidades";
            this.groupBoxFuncionalidades.Size = new System.Drawing.Size(358, 280);
            this.groupBoxFuncionalidades.TabIndex = 10;
            this.groupBoxFuncionalidades.TabStop = false;
            this.groupBoxFuncionalidades.Text = "Funcionalidades";
            this.groupBoxFuncionalidades.Enter += new System.EventHandler(this.groupBoxFuncionalidades_Enter);
            // 
            // labelNombreValidacion
            // 
            this.labelNombreValidacion.AutoSize = true;
            this.labelNombreValidacion.Location = new System.Drawing.Point(248, 9);
            this.labelNombreValidacion.Name = "labelNombreValidacion";
            this.labelNombreValidacion.Size = new System.Drawing.Size(39, 13);
            this.labelNombreValidacion.TabIndex = 11;
            this.labelNombreValidacion.Text = "Validar";
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(295, 348);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 12;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonCrear_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(12, 348);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 13;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // checkBoxHabilitado
            // 
            this.checkBoxHabilitado.AutoSize = true;
            this.checkBoxHabilitado.Location = new System.Drawing.Point(251, 39);
            this.checkBoxHabilitado.Name = "checkBoxHabilitado";
            this.checkBoxHabilitado.Size = new System.Drawing.Size(73, 17);
            this.checkBoxHabilitado.TabIndex = 14;
            this.checkBoxHabilitado.Text = "Habilitado";
            this.checkBoxHabilitado.UseVisualStyleBackColor = true;
            // 
            // RolModif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 379);
            this.Controls.Add(this.checkBoxHabilitado);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.labelNombreValidacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.groupBoxFuncionalidades);
            this.Name = "RolModif";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificación de Rol";
            this.Load += new System.EventHandler(this.RolModif_Load);
            this.groupBoxFuncionalidades.ResumeLayout(false);
            this.groupBoxFuncionalidades.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listFuncionalidades;
        private System.Windows.Forms.ListBox listAsignadas;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonQuitar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxFuncionalidades;
        private System.Windows.Forms.Label labelNombreValidacion;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.CheckBox checkBoxHabilitado;
    }
}