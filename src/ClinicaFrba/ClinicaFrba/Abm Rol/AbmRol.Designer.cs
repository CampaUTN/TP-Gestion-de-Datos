namespace ClinicaFrba.AbmRol
{
    partial class AbmRol
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
            this.buttonAlta = new System.Windows.Forms.Button();
            this.buttonBaja = new System.Windows.Forms.Button();
            this.buttonModificacion = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNombreUsuario = new System.Windows.Forms.TextBox();
            this.buttonModificarRoles = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAlta
            // 
            this.buttonAlta.Location = new System.Drawing.Point(22, 49);
            this.buttonAlta.Name = "buttonAlta";
            this.buttonAlta.Size = new System.Drawing.Size(88, 23);
            this.buttonAlta.TabIndex = 0;
            this.buttonAlta.Text = "Alta";
            this.buttonAlta.UseVisualStyleBackColor = true;
            this.buttonAlta.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonBaja
            // 
            this.buttonBaja.Location = new System.Drawing.Point(22, 155);
            this.buttonBaja.Name = "buttonBaja";
            this.buttonBaja.Size = new System.Drawing.Size(88, 23);
            this.buttonBaja.TabIndex = 2;
            this.buttonBaja.Text = "Baja";
            this.buttonBaja.UseVisualStyleBackColor = true;
            this.buttonBaja.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonModificacion
            // 
            this.buttonModificacion.Location = new System.Drawing.Point(22, 102);
            this.buttonModificacion.Name = "buttonModificacion";
            this.buttonModificacion.Size = new System.Drawing.Size(88, 23);
            this.buttonModificacion.TabIndex = 3;
            this.buttonModificacion.Text = "Modificación";
            this.buttonModificacion.UseVisualStyleBackColor = true;
            this.buttonModificacion.Click += new System.EventHandler(this.buttonModificacion_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAlta);
            this.groupBox1.Controls.Add(this.buttonBaja);
            this.groupBox1.Controls.Add(this.buttonModificacion);
            this.groupBox1.Location = new System.Drawing.Point(166, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(134, 210);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ABM Roles";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxNombreUsuario);
            this.groupBox2.Controls.Add(this.buttonModificarRoles);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(148, 139);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Roles por usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre de usuario:";
            // 
            // textBoxNombreUsuario
            // 
            this.textBoxNombreUsuario.Location = new System.Drawing.Point(6, 65);
            this.textBoxNombreUsuario.Name = "textBoxNombreUsuario";
            this.textBoxNombreUsuario.Size = new System.Drawing.Size(129, 20);
            this.textBoxNombreUsuario.TabIndex = 1;
            this.textBoxNombreUsuario.TextChanged += new System.EventHandler(this.textBoxNombreUsuario_TextChanged);
            // 
            // buttonModificarRoles
            // 
            this.buttonModificarRoles.Location = new System.Drawing.Point(39, 102);
            this.buttonModificarRoles.Name = "buttonModificarRoles";
            this.buttonModificarRoles.Size = new System.Drawing.Size(96, 23);
            this.buttonModificarRoles.TabIndex = 0;
            this.buttonModificarRoles.Text = "Modificar Roles";
            this.buttonModificarRoles.UseVisualStyleBackColor = true;
            this.buttonModificarRoles.Click += new System.EventHandler(this.buttonModificarRoles_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 234);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // AbmRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 269);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AbmRol";
            this.Text = "ABM Roles";
            this.Load += new System.EventHandler(this.AbmRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAlta;
        private System.Windows.Forms.Button buttonBaja;
        private System.Windows.Forms.Button buttonModificacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNombreUsuario;
        private System.Windows.Forms.Button buttonModificarRoles;
        private System.Windows.Forms.Button button2;

    }
}